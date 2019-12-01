using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileFoodSchedules.Models;

namespace MobileFoodSchedules.Controller
{
    [Route("api/FoodSurvey")]
    [ApiController]
    public class FoodSurveysController : ControllerBase
    {
        private readonly MobileFoodSchedulesContext _context;

        public FoodSurveysController(MobileFoodSchedulesContext context)
        {
            _context = context;
        }

        // GET: api/FoodSurveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodSurvey>>> GetFoodSurvey()
        {
            return await _context.FoodSurvey.ToListAsync();
        }

        // GET: api/FoodSurveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodSurvey>> GetFoodSurvey(int id)
        {
            var foodSurvey = await _context.FoodSurvey.FindAsync(id);

            if (foodSurvey == null)
            {
                return NotFound();
            }

            return foodSurvey;
        }

        // PUT: api/FoodSurveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodSurvey(int id, FoodSurvey foodSurvey)
        {
            if (id != foodSurvey.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodSurvey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodSurveys
        [HttpPost]
        public async Task<ActionResult<FoodSurvey>> PostFoodSurvey(FoodSurvey foodSurvey)
        {
            _context.FoodSurvey.Add(foodSurvey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodSurvey", new { id = foodSurvey.Id }, foodSurvey);
        }

        // DELETE: api/FoodSurveys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodSurvey>> DeleteFoodSurvey(int id)
        {
            var foodSurvey = await _context.FoodSurvey.FindAsync(id);
            if (foodSurvey == null)
            {
                return NotFound();
            }

            _context.FoodSurvey.Remove(foodSurvey);
            await _context.SaveChangesAsync();

            return foodSurvey;
        }

        private bool FoodSurveyExists(int id)
        {
            return _context.FoodSurvey.Any(e => e.Id == id);
        }
    }
}
