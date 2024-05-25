using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;
using System.IO;
using AAO_App.ModelView;
using Microsoft.AspNetCore.Http;
//using BC = BCrypt.Net.BCrypt;

namespace AAO_App.Controllers
{
    public class NewUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverTest/Create
        public IActionResult Index()
        {
            
            ViewData["CityName"] = new SelectList(_context.Cities, "CityId", "CityName");
            return View();
        }

        // POST: DriverTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( DriverViewModel model)
        {
            Driver obj = new Driver();
            if (ModelState.IsValid)
            {
                
                if (model.file != null && model.file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.file.CopyTo(ms);
                        obj.ProfileImage = ms.ToArray();
                    }
                }
                obj.DriverId = model.DriverId;
                obj.CityId = model.CityId;
                obj.Address = model.Address;
                obj.Birthday = model.Birthday;
                obj.Cities = model.Cities;
                obj.Firstname = model.Firstname;
                obj.IsValidated = model.IsValidated;
                obj.Lastname = model.Lastname;
                obj.Location = model.Location;
                obj.Password = model.Password;
                obj.Phone = model.Phone; 
                //driver.Password = BC.HashPassword(driver.Password); Some day my sweet prince some day
                _context.Add(obj);
                await _context.SaveChangesAsync();
                if (obj.DriverId>0) // Klam måde at tjekke login på, bør omskrives.. eventually.. Kraftedeme en bootleg måde jeg fandt her
                {

                    // HttpContext.Session.SetString("Address", driver[0].Address);
                    //HttpContext.Session.SetString("Birthday", driver[0].Birthday.ToString());
                    // HttpContext.Session.SetString("CityId", driver[0].CityId.ToString());
                    HttpContext.Session.SetString("DriverId", obj.DriverId.ToString());
                    HttpContext.Session.SetString("Firstname", obj.Firstname);
                    HttpContext.Session.SetString("Lastname", obj.Lastname);
                    HttpContext.Session.SetString("CityId", obj.CityId.ToString());


                    //HttpContext.Session.SetString("Location", driver[0].Location);
                    //HttpContext.Session.SetString("Phone", driver[0].Phone);

                    //return View("~/Views/Homepage/Index");
                    
                }
                return RedirectToAction("Index", "Home");
            }
            
            ViewData["CityName"] = new SelectList(_context.Cities, nameof(City.CityId), nameof(City.CityName), obj.CityId);
            return View(model);
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverId == id);
        }
    }
}