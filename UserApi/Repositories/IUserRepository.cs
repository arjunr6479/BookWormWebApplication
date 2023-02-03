using UserApi.Model.Domain;

namespace UserApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDetails>> GetUsersDetailsAsync();

        Task<UserDetails> GetUserDetailsByIdAsync(int id);

        Task<UserDetails> AddUserDetailsAsync(UserDetails userDetails);
        Task<UserDetails> DeleteUserDetailsAsync(int id);

        Task<UserDetails> UpdateUserDetailsAsync(UserDetails userDetails, int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review, int id);
        Task<Review> DeleteReviewAsync(int id);
    }
}
