using STPL.Core.IRepository;
using STPL.Entity;
using STPL.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Core.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly STPLContext _dbContext;
        public DeviceRepository(STPLContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
