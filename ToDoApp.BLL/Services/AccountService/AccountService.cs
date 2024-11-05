using ToDoApp.BLL.Services.JwtService;
using ToDoApp.DAL;
using ToDoApp.DAL.Models.Identity;
using ToDoApp.DAL.Repositories.UserRepository;
using ToDoApp.DAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using ToDoApp.BLL.Services;

namespace ToDoApp.BLL.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AccountService(UserManager<User> userManager, IUserRepository userRepository, IJwtService jwtService)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        public async Task<ServiceResponse> SignInAsync(SignInVM model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email, true);

            if (user == null)
            {
                return ServiceResponse.BadRequestResponse($"Користувача з поштою {model.Email} не знайдено");
            }

            var result = await _userRepository.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return ServiceResponse.BadRequestResponse($"Пароль вказано невірно");
            }

            var tokens = await _jwtService.GenerateTokensAsync(user);

            if (!tokens.Success)
            {
                return ServiceResponse.BadRequestResponse("Не вдалося згенерувати токени");
            }

            return ServiceResponse.OkResponse("Успіший вхід", tokens.Payload);
        }

        public async Task<ServiceResponse> SignUpAsync(SignUpVM model)
        {
            if (!await _userRepository.IsUniqueUserNameAsync(model.UserName))
            {
                return ServiceResponse.BadRequestResponse($"{model.UserName} вже викорстовується");
            }

            if (!await _userRepository.IsUniqueEmailAsync(model.Email))
            {
                return ServiceResponse.BadRequestResponse($"{model.Email} вже викорстовується");
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.UserName.ToUpper()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return ServiceResponse.BadRequestResponse(result.Errors.First().Description);
            }

            await _userManager.AddToRoleAsync(user, Settings.UserRole);


            var tokens = await _jwtService.GenerateTokensAsync(user);

            if (!tokens.Success)
            {
                return ServiceResponse.BadRequestResponse("Не вдалося згенерувати токени");
            }

            return ServiceResponse.OkResponse($"Користувач {model.Email} успішно зареєстрований", tokens.Payload);
        }




    }
}
