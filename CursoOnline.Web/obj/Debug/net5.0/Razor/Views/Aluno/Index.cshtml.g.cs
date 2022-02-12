#pragma checksum "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88eb1cd99abbebe4311d5d0308b40ffed04e5ea2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aluno_Index), @"mvc.1.0.view", @"/Views/Aluno/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\_ViewImports.cshtml"
using CursoOnline.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\_ViewImports.cshtml"
using CursoOnline.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
using CursoOnline.Dominio.Alunos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88eb1cd99abbebe4311d5d0308b40ffed04e5ea2", @"/Views/Aluno/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0d8200179469d3ff6fec63422201671018f588", @"/Views/_ViewImports.cshtml")]
    public class Views_Aluno_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CursoOnline.Web.Util.PaginatedList<AlunoParaListagemDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
  
    ViewData["Title"] = "Alunos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""pad-wrapper"">

    <div class=""row"">
        <div class=""col-md-12"">
            <a href=""/Aluno"" class=""btn"">Voltar</a>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-md-12"">
            <a href=""/Aluno/Novo"" class=""btn btn-primary"">Novo</a>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>CPF</th>
                        <th>E-mail</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 31 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 35 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                           Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 38 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                           Write(item.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 41 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1321, "\"", 1350, 2);
            WriteAttributeValue("", 1328, "/Aluno/Editar/", 1328, 14, true);
#nullable restore
#line 44 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
WriteAttributeValue("", 1342, item.Id, 1342, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn\">Editar</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 47 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n");
#nullable restore
#line 51 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
              
                var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
                var nextDisabled = !Model.HasNextPage ? "disabled" : "";
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88eb1cd99abbebe4311d5d0308b40ffed04e5ea27320", async() => {
                WriteLiteral("\r\n                Anterior\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                    WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1813, "btn", 1813, 3, true);
            AddHtmlAttributeValue(" ", 1816, "btn-default", 1817, 12, true);
#nullable restore
#line 58 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
AddHtmlAttributeValue(" ", 1828, prevDisabled, 1829, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88eb1cd99abbebe4311d5d0308b40ffed04e5ea210163", async() => {
                WriteLiteral("\r\n                Próximo\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
                    WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2003, "btn", 2003, 3, true);
            AddHtmlAttributeValue(" ", 2006, "btn-default", 2007, 12, true);
#nullable restore
#line 63 "D:\Cursos\Projetos\CursoTDDxUnit_dotnetcore\CursoOnline\CursoOnline.Web\Views\Aluno\Index.cshtml"
AddHtmlAttributeValue(" ", 2018, nextDisabled, 2019, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CursoOnline.Web.Util.PaginatedList<AlunoParaListagemDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
