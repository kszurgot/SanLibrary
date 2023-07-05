using Microsoft.AspNetCore.Mvc;
using SanLibrary.Application.DTO;
using SanLibrary.Application.Services;

namespace SanLibrary.Web.Controllers
{
    [ApiController]
    [Route("borrowing-book")]
    public class BorrowingBookController : ControllerBase
    {
        private readonly IBorrowingBookService _borrowingBookService;

        public BorrowingBookController(IBorrowingBookService borrowingBookService)
        {
            _borrowingBookService = borrowingBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowingBookDto>>> Get()
        {
            var UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // should be taken from: User.Identity.Name
            return Ok(await _borrowingBookService.GetAllAsync(UserId));
        }

        [HttpPost]
        public async Task<ActionResult> Post(BorrowingBookDto dto)
        {
            dto.Id = Guid.NewGuid();
            dto.UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // should be taken from: User.Identity.Name
            await _borrowingBookService.BorrowBookAsync(dto);
            
            return NoContent();
        }
    }
}