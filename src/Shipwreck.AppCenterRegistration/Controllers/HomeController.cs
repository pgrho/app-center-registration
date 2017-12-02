﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shipwreck.AppCenterRegistration.Models;

namespace Shipwreck.AppCenterRegistration.Controllers
{
    public class HomeController : Controller
    {
        private SiteConfiguration _Configuration;

        public HomeController(IOptions<SiteConfiguration> configuration, IConfiguration root)
        {
            _Configuration = configuration.Value;

            _Configuration.OwnerName = _Configuration.OwnerName ?? Environment.GetEnvironmentVariable("OWNER_NAME");
            _Configuration.OwnerDisplayName = _Configuration.OwnerDisplayName ?? Environment.GetEnvironmentVariable("OWNER_DISPLAY_NAME");

            _Configuration.AppName = _Configuration.AppName ?? Environment.GetEnvironmentVariable("APP_NAME");
            _Configuration.AppDisplayName = _Configuration.AppDisplayName ?? Environment.GetEnvironmentVariable("APP_DISPLAY_NAME");

            _Configuration.ApiToken = _Configuration.ApiToken ?? Environment.GetEnvironmentVariable("API_TOKEN");
        }

        [HttpGet]
        public IActionResult Index()
            => View(new IndexViewModel()
            {
                Configuration = _Configuration
            });

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            bool? r = null;
            if (ModelState.IsValid)
            {
                try
                {
                    using (var hc = new HttpClient())
                    {
                        var req = new HttpRequestMessage(HttpMethod.Post, $"https://api.appcenter.ms/v0.1/apps/{_Configuration.OwnerName}/{_Configuration.AppName}/invitations");
                        req.Headers.Add("X-API-Token", _Configuration.ApiToken);

                        req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            user_email = model.MailAddress
                        }), Encoding.UTF8, "application/json");

                        var res = await hc.SendAsync(req).ConfigureAwait(false);

                        r = res.IsSuccessStatusCode;
                    }
                }
                catch
                {
                    r = false;
                }
            }
            else
            {
                r = false;
            }

            return View(new IndexViewModel()
            {
                Result = r,
                Configuration = _Configuration
            });
        }

        public IActionResult Error()
            => View(new ErrorViewModel
            {
                Configuration = _Configuration,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}