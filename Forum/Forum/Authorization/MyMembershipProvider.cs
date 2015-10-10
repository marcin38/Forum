using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Authorization
{
    public class MyMembershipProvider : MembershipProvider
    {
        public IUserRepository userRepository;

        public MyMembershipProvider() {
            userRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }

        public MyMembershipProvider(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return false;
        }

        public override MembershipUser CreateUser(string username, string password, string email,
               string passwordQuestion, string passwordAnswer, bool isApproved,
               object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.Success;
            return null;
            
        }

        public override string ResetPassword(string username, string answer)
        {
            return "";
        }

        public override bool ValidateUser(string username, string password)
        {
            byte[] hash = ComputeHash(password, username);
            List<User> users = userRepository.Get(u => u.Name == username).ToList();

            if (users.Count == 0 || !hash.SequenceEqual(users.ElementAt(0).Hash))
            {
                return false;
            }
            else
            {
                return true;
            }
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

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        private byte[] ComputeHash(string data, string salt)
        {            
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(String.Format("{0}{1}",data,salt)));
            return hash;
        }
    }
}