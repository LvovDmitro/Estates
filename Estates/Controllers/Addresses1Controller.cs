using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estates.Data;
using Estates.Models;

namespace Estates.Controllers
{
    public class Addresses1Controller : Controller
    {
        public Addresses1Controller()
        {
        }

        // GET: Addresses1
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Addresses1/Details/5
    }
}
