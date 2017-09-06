using CarDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace CarDALEF
{
    public class ShowRFactory
    {
        ShowRDA obj; 
        public ShowRFactory()
        {
            obj = new ShowRDA();

        }
        public bool insert(City Cobj , ShowRoom SRobj)
        {
            return obj.insert(Cobj, SRobj);
        }
        public bool DeleteS(int id)
        {
            return obj.DeleteS(id);
        }
        public bool DeleteC(int id)
        {
            return obj.DeleteC(id);
        } 
        public List<ShowRModelView> GetAll()
        {
            return obj.GetAll();
        }
    }
}
