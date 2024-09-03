﻿using System.Net;

namespace Magi.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCodeCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
