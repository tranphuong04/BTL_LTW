using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Danhba
{
    class Information
    {
        private string maDN;
        private string phoneNumber;
        private string name;
        private string represent;
        private string note;

        public Information()
        {
        }

        public Information(string maDN, string name, string phoneNumber, string represent, string note)
        {
            this.maDN = maDN;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.represent = represent;
            this.note = note;

        }

        public string MaDN { get => maDN; set => maDN = value; }
         public string Name { get => name; set => name = value; }       
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Represent { get => represent; set => represent = value; }
        public string Note { get => note; set => note = value; }
    }
}
