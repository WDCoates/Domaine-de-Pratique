using System;
using System.Security.Claims;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web.Security;

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

            var section = 4;
            switch (section)
            {
                case 1:
                    AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                    var principal = WindowsPrincipal.Current as WindowsPrincipal;
                    var identity = principal.Identity as WindowsIdentity;

                    con.WriteLine($"Identity Type: {identity}");
                    con.WriteLine($"Name: {identity.Name}");
                    break;
                case 2:
                    //Declarative Role-Based Security
                    try
                    {
                        ShowMessage();
                    }
                    catch (SecurityException sE)
                    {
                        con.WriteLine($"Exception Message: {sE.Message}");
                    }
                    break;
                case 3:
                    var res = Membership.ValidateUser("Manager", "secret@Pa$$w0rd"); //Could never quite get this to work but the book example works without changing the names of services etc.
                    con.WriteLine(res);
                    break;
                case 4:

                    Encryptions e = new Encryptions();
                    e.CreateKeys();

                    con.WriteLine(e.aSigKey);
                    con.WriteLine(e.aPubKey);

                    break;

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
