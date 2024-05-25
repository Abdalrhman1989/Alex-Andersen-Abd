using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;
using Microsoft.AspNetCore.Http;
using AAO_App.ModelView;
using System.IO;

namespace AAO_App
{
    public class ProfileController : Controller
    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET: Driver
        // GET: DriverTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =await _db.Drivers.Include(d => d.Cities).Where(m => m.DriverId == int.Parse(this.HttpContext.Session.GetString("DriverId"))).FirstOrDefaultAsync();

            
            return View(applicationDbContext);
        }

        public byte[] GetImage(string sbase64sring)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sbase64sring))
            {
                bytes= Convert.FromBase64String(sbase64sring);
            }
            return bytes;
        }
        ////GET: DriverTest/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var driver = await _db.Drivers
        //        .Include(d => d.Cities)
        //        .FirstOrDefaultAsync(m => m.DriverId == id);
        //    if (driver == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(driver);
        //}

        //GET: DriverTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _db.Drivers.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            DriverViewModel obj = new DriverViewModel();
            
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
            //  ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", driver.CityId);
            return View(obj);
        }

        // POST: DriverTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverViewModel model)
        {
         

            if (ModelState.IsValid)
            {
                Driver obj = new Driver();
                try
                {
                    if (model.file != null && model.file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            model.file.CopyTo(ms);
                            obj.ProfileImage = ms.ToArray();
                        }
                    }
                     
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

                    obj.DriverId = id;
                    obj.DriverId = int.Parse(this.HttpContext.Session.GetString("DriverId"));
                    obj.CityId = int.Parse(this.HttpContext.Session.GetString("CityId"));
                    _db.Update(obj);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(obj.DriverId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", driver.CityId);
            return View(model);
        }

        // GET: DriverTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            var driver = await _db.Drivers
                .Include(d => d.Cities)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: DriverTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _db.Drivers.FindAsync(id);
            _db.Drivers.Remove(driver);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _db.Drivers.Any(e => e.DriverId == id);
        }


    }
}
