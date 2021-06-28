using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Models;
using BlacknutApiClient.Models.Requests;
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

        [HttpGet(Name = "Get all users with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<PaginationModel<UserModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<PaginationModel<UserModel>>))]
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
                return BadRequest(new ClientResponseModel<PaginationModel<UserModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("search", Name = "Search user by email")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<UserModel>))]
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
                return BadRequest(new ClientResponseModel<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost(Name = "Create new user")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<UserModel>))]
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
                return BadRequest(new ClientResponseModel<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get user by id")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<UserModel>))]
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
                return BadRequest(new ClientResponseModel<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
        
        [HttpPut("{id}", Name = "Update user partner Id")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<UserModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<UserModel>))]
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
                return BadRequest(new ClientResponseModel<UserModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }


        [HttpGet("{id}/subscriptions", Name = "Get all subscriptions of a user (active and cancelled)")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<IEnumerable<SubscriptionModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<IEnumerable<SubscriptionModel>>))]
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
                return BadRequest(new ClientResponseModel<IEnumerable<SubscriptionModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/streams", Name = "Get user streams")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<PaginationModel<StreamModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<PaginationModel<StreamModel>>))]
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
                return BadRequest(new ClientResponseModel<PaginationModel<StreamModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}/profiles", Name = "Get profiles/subaccounts of a user")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<IEnumerable<UserModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<IEnumerable<UserModel>>))]
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
                return BadRequest(new ClientResponseModel<IEnumerable<UserModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPost("{id}/token", Name = "Create a user token for the user")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<UserTokenModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<UserTokenModel>))]
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
                return BadRequest(new ClientResponseModel<UserTokenModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}