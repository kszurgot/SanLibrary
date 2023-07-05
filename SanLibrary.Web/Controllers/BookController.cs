using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SanLibrary.Application.DTO;
using SanLibrary.Application.Services;

namespace SanLibrary.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get([FromQuery] QueryBookDto dto)
        {
            return Ok(await _bookService.GetAllAsync(dto));
        }
           

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> Get(Guid id)
        {
            var book = await _bookService.GetAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateBookDto dto)
        {
            dto.Id = Guid.NewGuid();
            await _bookService.AddAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = dto.Id }, default);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateBookDto dto)
        {
            dto.Id = id;
            await _bookService.UpdateAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}