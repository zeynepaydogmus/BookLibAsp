using FirstProjectAsp.Utility;
using System.Linq.Expressions;

namespace FirstProjectAsp.Models
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void UpdateRent(Rent rent)
        {
            _applicationDbContext.Update(rent);
        }


    }
}
