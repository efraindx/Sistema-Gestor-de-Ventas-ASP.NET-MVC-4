using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using DotNetOpenAuth.AspNet.Clients;
using Test.Models;

namespace Test
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            Dictionary<string, object> SocialData = new Dictionary<string, object>();

            // Para permitir que los usuarios de este sitio inicien sesión con sus cuentas de otros sitios como, por ejemplo, Microsoft, Facebook y Twitter,
            // es necesario actualizar este sitio. Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkID=252166


            SocialData.Add("Icon1","../Images/facebook.png");

            OAuthWebSecurity.RegisterFacebookClient(
               appId: "684858058193600",
               appSecret: "02d3c5a8f4d342509572fa6074259aab",
               displayName: "Facebook",
               extraData: SocialData);

        }
    }
}
