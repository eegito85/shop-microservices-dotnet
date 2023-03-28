using EgitoShopping.Web.Models;
using EgitoShopping.Web.Services.IServices;
using EgitoShopping.Web.Utils;

namespace EgitoShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAll()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> FindById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public Task<ProductModel> FindByName(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> Create(ProductModel model)
        {
            var response = await _client.PostAsJson($"{BasePath}/create", model);

            if(response.IsSuccessStatusCode) { return await response.ReadContentAs<ProductModel>(); }

            throw new Exception("Something went wrong");
        }

        public async Task<ProductModel> Update(ProductModel model)
        {
            var response = await _client.PutAsJson($"{BasePath}/update", model);

            if (response.IsSuccessStatusCode) { return await response.ReadContentAs<ProductModel>(); }

            throw new Exception("Something went wrong");
        }

        public async Task<bool> DeleteById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();

            throw new Exception("Something went wrong");
        }
    }
}
