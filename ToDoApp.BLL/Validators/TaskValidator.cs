using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DAL.ViewModels;

namespace ToDoApp.BLL.Validators
{
    public class TaskValidator : AbstractValidator<TaskVM>
    {
        public TaskValidator()
        {
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("Назва є обов'язковою.")
                .Length(1, 100).WithMessage("Назва повинна бути від 1 до 100 символів.");

            RuleFor(task => task.Description)
                .NotEmpty().WithMessage("Опис є обов'язковим.")
                .Length(1, 500).WithMessage("Опис повинен бути від 1 до 500 символів.");

            RuleFor(task => task.Category)
                .NotEmpty().WithMessage("Категорія є обов'язковою.");

            RuleFor(task => task.Priority)
                .InclusiveBetween(1, 3).WithMessage("Пріоритет повинен бути між 1 (низький) і 3 (високий).");

            RuleFor(task => task.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Термін виконання повинен бути у майбутньому.");
        }
    }

}
