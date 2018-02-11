using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModProductType
{
    public class ProductTypeMasterDataManager
    {
        public DataTable GetProductTypeList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllProductType");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetProductTypeListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@ProductTypeID",ID)
                };
                return DBOperate.GetDataTable("usp_GetProductTypeById", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
