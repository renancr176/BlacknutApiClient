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
    public class StreamController : ControllerBase
    {
        private readonly IStreamService _streamService;

        public StreamController(IStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpGet(Name = "List existing streams with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<PaginationModel<StreamModel>>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<PaginationModel<StreamModel>>))]
        public async Task<IActionResult> GetAsync(PagedRequest<StreamGetRequest> request)
        {
            try
            {
                var result = await _streamService.GetAsync(request);

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

        [HttpGet("{id}", Name = "List existing streams with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<StreamModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<StreamModel>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _streamService.GetByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<StreamModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}