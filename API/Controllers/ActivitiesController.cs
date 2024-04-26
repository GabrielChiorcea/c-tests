using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
    


        [HttpGet] //api/activities 
        public async Task<ActionResult<List<Activity>>> GetActiviti(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/activities/id
        public async Task<IActionResult> GetActivity ( Guid id){
            return HandlerResult( await Mediator.Send(new Details.Query{Id = id}));
            
        }
      
        [HttpPost]
        public async Task<IActionResult> CreatActivity(Activity activity){
            
            return HandlerResult(await Mediator.Send(new Create.Command {Activity = activity} ));
        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){
            activity.Id = id;
            await Mediator.Send(new Edit.Command{Activity = activity});
            return Ok();
        }

        [HttpDelete("{ID}")] 
        public async Task<IActionResult> DeleteActivity (Guid id){
            return HandlerResult(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }

}