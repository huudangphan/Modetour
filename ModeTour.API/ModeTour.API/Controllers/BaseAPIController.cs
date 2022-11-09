using Microsoft.AspNetCore.Mvc;
using ModeTour.Services;

namespace ModeTour.API.Controllers
{
    //[Route("api/v1/[controller]/[action]")]
    [ApiController]

    public class BaseAPIController : ControllerBase
    {
        public BaseAPIController()
        {
        }
        protected UnitOfWorks GetUnitOfWork()
        {
            return UnitOfWorkFactory.GetUnitOfWork();
        }

    }
}
