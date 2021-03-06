// <auto-generated />
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
namespace Forum.Controllers
{
    public partial class UserController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Index()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Login()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ShowProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult RenderPhoto()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RenderPhoto);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditProfile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Ban()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Ban);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult BanConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BanConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Unban()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Unban);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UnbanConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UnbanConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult MyPosts()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyPosts);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult IsUserNameAvailable()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.IsUserNameAvailable);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult GetNames()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetNames);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "User";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "User";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Register = "Register";
            public readonly string Login = "Login";
            public readonly string LogOff = "LogOff";
            public readonly string ShowProfile = "ShowProfile";
            public readonly string RenderPhoto = "RenderPhoto";
            public readonly string EditProfile = "EditProfile";
            public readonly string AdministerCategories = "AdministerCategories";
            public readonly string Delete = "Delete";
            public readonly string DeleteConfirmed = "Delete";
            public readonly string Ban = "Ban";
            public readonly string BanConfirmed = "Ban";
            public readonly string Unban = "Unban";
            public readonly string UnbanConfirmed = "Unban";
            public readonly string MyPosts = "MyPosts";
            public readonly string IsUserNameAvailable = "IsUserNameAvailable";
            public readonly string GetNames = "GetNames";
            public readonly string ExportToPDF = "ExportToPDF";
            public readonly string ExportToXLS = "ExportToXLS";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Register = "Register";
            public const string Login = "Login";
            public const string LogOff = "LogOff";
            public const string ShowProfile = "ShowProfile";
            public const string RenderPhoto = "RenderPhoto";
            public const string EditProfile = "EditProfile";
            public const string AdministerCategories = "AdministerCategories";
            public const string Delete = "Delete";
            public const string DeleteConfirmed = "Delete";
            public const string Ban = "Ban";
            public const string BanConfirmed = "Ban";
            public const string Unban = "Unban";
            public const string UnbanConfirmed = "Unban";
            public const string MyPosts = "MyPosts";
            public const string IsUserNameAvailable = "IsUserNameAvailable";
            public const string GetNames = "GetNames";
            public const string ExportToPDF = "ExportToPDF";
            public const string ExportToXLS = "ExportToXLS";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string term = "term";
            public readonly string page = "page";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string user = "user";
            public readonly string upload = "upload";
        }
        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string returnUrl = "returnUrl";
            public readonly string credentials = "credentials";
        }
        static readonly ActionParamsClass_ShowProfile s_params_ShowProfile = new ActionParamsClass_ShowProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ShowProfile ShowProfileParams { get { return s_params_ShowProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ShowProfile
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_RenderPhoto s_params_RenderPhoto = new ActionParamsClass_RenderPhoto();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RenderPhoto RenderPhotoParams { get { return s_params_RenderPhoto; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RenderPhoto
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_EditProfile s_params_EditProfile = new ActionParamsClass_EditProfile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditProfile EditProfileParams { get { return s_params_EditProfile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditProfile
        {
            public readonly string id = "id";
            public readonly string user = "user";
            public readonly string upload = "upload";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DeleteConfirmed s_params_DeleteConfirmed = new ActionParamsClass_DeleteConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteConfirmed DeleteConfirmedParams { get { return s_params_DeleteConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteConfirmed
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Ban s_params_Ban = new ActionParamsClass_Ban();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Ban BanParams { get { return s_params_Ban; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Ban
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_BanConfirmed s_params_BanConfirmed = new ActionParamsClass_BanConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_BanConfirmed BanConfirmedParams { get { return s_params_BanConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_BanConfirmed
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Unban s_params_Unban = new ActionParamsClass_Unban();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Unban UnbanParams { get { return s_params_Unban; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Unban
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_UnbanConfirmed s_params_UnbanConfirmed = new ActionParamsClass_UnbanConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UnbanConfirmed UnbanConfirmedParams { get { return s_params_UnbanConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UnbanConfirmed
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_MyPosts s_params_MyPosts = new ActionParamsClass_MyPosts();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MyPosts MyPostsParams { get { return s_params_MyPosts; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MyPosts
        {
            public readonly string page = "page";
        }
        static readonly ActionParamsClass_IsUserNameAvailable s_params_IsUserNameAvailable = new ActionParamsClass_IsUserNameAvailable();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_IsUserNameAvailable IsUserNameAvailableParams { get { return s_params_IsUserNameAvailable; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_IsUserNameAvailable
        {
            public readonly string Name = "Name";
        }
        static readonly ActionParamsClass_GetNames s_params_GetNames = new ActionParamsClass_GetNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetNames GetNamesParams { get { return s_params_GetNames; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetNames
        {
            public readonly string term = "term";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _Table = "_Table";
                public readonly string AdministerCategories = "AdministerCategories";
                public readonly string Ban = "Ban";
                public readonly string Delete = "Delete";
                public readonly string EditProfile = "EditProfile";
                public readonly string Index = "Index";
                public readonly string Login = "Login";
                public readonly string MyPosts = "MyPosts";
                public readonly string Register = "Register";
                public readonly string Unban = "Unban";
            }
            public readonly string _Table = "~/Views/User/_Table.cshtml";
            public readonly string AdministerCategories = "~/Views/User/AdministerCategories.cshtml";
            public readonly string Ban = "~/Views/User/Ban.cshtml";
            public readonly string Delete = "~/Views/User/Delete.cshtml";
            public readonly string EditProfile = "~/Views/User/EditProfile.cshtml";
            public readonly string Index = "~/Views/User/Index.cshtml";
            public readonly string Login = "~/Views/User/Login.cshtml";
            public readonly string MyPosts = "~/Views/User/MyPosts.cshtml";
            public readonly string Register = "~/Views/User/Register.cshtml";
            public readonly string Unban = "~/Views/User/Unban.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserController : Forum.Controllers.UserController
    {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string term, int? page);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(string term, int? page)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "term", term);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "page", page);
            IndexOverride(callInfo, term, page);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            RegisterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Forum.ViewModels.UserRegisterViewModel user, System.Web.HttpPostedFileBase upload);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register(Forum.ViewModels.UserRegisterViewModel user, System.Web.HttpPostedFileBase upload)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "user", user);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "upload", upload);
            RegisterOverride(callInfo, user, upload);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Login(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Forum.ViewModels.UserLoginViewModel credentials, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Login(Forum.ViewModels.UserLoginViewModel credentials, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "credentials", credentials);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, credentials, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ShowProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ShowProfile(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ShowProfileOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void RenderPhotoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult RenderPhoto(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RenderPhoto);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RenderPhotoOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditProfile(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditProfileOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Forum.ViewModels.UserEditProfileViewModel user, System.Web.HttpPostedFileBase upload);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditProfile(Forum.ViewModels.UserEditProfileViewModel user, System.Web.HttpPostedFileBase upload)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditProfile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "user", user);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "upload", upload);
            EditProfileOverride(callInfo, user, upload);
            return callInfo;
        }

        [NonAction]
        partial void AdministerCategoriesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AdministerCategories()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AdministerCategories);
            AdministerCategoriesOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeleteConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteConfirmed(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteConfirmedOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void BanOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Ban(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Ban);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            BanOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void BanConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult BanConfirmed(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BanConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            BanConfirmedOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void UnbanOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Unban(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Unban);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            UnbanOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void UnbanConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult UnbanConfirmed(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UnbanConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            UnbanConfirmedOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void MyPostsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? page);

        [NonAction]
        public override System.Web.Mvc.ActionResult MyPosts(int? page)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MyPosts);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "page", page);
            MyPostsOverride(callInfo, page);
            return callInfo;
        }

        [NonAction]
        partial void IsUserNameAvailableOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string Name);

        [NonAction]
        public override System.Web.Mvc.JsonResult IsUserNameAvailable(string Name)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.IsUserNameAvailable);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Name", Name);
            IsUserNameAvailableOverride(callInfo, Name);
            return callInfo;
        }

        [NonAction]
        partial void GetNamesOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string term);

        [NonAction]
        public override System.Web.Mvc.JsonResult GetNames(string term)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetNames);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "term", term);
            GetNamesOverride(callInfo, term);
            return callInfo;
        }

        [NonAction]
        partial void ExportToPDFOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ExportToPDF()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExportToPDF);
            ExportToPDFOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ExportToXLSOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ExportToXLS()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExportToXLS);
            ExportToXLSOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
