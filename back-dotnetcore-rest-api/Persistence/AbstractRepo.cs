namespace back_dotnetcore_rest_api.Persistence
{
    public abstract class AbstractRepo
    {
        protected readonly CalculatorDBContext _context;
        public AbstractRepo(CalculatorDBContext context) 
        {
            this._context = context;
        }        
    } 
}