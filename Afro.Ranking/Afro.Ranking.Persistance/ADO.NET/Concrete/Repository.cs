using Afro.Ranking.Persistance.ADO.NET.ValueObjects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Afro.Ranking.Persistance.ADO.NET.Concrete
{
    public abstract class Repository
    {
        public IList<ConnectionOptions> _connectionOptions = [];
        public readonly ILogger<Repository> _logger;
        public Repository(IOptions<List<ConnectionOptions>> options, ILogger<Repository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            if (options == null)
            { throw new ArgumentNullException(nameof(options)); }
            _connectionOptions = options.Value;
            foreach (var option in _connectionOptions)
            {
                string trimSource = (option.Source ?? "").Trim();
                if (string.IsNullOrEmpty(trimSource))
                { 
                  throw new ArgumentNullException(nameof(option.Source)); 
                }
                string trimConnectionString = (option.ConnectionString ?? "").Trim();
                if (string.IsNullOrEmpty(trimConnectionString))
                {
                    throw new ArgumentNullException(nameof(option.ConnectionString));
                }
            }

        }


    }
}
