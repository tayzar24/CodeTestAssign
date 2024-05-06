﻿using STPL.Core.IRepository;
using STPL.Entity.Model;
using STPL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Core.Repository
{
    public class VersionRepository : GenericRepository<VersionData>, IVersionInfoRepository
    {
        private readonly STPLContext _dbContext;
        public VersionRepository(STPLContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
