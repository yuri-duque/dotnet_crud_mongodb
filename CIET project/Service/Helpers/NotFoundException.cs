using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aplication.Helpers
{
    [Serializable]
    public class NotFoundException : ResultException
    {
        public override string Message { get; }
        public override IDictionary Data { get; }

        public NotFoundException(string message)
        {
            Message = message;
        }

        public NotFoundException(string message, object data, string paramName = null)
        {
            Message = message;
            Data = new Dictionary<string, object>() { { paramName, data } };
        }

        public override ObjectResult GetReturn()
        {
            return new NotFoundObjectResult(new
            {
                error = true,
                message = Message,
                data = Data
            });
        }
    }
}
