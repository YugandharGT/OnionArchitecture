using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorServerApp.Pages
{
    public class LoginBase : ComponentBase
    {

        [Parameter]
        public string UserName { get; set; }
        [Parameter]
        public string Password { get; set; }
        [Parameter]
        public bool RememberMe { get; set; } = true;

        bool isShow;

        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        public void ButtonTestclick()
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

