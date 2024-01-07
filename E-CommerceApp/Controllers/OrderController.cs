using AutoMapper;
using Core.Entities.OrderAggregate;
using E_CommerceApp.Errors;
using E_CommerceApp.Extensions;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_CommerceApp.Controllers
{

    [Authorize]
    public class OrderController : BaseApiController
    {
        private  readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId,
                orderDto.BasketId, address);
            if (order == null) return BadRequest(new ApiResponse(400, "Problem Creating Order"));

            return Ok(order);


        }
    }
}
