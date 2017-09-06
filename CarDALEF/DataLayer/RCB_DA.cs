using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF.DataLayer
{
    public class RCB_DA
    {
        Customer_Table cobj;
        RCB_Table robj;
        AutoDealershipEntities obj;
        public RCB_DA()
        {
            cobj = new Customer_Table();
            robj = new RCB_Table();
            obj = new AutoDealershipEntities();
            
        }
        public bool insertC(Customer_Table cArg )
        {
            obj.Customer_Table.Add(cArg);
            return obj.SaveChanges()> 0;
        }
        public bool insertR(RCB_Table robj)
        {
            obj.RCB_Table.Add(robj);
            return obj.SaveChanges() > 0;
        }
        public List<Tax_Table> GetTax()
        {
            return obj.Tax_Table.ToList();
        }
        public object GetTP(int id)
        {
            return obj.Tax_Table.Where(x => x.T_ID == id);
        }
        public List<RCBViewModel> GetAll()
        {

            return (from c in obj.RCB_Table 
                    join s in obj.Customer_Table on c.C_ID equals s.C_ID
                    join a in obj.Tax_Table on c.T_ID equals a.T_ID
                    join ca in obj.Car_Table on c.CA_ID equals ca.CA_ID
                    select new RCBViewModel
                    {
                       CA_ID = ca.CA_ID,
                       CA_RegNo = ca.CA_RegNo,
                       C_Name = s.C_Name,
                       C_Phone = s.C_Phone,
                       C_Address = s.C_Address,
                       T_Per = a.T_Per,
                       RCB_DOI = c.RCB_DOI,
                       RCB_DOR = c.RCB_DOR,
                       RCB_RentPD = c.RCB_RentPD,
                       RCB_TotalBill = c.RCB_TotalBill
                    }).ToList();
        }
        
    }
}
