using STPL.Common.Constant;
using STPL.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.CustomError
{
    public class ErrorException : Exception
    {
        public ErrorInfo ErrorInfo { get; }
        public int StatusCode { get; }


        public ErrorException(ErrorInfo errorCode, string message, int statusCode) : base(message)
        {
            ErrorInfo = GenerateMessage(errorCode, message, null, null);
            StatusCode = statusCode;
        }

        public ErrorException(ErrorInfo errorCode, string message, int statusCode, List<Details> detailList) : base(message)
        {
            ErrorInfo = GenerateMessage(errorCode, message, detailList, null);
            StatusCode = statusCode;
        }

        public ErrorException(ErrorInfo errorCode, string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            ErrorInfo = GenerateMessage(errorCode, message, null, innerException);
            StatusCode = statusCode;
        }

        private static ErrorInfo GenerateMessage(ErrorInfo errorInfo, string message, List<Details> errorList, Exception? ex)
        {
            ErrorInfo error = new ErrorInfo();
            error = errorInfo;

            if (error.Details == null)
            {
                if (errorList != null && errorList.Count > 0)
                {
                    error.Details = errorList;
                }
                else
                {
                    error.Details = new List<Details>();

                    Details detail = new Details();
                    detail.ErrorCode = "";
                    if (errorInfo.Code == CommonConstant.ERROR_CODE_VALIDATION)
                    {
                        detail.ErrorCode = CommonConstant.ERROR_CODE_DETAIL_VALIDATION;
                    }

                    if (ex != null)
                        detail.ErrorDescription = ex.Message;

                    else
                        detail.ErrorDescription = message;

                    error.Details.Add(detail);
                }


            }

            return errorInfo;
        }
    }
}
