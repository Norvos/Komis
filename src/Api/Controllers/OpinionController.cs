using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Opinion;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Komis.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class OpinionController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOpinionService _opinionService;

        public OpinionController(IUserService userService, ICommandDispatcher commandDispatcher,IEmailSender emailSender, ICarService carService, IOpinionService opinionService)
           : base(commandDispatcher, emailSender, carService)
        {
            _userService = userService;
            _opinionService = opinionService;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData.Add("Email", await GetEmailAddress());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddOpinion command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await DispatchAsync(command);

            return RedirectToAction("SendSuccessful");
        }

        public async Task<IActionResult> SendSuccessful()
        {
            await _emailSender.SendEmail(await GetEmailAddress(), $"{User.Identity.Name} dziękujemy za opinię",Messages.Opinion);
            return View();
        }

        private async Task<string> GetEmailAddress()
        {
            var username = User.Identity.Name;

            if (!string.IsNullOrEmpty(username))
            {
                var user = await _userService.GetAsync(username);
  
                return user.Email;
            }
            return string.Empty;
        }

        public async Task<IActionResult> Answear(Guid id)
        {
            var opinion = await _opinionService.GetAsync(id);

            if (opinion == null) return NotFound();

            var answear = new FeedbackViewModel()
            {
                Email = opinion.Email,
                Username = opinion.Username,
                Message=opinion.Message,
                OpinionID = opinion.ID,
                Topic=opinion.Topic
            };
          
            return View(answear);
        }

        [HttpPost]
        public async Task<IActionResult> Answear(FeedbackViewModel answear)
        {
            if (!ModelState.IsValid)
            {
                return View(answear);
            }

            var opinion = await _opinionService.GetAsync(answear.OpinionID);

            if (opinion.WaitingForAnAnswer)
            {
                opinion.WaitingForAnAnswer = false;
                await _opinionService.Update(opinion);
            }
          
            await _emailSender.SendEmail(answear.Email, "Serwis Komis przesyła odpowiedź", answear.Feedback);

            return RedirectToAction("Index", "Home");
        }
       
        public async Task<IActionResult> List()
        {
            var opinions = await _opinionService.GetAllRequiredAsync();

            return View(opinions);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
           
            await _opinionService.DeleteAsync(id);

            return RedirectToAction("List", "Opinion");
        }
    }
}