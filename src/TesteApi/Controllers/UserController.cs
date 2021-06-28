using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
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
        [SwaggerResponse(200, Type = typeof(ClientResponse<PaginationModel<UserModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<PaginationModel<UserModel>>))]
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
                return BadRequest(new ClientResponse<PaginationModel<UserModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("search", Name = "Search user by email")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserModel>))]
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
                return BadRequest(new ClientResponse<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost(Name = "Create new user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserModel>))]
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                var result = await _userService.CreateAsync();

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get user by id")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserModel>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
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
                return BadRequest(new ClientResponse<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
        
        [HttpPut("{id}/partner", Name = "Update partner Id")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserModel>))]
        public async Task<IActionResult> UpdatePartnerIdAsync(Guid id, UpdatePartnerRequest request)
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
                return BadRequest(new ClientResponse<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }


        [HttpGet("{id}/subscriptions", Name = "Get all subscriptions of a user (active and cancelled)")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<IEnumerable<SubscriptionModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<IEnumerable<SubscriptionModel>>))]
        public async Task<IActionResult> GetSubscriptionsAsync(Guid id)
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
                return BadRequest(new ClientResponse<IEnumerable<SubscriptionModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("{id}/get-streams", Name = "Get user streams")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<PaginationModel<StreamModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<PaginationModel<StreamModel>>))]
        public async Task<IActionResult> GetStreamsAsync(Guid id, PagedRequest request)
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
                return BadRequest(new ClientResponse<PaginationModel<StreamModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/profiles", Name = "Get profiles/subaccounts of a user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<IEnumerable<UserModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<IEnumerable<UserModel>>))]
        public async Task<IActionResult> GetProfilesAsync(Guid id)
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
                return BadRequest(new ClientResponse<IEnumerable<UserModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("{id}/token", Name = "Create a user token for the user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<UserTokenModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<UserTokenModel>))]
        public async Task<IActionResult> CreateTokenAsync(Guid id)
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
                return BadRequest(new ClientResponse<UserTokenModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}