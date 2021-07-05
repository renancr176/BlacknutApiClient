using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models.Requests;
using BlacknutApiClient.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetAll", Name = "Get all users with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UsersResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UsersResponse>))]
        public async Task<IActionResult> GetAsync(PagedRequest request)
        {
            try
            {
                var result = await _userService.GetAsync(request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int) result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UsersResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("Search", Name = "Search user by email")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserResponse>))]
        public async Task<IActionResult> SearchAsync(UserSearchRequest request)
        {
            try
            {
                var result = await _userService.SearchAsync(request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost(Name = "Create new user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserResponse>))]
        public async Task<IActionResult> CreateAsync(UserCreateRequest request)
        {
            try
            {
                var result = await _userService.CreateAsync(request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get user by id")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserResponse>))]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var result = await _userService.GetByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
        
        [HttpPut("{id}/Partner", Name = "Update partner Id")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserResponse>))]
        public async Task<IActionResult> UpdatePartnerIdAsync(string id, UpdatePartnerRequest request)
        {
            try
            {
                var result = await _userService.UpdatePartnerIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/Subscriptions", Name = "Get all subscriptions of a user (active and cancelled)")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionsResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionsResponse>))]
        public async Task<IActionResult> GetSubscriptionsAsync(string id)
        {
            try
            {
                var result = await _userService.GetSubscriptionsAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionsResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("{id}/GetStreams", Name = "Get user streams")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<StreamsResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<StreamsResponse>))]
        public async Task<IActionResult> GetStreamsAsync(string id, PagedRequest request)
        {
            try
            {
                var result = await _userService.GetStreamsAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<StreamsResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/Profiles", Name = "Get profiles/subaccounts of a user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UsersResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UsersResponse>))]
        public async Task<IActionResult> GetProfilesAsync(string id)
        {
            try
            {
                var result = await _userService.GetProfilesAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UsersResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/Token", Name = "Create a user token for the user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserTokenResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserTokenResponse>))]
        public async Task<IActionResult> CreateTokenAsync(string id)
        {
            try
            {
                var result = await _userService.CreateTokenAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserTokenResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}