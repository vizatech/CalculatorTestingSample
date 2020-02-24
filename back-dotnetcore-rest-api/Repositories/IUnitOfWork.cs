using System.Threading.Tasks;

namespace back_dotnetcore_rest_api.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}