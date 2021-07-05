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
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("GetAll", Name = "List existing games with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<GamesResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<GamesResponse>))]
        public async Task<IActionResult> GetAsync(PagedRequest request)
        {
            try
            {
                var result = await _gameService.GetAsync(request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<GamesResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get one particular game")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<GameResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<GameResponse>))]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var result = await _gameService.GetByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<GameResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}