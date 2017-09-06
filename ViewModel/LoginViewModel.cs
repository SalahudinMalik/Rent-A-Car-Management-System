using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ViewModel
{
    public class LoginViewModel : IDataErrorInfo
    {
        public int A_ID { get; set; }
        public string A_UserName { get; set; }
        public string A_Password { get; set; }
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

                if (propName == "A_UserName")
                {
                    if (string.IsNullOrEmpty(this.A_UserName))
                    {
                        result = "User Name is required";
                    }

                }
                else if (propName == "A_Password")
                {
                    if (string.IsNullOrEmpty(this.A_Password))
                    {
                        result = "Password is required";
                    }
                    
                }
                return result;
            }
        }
    }
}
