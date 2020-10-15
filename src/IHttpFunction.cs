using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Redpanda.OpenFaaS
{
    public interface IHttpFunction
    {
        Task<IActionResult> HandleAsync( HttpRequest request );
    }
}
