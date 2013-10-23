using System;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Controllers;

namespace Test.Models
{
    public class Validator
    {
     /*   public static void CreateUserAndAccount(Person person)
        {
             TestContext db = new TestContext();
             db.People.Add(person);
             db.SaveChanges();
        }*/

        public static string Encriptar(string texto)
        {
            var data = Encoding.Unicode.GetBytes(texto);
            byte[] datos = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(datos);
        }

        public static string Desencriptar(string encripted)
        {
            byte[] datos = Convert.FromBase64String(encripted);
            byte[] desencrypted = ProtectedData.Unprotect(datos, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(desencrypted);
       } 
    }


}