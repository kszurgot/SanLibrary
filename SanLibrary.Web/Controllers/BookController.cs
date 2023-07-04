using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
            => Ok(await _bookService.GetAllAsync());

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
    }
}