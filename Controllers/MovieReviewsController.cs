using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Data;
using MovieReview.Models;

namespace MovieReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieReviewsController : ControllerBase
    {
        private readonly MovieReviewDbContext _dbContext;

        public MovieReviewsController(MovieReviewDbContext context)
        {
            _dbContext = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoviewReviews>>> GetMovieReviews()
        {
            return await _dbContext.MovieReviews.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MoviewReviews>> AddMovieReview(MoviewReviews review)
        {
            _dbContext.MovieReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovieReviews), new { id = review.ID }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieReview(int id, MoviewReviews review)
        {
            if (id != review.ID)
                return BadRequest();

            _dbContext.Entry(review).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/MovieReviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieReview(int id)
        {
            var review = await _dbContext.MovieReviews.FindAsync(id);
            if (review == null)
                return NotFound();
            _dbContext.MovieReviews.Remove(review);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
