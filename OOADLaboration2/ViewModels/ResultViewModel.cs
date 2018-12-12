using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOADLaboration2.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OOADLaboration2.ViewModels
{
    public class ResultViewModel: BaseViewModel
    {
        readonly HttpClient client;
        private ObservableCollection<Product> products;
        readonly string KEY = "325423-LookUp-ATIUNVKK";
        private string searchWord;
        private string type;
        private string resultMessage;
        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(storage: ref products, value: value);
        }

        public ResultViewModel(string searchWord, string type)
        {
            client = new HttpClient();
            products = new ObservableCollection<Product>();
            this.searchWord = searchWord;
            this.type = type;
            resultMessage = "";
            FetchAndUpdateProducts();
        }

        public string ResultMessage
        {
            get => resultMessage;
            set => SetProperty(ref resultMessage, value);
        }

        private string getUrlString()
        {
            return "https://tastedive.com/api/similar?q=" + searchWord + "&type=" + type + "&k=" + KEY;
        }

        private async void FetchAndUpdateProducts()
        {
            string url = getUrlString();
            var uri = new Uri(url);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                ObservableCollection<Product> fetchedProducts = new ObservableCollection<Product>();
                JObject SearchResult = JObject.Parse(content);
                IList<JToken> results = SearchResult["Similar"]["Results"].Children().ToList();

                foreach (JToken result in results)
                {
                    string resultName = result["Name"].ToString();
                    string resultType = result["Type"].ToString();
                    fetchedProducts.Add(new Product(resultName, resultType));
                }

                Products = fetchedProducts;
                ResultMessage = "Found " + Products.Count.ToString() + " results.";
            }
            else {
                ResultMessage = "Connection lost. Try again later";
            }
        }
    }
}
