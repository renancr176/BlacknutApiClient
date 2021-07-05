﻿using System;
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
    public class StreamController : ControllerBase
    {
        private readonly IStreamService _streamService;

        public StreamController(IStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpPost("GetAll", Name = "List existing streams with paged result")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<StreamsResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<StreamsResponse>))]
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
                return BadRequest(new ClientResponse<StreamsResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Filters streams started after startDate")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<StreamResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<StreamResponse>))]
        public async Task<IActionResult> GetByIdAsync(string id)
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
                return BadRequest(new ClientResponse<StreamResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }
    }
}