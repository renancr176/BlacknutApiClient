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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost(Name = "Create a new subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> CreateAsync(SubscriptionCreateRequest request)
        {
            try
            {
                var result = await _subscriptionService.CreateAsync(request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get subscription by id")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var result = await _subscriptionService.GetByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #region Update product

        [HttpPut("{id}/Product", Name = "Update an existing subscription from subscription Blacknut UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> UpdateByIdAsync(string id, UpdateProductRequest request)
        {
            try
            {
                var result = await _subscriptionService.UpdateByIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Partner/{id}/Product", Name = "Update an existing subscription from subscription Blacknut UUID by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> UpdateByPartnerIdAsync(string id, UpdateProductRequest request)
        {
            try
            {
                var result = await _subscriptionService.UpdateByPartnerIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Redemption/{code}/Product", Name = "Update an existing subscription from subscription Blacknut UUID by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> UpdateByRedemptionCodeAsync(string code, UpdateProductRequest request)
        {
            try
            {
                var result = await _subscriptionService.UpdateByRedemptionCodeAsync(code, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Suspend

        [HttpPut("{id}/Suspend", Name = "Suspend an existing subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> SuspendByIdAsync(string id)
        {
            try
            {
                var result = await _subscriptionService.SuspendByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Partner/{id}/Suspend", Name = "Suspend an existing subscription by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> SuspendByPartnerIdAsync(string id)
        {
            try
            {
                var result = await _subscriptionService.SuspendByPartnerIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Redemption/{code}/Suspend", Name = "Suspend an existing subscription by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> SuspendByRedemptionCodeAsync(string code)
        {
            try
            {
                var result = await _subscriptionService.SuspendByRedemptionCodeAsync(code);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Reactive

        [HttpPut("{id}/Reactive", Name = "Reactivate a suspended subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> ReactivateByIdAsync(string id)
        {
            try
            {
                var result = await _subscriptionService.ReactivateByIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Partner/{id}/Reactive", Name = "Reactivate a suspended subscription by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> ReactivateByPartnerIdAsync(string id)
        {
            try
            {
                var result = await _subscriptionService.ReactivateByPartnerIdAsync(id);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Redemption/{code}/Reactive", Name = "Reactivate a suspended subscription by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> ReactivateByRedemptionCodeAsync(string code)
        {
            try
            {
                var result = await _subscriptionService.ReactivateByRedemptionCodeAsync(code);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Cancel

        [HttpPut("{id}/Cancel", Name = "Cancel an active subscription from a field")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> CancelByIdAsync(string id, SubscriptionCancelRequest request)
        {
            try
            {
                var result = await _subscriptionService.CancelByIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Partner/{id}/Cancel", Name = "Cancel an active subscription from a field by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> CancelByPartnerIdAsync(string id, SubscriptionCancelRequest request)
        {
            try
            {
                var result = await _subscriptionService.CancelByPartnerIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Redemption/{code}/Cancel", Name = "Cancel an active subscription from a field by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> CancelByRedemptionCodeAsync(string code, SubscriptionCancelRequest request)
        {
            try
            {
                var result = await _subscriptionService.CancelByRedemptionCodeAsync(code, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Attach

        [HttpPut("{id}/Attach", Name = "Attach a subscription to a user")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> AttachByIdAsync(string id, SubscriptionAttachRequest request)
        {
            try
            {
                var result = await _subscriptionService.AttachByIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Partner/{id}/Attach", Name = "Attach a subscription to a user by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> AttachByPartnerIdAsync(string id, SubscriptionAttachRequest request)
        {
            try
            {
                var result = await _subscriptionService.AttachByPartnerIdAsync(id, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("Redemption/{code}/Attach", Name = "Attach a subscription to a user by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponse<SubscriptionResponse>))]
        [SwaggerResponse(400, Type = typeof(ClientResponse<SubscriptionResponse>))]
        public async Task<IActionResult> AttachByRedemptionCodeAsync(string code, SubscriptionAttachRequest request)
        {
            try
            {
                var result = await _subscriptionService.AttachByRedemptionCodeAsync(code, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponse<SubscriptionResponse>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<ErrorResponse>() { new ErrorResponse() { Status = $"{(int) HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion
    }
}