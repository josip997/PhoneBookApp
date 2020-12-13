using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Web.DataContext;
using PhoneBookApp.Web.Models;

namespace PhoneBookApp.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PhoneBookAppContext _context;

        public PeopleController(PhoneBookAppContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var phoneBookAppContext = _context.People.Include(p => p.City);
            return View(await phoneBookAppContext.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,Name,Surname,Phone,Gender,Email,BirthDate")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //Get city from person
            var myCity = await _context.Cities.FindAsync(person.CityId);
            //Get country from city
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", myCity.CountryId);
            //Get city from person and show other cities from same country
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.CountryId == myCity.CountryId), "Id", "Name", person.CityId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            //Get city from person
            var myCity = await _context.Cities.FindAsync(person.CityId);
            //Get country from city
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", myCity.CountryId);
            //Get city from person and show other cities from same country
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.CountryId == myCity.CountryId), "Id", "Name", person.CityId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityId,Name,Surname,Phone,Gender,Email,BirthDate")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            //Get city from person
            var myCity = await _context.Cities.FindAsync(person.CityId);
            //Get country from city
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", myCity.CountryId);
            //Get city from person and show other cities from same country
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.CountryId == myCity.CountryId), "Id", "Name", person.CityId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
