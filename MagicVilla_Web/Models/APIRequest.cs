﻿using static MagicVilla_Utility.SD;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public Object Data { get; set; }
        public string Token { get; set; }
    }
}
