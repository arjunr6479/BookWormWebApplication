using AutoMapper;
using BookWormWebApp.Data;
using BookWormWebApp.Model.DTO;
using BookWormWebAPP.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BookWormWebAPP.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDetailsDbContext _bookDetailsDbContext;
        private readonly IMapper _mapper;
        public BookRepository(BookDetailsDbContext bookDetailsDbContext, IMapper mapper)
        {
            this._bookDetailsDbContext = bookDetailsDbContext;
            this._mapper = mapper;


        }

        public async Task<AuthorDetails> AddAuthorAsync(AuthorDetails authorDetails)
        {
            await _bookDetailsDbContext.AddAsync(authorDetails);
            await _bookDetailsDbContext.SaveChangesAsync();
            return authorDetails;
        }

        public async Task<BookDetails> AddBookAsync(BookDetails bookDetails)
        {
            await _bookDetailsDbContext.AddAsync(bookDetails);
            await _bookDetailsDbContext.SaveChangesAsync();
            return bookDetails;
        }

        public async Task<CategoryDetails> AddCategoryAsync(CategoryDetails categoryDetails)
        {
            await _bookDetailsDbContext.AddAsync(categoryDetails);
            await _bookDetailsDbContext.SaveChangesAsync();
            return categoryDetails;
        }

        public async Task<AuthorDetails> DeleteAuthorAsync(int id)
        {
            var author = await _bookDetailsDbContext.AuthorDetails.SingleAsync(x => x.AuthId == id);
            if (author == null)
            {
                return null;
            }
            else
            {
                _bookDetailsDbContext.Remove(author);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return author;
        }

        public async Task<BookDetails> DeleteBookAsync(int id)
        {
            var book = await _bookDetailsDbContext.BookDetails.SingleAsync(x => x.id == id);
            if (book == null)
            {
                return null;
            }
            else
            {
                _bookDetailsDbContext.Remove(book);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return book;
        }

        public async Task<CategoryDetails> DeleteCategoryAsync(int id)
        {
            var category = await _bookDetailsDbContext.CategoryDetails.SingleAsync(x => x.CatId == id);
            if (category == null)
            {
                return null;
            }
            else
            {
                _bookDetailsDbContext.Remove(category);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return category;
        }

        public async Task<BookDetails> GetBookByIdAsync(int id)
        {
            return await _bookDetailsDbContext.BookDetails.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<IEnumerable<BookDetails>> GetBooksAsync()
        {
            return await _bookDetailsDbContext.BookDetails.ToListAsync();
        }

        public async Task<AuthorDetails> UpdateAuthorAsync(AuthorDetails authorDetails, int id)
        {
            var result = await _bookDetailsDbContext.AuthorDetails.FirstOrDefaultAsync(x => x.AuthId == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result = _mapper.Map<AuthorDetails>(authorDetails);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<BookDetails> UpdateBookAsync(BookDetails bookDetails, int id)
        {
            var result = await _bookDetailsDbContext.BookDetails.FirstOrDefaultAsync(x => x.id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result = _mapper.Map<BookDetails>(bookDetails);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<CategoryDetails> UpdateCategoryAsync(CategoryDetails categoryDetails, int id)
        {
            var result = await _bookDetailsDbContext.CategoryDetails.FirstOrDefaultAsync(x => x.CatId == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result = _mapper.Map<CategoryDetails>(categoryDetails);
                await _bookDetailsDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
