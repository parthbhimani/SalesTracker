#pragma checksum "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8024b3587691b7f464ef38f8a8e66d75000148ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SalesTracker.Pages.Pages_SearchStoreItems), @"mvc.1.0.razor-page", @"/Pages/SearchStoreItems.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/SearchStoreItems.cshtml", typeof(SalesTracker.Pages.Pages_SearchStoreItems), null)]
namespace SalesTracker.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\_ViewImports.cshtml"
using SalesTracker;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8024b3587691b7f464ef38f8a8e66d75000148ab", @"/Pages/SearchStoreItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4a3a4946964a97ede9026309cf6b6037f05efd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SearchStoreItems : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top: 50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
  
    ViewData["Title"] = "SearchStoreItems";

#line default
#line hidden
            BeginContext(108, 35, true);
            WriteLiteral("\r\n<h1>Search Store Items</h1>\r\n\r\n\r\n");
            EndContext();
            BeginContext(143, 380, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8024b3587691b7f464ef38f8a8e66d75000148ab4458", async() => {
                BeginContext(199, 317, true);
                WriteLiteral(@"
    <div class=""form-group"">
        <label class=""control-label"" for=""search"">Store Item Name</label>
        <input type=""text"" class=""form-control"" name=""search"" id=""search"" />
    </div>
    <div class=""form-group"">
        <input type=""submit"" value=""Search Items"" class=""btn btn-primary"" />
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(523, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 21 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
 if (Model.SearchCompleted)
{

#line default
#line hidden
            BeginContext(561, 333, true);
            WriteLiteral(@"    <table class=""table table-striped"">
        <thead>
            <tr class=""table-info"">

                <th>Item Name</th>
                <th>Department</th>
                <th>Selling Price</th>
                <th>Profit Margin</th>
                <th></th>

            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 36 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
             if (Model.SearchResults.Count > 0)
            {
                

#line default
#line hidden
#line 38 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                 foreach (var items in Model.SearchResults)
                {

#line default
#line hidden
            BeginContext(1038, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1077, 14, false);
#line 41 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
               Write(items.ItemName);

#line default
#line hidden
            EndContext();
            BeginContext(1091, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1119, 31, false);
#line 42 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
               Write(items.Department.DepartmentName);

#line default
#line hidden
            EndContext();
            BeginContext(1150, 29, true);
            WriteLiteral("</td>\r\n                <td>$ ");
            EndContext();
            BeginContext(1180, 18, false);
#line 43 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                 Write(items.SellingPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1198, 29, true);
            WriteLiteral("</td>\r\n                <td>$ ");
            EndContext();
            BeginContext(1228, 18, false);
#line 44 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                 Write(items.profitMargin);

#line default
#line hidden
            EndContext();
            BeginContext(1246, 51, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1297, "\"", 1334, 2);
            WriteAttributeValue("", 1304, "/Sales/Create?itemId=", 1304, 21, true);
#line 46 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
WriteAttributeValue("", 1325, items.Id, 1325, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1335, 57, true);
            WriteLiteral(">Add Sale</a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                }

#line default
#line hidden
#line 49 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                 
            }
            else
            {

#line default
#line hidden
            BeginContext(1459, 146, true);
            WriteLiteral("                <tr class=\"danger\">\r\n                    <td colspan=\"4\" class=\"text-center\">\r\n                        No results found for term \"");
            EndContext();
            BeginContext(1606, 12, false);
#line 55 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
                                              Write(Model.Search);

#line default
#line hidden
            EndContext();
            BeginContext(1618, 53, true);
            WriteLiteral("\"\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 58 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
            }

#line default
#line hidden
            BeginContext(1686, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 61 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1730, 164, true);
            WriteLiteral("    <div class=\"alert alert-info\">\r\n        <p>\r\n            Enter the search terms into the box and click <strong>Search Items</strong>\r\n        </p>\r\n    </div>\r\n");
            EndContext();
#line 69 "C:\Users\Parth\source\repos\SalesTracker\SalesTracker\Pages\SearchStoreItems.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SalesTracker.Pages.SearchStoreItemsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SalesTracker.Pages.SearchStoreItemsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SalesTracker.Pages.SearchStoreItemsModel>)PageContext?.ViewData;
        public SalesTracker.Pages.SearchStoreItemsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
