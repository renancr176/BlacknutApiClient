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
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet(Name = "List existing games with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<PaginationModel<GameModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<PaginationModel<GameModel>>))]
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
                return BadRequest(new ClientResponse<PaginationModel<GameModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get one particular game")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<GameModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<GameModel>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
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
                return BadRequest(new ClientResponse<GameModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}