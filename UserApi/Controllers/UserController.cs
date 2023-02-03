
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Model.Domain;
using UserApi.Model.Dto;
using UserApi.Repositories;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("AllUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var allUsers = await _userRepository.GetUsersDetailsAsync();
            if (allUsers.Count() == 0)
            {
                return NoContent();
            }
            var userDto = _mapper.Map<UserDetailsDto>(allUsers);
            return Ok(userDto);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserDetailsByIdAsync(id);
            if (user == null)
            {
                return NoContent();
            }
            var userDto = _mapper.Map<UserDetailsDto>(user);
            return Ok(userDto);
        }
        [HttpPost("User")]
        public async Task<IActionResult> AddUserAsync(UserDetailsDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var user = _mapper.Map<UserDetails>(userDto);
                var result = await _userRepository.AddUserDetailsAsync(user);
                return Created("Succesfully created", result);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUsersync(int id)
        {
            var user = await _userRepository.DeleteUserDetailsAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDetailsDto>(user);
            return Ok(userDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(UserDetailsDto userDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<UserDetails>(userDto);
            var updatedUser = await _userRepository.UpdateUserDetailsAsync(user, id);

            if (updatedUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userDto);
            }
        }
        [HttpPost("Review")]
        public async Task<IActionResult> AddRevAsync(ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var review = _mapper.Map<Review>(reviewDto);
                var result = await _userRepository.AddReviewAsync(review);
                return Created("Succesfully created", result);
                Console.WriteLine("dwjbujw");
            }
        }
        [HttpGet("AllReviews")]
        public async Task<IActionResult> GetAllRevsAsync()
        {
            var allReviews = await _userRepository.GetAllReviewsAsync();
            if (allReviews.Count() == 0)
            {
                return NoContent();
            }
            var reviewDto = _mapper.Map<UserDetailsDto>(allReviews);
            return Ok(reviewDto);
        }
        [HttpPut("Review")]
        public async Task<IActionResult> UpdateRevAsync(ReviewDto reviewDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var review = _mapper.Map<Review>(reviewDto);
            var updatedReview = await _userRepository.UpdateReviewAsync(review, id);

            if (updatedReview == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(reviewDto);
            }
        }
        [HttpDelete("Review")]
        public async Task<IActionResult> DeleteRevsync(int id)
        {
            var review = await _userRepository.DeleteReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            var reviewDto = _mapper.Map<UserDetailsDto>(review);
            return Ok(reviewDto);
        }

    }
}
