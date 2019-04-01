using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.Commands;
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

        [HttpPost]
        public async Task<IActionResult> Index(Opinion command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await DispatchAsync(command);

            return RedirectToAction("SendSuccessful");
        }

        public IActionResult SendSuccessful()
        {
            return View();
        }

    }
}