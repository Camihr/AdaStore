using AdaStore.UI.Interfaces;

namespace AdaStore.UI.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private string _apiUrl;

        public OrdersRepository(IConfiguration configuration)
        {
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }
    }
}
