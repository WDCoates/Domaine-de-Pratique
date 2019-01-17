using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Security.Prov
{
    public class Roles: RoleProvider
    {
        internal static string ManagerRoleName = "Manager".ToLowerInvariant();
        internal static string EmployeeRoleName = "Employee".ToLowerInvariant();

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = GetRolesForUser(username);
            foreach (var role in roles)
            {
                if (string.Equals(role, roleName))
                {
                    return true;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.Compare(username, Membership.ManagerUserName, true) == 0)
            {
                return new string[] {ManagerRoleName};
            } 
            else if(string.Compare(username, Membership.EmployeeUserName, true) == 0)
            {
                return new string[] {EmployeeRoleName};
            }
            else
            {
                return new string[0];
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
