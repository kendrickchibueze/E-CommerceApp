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
            
            var basket = await _basketRepo.GetBasketAsync(basketId);

            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _productsRepo.GetByIdAsync(item.Id.ToString());

                
                if (productItem == null)
                {
                    
                    throw new NotFoundException($"Product item with ID {item.Id} not found.");
                }

                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);

                items.Add(orderItem);
            }

            
            var deliveryMethod = await _deliveryMethodRepo.GetByIdAsync(deliveryMethodId.ToString());

            if (deliveryMethod == null)
            {
                
                throw new NotFoundException($"Delivery method with ID {deliveryMethodId} not found.");
            }

            
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            _orderRepo.Add(order);


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
