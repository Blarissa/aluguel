using System.Net;

namespace Aluguel.Commands.Results
{
    public class OkCommandResult : GenericCommandResult
    {
        public OkCommandResult(object data) : base(data)
        {
            base.Status = HttpStatusCode.OK;
        }
    }
}
