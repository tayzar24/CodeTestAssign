using STPL.AppService.Model.Request;
using STPL.Common.Constant;
using STPL.Common.CustomError;
using STPL.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.Util
{
    public class ValidationHelper
    {
        public static void CheckPayLoadOne(ReqDevice input)
        {
            
            if (input == null)
            {
                throw new ErrorException(ErrorData.ValidationError, string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice)), (int)HttpStatusCode.BadRequest);
            }
            else
            {
                string errorMessage = string.Empty;
                if (string.IsNullOrEmpty(input.DeviceId))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceId));
                }
                if (string.IsNullOrEmpty(input.DeviceName))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceName));
                }

                if(string.IsNullOrEmpty(input.DeviceType))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceType));
                }
                if (string.IsNullOrEmpty(input.GroupId))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.GroupId));
                }
                if (string.IsNullOrEmpty(input.DataType))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DataType));
                }
                
                if(input.Data == null)
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.Data));
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new ErrorException(ErrorData.ValidationError,errorMessage,(int)HttpStatusCode.BadRequest);
                }
            }
        }

        public static void CheckPayLoadTwo(ReqVersionInfo input)
        {

            if (input == null)
            {
                throw new ErrorException(ErrorData.ValidationError, string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice)), (int)HttpStatusCode.BadRequest);
            }
            else
            {
                string errorMessage = string.Empty;
                if (string.IsNullOrEmpty(input.DeviceId))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceId));
                }
                if (string.IsNullOrEmpty(input.DeviceName))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceName));
                }

                if (string.IsNullOrEmpty(input.DeviceType))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DeviceType));
                }
                if (string.IsNullOrEmpty(input.GroupId))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.GroupId));
                }
                if (string.IsNullOrEmpty(input.DataType))
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.DataType));
                }

                if (input.Data == null)
                {
                    errorMessage += string.Format(CommonConstant.API_REQUIRED_MESSAGE, nameof(ReqDevice.Data));
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new ErrorException(ErrorData.ValidationError, errorMessage, (int)HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
