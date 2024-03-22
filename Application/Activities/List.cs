using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Qwery : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Qwery, List<Activity>>
        {
            private readonly DataContext _cocntext;
            public Handler(DataContext cocntext)
            {
                _cocntext = cocntext;
            }

            public async Task<List<Activity>> Handle(Qwery request, CancellationToken cancellationToken)
            {
                return await _cocntext.Activities.ToListAsync();
            }
        }

    }
}