#pragma checksum "C:\Users\ops31\source\repos\esu_v\esu_v\Views\About\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55196074438a7a0c6b592dadfcaaceb035d3dfd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_ContactUs), @"mvc.1.0.view", @"/Views/About/ContactUs.cshtml")]
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
#line 1 "C:\Users\ops31\source\repos\esu_v\esu_v\Views\_ViewImports.cshtml"
using esu_v;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ops31\source\repos\esu_v\esu_v\Views\_ViewImports.cshtml"
using esu_v.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55196074438a7a0c6b592dadfcaaceb035d3dfd0", @"/Views/About/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e20fdcfd311bd3be2b09e5f987265728ef9b1cda", @"/Views/_ViewImports.cshtml")]
    public class Views_About_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ops31\source\repos\esu_v\esu_v\Views\About\ContactUs.cshtml"
  
    ViewData["Title"] = "찾아오시는 길";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<hr />
<div class=""esu-about"">
    <div class=""esu-map"">
        <h3>찾아오시는 길 (feat. 구글 맵)</h3>
        <div id=""googleMap"" style=""width:100%;height:600px;""></div>
    </div>
</div>
<div class=""esu-about"">
    <div class=""esu-transport"">
        <table class=""table table-striped"">
            <tbody>
                <tr>
                    <th scope=""row"">주소</th>
                    <td>
                        서울시 서초구 방배동 3001-2 디오슈페리움1 17층 1706호
                    </td>
                </tr>
                <tr>
                    <th scope=""row"">지하철</th>
                    <td>
                        4,7호선 환승역 총신대(이수)역, 4번 출구 앞
                    </td>
                </tr>
                <tr>
                    <th scope=""row"">버스</th>
                    <td>
                        (이수역 하차) 540, 4212, 4319, 11-1 11-2 11-5
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>

<script>
    function myMap() {
     ");
            WriteLiteral(@"   var esu = { lat: 37.485952, lng: 126.983025 };

        var map = new google.maps.Map(
            document.getElementById('googleMap'), {zoom: 18, center: esu});

        var marker = new google.maps.Marker({position: esu, map: map});
    }
</script>

<script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyAVVcpNC_2fK1oX9kfIIb5SFbSyOeD5JM8&callback=myMap""></script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
