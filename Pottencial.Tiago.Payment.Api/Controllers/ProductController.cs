using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Swashbuckle.AspNetCore.Annotations;

namespace Pottencial.Tiago.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IRegisterProductService _registerProductService { get; set; }
        public IRegisterItemService registerItemService { get; set; }
        public ProductController(IRegisterProductService registerProductService, IRegisterItemService registerItemService)
        {
            _registerProductService = registerProductService;
            this.registerItemService = registerItemService;
        }



        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo produto")]
        public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductRequestModel request)
        {
            var result = await _registerProductService.Add(request);

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os produtos")]
        public async Task<IActionResult> ListProducts()
        {
            var result = await _registerProductService.ListProducts();

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }

        [HttpPost("populate")]
        [SwaggerOperation(Summary = "Para testes: Registra 5 produtos para teste")]
        public async Task<IActionResult> PopulateProducts()
        {
            var result = await _registerProductService.Populate();

            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message;
            Response.StatusCode = result.StatusCode;
            return new ObjectResult(result);
        }
    }
}

