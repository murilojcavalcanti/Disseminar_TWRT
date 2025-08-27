using ValidacaoExcecoes.Application.Models.UserModels;
using ValidacaoExcecoes.Application.ViewModels.UserModels;

namespace ValidacaoExcecoes.Application.UserServices
{
    public interface IUserService
    {
        Task<UserViewModel> Create(UserCreateModel user);
        Task<List<UserViewModel>> GetAll();
    }
}
