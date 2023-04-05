using Aluguel.Commands.Contracts;
using System.Net;

namespace Aluguel.Commands.Results
{
    public class UnprocessableEntityCommandResult : GenericCommandResult
    {
        public UnprocessableEntityCommandResult(object data) : base(data)
        {
            base.Status = HttpStatusCode.UnprocessableEntity;
        }

        public UnprocessableEntityCommandResult() : base() 
        {
            base.Status = HttpStatusCode.UnprocessableEntity;
        }
    }
}
