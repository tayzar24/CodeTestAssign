using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.Constant
{
    public class CommonConstant
    {
        #region String Format
        public const string API_REQUIRED_MESSAGE = "{0} is required.";
        public const string API_ALREADYEXIST_MESSAGE = "{0} is already exist.";
        #endregion

        #region Error Code  Detail 
        public const string ERROR_CODE_Unauthorized = "1000";
        public const string ERROR_CODE_VALIDATION = "1001";
        public const string ERROR_CODE_DatabaseError = "1012";
        public const string ERROR_CODE_DuplicateRecord = "1013";
        public const string ERROR_CODE_UnknownException = "1014";
        public const string ERROR_CODE_ThirdParty_Error = "1015";
        public const string ERROR_CODE_Timeout = "1016";
        #endregion


        #region Error Code  Detail 
        public const string ERROR_CODE_DETAIL_VALIDATION = "10100001";
        #endregion
    }

}