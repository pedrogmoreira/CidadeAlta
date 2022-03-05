namespace CidadeAlta.Domain.DTO
{
    public class CriminalCodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisionTime { get; set; }
        public int StatusId { get; set; }
    }
}
