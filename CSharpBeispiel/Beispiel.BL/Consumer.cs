using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.BL
{
    public class Consumer
    {
        private string _firstName;
        private string _lastName;
        private string fullName;
        private string _emailAdress;

        private int id;

        private static int instanceCount ;

        public static int InstanceCount { get; set; }


        public int ID
        {
            get { return id; }
            private  set { id = value; }
        }

        public Consumer()
        {

        }

        public Consumer(int id)
        {
            this.id = id;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string EmailAddress
        {
            get { return _emailAdress; }
            set { _emailAdress = value; }
        }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(FirstName)) isValid = false;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;

            return isValid;

        }
    }
}
