using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace CalculatorN
{
    internal class CurrencyConverter
    {
        Dictionary<string, string> symbols;
        public Dictionary<string, string> GetSymbols()
        {
            if (symbols == null)
            {
                symbols = new Dictionary<string, string>();
                string responseContent = getResponseString("exchangerates_data/symbols");

                Dictionary<string, object> responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
                if ((bool)responseData["success"])
                {
                    var tempSymbols = (JObject)responseData["symbols"];
                    symbols = tempSymbols.ToObject<Dictionary<string, string>>();
                }
            }
            return symbols;
        }

        private string getResponseString(string relativeURI)
        {
            var client = new RestClient("https://api.apilayer.com/");


            var request = new RestRequest(relativeURI, Method.Get);
            request.AddHeader("apikey", "Og78iNvZ3OhjqfxzpFO0coxnHhBUoMh4");

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;

        }
        public double Convert(string fromCurrency, string toCurrency, double currencyAmount)
        {
            string responseContent = getResponseString($"exchangerates_data/convert?to={toCurrency}&from={fromCurrency}&amount={currencyAmount}");

            Dictionary<string, object> responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
            if ((bool)responseData["success"])
            {
                return (double)responseData["result"];
            }
            else
            {
                return -1;
            }
        }
    }
}
