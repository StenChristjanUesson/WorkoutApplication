using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutApplication.Controllers
{
    public class ExerciseController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ExerciseController : ControllerBase
        {
            private readonly DataContext _context;

            public ExerciseController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetExercise([FromQuery] ExerciseIntensity? intensity)
            {
                if (intensity.HasValue)
                {
                    return Ok(_context.ExerciseList?.where(x => x.Intensity == Intensity.Value));
                }
                return Ok(_context.ExerciseList);
            }

            [HttpGet("{id}")]
            public IActionResult GetDetails(int? id)
            {
                var exercise = _context.ExerciseList?.FirstOrDefault(e => e.Id == id);
                if (exercise == null)
                {
                    return NotFound();
                }

                return Ok(exercise);
            }

            [HttpPost]
            public IActionResult Create([FromBody] Exercise exercise)
            {
                var dbExercise = _context.ExerciseList?.Find(exercise.Id);
                if (dbExercise == null)
                {
                    _context.Add(exercise);
                    _context.SaveChanges();
                    
                    return CreatedAtAction(Nameof(GetDetails), new { Id = exercise.Id }, exercise);
                }
                else
                {
                    return Conflict();
                }
            }

            [HttpPut("{id}")]
            public IActionResult Update(int? id, [FromBody] Exercise exercise)
            {
                if (id != exercise.Id || !_context.ExerciseList!.Any(e => e.Id == id))
                {
                    return NotFound();
                }

                _context.Update(exercise);
                _context.SaveChanges();

                return NoContent();
            }

        }
    }
}