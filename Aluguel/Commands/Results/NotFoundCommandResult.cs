using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands.Results
{
    public class NotFoundCommandResult : GenericCommandResult
    {
        public NotFoundCommandResult(object data) : base(data)
        {
            base.Status = HttpStatusCode.InternalServerError;
        }

        public NotFoundCommandResult() : base()
        {
            base.Status = HttpStatusCode.NotFound;
        }
    }
}
