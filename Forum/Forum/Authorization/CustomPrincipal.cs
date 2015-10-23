using System.Security.Principal;
using System.Web.Security;

namespace Forum.Authorization
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        
        public int Id { get; set; }
        public string Token { get; set; }

        public CustomPrincipal(){}

        public CustomPrincipal(int id, string name, string token)
        {
            this.Identity = new GenericIdentity(name, "Custom");
            this.Id = id;
            this.Token = token;
        }

        public bool IsInRole(string role) 
        {
            return Roles.IsUserInRole(role);
        }

    }
}