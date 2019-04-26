using RPB.Website.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RPB.Website.BL
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Username")]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Password")]
        public string UserPass { get; set; }

        public User()
        {

        }

        public User(string userId, string password)
        {
            UserId = userId;
            UserPass = password;
        }

        public User(string userId, string firstName, string lastName, string password)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserPass = password;
        }
        public User(int id, string userId, string firstName, string lastName, string password)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserPass = password;
        }

        private void Map(tblUser user)
        {
            user.Id = Id;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserId = UserId;
            user.UserPass = UserPass;
        }

        public void Insert()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                {
                    tblUser user = new tblUser();
                    Map(user);
                    user.Id = oDc.tblUsers.Any() ? oDc.tblUsers.Max(u => u.Id) + 1 : 1;
                    oDc.tblUsers.Add(user);
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashBytes = Encoding.UTF8.GetBytes(UserPass);
                return Convert.ToBase64String(hash.ComputeHash(hashBytes));
            }
        }

        public void Seed()
        {
            UserPass = GetHash();
            Insert();
        }

        public bool Login()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(UserId))
                {
                    if (!String.IsNullOrWhiteSpace(UserPass))
                    {
                        using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                        {
                            tblUser user = oDc.tblUsers.FirstOrDefault(u => u.UserId == UserId);
                            if (user != null)
                            {
                                if (user.UserPass == GetHash())
                                {
                                    FirstName = user.FirstName;
                                    LastName = user.LastName;
                                    Id = user.Id;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                    }
                    else
                        throw new Exception("Password needs to be set.");
                }
                else
                    throw new Exception("UserId needs to be set.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class UserList : List<User>
    {
        public void Load()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                    oDc.tblUsers.ToList().ForEach(u => Add(new User(u.Id, u.UserId, u.FirstName, u.LastName, u.UserPass)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
