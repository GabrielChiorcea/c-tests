using Application.Activities;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class Edit
{
    public class Command : IRequest{

        public Activity Activity { get; set; }
    }

     public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivtyValidator());
            }
        }

    public class Handler : IRequestHandler<Command>
    {

        private readonly DataContext _context;
        private readonly IMapper _mapping;
        public  Handler(DataContext context, IMapper mapping){
            _mapping = mapping;
            _context = context;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Activity.Id);

            _mapping.Map(request.Activity, activity);

            await _context.SaveChangesAsync();
        }
    }
}
