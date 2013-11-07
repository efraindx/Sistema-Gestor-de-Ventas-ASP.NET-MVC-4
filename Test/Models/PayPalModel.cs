using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class PayPalModel
    {
        public string cmd { get; set; }
        public string business { get; set; }
        public string no_shipping { get; set; }
        public string @return { get; set; }
        public string cancel_return { get; set; }
        public string notify_url { get; set; }
        public string currency_code { get; set; }
        public string item_name { get; set; }
        public string amount { get; set; }
        public string actionURL { get; set; }

        public PayPalModel(bool useSandbox)
        {
            this.cmd = "_xclick";
            this.business = System.Configuration.ConfigurationManager.AppSettings.Get("business");
            this.cancel_return = System.Configuration.ConfigurationManager.AppSettings.Get("cancel_returns");
            this.@return = System.Configuration.ConfigurationManager.AppSettings.Get("return");

            if (useSandbox)
            {
                this.actionURL = System.Configuration.ConfigurationManager.AppSettings.Get("test_url");
            }
            else
            {
                this.actionURL = System.Configuration.ConfigurationManager.AppSettings.Get("Prod_url");
            }
            this.notify_url = System.Configuration.ConfigurationManager.AppSettings.Get("notify_url");
            this.currency_code = System.Configuration.ConfigurationManager.AppSettings.Get("currency_code");
        }
    }
}