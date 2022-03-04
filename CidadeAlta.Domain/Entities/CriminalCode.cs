namespace CidadeAlta.Domain.Entities
{
    public class CriminalCode : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisionTime { get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime? UpdateDate { get; set; }
        public int StatusId { get; set; }
        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }

        public Status Status { get; set; }
        public User CreateUser { get; set; }
        public User? UpdateUser { get; set; }
    }
}
