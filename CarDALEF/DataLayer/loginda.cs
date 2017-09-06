using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDALEF.DataLayer
{
    public class LoginDA
    {
        AutoDealershipEntities obj;
        public LoginDA()
        {
            obj = new AutoDealershipEntities();

        }
        public Admin_Table GetData (int id)
        {
            return obj.Admin_Table.Where(x=> x.A_ID==id).FirstOrDefault();

        }
       
    }
}
