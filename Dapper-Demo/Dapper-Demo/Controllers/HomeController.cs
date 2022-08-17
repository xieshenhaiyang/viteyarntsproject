using Microsoft.AspNetCore.Mvc;

namespace Dapper_Demo.Controllers
{
    public class HomeController : ControllerBase
    {
        public string Say() {
            return "Hello Net6.0";
        }
    }
}
