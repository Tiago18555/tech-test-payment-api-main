﻿namespace Pottencial.Tiago.Payment.Api.CrossCutting
{
    public class ResponseModel
    {
        public string Result { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = null;
        public object Data { get; set; }
    }
}
