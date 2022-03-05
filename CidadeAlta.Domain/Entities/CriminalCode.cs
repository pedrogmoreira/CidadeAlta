using CidadeAlta.Domain.DTO;

namespace CidadeAlta.Domain.Entities
{
    public class CriminalCode : BaseEntity
    {
        public CriminalCode()
        {
        }

        public CriminalCode(CriminalCodeDTO criminalCodeViewModel, int userId)
        {
            Name = criminalCodeViewModel.Name;
            Description = criminalCodeViewModel.Description;
            Penalty = criminalCodeViewModel.Penalty;
            PrisionTime = criminalCodeViewModel.PrisionTime;
            StatusId = criminalCodeViewModel.StatusId;
            CreateDate = DateTime.UtcNow;
            CreateUserId = userId;
        }

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
