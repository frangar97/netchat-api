using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Channels
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Channel channel = new Channel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description
                };

                _context.Channel.Add(channel);

                int success = await _context.SaveChangesAsync();

                if (success==0)
                {
                    throw new Exception("Ocurrio un problema al guardar los datos");
                }

                return Unit.Value;
            }
        }
    }
}
