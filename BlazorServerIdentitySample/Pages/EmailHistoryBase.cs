using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerIdentitySample.Pages
{
    public class EmailHistoryBase : ComponentBase
    {
        [Parameter]
        public string EmailId { get; set; }
        [Parameter]
        public DateTime? FromDate { get; set; }
        [Parameter]
        public DateTime? ToDate { get; set; }
        [Parameter]
        public string SelectedOption { get; set; }

        public void SubmitAll()
        {

        }

        public void ReleaseAll()
        {

        }
    }
}
