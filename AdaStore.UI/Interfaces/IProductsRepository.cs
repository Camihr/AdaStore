using AdaStore.Shared.Models;
using AdaStore.UI.Repositories;

namespace AdaStore.UI.Interfaces
{
    public interface IProductsRepository
    {
        Task<HttpResponse<List<Product>>> GetProducts();
    }
}
