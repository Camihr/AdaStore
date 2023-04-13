using AdaStore.Shared.Enums;

namespace AdaStore.Shared.Models
{
    public class Order : ModelBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public OrderStatuses Status { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
