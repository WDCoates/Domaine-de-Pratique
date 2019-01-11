using System;
using System.Security.Claims;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;

using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

using con = System.Console;

namespace ConsoleA1._22_Security
{
    public class _Main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"This is all about Security!");

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var principal = WindowsPrincipal.Current as WindowsPrincipal;
            var identity = principal.Identity as WindowsIdentity;

            con.WriteLine($"Identity Type: {identity}");
            con.WriteLine($"Name: {identity.Name}");

            //Declarative Role-Based Security
            try
            {
                ShowMessage();
            }
            catch (SecurityException sE)
            {
                con.WriteLine($"Exception Message: {sE.Message}");
            }


            Console.Write($"Thank you.");
            Console.ReadLine();
        }
        
        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Devs")]
        static void ShowMessage()
        {
            con.WriteLine($"Current principal is logged in locally");
            con.WriteLine($"(Member of local User Group)");
        }
    }
}
