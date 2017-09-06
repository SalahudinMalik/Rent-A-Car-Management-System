using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF.DataLayer
{
    public class CarDA
    {
        AutoDealershipEntities obj;
        public CarDA()
        {
            obj = new AutoDealershipEntities();
        }

        public bool Insert(Car_Table cobj)
        {
            obj.Car_Table.Add(cobj);
            return obj.SaveChanges() > 0;

        }
        public List<CarViewModel> GetAll()
        {
                //return obj.Car_Table.Where(x=>  x.CA_Status==true).ToList();
            
            return (from l in obj.Car_Table
                    where (l.CA_Status ==true )
                    select new ViewModel.CarViewModel 
                    {
                        CA_ID = l.CA_ID,
                       CA_RegNo = l.CA_RegNo,
                       CA_Color = l.CA_Color,
                       CA_Company = l.CA_Company, 
                       CA_Model = l.CA_Model,
                       CA_Status = l.CA_Status
                    }).ToList();
        }
        public List<CarViewModel> GetAllCar()
        {
            //return obj.Car_Table.Where(x=>  x.CA_Status==true).ToList();

            return (from l in obj.Car_Table
                    select new ViewModel.CarViewModel
                    {
                        CA_ID = l.CA_ID,
                        CA_RegNo = l.CA_RegNo,
                        CA_Color = l.CA_Color,
                        CA_Company = l.CA_Company,
                        CA_Model = l.CA_Model,
                        CA_Status = l.CA_Status
                    }).ToList();
        }
        public List<CarViewModel> GetAllCarSF()
        {
            //return obj.Car_Table.Where(x=>  x.CA_Status==true).ToList();

            return (from l in obj.Car_Table
                    where(l.CA_Status == false)
                    select new ViewModel.CarViewModel
                    {
                        CA_ID = l.CA_ID,
                        CA_RegNo = l.CA_RegNo,
                        CA_Color = l.CA_Color,
                        CA_Company = l.CA_Company,
                        CA_Model = l.CA_Model,
                        CA_Status = l.CA_Status
                    }).ToList();
        }
        public Car_Table GetAllCarT(int id)
        {
            return obj.Car_Table.Where(x => x.CA_ID == id).FirstOrDefault();
        }
        public bool Delete(string Regno)
        {
            Car_Table std = obj.Car_Table.Where(x => x.CA_RegNo == Regno).FirstOrDefault();
            if (std != null)
                obj.Car_Table.Remove(std);
            return obj.SaveChanges() > 0;
        }
        public bool ChangeStatus(int id, bool status)
        {
            Car_Table std = obj.Car_Table.Where(x => x.CA_ID == id).FirstOrDefault();
            if (std != null)
                std.CA_Status = status;
            return obj.SaveChanges() > 0;
        }
        public bool Update(Car_Table CTobj)
        {
            Car_Table std = obj.Car_Table.Where(x => x.CA_ID == CTobj.CA_ID).FirstOrDefault();
            if (std != null)
            {
                std.CA_ID = CTobj.CA_ID;
                std.CA_Model = CTobj.CA_Model;
                std.CA_RegNo = CTobj.CA_RegNo;
                std.CA_Company = CTobj.CA_Company;
                std.CA_Color = CTobj.CA_Color;
            }
            return obj.SaveChanges() > 0;
        }
    }
}
