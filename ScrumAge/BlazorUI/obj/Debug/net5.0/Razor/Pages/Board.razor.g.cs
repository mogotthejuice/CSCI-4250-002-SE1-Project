#pragma checksum "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\Pages\Board.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9f64b117a72df43e418fb8135e62d99ef9dd061"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorUI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using BlazorUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using BlazorUI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\_Imports.razor"
using GameLibrary.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/board")]
    public partial class Board : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 b-kb93bnuiiw>Board</h1>\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "id", "board");
            __builder.AddAttribute(3, "b-kb93bnuiiw");
            __builder.OpenElement(4, "tr");
            __builder.AddAttribute(5, "b-kb93bnuiiw");
            __builder.OpenElement(6, "th");
            __builder.AddAttribute(7, "class", "padColOne");
            __builder.AddAttribute(8, "style", "background-color:" + " " + (
#nullable restore
#line 7 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\Pages\Board.razor"
                                                        color

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "b-kb93bnuiiw");
            __builder.OpenElement(10, "button");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\Pages\Board.razor"
                                                                                 Click

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "b-kb93bnuiiw");
            __builder.AddContent(13, "Overtime");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.AddMarkupContent(15, "<th b-kb93bnuiiw>Cafe<br b-kb93bnuiiw>(Coffee)</th>\r\n        ");
            __builder.AddMarkupContent(16, "<th b-kb93bnuiiw>Staples <br b-kb93bnuiiw> (USB Sticks)</th>");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n    ");
            __builder.AddMarkupContent(18, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>Field<br b-kb93bnuiiw>(Bitcoin Investment)</th>\r\n        <th b-kb93bnuiiw></th>\r\n        <th b-kb93bnuiiw>Factory<br b-kb93bnuiiw>(CPU Cores)</th></tr>\r\n    ");
            __builder.AddMarkupContent(19, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>Training<br b-kb93bnuiiw>Center</th>\r\n        <th b-kb93bnuiiw>Overclocking Stack</th>\r\n        <th b-kb93bnuiiw>Power Plant<br b-kb93bnuiiw>Power</th></tr>\r\n    ");
            __builder.AddMarkupContent(20, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>License Tiles</th>\r\n        <th b-kb93bnuiiw></th>\r\n        <th b-kb93bnuiiw>Con Card</th>\r\n        <th b-kb93bnuiiw>Con Card</th>\r\n        <th b-kb93bnuiiw>Con Card</th>\r\n        <th b-kb93bnuiiw>Con Card</th></tr>\r\n    ");
            __builder.AddMarkupContent(21, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>License Tiles</th></tr>\r\n    ");
            __builder.AddMarkupContent(22, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>License Tiles</th></tr>\r\n    ");
            __builder.AddMarkupContent(23, "<tr b-kb93bnuiiw><th b-kb93bnuiiw>License Tiles</th>\r\n        <th b-kb93bnuiiw>Player Name</th>\r\n        <th b-kb93bnuiiw></th></tr>");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\Pages\Board.razor"
       
    private ElementReference button1;
    private string color;

    public void Click()
    {
        var random = new Random();

        var vrcolor = String.Format("#{0:X6}", random.Next(0x1000000));

        color = vrcolor;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
