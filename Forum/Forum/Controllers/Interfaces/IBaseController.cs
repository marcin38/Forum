using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Controllers.Interfaces
{
    interface IBaseController
    {
        bool CheckIfUserIsAuthenticated();
        bool CheckIfUserIsAdministrator();
        string GetUserName();
        int GetUserId();
    }
}
