using System.Net;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Angular.Data;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "SEcret text";
        }


        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Users.Find(-1);
            var thingToreturn = thing.ToString();
            return thingToreturn;

        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request");
        }
    }
}