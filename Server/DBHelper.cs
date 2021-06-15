using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;
using WorkOutAppDatabase;

namespace WorkOutAppApi.Server
{
    public static class DBHelper
    {
        #region ##Registration##

        public static RegisterModel Registration(RegisterModel model)
        {
            return WorkOutDb.Registration(model);
        }
        #endregion

        #region ##Login##
        public static LoginUser Login(LoginUser model)
        {
            return WorkOutDb.Login(model);
        }
        #endregion
    }
}
