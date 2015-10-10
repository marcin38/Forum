using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Authorization
{
    public class MyRoleProvider : RoleProvider
    {
        private IUserRepository userRepository;

        public MyRoleProvider() {
            userRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }

        public MyRoleProvider(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try 
            {
                User user = userRepository.Get(m => m.Name == username).Single();

                if (roleName == "Administrator")
                {
                    return user.IsAdministrator;
                }
                if (roleName == "User")
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;

        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            User user = userRepository.Get(m => m.Name == username).Single();

            if (user.IsAdministrator)
                return new[] { "User", "Administrator" };
            else
                return new[] { "User" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}