using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Qwery : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Qwery, List<Activity>>
        {
            private readonly DataContext _cocntext;
            private readonly ILogger<List> _logger;
            public Handler(DataContext cocntext, ILogger<List> logger)
            {
                _logger = logger;
                _cocntext = cocntext;
            }

            public async Task<List<Activity>> Handle(Qwery request, CancellationToken cancellationToken)
            {
                try
                {
                    for (var i = 0; i < 2; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has coplited");
                    }
                }
                catch (System.Exception)
                {
                    
                    _logger.LogInformation("Task Was cancelled");
                }

                return await _cocntext.Activities.ToListAsync();
            }
        }

    }
}