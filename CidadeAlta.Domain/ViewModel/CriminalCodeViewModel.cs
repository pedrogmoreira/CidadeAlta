namespace CidadeAlta.Domain.ViewModel
{
    public class CriminalCodeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisionTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public StatusViewModel Status { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
