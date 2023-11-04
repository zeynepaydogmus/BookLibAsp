namespace FirstProjectAsp.Models
{
    public interface IRentRepository : IRepository<Rent>
    {
        void UpdateRent(Rent rent);
        void Save();
    }
}
