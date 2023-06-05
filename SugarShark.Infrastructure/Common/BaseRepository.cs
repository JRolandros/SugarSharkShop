using SugarShark.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.Common
{
    public abstract class BaseRepository
    {
        protected ISugarSharkDbContext _dbContext;

        protected BaseRepository(ISugarSharkDbContext dbContext) {
        _dbContext=dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
