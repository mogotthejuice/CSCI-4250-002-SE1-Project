// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\sethn\Documents\MainComputer\Software Engineering\SemesterProject\ScrumAge\BlazorUI\Pages\Board.razor"
       
    private ElementReference button1;
    private string color;

    public void Click()
    {

        var vrcolor = String.Format("#{0:X6}", 255);

        color = vrcolor;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
