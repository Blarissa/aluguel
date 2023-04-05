using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands.Results
{
    public class NotFoundCommandResult : GenericCommandResult
    {
        public HttpStatusCode Status { get; private set; }
        public object Data { get; private set; }

        public NotFoundCommandResult(object data)
        {
            Data = data;
            Status = HttpStatusCode.InternalServerError;
        }

        public NotFoundCommandResult()
        {
            Status = HttpStatusCode.NotFound;
        }
    }
}
