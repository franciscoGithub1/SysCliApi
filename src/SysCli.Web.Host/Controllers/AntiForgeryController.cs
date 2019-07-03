using Microsoft.AspNetCore.Antiforgery;
using SysCli.Controllers;

namespace SysCli.Web.Host.Controllers
{
    public class AntiForgeryController : SysCliControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
