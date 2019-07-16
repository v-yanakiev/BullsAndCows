#pragma checksum "C:\Users\vasko\source\repos\BullsAndCows\BullsAndCows\Pages\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcf40b5d58f310a3d872b4236f2eca0df7772a1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Game_Index), @"mvc.1.0.razor-page", @"/Pages/Game/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Game/Index.cshtml", typeof(AspNetCore.Pages_Game_Index), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf40b5d58f310a3d872b4236f2eca0df7772a1f", @"/Pages/Game/Index.cshtml")]
    public class Pages_Game_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Game/game.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\vasko\source\repos\BullsAndCows\BullsAndCows\Pages\Game\Index.cshtml"
  
    ViewData["Title"] = "Play";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(136, 1532, true);
            WriteLiteral(@"<h2 style=""text-align:center;"">Bulls and Cows</h2>
<div class=""card mx-auto"" style=""width: 50em; background-color:#444444"">
    <div class=""card-body"" style=""color:#fff;"" id=""gamingField"">
        
    </div>
</div>
<div class=""alert alert-danger"" role=""alert"" id=""errorMessage"" style=""display:none"">
</div>
<div class=""alert alert-success"" role=""alert"" id=""successAlert"" style=""display:none"">
</div>
<div class=""alert alert-primary"" role=""alert"" id=""loading"" style=""display:none"">
    Loading...
</div>


<br />
<h3>Rules of the Game</h3>
<ul>
    <li>
        Bulls and cows is a lot like the commercial game Mastermind™️,
        but using four-digit numbers instead of coloured pegs.
    </li>
    <li>
        In this version, you play head-to-head with the computer, taking alternate turns to guess each other's number.
    </li>
    <li>
        The winner is the first player to guess their number. You always play first and so have a small advantage.
    </li>
    <li>
        Each gue");
            WriteLiteral(@"ss is marked according to how many bulls (that is correct digits in correct locations) and how many cows (that is correct digits but in the wrong position) are present in the guess.
        The number of bulls and cows for each guess is displayed in red to the right of the guess.
    </li>
    <li>
        To play the game, first enter a number for the computer to guess (it doesn't cheat!)
        at the top of the table, then enter your guesses at the bottom of your column.
    </li>

</ul>

");
            EndContext();
            BeginContext(1668, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcf40b5d58f310a3d872b4236f2eca0df7772a1f4912", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1709, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BullsAndCows.Pages.Game.PlayModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BullsAndCows.Pages.Game.PlayModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BullsAndCows.Pages.Game.PlayModel>)PageContext?.ViewData;
        public BullsAndCows.Pages.Game.PlayModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
