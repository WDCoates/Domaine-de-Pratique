using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

[assembly: SecurityRules(SecurityRuleSet.Level2)]
[assembly: SecurityTransparent()]
[assembly: AllowPartiallyTrustedCallers()]
namespace ConsoleA1._22_Security
{
    
    public class Transparency_Level_2
    {
        
        public Transparency_Level_2()
        {
        }

        [SecuritySafeCritical()]
        public bool AskPermissions(string path)
        {
            var res = false;

            try
            {
                var fileIOPermission = new FileIOPermission(PermissionState.Unrestricted);
                fileIOPermission.Demand();

            }
            catch (Exception)
            {

                throw;
            }
            return true;

        }
    }

    [SecuritySafeCritical]
    public class RequirePermission : MarshalByRefObject
    {
        public bool RequiredFilePermission(string path)
        {
            bool accGranted = true;

            try
            {
                StreamWriter sWriter = File.CreateText(path);
                sWriter.WriteLine("Write successfully wow!");
                sWriter.Close();
            }
            catch (SecurityException)
            {
                accGranted = false;
            }

            return accGranted;
        }
    }


}
