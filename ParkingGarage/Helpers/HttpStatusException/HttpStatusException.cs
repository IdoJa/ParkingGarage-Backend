using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ParkingGarage.Helpers.HttpStatusException
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode Status { get; private set; }
        
        public string Msg { get; }

        public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
            Msg = msg;
        }
    }
}