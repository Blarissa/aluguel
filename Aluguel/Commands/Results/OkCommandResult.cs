using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands.Results
{
    public class OkCommandResult : GenericCommandResult
    {
        public HttpStatusCode Status { get; private set; }
        public object Data { get; private set; }

        public OkCommandResult(object data)
        {
            Data = data;
            Status = HttpStatusCode.OK;
        }

        public OkCommandResult()
        {
            Status = HttpStatusCode.OK;
        }
    }
}
