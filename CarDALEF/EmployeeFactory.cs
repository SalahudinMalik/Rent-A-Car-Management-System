using CarDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
//using ViewModel;
namespace CarDALEF
{
    public class EmployeeFactory
    {
        EmployeeDA obj;
        public EmployeeFactory()
        {
            obj = new EmployeeDA();
        }
        public bool insert(Employee_Table eobj)
        {
            return obj.Insert(eobj);
        }

        public List<EmployeeViewModel> GetAll()
        {
            return obj.GetAll();
        }
        public Employee_Table GetAllByName(int id)
        {
           return obj.GetAllByName(id);
        }
        public bool Delete(string Name)
        {
            return obj.Delete(Name);
        }
        public bool Update(Employee_Table ETobj)
        {
            return obj.Update(ETobj);
        }
    }
}
