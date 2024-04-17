﻿using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using SQLitePCL;

namespace Application;

public class Details
{
    public class Query : IRequest<Activity>{
        public Guid Id{ get; set; }
    }

    public class Handler : IRequestHandler<Query, Activity>
    {
        public readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);
        }
    }
}


