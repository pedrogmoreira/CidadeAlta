namespace CidadeAlta.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<CriminalCode> CriminalCodes { get; set; }
    }
}
