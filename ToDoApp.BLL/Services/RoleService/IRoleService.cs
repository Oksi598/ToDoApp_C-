﻿using ToDoApp.DAL.ViewModels;
using ToDoApp.BLL.Services;

namespace ToDoApp.BLL.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse> GetAllAsync();
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetByNameAsync(string name);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> CreteAsync(RoleVM model);
        Task<ServiceResponse> UpdateAsync(RoleVM model);
    }
}
