using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Swashbuckle.AspNetCore.Annotations;

namespace Pottencial.Tiago.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(
            IFindOrderService findOrderService,
            IUpdateOrderService updateOrderService,
            ICreateOrderService createOrderService
        )
        {
            _findOrderService = findOrderService;
            _updateOrderService = updateOrderService;
            _createOrderService = createOrderService;
        }

        public IFindOrderService _findOrderService { get; set; }
        public IUpdateOrderService _updateOrderService { get; set; }
        public ICreateOrderService _createOrderService { get; set; }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo pedido", Description = @" STATUS: 
        0. Aguardando Pagamento,
        1. Pagamento Aprovado,
        2. Enviado Para Transportadora,
        3. Entregue, 
        4. Cancelada")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequestModel request)
        {
            var result = _createOrderService.CreateOrder(request);

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza o status do pedido", Description = @" STATUS: 
        0. Aguardando Pagamento,
        1. Pagamento Aprovado,
        2. Enviado Para Transportadora,
        3. Entregue, 
        4. Cancelada")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderRequestModel request)
        {
            var result = _updateOrderService.UpdateStatus(request);

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Localiza o pedido", Description = @" STATUS: 
        0. Aguardando Pagamento,
        1. Pagamento Aprovado,
        2. Enviado Para Transportadora,
        3. Entregue, 
        4. Cancelada")]
        public IActionResult FindOrder(long id)
        {
            var result = _findOrderService.FindOrder(id);

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os pedidos")]
        public async Task<IActionResult> ListOrders()
        {
            var result = await _findOrderService.ListOrders();

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }
    }
}

