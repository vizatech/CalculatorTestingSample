using System.Threading.Tasks;
using back_dotnetcore_rest_api.Persistence;

namespace back_dotnetcore_rest_api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalculatorDBContext _context;

        public UnitOfWork(CalculatorDBContext context)
        {
            this._context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}