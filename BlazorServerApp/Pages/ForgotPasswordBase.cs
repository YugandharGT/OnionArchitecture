using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class ForgotPasswordBase : ComponentBase
    {
        [Parameter]
        public string EmailAddress { get; set; }
    }
}
