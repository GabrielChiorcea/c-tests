using System.Runtime.InteropServices;
using Application.Activities;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application{


public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Activity Activity {get; set;}
    }



        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivtyValidator());
            }
        }
        public class Hendler : IRequestHandler<Command, Result<Unit>>
        {
           public readonly DataContext _context;
           public Hendler(DataContext context)
          {
            _context = context;
          }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);
                var result = await _context.SaveChangesAsync() > 0;
                if(!result) return Result<Unit>.Failure("Fail to create");
                return Result<Unit>.Succes(Unit.Value);
                
            }
        }
    
}
}