using CidadeAlta.Domain.Filters.Enums;

namespace CidadeAlta.Domain.Filters
{
    public class CriminalCodesFilter
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Penalty { get; set; }
        public int? PrisionTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StatusId { get; set; }
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public CriminalCodesOrderBy CriminalCodesOrderBy { get; set; } = CriminalCodesOrderBy.DEFAULT;
    }
}
