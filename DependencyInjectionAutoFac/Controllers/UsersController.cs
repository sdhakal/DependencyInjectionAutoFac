using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DependencyInjectionAutoFac.Models;

namespace DependencyInjectionAutoFac.Controllers
{
    public class UsersController : Controller
    {
        private readonly DependencyInjectionAutoFacContext _context;
        public UsersController(DependencyInjectionAutoFacContext context)
        {
            _context = context;
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(_context.Users.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
