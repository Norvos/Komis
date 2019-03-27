using Komis.Core.Models;
using System;
using System.Threading.Tasks;

namespace Komis.Core.Repositories
{
    public interface IOpinionRepository : IRepository
    {
        Task<Opinion> GetOrFailAsync(Guid id);
        //Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(Opinion opinion);
        Task UpdateAsync(Opinion opinion);
        Task DeleteAsync(Guid id);
    }
}
