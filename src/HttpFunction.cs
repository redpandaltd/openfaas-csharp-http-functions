using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Redpanda.OpenFaaS
{
    public abstract class HttpFunction : IHttpFunction
    {
        private static Task<IActionResult> methodNotAllowed = Task.FromResult<IActionResult>( new StatusCodeResult( StatusCodes.Status405MethodNotAllowed ) );

        public virtual Task<IActionResult> HandleAsync( HttpRequest request )
        {
            if ( HttpMethods.IsGet( request.Method ) )
            {
                return HandleGetAsync( request );
            }

            if ( HttpMethods.IsPost( request.Method ) )
            {
                return HandlePostAsync( request );
            }

            if ( HttpMethods.IsPut( request.Method ) )
            {
                return HandlePutAsync( request );
            }

            if ( HttpMethods.IsPatch( request.Method ) )
            {
                return HandlePatchAsync( request );
            }

            if ( HttpMethods.IsDelete( request.Method ) )
            {
                return HandleDeleteAsync( request );
            }

            return methodNotAllowed;
        }

        protected virtual Task<IActionResult> HandleGetAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePostAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePutAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePatchAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandleDeleteAsync( HttpRequest request ) => methodNotAllowed;

        protected IActionResult NoContent()
        {
            return new NoContentResult();
        }

        protected IActionResult Ok()
        {
            return new OkResult();
        }

        protected IActionResult Ok( object value )
        {
            return new OkObjectResult( value );
        }

        protected IActionResult Unauthorized()
        {
            return new UnauthorizedResult();
        }

        protected IActionResult Forbidden()
        {
            return new ForbidResult();
        }

        protected IActionResult NotFound()
        {
            return new NotFoundResult();
        }

        protected IActionResult Accepted()
        {
            return new AcceptedResult();
        }

        protected IActionResult Accepted( string location, object value )
        {
            return new AcceptedResult( location, value );
        }

        protected IActionResult Created( string location, object value )
        {
            return new CreatedResult( location, value );
        }

        protected IActionResult StatusCode( int statusCode )
        {
            return new StatusCodeResult( statusCode );
        }
    }
}
