using Microsoft.EntityFrameworkCore;
using back_dotnetcore_rest_api.Models;

namespace back_dotnetcore_rest_api.Persistence
{
    public class CalculatorDBContext: DbContext
    {
        public CalculatorDBContext(DbContextOptions<CalculatorDBContext> options): base(options) 
        {

        }

        public DbSet<UserAction> ActionsOfUser
        { 
            get; set; 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserAction>().ToTable("ActionsOfUser");

            builder.Entity<UserAction>().HasKey(item => item.ActionId);

            builder.Entity<UserAction>().Property(item => item.ActionId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<UserAction>().Property(item => item.MathOperation)
                .IsRequired();
            builder.Entity<UserAction>().Property(item => item.MathResult)
                .IsRequired();

            builder.Entity<UserAction>()
                .HasData(
                    new UserAction { ActionId = 100, MathOperation = "15+12", MathResult = "27"},
                    new UserAction { ActionId = 101, MathOperation = "7*7", MathResult = "49"},
                    new UserAction { ActionId = 102, MathOperation = "33/11", MathResult = "3"}
            );
        }
    } 
}