using ToDoApp.DAL.ViewModels;
using ToDoApp.BLL.Services;

namespace ToDoApp.BLL.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse> SignInAsync(SignInVM model);
        Task<ServiceResponse> SignUpAsync(SignUpVM model);
    }
}
