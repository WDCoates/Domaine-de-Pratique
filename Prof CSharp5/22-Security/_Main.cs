using System;
using System.IO;
using System.Security.Claims;
using System.Security;
using System.Security.AccessControl;
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

            var section = 5;
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

                    var aData = Encoding.UTF8.GetBytes("Alice's Boots are long.");
                    byte[] aSig = e.CreateSignature(aData, e.aSigKey);

                    con.WriteLine($"A Created Sig: {Convert.ToBase64String(aSig)}");

                    var r = e.VerifySignature(aData, aSig, e.aPubKey);
                    var r2 = e.VerifySignature(aData, aSig, aSig);

                    //Now for key exchange and secure transfer.
                    e.Start();
                    break;
                case 5:
                    //Access to file system objects
                    string fName = "C:\\Windows\\win.ini";

                    using (FileStream fStream = File.Open(fName, FileMode.Open))
                    {
                        FileSecurity secDes = fStream.GetAccessControl();
                        AuthorizationRuleCollection aRC = secDes.GetAccessRules(true, true, typeof(NTAccount));

                        foreach (AuthorizationRule rule in aRC)
                        {
                            var fRule = rule as FileSystemAccessRule;

                        }
                    }

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
