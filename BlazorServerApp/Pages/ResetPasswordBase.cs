using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class ResetPasswordBase : ComponentBase
    {
        [Parameter]
        public string ConfirmPassword { get; set; }
        [Parameter]
        public string Password { get; set; }

        bool isConfirmShow;
        public InputType ConfirmPassworddInput = InputType.Password;
        public string ConfirmPasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public void ConfirmPasswordclick()
        {
            if (isConfirmShow)
            {
                isConfirmShow = false;
                ConfirmPasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                ConfirmPassworddInput = InputType.Password;
            }
            else
            {
                isConfirmShow = true;
                ConfirmPasswordInputIcon = Icons.Material.Filled.Visibility;
                ConfirmPassworddInput = InputType.Text;
            }
        }

        bool isShow;
        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public void Passwordclick()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}
