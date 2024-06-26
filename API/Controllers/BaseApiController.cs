using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        protected ActionResult HandlerResult<T>(Result<T> result){
            if(result == null) return NotFound();
            if(result.IsSucces && result.Value != null)
                return Ok(result.Value);
            if(result.IsSucces && result.Value == null)
                return NotFound();
            
            return BadRequest(result.Error);
        }
    }
}