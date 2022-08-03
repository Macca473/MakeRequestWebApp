using MakeRequestWebApp.Controllers;
using MakeRequestWebApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Pages.FormInput
{
    public partial class FormInput
    {
        [ParameterAttribute]
        public FormProp thisProp { get; set; }

        [ParameterAttribute]
        public EventCallback<FormProp> UpdatedProp { get; set; }

        public string BackgroundColor { get; set; } = "white";
        

        protected void thisPropEdited(ChangeEventArgs newval)
        {
            thisProp.IsEdited = true;

            if (newval.Value != null)
            {
                thisProp.Value = (string)newval.Value;
            }

            UpdatedProp.InvokeAsync(thisProp);

            ChangeColor();
        }

        public void ChangeColor()
        {
            BackgroundColor = "antiquewhite";
        }
    } 
}
