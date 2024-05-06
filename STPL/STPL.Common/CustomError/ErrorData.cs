using STPL.Common.Constant;
using STPL.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.CustomError
{
    public class ErrorData
    {
        public static ErrorInfo ValidationError { get { return new ErrorInfo { Code = "1001", Message = "Validation error" }; } }
        public static ErrorInfo DatabaseError { get { return new ErrorInfo { Code = "1002", Message = "Database Error." }; } }
        public static ErrorInfo NoRowsAffected { get { return new ErrorInfo { Code = "1003", Message = "No Rows Affected." }; } }
        public static ErrorInfo NoRecordFound { get { return new ErrorInfo { Code = "1004", Message = "No Record Found!" }; } }
        public static ErrorInfo DuplicateRecord { get { return new ErrorInfo { Code = "1005", Message = "Duplicate Record!" }; } }
        public static ErrorInfo UnknownException { get { return new ErrorInfo { Code = "1006", Message = "Indicate unknown exception." }; } }
        public static Details ValidationError_Detail { get { return new Details { ErrorCode = CommonConstant.ERROR_CODE_DETAIL_VALIDATION, ErrorDescription = "{0}" }; } }
        public static Details Data_Not_Found { get { return new Details { ErrorCode = "103000009", ErrorDescription = "Data Not found." }; } }
    }
}
