using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Models
{
    public class ShoppingCartModels
    {
    }

    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
    }

    public partial class ShoppingCart
    {
        TestContext db = new TestContext();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        //Helper Methos for simple calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            var cartItem = db.Carts.SingleOrDefault(
                   c => c.CartId == ShoppingCartId
                   && c.ProductId == product.ProductID);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ProductId = product.ProductID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
               
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        { 
            //Get Cart
            var cartItem = db.Carts.Single(
                    cart => cart.CartId == ShoppingCartId
                    && cart.RecordId == id
                );
            
            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }

            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        { 
            int? count = (from carItems in db.Carts
                          where carItems.CartId == ShoppingCartId
                          select (int?)carItems.Count).Sum();

            return count ?? 0;
        }

        public double GetTotal()
        { 
            double? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?) cartItems.Count * cartItems.Product.Price).Sum();

            return total ?? 0;
        }

        public int CreateOrder(Order order)
        {
            double OrderTotal = 0;

            var carItems = GetCartItems();

            foreach (var cartItem in carItems)
            {
                var orderDetail = new OrderDetail 
                {
                    ProductId = cartItem.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = Convert.ToDecimal(cartItem.Product.Price),
                    Quatity = cartItem.Count
                };

                OrderTotal += (cartItem.Count * cartItem.Product.Price);
                db.OrderDetails.Add(orderDetail);
            }

            order.Total = Convert.ToDecimal(OrderTotal);
            db.SaveChanges();
            EmptyCart();

            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrEmpty(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                { 
                    //Generate a new random GUI
                    Guid tempCartId = Guid.NewGuid();

                    //Send the GUID to the cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        //When a new user is logged in, migrate their shopping cart
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail 
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quatity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Product Prodct { get; set; }
        public virtual Order Order { get; set; }
    }
}