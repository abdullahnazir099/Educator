using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Educator.Data;
using Educator.Models;

namespace Educator.Controllers
{
    public class reviewsController : Controller
    {
        private readonly EducatordbContext _context;

        public reviewsController(EducatordbContext context)
        {
            _context = context;
        }

        // GET: reviews
        public async Task<IActionResult> Index()
        {
              return _context.review != null ? 
                          View(await _context.review.ToListAsync()) :
                          Problem("Entity set 'EducatordbContext.review'  is null.");
        }

        // GET: reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.review == null)
            {
                return NotFound();
            }

            var review = await _context.review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: reviews/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Topic,Description")] review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.review == null)
            {
                return NotFound();
            }

            var review = await _context.review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: reviews/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Topic,Description")] review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reviewExists(review.Id))
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
            return View(review);
        }

        // GET: reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.review == null)
            {
                return NotFound();
            }

            var review = await _context.review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.review == null)
            {
                return Problem("Entity set 'EducatordbContext.review'  is null.");
            }
            var review = await _context.review.FindAsync(id);
            if (review != null)
            {
                _context.review.Remove(review);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reviewExists(int id)
        {
          return (_context.review?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
