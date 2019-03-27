using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Opinion;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komis.Controllers
{
    public class OpinionController : ApiControllerBase
    {
        private readonly IOpinionRepository _opinionRepository;

        public OpinionController(IOpinionRepository opinionRepository, ICommandDispatcher commandDispatcher)
           :base(commandDispatcher)
        {
            _opinionRepository = opinionRepository;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Opinion opinion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(opinion);
        //    }

        //    await _opinionRepository.AddAsync(opinion);
        //    return RedirectToAction("OpiniaWyslana");
        //}

        [HttpPost]
        public async Task<IActionResult> Index(AddOpinion command)
        {
            await DispatchAsync(command);
            return RedirectToAction("OpiniaWyslana");
        }

        public IActionResult OpiniaWyslana()
        {
            return View();
        }

    }
}