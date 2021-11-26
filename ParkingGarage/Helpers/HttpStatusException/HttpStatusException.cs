using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParkingGarage.Helpers.HttpStatusException
{
    public class HttpStatusException : Exception
    {
        public HttpStatusException(StatusCodeResult statusCodeResult, [Optional] string msg)
        {
            StatusCodeResult = statusCodeResult;
            Msg = msg;
        }

        public StatusCodeResult StatusCodeResult { get; }

        public string Msg { get; }
    }
}