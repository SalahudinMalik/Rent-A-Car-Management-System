using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class EmployeeViewModel : IDataErrorInfo
    {
        public int E_ID { get; set; }
        private string Name;
        public string E_Name
        {
           get { return Name; }
           set { Name = value; }
        }
        public string E_Address { get; set; }
        public string E_Desg { get; set; }
        public int E_Phone { get; set; }
        public decimal E_Salary { get; set; }
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

                if (propName == "E_Name")
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        result = "Name is required";
                    }
                }
                else if (propName == "E_Address")
                {
                    if (string.IsNullOrEmpty(this.E_Address))
                    {
                        result = "Address is required";
                    }
                    else if((this.E_Address.Length) <= 6)
                    {
                        result = "Address charater length is too short is must be greater then 6.";
                    }
                }
                else if (propName == "E_Desg")
                {
                    if (string.IsNullOrEmpty(this.E_Desg))
                    {
                        result = "Designation is required";
                    }
                }
                else if (propName == "E_Phone")
                {
                    if (string.IsNullOrEmpty(this.E_Phone.ToString()))
                    {
                        result = "Phone Number is required";
                    }
                  

                }
                else if (propName == "E_Salary")
                {
                    if (string.IsNullOrEmpty(this.E_Salary.ToString()))
                    {
                        result = "Salary is required";
                    }

                }


                return result;
            }

        }
    }
}
