using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ValidacaoExcecoes.Application.Models.UserModels;
using ValidacaoExcecoes.Application.UserServices;
using ValidacaoExcecoes.Application.ViewModels.UserModels;


namespace ValidacaoExcecoes.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> userList = await _userService.GetAll();
            return  View(userList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( UserCreateModel user)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v=>v.Errors).Select(e=>e.ErrorMessage).ToList();
                TempData["MensagemErro"] = $"Erros Encontrados: {string.Concat(" | ", erros)}";
                return View(user);
            }
            await _userService.Create(user);
            TempData["MensagemSucesso"] = "Usuario Criado com sucesso!";
            return View();
        }


    }
}
