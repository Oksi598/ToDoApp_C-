﻿using ToDoApp.DAL.ViewModels;
using ToDoApp.BLL.Services;

namespace ToDoApp.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetByEmailAsync(string email);
        Task<ServiceResponse> GetByUserNameAsync(string userName);
        Task<ServiceResponse> GetAllAsync();
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> CreateAsync(CreateUpdateUserVM model);
        Task<ServiceResponse> UpdateAsync(CreateUpdateUserVM model);
    }
}
