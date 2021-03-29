using LibraryWebApp.Entities;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private ReviewService reviewService = new ReviewService();

        // GET: api/<ReviewController>
        [HttpGet("GetByBook/{insb}")]
        public IEnumerable<ReviewResponse> Get(Guid insb)
        {
            return reviewService.GetAllReviewsByInsb(insb);
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<ReviewResponse> Get()
        {
            return reviewService.GetAllReviews();
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public ReviewResponse Get(int id)
        {
            return reviewService.GetReviewById(id);
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] ReviewRequest reviewRequest)
        {
            reviewService.SaveReview(reviewRequest);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReviewRequest reviewRequest)
        {
            reviewService.UpdateReview(id, reviewRequest);
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reviewService.DeleteReview(id);
        }
    }
}
