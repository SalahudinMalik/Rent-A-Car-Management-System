using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RCBViewModel : IDataErrorInfo
    {
        public RCBViewModel()
        {

        }
        public int RCB_ID { get; set; }

        private DateTime issue;
        private DateTime retun;
        public System.DateTime RCB_DOI {
            get { return issue; }
            set { issue = value; }
        }
        public System.DateTime RCB_DOR {
            get { return  retun; }
            set { retun = value; }
        }
        private int tid;
        public int T_ID {
            get { return  tid; }
            set { tid = value; }
        }
        public decimal RCB_RentPD { get; set; }
        public decimal RCB_TotalBill { get; set; }
        public int C_ID { get; set; }
        private Int32 ca_ID;
        public Int32 CA_ID { get { return ca_ID; } set { ca_ID = value; } }
        public string CA_RegNo { get; set; }
        
        // public int C_ID { get; set; }
        public string C_Name { get; set; }
        public string C_Address { get; set; }
        public string C_Phone { get; set; }
        // public int T_ID { get; set; }
        public int T_Per { get; set; }
        public string T_Desc { get; set; }
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

                if (propName == "C_Name")
                {
                    if (string.IsNullOrEmpty(this.C_Name))
                    {
                        result = "Name is required";
                    }
                }
                else if (propName == "CA_ID")
                {
                    if (this.CA_ID < 0)
                    {
                        result = "You haven't selected car";
                    }
                }
                else if (propName == "C_Address")
                {
                    if (string.IsNullOrEmpty(this.C_Address))
                    {
                        result = "Address is required";
                    }
                    else if ((this.C_Address.Length) <= 6)
                    {
                        result = "Address charater length is too short is must be greater then 6.";
                    }
                }
                else if (propName == "CA_RegNo")
                {
                    if (string.IsNullOrEmpty(this.CA_RegNo))
                    {
                        result = "Registration Number is required";
                    }
                    
                }
                else if (propName == "T_ID")
                {
                    if (tid<=0)
                    {
                        result = "Tax is required";
                    }

                }

                else if (propName == "RCB_RentPD")
                {
                    if(string.IsNullOrEmpty(this.RCB_RentPD.ToString()))
                    {
                        result = "Rent Per Day field is required.";
                    }
                }
                else if (propName == "RCB_TotalBill")
                {
                    if (string.IsNullOrEmpty(this.RCB_TotalBill.ToString()))
                    {
                        result = "Total Bill field is required.";
                    }
                }
                else if (propName == "C_Phone")
                {
                    if (string.IsNullOrEmpty(this.C_Phone))
                    {
                        result = "Phone Number is required";
                    }
                }
               
                else if (propName== "RCB_DOI")
                {
                    if(this.issue==null)
                    {
                        result = "Date of Issue is reqiured.";
                    }
                    else if (this.issue.Date < DateTime.Today.Date)
                    {
                        result = "Date of Issue is less then your device date. It must be greater then device date.";
                    }
                }              
                else if (propName == "RCB_DOR" )
                {
                    if (this.RCB_DOR==null)
                    {
                        result = "Date of Return is reqiured.";
                    }
                    else if (this.RCB_DOI.Date >= this.RCB_DOR.Date)
                    {
                        result = "Date of return is must be greater then date of issue.";
                    }
                }
                

                return result;
            }
        }
    }
}
