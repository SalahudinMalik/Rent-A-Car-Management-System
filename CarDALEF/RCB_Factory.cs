using CarDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF
{
    public class RCB_Factory
    {
        RCB_DA obj;
        public RCB_Factory()
        {
            obj = new RCB_DA();
        }
        public bool insertC(Customer_Table cobj )
        {
            return obj.insertC(cobj);
        }
        public bool insertR( RCB_Table robj)
        {
            return obj.insertR(robj);
        }
        public List<Tax_Table> GetTax()
        {
            return obj.GetTax();
        }
        public object GetTP(int id)
        {
            return obj.GetTP(id);
        }
        public List<RCBViewModel> GetAll()
        {
            return obj.GetAll();
        }
    }
}
