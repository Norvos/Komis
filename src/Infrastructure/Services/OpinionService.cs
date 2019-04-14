using Komis.Core.Models;
using Komis.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly IOpinionRepository _opinionRepository;

        public OpinionService(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }

       public async Task AddAsync(Guid id, string email, string username, string message, bool waitingForAnAnswer)
        {
            var opinion = await _opinionRepository.GetAsync(id);
            if (opinion != null)
            {
                throw new Exception($"Opinion with id: '{id}' already exists.");
            }
            opinion = new Opinion(email,username,message,waitingForAnAnswer);
            await _opinionRepository.AddAsync(opinion);
        }

        public async Task AddAsync(Opinion opinion)
        => await _opinionRepository.AddAsync(opinion);

        public async Task DeleteAsync(Guid opinionId)
        {
            await _opinionRepository.DeleteAsync(opinionId);
        }

        public async Task<Opinion> GetAsync(Guid opinionId)
        {
            var opinion = await _opinionRepository.GetAsync(opinionId);
            return opinion;
        }


        public async Task Update(Opinion opinion)
         => await _opinionRepository.Update(opinion);
    } 
}
