using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartnerAPI.CustomExceptions;
using PartnerAPI.Models;
using PartnerAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartnerAPI.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partherService;
        private readonly IHttpClientFactory _httpClientFactory;

        public PartnerController(IPartnerService partherService, IHttpClientFactory httpClientFactory)
        {        
            _partherService = partherService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Partner>> GetPartner(string name)
        {
            HttpResponseMessage errorMsg;

            if (name == "")
            {
                return NotFound(new { name });
            }

            try
            {
                var partner = await _partherService.Get(name);
                if (partner != null)
                {
                    return Ok(partner);
                }
                else
                {
                    errorMsg = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(String.Format("There is no record found.")),
                        ReasonPhrase = String.Format("Data not found for name: {0}.", name)
                    };

                    return NotFound(new { errorMsg });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
