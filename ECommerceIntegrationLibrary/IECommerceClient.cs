using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceIntegrationLibrary
{
    public class RequestCreateCatalogItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string InventoryQuantity { get; set; }
    }

    public class ResponseCreateCatalogItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string InventoryQuantity { get; set; }
    }

    public class RequestGetCatalogItemById
    {
        public long ID { get; set; }
    }

    public class ResponseGetCatalogItemById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string InventoryQuantity { get; set; }
    }

    public interface IECommerceClient
    {
        Task<ResponseCreateCatalogItem> CreateCatalogItemAsync(RequestCreateCatalogItem catalogItem);
        Task<ResponseGetCatalogItemById> GetCatalogItemAsync(RequestGetCatalogItemById requestGetCatalogItemById);
    }

    public class ShopifyClient : IECommerceClient
    {
        private readonly HttpClient _httpClient;

        public ShopifyClient(HttpClient httpClient, string shopifyBaseUrl, string apiKey, string apiPassword)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(shopifyBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-Shopify-Access-Token", $"{apiKey}:{apiPassword}");
        }

        public Task<ResponseCreateCatalogItem> CreateCatalogItemAsync(RequestCreateCatalogItem catalogItem)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseGetCatalogItemById> GetCatalogItemAsync(RequestGetCatalogItemById requestGetCatalogItemById)
        {
            throw new NotImplementedException();
        }
    }

    public class KlaviyoClient : IECommerceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _klaviyoApiKey;

        public KlaviyoClient(HttpClient httpClient, string klaviyoBaseUrl, string apiKey)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(klaviyoBaseUrl);
            _klaviyoApiKey = apiKey;
        }

        public Task<ResponseCreateCatalogItem> CreateCatalogItemAsync(RequestCreateCatalogItem catalogItem)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseGetCatalogItemById> GetCatalogItemAsync(RequestGetCatalogItemById requestGetCatalogItemById)
        {
            throw new NotImplementedException();
        }
    }

    public class ECommerceClientFactory
    {
        private readonly HttpClient _httpClient;

        public ECommerceClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IECommerceClient CreateShopifyClient(string baseUrl, string apiKey, string apiPassword)
        {
            return new ShopifyClient(_httpClient, baseUrl, apiKey, apiPassword);
        }

        public IECommerceClient CreateKlaviyoClient(string baseUrl, string apiKey)
        {
            return new KlaviyoClient(_httpClient, baseUrl, apiKey);
        }
    }
}
