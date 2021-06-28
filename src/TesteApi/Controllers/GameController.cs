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
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet(Name = "List existing games with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<PaginationModel<GameModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<PaginationModel<GameModel>>))]
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
                return BadRequest(new ClientResponseModel<PaginationModel<GameModel>>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get one particular game")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<GameModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<GameModel>))]
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
                return BadRequest(new ClientResponseModel<GameModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}