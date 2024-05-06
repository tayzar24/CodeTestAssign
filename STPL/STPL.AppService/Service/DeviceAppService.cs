using STPL.AppService.IService;
using STPL.AppService.Model.Request;
using STPL.AppService.Util;
using STPL.Common.CustomError;
using STPL.Common.Log;
using STPL.Core.IRepository;
using STPL.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.Service
{
    public  class DeviceAppService : IDeviceAppService
    {
        private LogService _logService;
        private IDeviceRepository _deviceRepository;
        private IFirmwareRepository _firmwareRepository;
        private IVersionInfoRepository _versionInfoRepository;
        public DeviceAppService(LogService logService,IDeviceRepository deviceRepository,IFirmwareRepository firmwareRepository,IVersionInfoRepository versionInfoRepository) 
        {
          _deviceRepository = deviceRepository;
            _logService = logService;
            _firmwareRepository = firmwareRepository;
            _versionInfoRepository = versionInfoRepository;
        }

        public async Task<string> PayloadOneService(ReqDevice input)
        {
            try
            {
                ValidationHelper.CheckPayLoadOne(input);

                if( _deviceRepository.Find(w=>w.DeviceID == input.DeviceId).Any())
                {
                    throw new ErrorException(ErrorData.DuplicateRecord, "", (int)HttpStatusCode.BadRequest);
                }

                Device objDevice = new Device()
                {
                    DataType = input.DataType,
                    DeviceID = input.DeviceId,
                    DeviceName = input.DeviceName,
                    DeviceType = input.DeviceType,
                    GroupID = input.GroupId,
                    Timestamp = input.Timestamp,
                    ID = Guid.NewGuid().ToString()
                };
                await _deviceRepository.Add(objDevice);
                Firmware firmware = new Firmware()
                {
                    ActivePowerControl = input.Data.ActivePowerControl,
                    DeviceID = objDevice.ID,
                    ID = Guid.NewGuid().ToString(),
                    FirmwareVersion = input.Data.FirmwareVersion,
                    FullPowerMode = input.Data.FullPowerMode,
                    Humidity = input.Data.Humidity,
                    Temperature = input.Data.Tempeature
                };
                await _firmwareRepository.Add(firmware);
                _deviceRepository.Commit();
                return "Device has been added";
            }
            catch(ErrorException e)
            {
                throw e;
            }
            catch(Exception ex)
            {
                throw new ErrorException(ErrorData.UnknownException,"",(int)HttpStatusCode.BadRequest);
            }
        }
        public async Task<string> PayloadTwoService(ReqVersionInfo input)
        {
            try
            {
                ValidationHelper.CheckPayLoadTwo(input);

                if (_deviceRepository.Find(w => w.DeviceID == input.DeviceId).Any())
                {
                    throw new ErrorException(ErrorData.DuplicateRecord, "", (int)HttpStatusCode.BadRequest);
                }

                Device objDevice = new Device()
                {
                    DataType = input.DataType,
                    DeviceID = input.DeviceId,
                    DeviceName = input.DeviceName,
                    DeviceType = input.DeviceType,
                    GroupID = input.GroupId,
                    Timestamp = input.Timestamp,
                    ID = Guid.NewGuid().ToString()
                };
                await _deviceRepository.Add(objDevice);
                VersionData varsion = new VersionData()
                {
                    DeviceID = input.DeviceId,
                    ID = Guid.NewGuid().ToString(),
                    MessageType = input.Data.MessageType,
                    Occupancy = input.Data.Occupancy,
                    StageChange = input.Data.StageChange,
                    Version = input.Data.Version,
                };

                await _versionInfoRepository.Add(varsion);

                _deviceRepository.Commit();
                return "Device has been added";
            }
            catch (ErrorException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw new ErrorException(ErrorData.UnknownException, "", (int)HttpStatusCode.BadRequest);
            }
        }

    }
}
