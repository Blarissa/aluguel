using System.Net;

namespace Aluguel.Commands.Results
{
    public class MethodNotAllowedCommandesult : GenericCommandResult
    {
        public MethodNotAllowedCommandesult(object data) : base(data)
        {
            Status = HttpStatusCode.MethodNotAllowed;
        }
    }
}
