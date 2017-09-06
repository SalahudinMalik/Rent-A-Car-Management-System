using CarDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDALEF
{
    public class LoginFactory
    {
        LoginDA obj;
        public LoginFactory()
        {
            obj = new LoginDA();
        }
        public Admin_Table GetData (int id)
        {
            return obj.GetData(id);
        }
    }
}
