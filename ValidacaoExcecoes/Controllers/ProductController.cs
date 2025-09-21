using Microsoft.AspNetCore.Mvc;
using ValidacaoExcecoes.Application.Services.ProductServices;
using ValidacaoExcecoes.Application.ViewModels.ProductModels;

namespace ValidacaoExcecoes.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListarProdutos (decimal preco, string nome)
        {
            var products = await productService.GetAll(preco,nome);
            return Json(products);
        }
        [HttpPost]
        public async Task<JsonResult> AdicionarProduto([FromBody] ProductModel model)
        {
            await productService.AddProduct(model);
            return Json(model);
        }
    }
}
