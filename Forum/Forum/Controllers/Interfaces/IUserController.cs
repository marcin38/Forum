using Forum.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IUserController
    {
        ActionResult Index(string term, int? page);
        ActionResult Register();
        ActionResult Register(UserRegisterViewModel user, HttpPostedFileBase upload);
        ActionResult Login(string returnUrl);
        ActionResult Login(UserLoginViewModel credentials, string returnUrl);
        ActionResult LogOff();
        ActionResult ShowProfile(int? id);
        ActionResult RenderPhoto(int id);
        ActionResult EditProfile(int id);
        ActionResult EditProfile(UserEditProfileViewModel user, HttpPostedFileBase upload);
        ActionResult AdministerCategories();
        ActionResult Delete(int id);
        ActionResult DeleteConfirmed(int id);
        ActionResult Ban(int id);
        ActionResult BanConfirmed(int id);
        ActionResult Unban(int id);
        ActionResult UnbanConfirmed(int id);
        ActionResult MyPosts(int? page);
        JsonResult IsUserNameAvailable(string Name);
        ActionResult ExportToPDF();
        ActionResult ExportToXLS();
    }
}
