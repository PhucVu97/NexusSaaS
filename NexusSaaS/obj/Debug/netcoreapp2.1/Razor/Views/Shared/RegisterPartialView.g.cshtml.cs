#pragma checksum "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45f5ddccf03df6ea5c7e0dd5c18d2e73bf0c1104"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_RegisterPartialView), @"mvc.1.0.view", @"/Views/Shared/RegisterPartialView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/RegisterPartialView.cshtml", typeof(AspNetCore.Views_Shared_RegisterPartialView))]
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
#line 1 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\_ViewImports.cshtml"
using NexusSaaS;

#line default
#line hidden
#line 2 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\_ViewImports.cshtml"
using NexusSaaS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45f5ddccf03df6ea5c7e0dd5c18d2e73bf0c1104", @"/Views/Shared/RegisterPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"781d58719822ae4423193b9976002c05722650a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_RegisterPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NexusSaaS.Models.UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("modal-content animate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/action_page.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml"
  
    var listRoles = ViewData["listRoles"] as List<RoleModel>;

#line default
#line hidden
            BeginContext(107, 39, true);
            WriteLiteral("\r\n<div id=\"id01\" class=\"modal\">\r\n\r\n    ");
            EndContext();
            BeginContext(146, 1199, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8664aea96bd471a96515cac2e7d2d5a", async() => {
                BeginContext(208, 646, true);
                WriteLiteral(@"

        <div class=""container"">
            <label for=""uname""><b>Name</b></label>
            <input type=""text"" placeholder=""Enter Username"" name=""uname"" required>

            <label for=""psw""><b>Password</b></label>
            <input type=""password"" placeholder=""Enter Password"" name=""psw"" required>

            <label for=""psw""><b>Email</b></label>
            <input type=""password"" placeholder=""Enter Password"" name=""psw"" required>

            <label for=""psw""><b>Phone</b></label>
            <input type=""password"" placeholder=""Enter Password"" name=""psw"" required>

            <label for=""psw""><b>Roles</b></label>
");
                EndContext();
#line 25 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml"
             foreach (var r in listRoles)
            {

#line default
#line hidden
                BeginContext(912, 83, true);
                WriteLiteral("                <label class=\"radio-inline\"><input type=\"checkbox\" name=\"roleIds[]\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 995, "\"", 1012, 1);
#line 27 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml"
WriteAttributeValue("", 1003, r.RoleId, 1003, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1013, 2, true);
                WriteLiteral("> ");
                EndContext();
                BeginContext(1016, 6, false);
#line 27 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml"
                                                                                                  Write(r.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1022, 11, true);
                WriteLiteral(" </label>\r\n");
                EndContext();
#line 28 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Shared\RegisterPartialView.cshtml"
            }

#line default
#line hidden
                BeginContext(1048, 290, true);
                WriteLiteral(@"
            <button type=""submit"">Sign Up</button>
        </div>

        <div class=""container"" style=""background-color:#f1f1f1"">
            <button type=""button"" onclick=""document.getElementById('id01').style.display='none'"" class=""cancelbtn"">Cancel</button>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1345, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NexusSaaS.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
