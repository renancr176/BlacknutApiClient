﻿using System;

namespace BlacknutApiClient.Models.Requests
{
    public class StreamGetRequest : BaseQueryParamRequest
    {
        public Guid? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}