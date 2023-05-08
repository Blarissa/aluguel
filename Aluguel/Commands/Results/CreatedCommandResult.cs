using System.Net;

namespace Aluguel.Commands.Results
{
    public class CreatedCommandResult : GenericCommandResult
    {
        public CreatedCommandResult(object data) : base(data)
        {
            Status = HttpStatusCode.Created;
        }
    }
}
