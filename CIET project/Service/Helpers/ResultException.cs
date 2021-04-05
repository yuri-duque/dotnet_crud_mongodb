using Microsoft.AspNetCore.Mvc;
using System;

namespace Aplication.Helpers
{
    public class ResultException : Exception
    {
        public virtual ObjectResult GetReturn()
        {
            throw new NotImplementedException();
        }
    }
}
