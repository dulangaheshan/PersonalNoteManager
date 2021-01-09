using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging;

namespace CordFortPersonalNoteManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalNoteManagerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PersonalNoteManagerController> _logger;

        public PersonalNoteManagerController(ILogger<PersonalNoteManagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult Get()
        {
            String logourl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/1200px-.NET_Core_Logo.svg.png";
            String heartUrl = "https://mpng.subpng.com/20191211/ryl/transparent-red-heart-logo-icon-5e359b66395da8.158314961580571494235.jpg";
            String coffeeUrl = "https://img.favpng.com/12/23/15/coffee-cafe-scalable-vector-graphics-logo-png-favpng-F6jv1U3z5E7wjZBbVS4ZErVa0.jpg";
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = $"<html><body> Welcome  Personal Note Manager With <img src={heartUrl} width={30} height={30}> + <img src={coffeeUrl} width={30} height={30}> + <img src={logourl} width={30} height={30}></body></html>"
            };

          
        }
    }
}
