using Catalyst.Business.Model.ModUserMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModUserMaster
{
    public class UserMasterDataManager
    {
        public DataTable GetUserList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllUserMaster");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetUserListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@UserID",ID)
                };
                return DBOperate.GetDataTable("usp_GetUserMasterById", parameter);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateUserDetail(UserMaster obj)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@UserId",obj.UserId),    
                        new SqlParameter("@UserName",obj.UserName),
                        new SqlParameter("@EmailID",obj.Email),
                        new SqlParameter("@AccountStatus",obj.AccountStatus),
                        new SqlParameter("@ValidFrom",obj.ValidFrom),
                        new SqlParameter("@ValidUpto",obj.ValidTo)                      
                };
                DBOperate.ExecuteProcedureWithOutReturn("usp_UpdateUserStatus", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
