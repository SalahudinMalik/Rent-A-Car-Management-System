using CarDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF
{
     public class CarFactory
    {
         CarDA obj;
         public CarFactory()
         {
             obj = new CarDA();
         }

         public bool insert (Car_Table cobj)
         {
             return obj.Insert(cobj);
         }
         public List<CarViewModel> GetAll()
         {
             
             return obj.GetAll();
         }
         public bool Delete(string regno)
         {
             return obj.Delete(regno);
         }
        public bool ChangeStatus(int id , bool status)
         {
             return obj.ChangeStatus(id, status);
         }
         public List<CarViewModel> GetAllCar()
        {
            return obj.GetAllCar();
        }
         public List<CarViewModel> GetAllCarSF()
         {
             return obj.GetAllCarSF();
         }
         public Car_Table GetAllCarT(int id)
        {
            return obj.GetAllCarT(id);
        }
         public bool Update(Car_Table CTobj)
         {
             return obj.Update(CTobj);
         }
    }
}
