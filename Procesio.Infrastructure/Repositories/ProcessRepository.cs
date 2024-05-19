using Procesio.Core.Entities;
using Procesio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Infrastructure.Repositories
{
    public class ProcessRepository : Repository<Process>, IProcessRepository
    {

        public ProcessRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
