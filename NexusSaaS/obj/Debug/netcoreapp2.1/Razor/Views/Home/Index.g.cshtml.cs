#pragma checksum "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac4822d8b6931ba846323f9ab0983c893af769e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac4822d8b6931ba846323f9ab0983c893af769e8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"781d58719822ae4423193b9976002c05722650a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NexusSaaS.Models.FeatureModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_NexusLayout";

#line default
#line hidden
            BeginContext(121, 2864, true);
            WriteLiteral(@"
<section class=""home_banner_area"">
    <div class=""banner_inner"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-5"">
                    <div class=""banner_content"">
                        <h2>Mass People <br />Oriented Software</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim. sed do eiusmod tempor incididunt.</p>
                        <a class=""banner_btn"" href=""#"">Get Started</a>
                        <a class=""banner_btn2"" href=""#"">Download</a>
                    </div>
                </div>
                <div class=""col-lg-7"">
                    <div class=""home_left_img"">
                        <img class=""img-fluid"" src=""img/banner/home-left-1.png"" alt="""">
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""work_area p_120"">
");
            WriteLiteral(@"    <div class=""container"">
        <div class=""main_title"">
            <h2>How It work for you</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.</p>
        </div>
        <div class=""work_inner row"">
            <div class=""col-lg-4"">
                <div class=""work_item"">
                    <i class=""lnr lnr-screen""></i>
                    <a href=""#""><h4>Stunning Visuals</h4></a>
                    <p>Here, I focus on a range of items and features that we use in life without giving them a second thought such as Coca Cola.</p>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""work_item"">
                    <i class=""lnr lnr-code""></i>
                    <a href=""#""><h4>Stunning Visuals</h4></a>
                    <p>Here, I focus on a range of items and features that we use in life w");
            WriteLiteral(@"ithout giving them a second thought such as Coca Cola.</p>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""work_item"">
                    <i class=""lnr lnr-clock""></i>
                    <a href=""#""><h4>Stunning Visuals</h4></a>
                    <p>Here, I focus on a range of items and features that we use in life without giving them a second thought such as Coca Cola.</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Work Area =================-->
<!--================Made Life Area =================-->
<section class=""made_life_area p_120"">
    <div class=""container"">
        <div class=""made_life_inner"">
            <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
");
            EndContext();
#line 79 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                 for (var i = 0; i < Model.Count(); i++)
                {
                    if (i == 0)
                    {

#line default
#line hidden
            BeginContext(4054, 124, true);
            WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a class=\"nav-link active show\" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4178, "\"", 4202, 3);
            WriteAttributeValue("", 4185, "#", 4185, 1, true);
#line 84 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 4186, Model[0].Id, 4186, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 4198, "-tab", 4198, 4, true);
            EndWriteAttribute();
            BeginContext(4203, 33, true);
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
            EndContext();
            BeginContext(4237, 13, false);
#line 84 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                                                                                                                  Write(Model[0].Name);

#line default
#line hidden
            EndContext();
            BeginContext(4250, 37, true);
            WriteLiteral("</a>\r\n                        </li>\r\n");
            EndContext();
#line 86 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(4359, 112, true);
            WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a class=\"nav-link\" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4471, "\"", 4495, 3);
            WriteAttributeValue("", 4478, "#", 4478, 1, true);
#line 90 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 4479, Model[i].Id, 4479, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 4491, "-tab", 4491, 4, true);
            EndWriteAttribute();
            BeginContext(4496, 33, true);
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
            EndContext();
            BeginContext(4530, 13, false);
#line 90 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                                                                                                      Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(4543, 37, true);
            WriteLiteral("</a>\r\n                        </li>\r\n");
            EndContext();
#line 92 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                    }

                }

#line default
#line hidden
            BeginContext(4624, 76, true);
            WriteLiteral("            </ul>\r\n            <div class=\"tab-content\" id=\"myTabContent\">\r\n");
            EndContext();
#line 165 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                 for (var i = 0; i < Model.Count(); i++)
                {
                    var imgUrl = "/images/";
                    if(Model[i].ImgUrl == null || Model[i].ImgUrl == "")
                    {
                        imgUrl += "noImg.png";
                    }
                    else
                    {
                        imgUrl += Model[i].ImgUrl;
                    }
                    if (i == 0)
                    {

#line default
#line hidden
            BeginContext(9653, 62, true);
            WriteLiteral("                        <div class=\"tab-pane fade show active\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 9715, "\"", 9736, 2);
#line 178 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 9720, Model[0].Id, 9720, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 9732, "-tab", 9732, 4, true);
            EndWriteAttribute();
            BeginContext(9737, 247, true);
            WriteLiteral(" role=\"tabpanel\">\r\n                            <div class=\"row made_life_text\">\r\n                                <div class=\"col-lg-6\">\r\n                                    <div class=\"left_side_text\">\r\n                                        <h3>");
            EndContext();
            BeginContext(9985, 14, false);
#line 182 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                       Write(Model[0].Title);

#line default
#line hidden
            EndContext();
            BeginContext(9999, 51, true);
            WriteLiteral("</h3>\r\n                                        <h6>");
            EndContext();
            BeginContext(10051, 20, false);
#line 183 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                       Write(Model[0].Description);

#line default
#line hidden
            EndContext();
            BeginContext(10071, 50, true);
            WriteLiteral("</h6>\r\n                                        <p>");
            EndContext();
            BeginContext(10122, 16, false);
#line 184 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                      Write(Model[0].Content);

#line default
#line hidden
            EndContext();
            BeginContext(10138, 359, true);
            WriteLiteral(@"</p>
                                        <a class=""main_btn"" href=""#"">Get Started Now</a>
                                    </div>
                                </div>
                                <div class=""col-lg-6"">
                                    <div class=""chart_img"">
                                        <img class=""img-fluid""");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 10497, "\"", 10510, 1);
#line 190 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 10503, imgUrl, 10503, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(10511, 155, true);
            WriteLiteral(">\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 195 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(10738, 55, true);
            WriteLiteral("                        <div class=\"tab-pane fade show\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 10793, "\"", 10814, 2);
#line 198 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 10798, Model[i].Id, 10798, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 10810, "-tab", 10810, 4, true);
            EndWriteAttribute();
            BeginContext(10815, 247, true);
            WriteLiteral(" role=\"tabpanel\">\r\n                            <div class=\"row made_life_text\">\r\n                                <div class=\"col-lg-6\">\r\n                                    <div class=\"left_side_text\">\r\n                                        <h3>");
            EndContext();
            BeginContext(11063, 14, false);
#line 202 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                       Write(Model[i].Title);

#line default
#line hidden
            EndContext();
            BeginContext(11077, 51, true);
            WriteLiteral("</h3>\r\n                                        <h6>");
            EndContext();
            BeginContext(11129, 20, false);
#line 203 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                       Write(Model[i].Description);

#line default
#line hidden
            EndContext();
            BeginContext(11149, 50, true);
            WriteLiteral("</h6>\r\n                                        <p>");
            EndContext();
            BeginContext(11200, 16, false);
#line 204 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                                      Write(Model[i].Content);

#line default
#line hidden
            EndContext();
            BeginContext(11216, 359, true);
            WriteLiteral(@"</p>
                                        <a class=""main_btn"" href=""#"">Get Started Now</a>
                                    </div>
                                </div>
                                <div class=""col-lg-6"">
                                    <div class=""chart_img"">
                                        <img class=""img-fluid""");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 11575, "\"", 11588, 1);
#line 210 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
WriteAttributeValue("", 11581, imgUrl, 11581, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(11589, 161, true);
            WriteLiteral(">\r\n                                    </div>\r\n\r\n                                </div>\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n");
            EndContext();
#line 218 "C:\Users\VuPhuc\source\repos\NexusSaaS\NexusSaaS\Views\Home\Index.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(11792, 13603, true);
            WriteLiteral(@"            </div>
        </div>
</section>
<!--================End Made Life Area =================-->
<!--================Screen Area =================-->
<section class=""screen_area text-center p_120"">
    <div class=""container"">
        <div class=""main_title"">
            <h2>Unique Screens that work perfectly</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.</p>
        </div>
        <img class=""img-fluid"" src=""img/banner/home-left-1.png"" alt="""">
    </div>
</section>
<!--================End Screen Area =================-->
<!--================Made Life Area =================-->
<section class=""made_life_area p_120"">
    <div class=""container"">
        <div class=""made_life_inner"">
            <div class=""row made_life_text"">
                <div class=""col-lg-6"">
                    <div class=""left_side_text"">
                       ");
            WriteLiteral(@" <h3>We’ve made a life <br />that will change you</h3>
                        <h6>We are here to listen from you deliver exellence</h6>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp or incididunt ut labore et dolore magna aliqua. Ut enim ad minim.</p>
                        <a class=""main_btn"" href=""#"">Get Started Now</a>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""chart_img"">
                        <img class=""img-fluid"" src=""img/browser.png"" alt="""">
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Made Life Area =================-->
<!--================Price Area =================-->
<section class=""price_area p_120"">
    <div class=""container"">
        <div class=""main_title"">
            <h2>Choose Your Price Plan</h2>
            <p>Lorem ipsum dolor sit amet, consect");
            WriteLiteral(@"etur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.</p>
        </div>
        <div class=""price_inner row"">
            <div class=""col-lg-4"">
                <div class=""price_item"">
                    <div class=""price_head"">
                        <h4>Real Basic</h4>
                    </div>
                    <div class=""price_body"">
                        <ul class=""list"">
                            <li><a href=""#"">2.5 GB Space</a></li>
                            <li><a href=""#"">Secure Online Transfer</a></li>
                            <li><a href=""#"">Unlimited Styles</a></li>
                            <li><a href=""#"">Customer Service</a></li>
                        </ul>
                    </div>
                    <div class=""price_footer"">
                        <h3><span class=""dlr"">$</span> 39 <span class=""month"">Per <br />Month</span></h3>
                        <a class=""ma");
            WriteLiteral(@"in_btn"" href=""#"">Get Started</a>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""price_item"">
                    <div class=""price_head"">
                        <h4>Real Standard</h4>
                    </div>
                    <div class=""price_body"">
                        <ul class=""list"">
                            <li><a href=""#"">10 GB Space</a></li>
                            <li><a href=""#"">Secure Online Transfer</a></li>
                            <li><a href=""#"">Unlimited Styles</a></li>
                            <li><a href=""#"">Customer Service</a></li>
                        </ul>
                    </div>
                    <div class=""price_footer"">
                        <h3><span class=""dlr"">$</span> 69 <span class=""month"">Per <br />Month</span></h3>
                        <a class=""main_btn"" href=""#"">Get Started</a>
                    </div>
                </div>
        ");
            WriteLiteral(@"    </div>
            <div class=""col-lg-4"">
                <div class=""price_item"">
                    <div class=""price_head"">
                        <h4>Real Ultimate</h4>
                    </div>
                    <div class=""price_body"">
                        <ul class=""list"">
                            <li><a href=""#"">Unlimited Space</a></li>
                            <li><a href=""#"">Secure Online Transfer</a></li>
                            <li><a href=""#"">Unlimited Styles</a></li>
                            <li><a href=""#"">Customer Service</a></li>
                        </ul>
                    </div>
                    <div class=""price_footer"">
                        <h3><span class=""dlr"">$</span> 99 <span class=""month"">Per <br />Month</span></h3>
                        <a class=""main_btn"" href=""#"">Get Started</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Price Area ===");
            WriteLiteral(@"==============-->
<!--================Testimonials Area =================-->
<section class=""testimonials_area p_120"">
    <div class=""container"">
        <div class=""main_title"">
            <h2>Feedback from Customers</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.</p>
        </div>
        <div class=""testi_slider owl-carousel"">
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-1.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, scanner, speaker, projector, hardware.</p>
                            <h4>Mark Alviro");
            WriteLiteral(@" Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-2.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, scanner, speaker, projector, hardware.</p>
                          ");
            WriteLiteral(@"  <h4>Mark Alviro Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-1.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, scanner, speaker, projector, hardware.</p>
         ");
            WriteLiteral(@"                   <h4>Mark Alviro Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-2.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, scanner, speaker, projector, hardwar");
            WriteLiteral(@"e.</p>
                            <h4>Mark Alviro Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-1.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, scanner, speaker, p");
            WriteLiteral(@"rojector, hardware.</p>
                            <h4>Mark Alviro Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""item"">
                <div class=""testi_item"">
                    <div class=""media"">
                        <div class=""d-flex"">
                            <img src=""img/testimonials/testi-2.png"" alt="""">
                        </div>
                        <div class=""media-body"">
                            <p>Accessories Here you can find the best computer accessory for your laptop, monitor, printer, sc");
            WriteLiteral(@"anner, speaker, projector, hardware.</p>
                            <h4>Mark Alviro Wiens</h4>
                            <div class=""rating"">
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star""></i>
                                <i class=""fa fa-star-half-o""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Testimonials Area =================-->
<!--================Made Life Area =================-->
<section class=""made_life_area made_white p_120"">
    <div class=""container"">
        <div class=""made_life_inner"">
            <div class=""row made_life_text"">
                <div class=""col-lg-6"">
                    <div class=""chart_img"">
                  ");
            WriteLiteral(@"      <img class=""img-fluid"" src=""img/banner/home-left-1.png"" alt="""">
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""left_side_text"">
                        <h3>We’ve made a life <br />that will change you</h3>
                        <h6>We are here to listen from you deliver exellence</h6>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp or incididunt ut labore et dolore magna aliqua. Ut enim ad minim.</p>
                        <a class=""main_btn"" href=""#"">Get Started Now</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Made Life Area =================-->
<!--================Impress Area =================-->
<section class=""impress_area p_120"">
    <div class=""container"">
        <div class=""impress_inner"">
            <h2>Got Impressed to our features?</h2>
            <p");
            WriteLiteral(@">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore  et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.</p>
            <a class=""banner_btn2"" href=""#"">Request Free Demo</a>
        </div>
    </div>
</section>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NexusSaaS.Models.FeatureModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
