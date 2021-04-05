using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Aplication.Helpers
{
    [Serializable]
    public class ErrorException : ResultException
    {
        public override string Message { get; }
        public IList<string> Erros { get; }

        public ErrorException(string message)
        {
            Message = message;
        }

        public ErrorException(IList<string> erros)
        {
            Erros = erros;
        }

        public ErrorException(string message, IList<string> erros)
        {
            Message = message;
            Erros = erros;
        }

        public override ObjectResult GetReturn()
        {
            return new BadRequestObjectResult(new
            {
                error = true,
                message = Message,
                erros= Erros
            });
        }
    }
}
