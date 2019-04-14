using Komis.Core.Models;
using System;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface IOpinionService : IService
    {
        Task<Opinion> GetAsync(Guid opinionId);
        Task AddAsync(Guid id, string email, string username, string message, bool waitingForAnAnswer);
        Task AddAsync(Opinion opinion);
        Task DeleteAsync(Guid id);
        Task Update(Opinion opinion);
    }
}
