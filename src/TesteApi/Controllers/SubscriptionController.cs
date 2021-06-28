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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost(Name = "Create a new subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpGet("{id}", Name = "Get subscription by id")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #region Update product

        [HttpPut("{id}/product", Name = "Update an existing subscription from subscription Blacknut UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> UpdateByIdAsync(Guid id, UpdateProductRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("partner/{id}/product", Name = "Update an existing subscription from subscription Blacknut UUID by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> UpdateByPartnerIdAsync(Guid id, UpdateProductRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("redemption/{redemptionCode}/product", Name = "Update an existing subscription from subscription Blacknut UUID by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> UpdateByRedemptionCodeAsync(string redemptionCode, UpdateProductRequest request)
        {
            try
            {
                var result = await _subscriptionService.UpdateByRedemptionCodeAsync(redemptionCode, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Suspend

        [HttpPut("{id}/suspend", Name = "Suspend an existing subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> SuspendByIdAsync(Guid id)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("partner/{id}/suspend", Name = "Suspend an existing subscription by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> SuspendByPartnerIdAsync(Guid id)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("redemption/{redemptionCode}/suspend", Name = "Suspend an existing subscription by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> SuspendByRedemptionCodeAsync(string redemptionCode)
        {
            try
            {
                var result = await _subscriptionService.SuspendByRedemptionCodeAsync(redemptionCode);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Reactive

        [HttpPut("{id}/reactive", Name = "Reactivate a suspended subscription")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> ReactivateByIdAsync(Guid id)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("partner/{id}/reactive", Name = "Reactivate a suspended subscription by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> ReactivateByPartnerIdAsync(Guid id)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("redemption/{redemptionCode}/reactive", Name = "Reactivate a suspended subscription by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> ReactivateByRedemptionCodeAsync(string redemptionCode)
        {
            try
            {
                var result = await _subscriptionService.ReactivateByRedemptionCodeAsync(redemptionCode);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Cancel

        [HttpPut("{id}/cancel", Name = "Cancel an active subscription from a field")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> CancelByIdAsync(Guid id, SubscriptionCancelRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("partner/{id}/cancel", Name = "Cancel an active subscription from a field by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> CancelByPartnerIdAsync(Guid id, SubscriptionCancelRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("redemption/{redemptionCode}/cancel", Name = "Cancel an active subscription from a field by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> CancelByRedemptionCodeAsync(string redemptionCode, SubscriptionCancelRequest request)
        {
            try
            {
                var result = await _subscriptionService.CancelByRedemptionCodeAsync(redemptionCode, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion

        #region Attach

        [HttpPut("{id}/attach", Name = "Attach a subscription to a user")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> AttachByIdAsync(Guid id, SubscriptionAttachRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("partner/{id}/attach", Name = "Attach a subscription to a user by partner UUID")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> AttachByPartnerIdAsync(Guid id, SubscriptionAttachRequest request)
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
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        [HttpPut("redemption/{redemptionCode}/attach", Name = "Attach a subscription to a user by redemptionCode")]
        [SwaggerResponse(200, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        [SwaggerResponse(400, Type = typeof(ClientResponseModel<SubscriptionModel>))]
        public async Task<IActionResult> AttachByRedemptionCodeAsync(string redemptionCode, SubscriptionAttachRequest request)
        {
            try
            {
                var result = await _subscriptionService.AttachByRedemptionCodeAsync(redemptionCode, request);

                if (result.Success)
                    return Ok(result);
                else
                    return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception e)
            {
                return BadRequest(new ClientResponseModel<SubscriptionModel>()
                {
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Erros = new List<ResponseErrorModel>() { new ResponseErrorModel() { Status = $"{HttpStatusCode.BadRequest}", Title = e.Message } }
                });
            }
        }

        #endregion
    }
}