using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeeSharpEyewear.Models;
using SeeSharpEyewear.Services;

namespace SeeSharpEyewear.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EyewearController : ControllerBase
    {
        public EyewearController()
        {
        }

        // GET action
        [HttpGet]
        public ActionResult<List<Eyewear>> GetAll() =>
            EyewearService.GetAll();
        //

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Eyewear> Get(int id)
        {
            var eyewear = EyewearService.Get(id);

            if(eyewear == null)
                return NotFound();

            return eyewear;
        }
        //

        // POST action
        [HttpPost]
        public IActionResult Create(Eyewear eyewear)
        {            
            EyewearService.Add(eyewear);
            return CreatedAtAction(nameof(Create), new { id = eyewear.Id }, eyewear);
        }
        //

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Eyewear eyewear)
        {
            if (id != eyewear.Id)
                return BadRequest();

            var existingEyewear = EyewearService.Get(id);
            if(existingEyewear is null)
                return NotFound();

            EyewearService.Update(eyewear);           

            return NoContent();
        }
        //

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eyewear = EyewearService.Get(id);

            if (eyewear is null)
                return NotFound();

            EyewearService.Delete(id);

            return NoContent();
        }
        //
    }
}