using Microsoft.AspNetCore.Components;
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

        public void SignIn()
        {
            //NavigationManager navigation = new ;
        }
    }
}
