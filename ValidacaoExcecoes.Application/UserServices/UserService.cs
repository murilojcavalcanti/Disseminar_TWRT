using Microsoft.EntityFrameworkCore;
using ValidacaoExcecoes.Application.Models.UserModels;
using ValidacaoExcecoes.Application.ViewModels.UserModels;
using ValidacaoExcecoes.Core.Entities;
using ValidacaoExcecoes.Infra.Persistence;

namespace ValidacaoExcecoes.Application.UserServices
{
    public class UserService : IUserService
    {
        private readonly ProjectDbContext _context;

        public UserService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> Create(UserCreateModel userInputModel)
        {
            User user = userInputModel.ToEntity();
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
            return UserViewModel.FromEntity(user);
        }

        public async Task<List<UserViewModel>> GetAll()
        {

            List<User> userList = await _context.Set<User>().ToListAsync();
            return userList.Select(u => UserViewModel.FromEntity(u)).ToList();
        }
    }
}
