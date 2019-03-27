using Komis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface IOpinionService : IService
    {
        Task<Opinion> GetAsync(Guid opinionId);
        //Task<IEnumerable<Opinion>> BrowseAsync();
        Task AddAsync(Guid id, string email, string username, string message, bool waitingForAnAnswer);
        Task DeleteAsync(Guid id);
    }
}
