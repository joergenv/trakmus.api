using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trakmus.api.Services;

namespace Trakmus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TractorController : ControllerBase
    {        
        private readonly ITractorService _tractorService;
        
        public TractorController(ITractorService tractorService)
        {
            _tractorService = tractorService;
        }
    }
}
