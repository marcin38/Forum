using System.Security.Principal;
using System.Web.Security;

namespace Forum.Authorization
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        
        public int Id { get; set; }
        public string Token { get; set; }
        //public string Name { get; set; }
        //public bool IsAuthenticated { get; set; }

        public CustomPrincipal()
        {
            //this.Identity = new GenericIdentity("");
        }

        public CustomPrincipal(int id, string name, string token)
        {
            this.Identity = new GenericIdentity(name, "Custom");
            this.Id = id;
            this.Token = token;
            //this.Name = name;
            //this.IsAuthenticated = true;
        }

        public bool IsInRole(string role) 
        {
            return Roles.IsUserInRole(role);
        }

    }
}