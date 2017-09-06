using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CarViewModel : IDataErrorInfo
    {
        public int CA_ID { get; set; }
        private string regNo;
        public string CA_RegNo
        {
            get { return regNo; }
            set { regNo = value; }
        }
        private string color;
        public string CA_Color
        {
            get { return color; }
            set { color = value; }
        }
        private int Model;
        public int CA_Model
        {
            get { return Model; }
            set { Model = value; }
        }
        private string Company;
        public string CA_Company
        {
            get { return Company; }
            set { Company = value; }
        }
        public bool CA_Status { get; set; }

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

                if (propName == "CA_RegNo")
                {
                    if (string.IsNullOrEmpty(this.regNo))
                    {
                        result = "Reg No is required";
                    }
                }
                else if (propName == "CA_Color")
                {
                    if (string.IsNullOrEmpty(this.color))
                    {
                        result = "Color is required";
                    }
                }
                else if (propName == "CA_Model")
                {
                    if (string.IsNullOrEmpty(this.Model.ToString()))
                    {
                        result = "Model is required";
                    }
                }
                else if (propName == "CA_Company")
                {
                    if (string.IsNullOrEmpty(this.Company))
                    {
                        result = "Company is required";
                    }
                }


                return result;
            }
        }
    }
}
