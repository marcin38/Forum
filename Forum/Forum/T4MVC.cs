﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static Forum.Controllers.BaseController Base = new Forum.Controllers.T4MVC_BaseController();
    public static Forum.Controllers.CategoryController Category = new Forum.Controllers.T4MVC_CategoryController();
    public static Forum.Controllers.ErrorController Error = new Forum.Controllers.T4MVC_ErrorController();
    public static Forum.Controllers.GalleryController Gallery = new Forum.Controllers.T4MVC_GalleryController();
    public static Forum.Controllers.HomeController Home = new Forum.Controllers.T4MVC_HomeController();
    public static Forum.Controllers.MessageController Message = new Forum.Controllers.T4MVC_MessageController();
    public static Forum.Controllers.PostController Post = new Forum.Controllers.T4MVC_PostController();
    public static Forum.Controllers.ThreadController Thread = new Forum.Controllers.T4MVC_ThreadController();
    public static Forum.Controllers.UserController User = new Forum.Controllers.T4MVC_UserController();
    public static Forum.Controllers.WarningController Warning = new Forum.Controllers.T4MVC_WarningController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_EmptyResult : System.Web.Mvc.EmptyResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_EmptyResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_JsonResult : System.Web.Mvc.JsonResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_JsonResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string _references_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_references.min.js") ? Url("_references.min.js") : Url("_references.js");
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        public static readonly string jquery_1_10_2_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.intellisense.min.js") ? Url("jquery-1.10.2.intellisense.min.js") : Url("jquery-1.10.2.intellisense.js");
        public static readonly string jquery_1_10_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.min.js") ? Url("jquery-1.10.2.min.js") : Url("jquery-1.10.2.js");
        public static readonly string jquery_1_10_2_min_js = Url("jquery-1.10.2.min.js");
        public static readonly string jquery_1_10_2_min_map = Url("jquery-1.10.2.min.map");
        public static readonly string jquery_ui_1_11_4_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-ui-1.11.4.min.js") ? Url("jquery-ui-1.11.4.min.js") : Url("jquery-ui-1.11.4.js");
        public static readonly string jquery_ui_1_11_4_min_js = Url("jquery-ui-1.11.4.min.js");
        public static readonly string jquery_unobtrusive_ajax_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.unobtrusive-ajax.min.js") ? Url("jquery.unobtrusive-ajax.min.js") : Url("jquery.unobtrusive-ajax.js");
        public static readonly string jquery_unobtrusive_ajax_min_js = Url("jquery.unobtrusive-ajax.min.js");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        public static readonly string modernizr_2_6_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/modernizr-2.6.2.min.js") ? Url("modernizr-2.6.2.min.js") : Url("modernizr-2.6.2.js");
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_min_js = Url("respond.min.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
             
        public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Images {
            private const string URLPATH = "~/Content/Images";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string ball_jpg = Url("ball.jpg");
            public static readonly string calendar_jpg = Url("calendar.jpg");
            public static readonly string elektrownia_atomowa_jpg = Url("elektrownia-atomowa.jpg");
            public static readonly string email_jpg = Url("email.jpg");
            public static readonly string help_jpg = Url("help.jpg");
            public static readonly string kawa_jpg = Url("kawa.jpg");
            public static readonly string ksiezyc_jpg = Url("ksiezyc.jpg");
            public static readonly string slon_jpg = Url("slon.jpg");
        }
    
        public static readonly string jquery_ui_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-ui.min.css") ? Url("jquery-ui.min.css") : Url("jquery-ui.css");
             
        public static readonly string PagedList_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/PagedList.min.css") ? Url("PagedList.min.css") : Url("PagedList.css");
             
        public static readonly string Site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Site.min.css") ? Url("Site.min.css") : Url("Site.css");
             
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class themes {
            private const string URLPATH = "~/Content/themes";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class @base {
                private const string URLPATH = "~/Content/themes/base";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string accordion_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/accordion.min.css") ? Url("accordion.min.css") : Url("accordion.css");
                     
                public static readonly string all_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/all.min.css") ? Url("all.min.css") : Url("all.css");
                     
                public static readonly string autocomplete_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/autocomplete.min.css") ? Url("autocomplete.min.css") : Url("autocomplete.css");
                     
                public static readonly string base_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/base.min.css") ? Url("base.min.css") : Url("base.css");
                     
                public static readonly string button_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/button.min.css") ? Url("button.min.css") : Url("button.css");
                     
                public static readonly string core_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/core.min.css") ? Url("core.min.css") : Url("core.css");
                     
                public static readonly string datepicker_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/datepicker.min.css") ? Url("datepicker.min.css") : Url("datepicker.css");
                     
                public static readonly string dialog_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/dialog.min.css") ? Url("dialog.min.css") : Url("dialog.css");
                     
                public static readonly string draggable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/draggable.min.css") ? Url("draggable.min.css") : Url("draggable.css");
                     
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class images {
                    private const string URLPATH = "~/Content/themes/base/images";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string ui_bg_flat_0_aaaaaa_40x100_png = Url("ui-bg_flat_0_aaaaaa_40x100.png");
                    public static readonly string ui_bg_flat_75_ffffff_40x100_png = Url("ui-bg_flat_75_ffffff_40x100.png");
                    public static readonly string ui_bg_glass_55_fbf9ee_1x400_png = Url("ui-bg_glass_55_fbf9ee_1x400.png");
                    public static readonly string ui_bg_glass_65_ffffff_1x400_png = Url("ui-bg_glass_65_ffffff_1x400.png");
                    public static readonly string ui_bg_glass_75_dadada_1x400_png = Url("ui-bg_glass_75_dadada_1x400.png");
                    public static readonly string ui_bg_glass_75_e6e6e6_1x400_png = Url("ui-bg_glass_75_e6e6e6_1x400.png");
                    public static readonly string ui_bg_glass_95_fef1ec_1x400_png = Url("ui-bg_glass_95_fef1ec_1x400.png");
                    public static readonly string ui_bg_highlight_soft_75_cccccc_1x100_png = Url("ui-bg_highlight-soft_75_cccccc_1x100.png");
                    public static readonly string ui_icons_222222_256x240_png = Url("ui-icons_222222_256x240.png");
                    public static readonly string ui_icons_2e83ff_256x240_png = Url("ui-icons_2e83ff_256x240.png");
                    public static readonly string ui_icons_454545_256x240_png = Url("ui-icons_454545_256x240.png");
                    public static readonly string ui_icons_888888_256x240_png = Url("ui-icons_888888_256x240.png");
                    public static readonly string ui_icons_cd0a0a_256x240_png = Url("ui-icons_cd0a0a_256x240.png");
                }
            
                public static readonly string menu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/menu.min.css") ? Url("menu.min.css") : Url("menu.css");
                     
                public static readonly string progressbar_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/progressbar.min.css") ? Url("progressbar.min.css") : Url("progressbar.css");
                     
                public static readonly string resizable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/resizable.min.css") ? Url("resizable.min.css") : Url("resizable.css");
                     
                public static readonly string selectable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectable.min.css") ? Url("selectable.min.css") : Url("selectable.css");
                     
                public static readonly string selectmenu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectmenu.min.css") ? Url("selectmenu.min.css") : Url("selectmenu.css");
                     
                public static readonly string slider_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/slider.min.css") ? Url("slider.min.css") : Url("slider.css");
                     
                public static readonly string sortable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sortable.min.css") ? Url("sortable.min.css") : Url("sortable.css");
                     
                public static readonly string spinner_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/spinner.min.css") ? Url("spinner.min.css") : Url("spinner.css");
                     
                public static readonly string tabs_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tabs.min.css") ? Url("tabs.min.css") : Url("tabs.css");
                     
                public static readonly string theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/theme.min.css") ? Url("theme.min.css") : Url("theme.css");
                     
                public static readonly string tooltip_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tooltip.min.css") ? Url("tooltip.min.css") : Url("tooltip.css");
                     
            }
        
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static class Assets
            {
                public const string _references_js = "~/Scripts/_references.js"; 
                public const string bootstrap_js = "~/Scripts/bootstrap.js"; 
                public const string bootstrap_min_js = "~/Scripts/bootstrap.min.js"; 
                public const string jquery_1_10_2_intellisense_js = "~/Scripts/jquery-1.10.2.intellisense.js"; 
                public const string jquery_1_10_2_js = "~/Scripts/jquery-1.10.2.js"; 
                public const string jquery_1_10_2_min_js = "~/Scripts/jquery-1.10.2.min.js"; 
                public const string jquery_ui_1_11_4_js = "~/Scripts/jquery-ui-1.11.4.js"; 
                public const string jquery_ui_1_11_4_min_js = "~/Scripts/jquery-ui-1.11.4.min.js"; 
                public const string jquery_unobtrusive_ajax_js = "~/Scripts/jquery.unobtrusive-ajax.js"; 
                public const string jquery_unobtrusive_ajax_min_js = "~/Scripts/jquery.unobtrusive-ajax.min.js"; 
                public const string jquery_validate_js = "~/Scripts/jquery.validate.js"; 
                public const string jquery_validate_min_js = "~/Scripts/jquery.validate.min.js"; 
                public const string jquery_validate_unobtrusive_js = "~/Scripts/jquery.validate.unobtrusive.js"; 
                public const string jquery_validate_unobtrusive_min_js = "~/Scripts/jquery.validate.unobtrusive.min.js"; 
                public const string modernizr_2_6_2_js = "~/Scripts/modernizr-2.6.2.js"; 
                public const string respond_js = "~/Scripts/respond.js"; 
                public const string respond_min_js = "~/Scripts/respond.min.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class Images 
            {
                public static class Assets
                {
                }
            }
            public static partial class themes 
            {
                public static partial class @base 
                {
                    public static partial class images 
                    {
                        public static class Assets
                        {
                        }
                    }
                    public static class Assets
                    {
                        public const string accordion_css = "~/Content/themes/base/accordion.css";
                        public const string all_css = "~/Content/themes/base/all.css";
                        public const string autocomplete_css = "~/Content/themes/base/autocomplete.css";
                        public const string base_css = "~/Content/themes/base/base.css";
                        public const string button_css = "~/Content/themes/base/button.css";
                        public const string core_css = "~/Content/themes/base/core.css";
                        public const string datepicker_css = "~/Content/themes/base/datepicker.css";
                        public const string dialog_css = "~/Content/themes/base/dialog.css";
                        public const string draggable_css = "~/Content/themes/base/draggable.css";
                        public const string menu_css = "~/Content/themes/base/menu.css";
                        public const string progressbar_css = "~/Content/themes/base/progressbar.css";
                        public const string resizable_css = "~/Content/themes/base/resizable.css";
                        public const string selectable_css = "~/Content/themes/base/selectable.css";
                        public const string selectmenu_css = "~/Content/themes/base/selectmenu.css";
                        public const string slider_css = "~/Content/themes/base/slider.css";
                        public const string sortable_css = "~/Content/themes/base/sortable.css";
                        public const string spinner_css = "~/Content/themes/base/spinner.css";
                        public const string tabs_css = "~/Content/themes/base/tabs.css";
                        public const string theme_css = "~/Content/themes/base/theme.css";
                        public const string tooltip_css = "~/Content/themes/base/tooltip.css";
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public const string bootstrap_css = "~/Content/bootstrap.css";
                public const string bootstrap_min_css = "~/Content/bootstrap.min.css";
                public const string jquery_ui_css = "~/Content/jquery-ui.css";
                public const string PagedList_css = "~/Content/PagedList.css";
                public const string Site_css = "~/Content/Site.css";
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


