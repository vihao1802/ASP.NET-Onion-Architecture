using BulkeyWebManage.Application.DTOs;
using BulkeyWebManage.Application.Interfaces;
using BulkeyWebManage.Application.Service;
using BulkeyWebManage.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BulkeyWebManage.Areas.Admin.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _genreService;

        public GenreController(BookStoreDbContext bookStoreDbContext, IGenreService genreService, ILogger<GenreController> logger)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _genreService = genreService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            Console.WriteLine("GetAllGenres");
            var genres = await _genreService.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            _logger.LogInformation("GetGenreById");

            var genre = await _genreService.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO createGenreDTO)
        {
            _logger.LogInformation("CreateGenre");
            if (createGenreDTO == null)
            {
                return BadRequest("Genre object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGenreDTO = await _genreService.Add(createGenreDTO);

            return CreatedAtAction(nameof(GetGenreById), new { id = newGenreDTO.Id }, newGenreDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDTO updateGenreDTO)
        {
            _logger.LogInformation("UpdateGenre");
            if (updateGenreDTO == null)
            {
                return BadRequest("Genre object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _genreService.Update(id, updateGenreDTO);

            var genre = await _genreService.GetById(id);

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            _logger.LogInformation("DeleteGenre");

            var genre = await _genreService.GetById(id);
            if (genre == null)
            {
                return NotFound(new { message = "Genre not found" });
            }
            await _genreService.Delete(id);

            return Ok(new { message = "Genre deleted successfully" });
        }
    }
}
