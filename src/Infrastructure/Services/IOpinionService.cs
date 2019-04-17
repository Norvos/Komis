using Komis.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface IOpinionService : IService
    {
        Task<Opinion> GetAsync(Guid opinionId);
        Task AddAsync(Guid id, string email, string username, string message, bool waitingForAnAnswer, string topic);
        Task AddAsync(Opinion opinion);
        Task DeleteAsync(Guid id);
        Task Update(Opinion opinion);
        Task<IEnumerable<Opinion>> GetAllRequiredAsync();
        Task<int> GetNumberOfRequiredAsync();
    }
}
