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
        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(storage: ref products, value: value);
        }

        // Add arguments (searchWord etc)
        public ResultViewModel()
        {
            client = new HttpClient();
            products = new ObservableCollection<Product>();
            FetchAndUpdateProducts();
        }

        private async void FetchAndUpdateProducts()
        {
            string url = "https://tastedive.com/api/similar?q=movie:goodfellas&type=movies&info=0&k=325423-LookUp-ATIUNVKK";
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
            }
        }
    }
}
