using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._12_Dynamic_Language_Extensions
{
    class DynamicObj : DynamicObject
    {
        Dictionary<string, object> _dynamicDic = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder memBinder, out object result)
        {
            bool success = false;
            result = null;

            if (_dynamicDic.ContainsKey(memBinder.Name))
            {
                result = _dynamicDic[memBinder.Name];
                success = true;
            }
            else
            {
                result = "Property Not Found!";
            }

            return success;
        }

        public override bool TrySetMember(SetMemberBinder memBinder, object value)
        {
            _dynamicDic[memBinder.Name] = value;
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder memberBinder, object[] args, out object result)
        {
            dynamic method = _dynamicDic[memberBinder.Name];
            result = method((DateTime) args[0]);
            return result != null;
        }
    }
}
