using ToDoApp.DAL.Models.Identity;
using ToDoApp.DAL.ViewModels;
using ToDoApp.BLL.Services;

namespace ToDoApp.BLL.Services.JwtService
{
    public interface IJwtService
    {
        Task<ServiceResponse> GenerateTokensAsync(User user);
        Task<ServiceResponse> RefreshTokensAsync(JwtVM model);
    }
}
