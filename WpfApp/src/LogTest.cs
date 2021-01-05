using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.src
{
    public class LogTest
    {
        public bool Login(string log, string pas)
        {
            string userRight = "user";
            string pswRight = "12345";

            return (0 == String.Compare(log, userRight) && 0 == String.Compare(pas, pswRight)); 
        }
    }
}
