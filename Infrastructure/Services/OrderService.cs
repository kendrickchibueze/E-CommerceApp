using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Product> _productsRepo;
        private readonly IRepository<DeliveryMethod> _deliveryMethodRepo;
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger, IBasketRepository basketRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _orderRepo = _unitOfWork.GetRepository<Order>();
            _productsRepo = _unitOfWork.GetRepository<Product>();
            _deliveryMethodRepo = _unitOfWork.GetRepository<DeliveryMethod>();
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            //get items from the product repo
            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _productsRepo.GetByIdAsync(item.Id.ToString());
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name,
                    productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);

                items.Add(orderItem);
            }



            //get delivery method from repo
            var deliveryMethod = await _deliveryMethodRepo.GetByIdAsync(deliveryMethodId.ToString());

            //calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            //create order
            var order = new Order(items, buyerEmail,shippingAddress,deliveryMethod,subtotal);

            // Todo: save to db

            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
