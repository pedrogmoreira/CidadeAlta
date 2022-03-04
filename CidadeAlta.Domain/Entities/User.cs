namespace CidadeAlta.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public IEnumerable<CriminalCode> CriminalCodesCreated { get; set; }
        public IEnumerable<CriminalCode> CriminalCodesUpdated { get; set; }
    }
}
