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
            
            SocialData.Add("Icon1","../Images/facebook.png");

            OAuthWebSecurity.RegisterFacebookClient(
               appId: "684858058193600",
               appSecret: "02d3c5a8f4d342509572fa6074259aab",
               displayName: "Facebook",
               extraData: SocialData);
        }
    }
}
