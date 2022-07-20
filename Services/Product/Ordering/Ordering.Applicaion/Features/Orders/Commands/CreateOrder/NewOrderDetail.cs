namespace Ordering.Applicaion.Features.Orders.Commands.CreateOrder
{
    public class NewOrderDetail
    {
        public long ProductId { get; set; }
        public int Price { get; set; }
    }
}