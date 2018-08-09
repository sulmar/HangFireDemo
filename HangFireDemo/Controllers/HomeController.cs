using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HangFireDemo.Models;
using Hangfire;
using System.Threading;
using HangFireDemo.Services;

namespace HangFireDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBackgroundJobClient backgroundJob;
        private readonly IMessagesService messagesService;

        public HomeController(IBackgroundJobClient backgroundJob, IMessagesService messagesService)
        {
            this.backgroundJob = backgroundJob;
            this.messagesService = messagesService;
        }

        public IActionResult Index()
        {
            // backgroundJob.Enqueue(() => Debug.WriteLine("Background Job completed successfully!"));

            messagesService.Add(new Message { Content = "Hey" });

            backgroundJob.Enqueue(() => LongProcess());

            backgroundJob.Enqueue<ISendRequest>(x => x.SendSms("Hello HangFire!"));

            return View();
        }

        public void LongProcess()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));

            // throw new ApplicationException("My exception");

            Debug.WriteLine("Background LongProcess completed successfully!");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
