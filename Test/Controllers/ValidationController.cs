using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        private TestContext db = new TestContext();

        public JsonResult User_Available(string UserName)
        {
            if (!db.UsersProfiles.Any(m => m.UserName == UserName))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string Suggest = String.Format(CultureInfo.InvariantCulture,
              "{0} no está disponible.", UserName);

                for (int i = 1; i < 100; i++)
                {
                    string Candidate = UserName + i.ToString();
                    if (!db.UsersProfiles.Any(p => p.UserName == Candidate))
                    {
                        Suggest = String.Format(CultureInfo.InvariantCulture,
                            "{0} no está disponible. Pruebe: {1}. <a href='#'></a>", UserName, Candidate);
                        break;
                    }
                }
                return Json(Suggest, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
