using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor;
using Swashbuckle.AspNetCore.Annotations;

namespace Pottencial.Tiago.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        public IRegisterSellerService _registerSellerService { get; set; }
        public SellerController(IRegisterSellerService registerSellerService)
        {
            _registerSellerService = registerSellerService;
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo vendedor")]
        public async Task<IActionResult> RegisterSeller([FromBody] RegisterSellerRequestModel request)
        {
            var result = await _registerSellerService.Add(request);

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os vendedores")]
        public async Task<IActionResult> ListSellers()
        {
            var result = await _registerSellerService.ListSellers();

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpPost("populate")]
        [SwaggerOperation(Summary = "Para testes: Registra 5 vendedores para teste")]
        public async Task<IActionResult> PopulateSellers()
        {
            var result = await _registerSellerService.Populate();

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }
    }
}

