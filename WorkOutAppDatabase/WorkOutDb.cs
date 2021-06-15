using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;
using WorkOutAppDatabase;
using WorkOutAppDatabase.Models;

namespace WorkOutAppDatabase
{
    public static class WorkOutDb
    {
        #region ## User Registration ##

        public static RegisterModel Registration(RegisterModel model)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            try
            {
                using (_db)
                {
                    if (!UserNameOrEmailWasTaken(model.Email, model.UserName))
                    {
                        return new RegisterModel { Error = "Ezen adatok valamelyikével már regisztráltak." };
                    }
                    else
                    {
                        User user = new User()
                        {
                            Email = model.Email,
                            UserName = model.UserName,
                            Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                        };

                        _db.User.Add(user);
                        _db.SaveChanges();
                        int userId = user.Id;
                        return _db.User.Where(w => w.Id == userId).Select(s => new RegisterModel
                        {
                            Email = s.Email,
                            UserName = s.UserName,
                            Error = "Sikeres regisztráció"
                        }).FirstOrDefault();
                    }
                }

            }
            catch (Exception)
            {
                return new RegisterModel { Error = "Hiba lépett fel a regisztráció közben!" };

            }

        }
        //regisztáltak-e már ezzel a felhasználónévvel vagy e-mail címmel
        public static bool UserNameOrEmailWasTaken(string email, string username)
        {
            ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
            User userList = new User();
            using (_db)
            {
                userList = _db.User.Where(w => w.Email == email && w.UserName == username).Select(s => s).FirstOrDefault();

            }
            if (userList == null)
            {
                return true;
            }
            else if (userList.Email == null && userList.UserName == null)
            {
                return true;
            }
            else
                return false;
        }

        #endregion
        #region ## User Login ##

        //bejelentkezés
        public static LoginUser Login(LoginUser loginUser)
        {
            try
            {
                ApplicationDbContext _db = new ApplicationDbContext(SetDatabase.dbContextOptionsBuilder());
                using (_db)
                {
                    User user = _db.User.Where(w => w.UserName == loginUser.UserName).Select(s => s).FirstOrDefault();
                    if (BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
                    {
                        return new LoginUser { UserName = user.UserName, Succes = true, Error = "Sikeres bejelentkezés" };
                    }
                    else
                    {
                        return new LoginUser { Error = "Sikertelen bejelentkezés", Succes = false };
                    }
                }
            }
            catch (Exception)
            {
                return new LoginUser { Error = "Sikertelen bejelentkezés", Succes = false };
            }
        }
        #endregion
    }
}
