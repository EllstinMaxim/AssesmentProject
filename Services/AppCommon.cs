using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesmentProject.Services
{
    class AppCommon
    {
        public static DateTime MinDateValue = new DateTime(0001, 1, 1);
        public static decimal MinDecimalValue = 0;

        public static string StringNullCheck(object as_value, string as_default)
        {
            string ls_rtn_value = as_default;
            if (!DBNull.Value.Equals(as_value))
            {
                if (as_value != null)
                {
                    ls_rtn_value = as_value.ToString();
                }
            }
            return ls_rtn_value;
        }
        public static int IntNullCheck(object as_value, int as_default)
        {
            int ls_rtn_value = as_default;
            if (as_value == null)
            {
                return ls_rtn_value;
            }
            if (!DBNull.Value.Equals(as_value) && as_value.ToString().Trim().Length > 0)
            {
                ls_rtn_value = Convert.ToInt32(as_value);
            }

            return ls_rtn_value;
        }
        
    }
}
