using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.Domain.Interfaces
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetByName(string name);
    }
}
