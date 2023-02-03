using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Model.Domain;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;
        public UserRepository(UserDbContext userDbContext, IMapper mapper)
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }

        public async Task<UserDetails> GetUserDetailsByIdAsync(int id)
        {
            return await _userDbContext.UserDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserDetails>> GetUsersDetailsAsync()
        {
            return await _userDbContext.UserDetails.ToListAsync();
        }

        public async Task<UserDetails> AddUserDetailsAsync(UserDetails userDetails)
        {
            await _userDbContext.AddAsync(userDetails);
            await _userDbContext.SaveChangesAsync();
            return userDetails;
        }


        public async Task<UserDetails> DeleteUserDetailsAsync(int id)
        {
            var user = await _userDbContext.UserDetails.SingleAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            else
            {
                _userDbContext.Remove(user);
                await _userDbContext.SaveChangesAsync();
            }
            return user;
        }

        public async Task<UserDetails> UpdateUserDetailsAsync(UserDetails userDetails, int id)
        {
            var result = await _userDbContext.UserDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result = _mapper.Map<UserDetails>(userDetails);
                await _userDbContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<Review> AddReviewAsync(Review review)
        {
            await _userDbContext.AddAsync(review);
            await _userDbContext.SaveChangesAsync();
            return review;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _userDbContext.Reviews.ToListAsync();
        }
        public async Task<Review> UpdateReviewAsync(Review review, int id)
        {
            var result = await _userDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result = _mapper.Map<Review>(review);
                await _userDbContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<Review> DeleteReviewAsync(int id)
        {
            var review = await _userDbContext.Reviews.SingleAsync(x => x.Id == id);
            if (review == null)
            {
                return null;
            }
            else
            {
                _userDbContext.Remove(review);
                await _userDbContext.SaveChangesAsync();
            }
            return review;
        }


    }
}
