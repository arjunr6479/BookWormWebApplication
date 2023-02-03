using BookWormWebApp.Model.DTO;
using BookWormWebAPP.Model.Domain;

namespace BookWormWebAPP.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDetails>> GetBooksAsync();

        Task<BookDetails> GetBookByIdAsync(int id);

        Task<BookDetails> AddBookAsync(BookDetails bookDetails);
        Task<BookDetails> DeleteBookAsync(int id);

        Task<BookDetails> UpdateBookAsync(BookDetails bookDetails, int id);


        Task<AuthorDetails> AddAuthorAsync(AuthorDetails authorDetails);
        Task<AuthorDetails> DeleteAuthorAsync(int id);

        Task<AuthorDetails> UpdateAuthorAsync(AuthorDetails authorDetails, int id);

        Task<CategoryDetails> AddCategoryAsync(CategoryDetails categoryDetails);
        Task<CategoryDetails> DeleteCategoryAsync(int id);

        Task<CategoryDetails> UpdateCategoryAsync(CategoryDetails categoryDetails, int id);



    }
}
