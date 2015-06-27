namespace FullStack.WebApi.Controllers
{
    using System.Web.Http;

    public class HelloWorldController : ApiController
    {
        public IHttpActionResult GetValues()
        {
            return Ok(new[] { "johnny" });
        }
    }
}
