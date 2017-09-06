using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF.DataLayer
{
    
    public class ShowRDA
    {
        AutoDealershipEntities obj;
        public ShowRDA()
        {
            obj = new AutoDealershipEntities();
        }
        public bool insert(City Cobj , ShowRoom SRobj)
        {
            obj.Cities.Add(Cobj);
            obj.SaveChanges();
            SRobj.City_ID = Cobj.Ci_ID;
            obj.ShowRooms.Add(SRobj);
            return obj.SaveChanges() > 0;
        }
        public List<ShowRModelView> GetAll()
        {

            return (from c in obj.Cities
                    join s in obj.ShowRooms on c.Ci_ID equals s.City_ID
                    select new ShowRModelView { 
                    S_ID=s.S_ID,
                    CityName = c.CityName,
                    ShowRName = s.ShowRName,
                    SRContectNumber = s.SRContectNumber
                    }).ToList();
        }
        
        public bool DeleteS(int id)
        {
            ShowRoom sr = obj.ShowRooms.Where(x => x.S_ID == id).FirstOrDefault();
            if (sr != null)
            {
                obj.ShowRooms.Remove(sr);
                return obj.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool DeleteC(int id)
        {
            City c = obj.Cities.Where(x => x.Ci_ID == id).FirstOrDefault();
            if ( c != null)
            {
                obj.Cities.Remove(c);
                return obj.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
