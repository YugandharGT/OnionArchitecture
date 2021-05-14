﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class RegisterBase : ComponentBase
    {
        [Parameter]
        public string UserName { get; set; }
        [Parameter]
        public string EmailAddress { get; set; }
        [Parameter]
        public string Password { get; set; }

        bool isShow;
        
        public InputType PasswordInput = InputType.Password;
        public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        public void ButtonTestclick()
        {
            System.Diagnostics.Debug.WriteLine($"enterd password is: {0}", Password);
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
