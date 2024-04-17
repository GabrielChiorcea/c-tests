﻿using System.Runtime.InteropServices;
using Domain;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application{


public class Create
{
    public class Command : IRequest{
        public Activity Activity {get; set;}
    }
        public class Hendler : IRequestHandler<Command>
        {
           public readonly DataContext _context;
           public Hendler(DataContext context)
          {
            _context = context;
          }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
                
            }
        }
    
}
}