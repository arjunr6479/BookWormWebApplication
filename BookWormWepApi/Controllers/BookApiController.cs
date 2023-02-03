using AutoMapper;
using BookWormWebApp.Model.DTO;
using BookWormWebAPP.Model.Domain;
using BookWormWebAPP.Model.DTO;
using BookWormWebAPP.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BookWormWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookApiController(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = await _bookRepository.GetBooksAsync();
            if (allBooks.Count() == 0)
            {
                return NoContent();
            }
            var bookDto = _mapper.Map<BookDto>(allBooks);
            return Ok(bookDto);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NoContent();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.DeleteBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBookAsync(UpdateBookDto book, int id)
        {
            if (!ValidateUpdateBookAsync(book, id))
            {
                return BadRequest(ModelState);
            }
            var bookDto = _mapper.Map<BookDetails>(book);
            var updatedBook = await _bookRepository.UpdateBookAsync(bookDto, id);

            if (updatedBook == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBookAsync(AddBookDto book)
        {
            if (!ValidateAddBookAsync(book))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var bookDto = _mapper.Map<BookDetails>(book);
                var addedBook = await _bookRepository.AddBookAsync(bookDto);
                return Created("Succesfully created", addedBook);
            }
        }
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthorAsync(AddAuthorDto author)
        {
            if (!ValidateAddAuthorAsync(author))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var authorDto = _mapper.Map<AuthorDetails>(author);
                var addedAuthor = await _bookRepository.AddAuthorAsync(authorDto);
                return Created("Succesfully created", addedAuthor);
            }
        }
        [HttpPost("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthorAsync(UpdateAuthorDto author, int id)
        {
            if (!ValidateAddAuthorAsync(author, id))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var authorDto = _mapper.Map<AuthorDetails>(author);
                var updatedAuthor = await _bookRepository.UpdateAuthorAsync(authorDto, id);
                return Created("Succesfully created", updatedAuthor);
            }
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryDto category)
        {
            if (!ValidateAddCategoryAsync(category))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var categoryDto = _mapper.Map<AuthorDetails>(category);
                var addedCategory = await _bookRepository.AddAuthorAsync(categoryDto);
                return Created("Succesfully created", addedCategory);
            }
        }
        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto category, int id)
        {
            if (!ValidateAddCategoryAsync(category, id))
            {
                return BadRequest(ModelState);
            }
            else
            {
                var categoryDto = _mapper.Map<AuthorDetails>(category);
                var updatedCategory = await _bookRepository.UpdateAuthorAsync(categoryDto, id);
                return Created("Succesfully created", updatedCategory);
            }
        }


        #region Validation Methods
        //add book validation
        private bool ValidateAddBookAsync(AddBookDto addBook)
        {
            if (addBook == null)
            {
                ModelState.AddModelError(nameof(addBook), $"Book Details Is Required");

            }
            if (string.IsNullOrWhiteSpace(addBook.BookName))
            {
                ModelState.AddModelError(nameof(addBook.BookName),
                    $"Name Can not be empty or white space");

            }
            var authorDto = new AuthorDetails();
            if (authorDto.Equals(addBook.authorDetails))
            {
                ModelState.AddModelError(nameof(addBook.authorDetails),
                    $"Author cannot be empty");

            }
            var categoryto = new CategoryDetails();
            if (categoryto.Equals(addBook.categoryDetails))
            {
                ModelState.AddModelError(nameof(addBook.categoryDetails), $"Category cannot be empty");
            }
            return true;
        }
        //add author validation
        private bool ValidateAddAuthorAsync(AddAuthorDto addAuthor)
        {
            if (addAuthor == null)
            {
                ModelState.AddModelError(nameof(addAuthor), $"Author details cannot be empty");

            }
            if (string.IsNullOrWhiteSpace(addAuthor.AuthorName))
            {
                ModelState.AddModelError(nameof(addAuthor.AuthorName),
                    $"Name cannot be empty or white space");

            }
            return true;
        }
        //add category validation
        private bool ValidateAddCategoryAsync(AddCategoryDto addCategory)
        {
            if (addCategory == null)
            {
                ModelState.AddModelError(nameof(addCategory), $"Category details cannot be empty");

            }
            if (string.IsNullOrWhiteSpace(addCategory.CategoryType))
            {
                ModelState.AddModelError(nameof(addCategory.CategoryType),
                    $"Category type cannot be empty or white space");

            }
            return true;
        }

        //update book validation
        private bool ValidateUpdateBookAsync(UpdateBookDto updateBook, int id)
        {
            if (updateBook == null)
            {
                ModelState.AddModelError(nameof(updateBook), $"Book Details Is Required");

            }
            if (id.GetType() == typeof(int))
            {
                ModelState.AddModelError(nameof(id),
                    $"Id Can not be empty or white space");

            }
            if (string.IsNullOrWhiteSpace(updateBook.BookName))
            {
                ModelState.AddModelError(nameof(updateBook.BookName),
                    $"Name Can not be empty or white space");

            }
            var authorDto = new AuthorDetails();
            if (authorDto.Equals(updateBook.authorDetails))
            {
                ModelState.AddModelError(nameof(updateBook.authorDetails),
                    $"Author cannot be empty");

            }
            var categoryto = new CategoryDetails();
            if (categoryto.Equals(updateBook.categoryDetails))
            {
                ModelState.AddModelError(nameof(updateBook.categoryDetails), $"Category cannot be empty");
            }
            return true;
        }
        //update author validation
        private bool ValidateAddAuthorAsync(UpdateAuthorDto updateAuthor, int id)
        {
            if (updateAuthor == null)
            {
                ModelState.AddModelError(nameof(updateAuthor), $"Author details cannot be empty");

            }
            if (id.GetType() == typeof(int))
            {
                ModelState.AddModelError(nameof(id),
                    $"AuthId Can not be empty or white space");

            }
            if (string.IsNullOrWhiteSpace(updateAuthor.AuthorName))
            {
                ModelState.AddModelError(nameof(updateAuthor.AuthorName),
                    $"Name cannot be empty or white space");

            }
            return true;
        }
        //update category validation
        private bool ValidateAddCategoryAsync(UpdateCategoryDto updateCategory, int id)
        {
            if (updateCategory == null)
            {
                ModelState.AddModelError(nameof(updateCategory), $"Category details cannot be empty");

            }
            if (id.GetType() == typeof(int))
            {
                ModelState.AddModelError(nameof(id),
                    $"AuthId Can not be empty or white space");

            }
            if (string.IsNullOrWhiteSpace(updateCategory.CategoryType))
            {
                ModelState.AddModelError(nameof(updateCategory.CategoryType),
                    $"Category type cannot be empty or white space");

            }
            return true;
        }



        #endregion

    }
}
