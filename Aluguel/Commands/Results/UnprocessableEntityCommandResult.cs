using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands.Results
{
    public class UnprocessableEntityCommandResult : GenericCommandResult
    {
        public HttpStatusCode Status { get; private set; }
        public object Data { get; private set; }

        public UnprocessableEntityCommandResult(object data)
        {
            Data = data;
            Status = HttpStatusCode.UnprocessableEntity;
        }

        public UnprocessableEntityCommandResult()
        {
            Status = HttpStatusCode.UnprocessableEntity;
        }
    }
}
