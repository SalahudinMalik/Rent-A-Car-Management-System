using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF.DataLayer
{
    public class EmployeeDA
    {
        AutoDealershipEntities obj;
        public EmployeeDA()
        {
            obj = new AutoDealershipEntities();
        }
        public bool Insert(Employee_Table eobj)
        {
            obj.Employee_Table.Add(eobj);
            return obj.SaveChanges() > 0;

        }
        public List<EmployeeViewModel> GetAll()
        {
            return (from l in obj.Employee_Table
                    select new ViewModel.EmployeeViewModel
                    {
                        E_ID = l.E_ID,
                        E_Name = l.E_Name,
                        E_Address= l.E_Address,
                        E_Desg = l.E_Desg,
                        E_Phone = l.E_Phone,
                        E_Salary = l.E_Salary
                    }).ToList();
        }
        public Employee_Table GetAllByName(int id)
        {
            return obj.Employee_Table.Where(x=> x.E_ID == id).FirstOrDefault();
        }
        public bool Delete(string Name)
        {
            Employee_Table std = obj.Employee_Table.Where(x => x.E_Name == Name).FirstOrDefault();
            if (std != null)
                obj.Employee_Table.Remove(std);
            return obj.SaveChanges() > 0;
        }
        public bool Update(Employee_Table ETobj)
        {
            Employee_Table std = obj.Employee_Table.Where(x => x.E_ID == ETobj.E_ID).FirstOrDefault();
            if (std != null)
            { 
                std.E_Name = ETobj.E_Name;
                std.E_Desg = ETobj.E_Desg;
                std.E_Address = ETobj.E_Address;
                std.E_Salary = ETobj.E_Salary;
                std.E_Phone = ETobj.E_Phone;
            }
            return obj.SaveChanges() > 0;
        }
    }
}
