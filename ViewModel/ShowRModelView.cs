using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ShowRModelView : IDataErrorInfo
    {
        public int S_ID { get; set; }
        public string ShowRName { get; set; }
        public int SRContectNumber { get; set; }
        public string CityName { get; set; }
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string propName]
        {
            get
            {
                string result = null;

                if (propName == "ShowRName")
                {
                    if (string.IsNullOrEmpty(this.ShowRName))
                    {
                        result = "Showroom Name is required";
                    }

                }
                else if (propName == "SRContectNumber")
                {
                    if (string.IsNullOrEmpty(this.SRContectNumber.ToString()))
                    {
                        result = "Contect Number is required";
                    }
                    else if(SRContectNumber==0)
                    {
                        result = "Contect Number is required";
                    }

                }
                else if (propName == "CityName")
                {
                    if (string.IsNullOrEmpty(this.CityName))
                    {
                        result = "City is required";
                    }

                }
                return result;
            }
        }
    }
}
