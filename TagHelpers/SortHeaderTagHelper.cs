using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcEFApp.Models;


namespace MvcEFApp.TagHelpers
{
    public class SortHeaderTagHelper : TagHelper
    {
        public SortProp Property { get; set; }
        public SortProp Current { get; set; }
        public string? Action { get; set; } 
        public bool Up { get; set; }
    }
}
