using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.Errors
{
    public class DomainErrors
    {
      

        public static class FirstName {
         public static string TooLong = "First Name is too Long";
      }
        public static class LastName
        {
            public static string TooLong = "Last Name is too Long";
        }
        public static class Password
        {
            public static string TooLong = "Password is too Long";
        }
        public static class Email
        {
            public static string TooLong = "Email is too Long";
        }
    }
}
