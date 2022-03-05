using CidadeAlta.Data.Context;
using CidadeAlta.Domain.DTO;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Filters;
using CidadeAlta.Domain.Filters.Enums;
using CidadeAlta.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CidadeAlta.Data.Repositories
{
    public class CriminalCodeRepository : BaseRepository<CriminalCode>, ICriminalCodeRepository
    {
        public CriminalCodeRepository(CidadeAltaContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets a paged list of Criminal Codes
        /// </summary>
        /// <param name="page"></param>
        /// <param name="paginationSize"></param>
        /// <param name="criminalCodesFilter"></param>
        /// <returns></returns>
        public IEnumerable<CriminalCode> Get(int page, int paginationSize, CriminalCodesFilter criminalCodesFilter)
        {
            if (page > 0)
            {
                var criminalCodes = _dbSet
                    .Include(cc => cc.Status)
                    .Skip((page - 1) * paginationSize)
                    .Take(paginationSize);
                return FilterCriminalCodes(criminalCodes, criminalCodesFilter);
            }

            return Enumerable.Empty<CriminalCode>();
        }

        /// <summary>
        /// Inserts a Criminal Code
        /// </summary>
        /// <param name="criminalCodeViewModel"></param>
        /// <param name="userId"></param>
        public void Insert(CriminalCodeDTO criminalCodeViewModel, int userId)
        {
            var criminalCode = new CriminalCode(criminalCodeViewModel, userId);
            
            base.Insert(criminalCode);
        }

        /// <summary>
        /// Updates a Criminal Code
        /// </summary>
        /// <param name="criminalCodeViewModel"></param>
        /// <param name="userId"></param>
        public void Update(CriminalCodeDTO criminalCodeViewModel, int userId)
        {
            var criminalCode = Find(criminalCodeViewModel.Id);

            if (criminalCode != null)
            {
                criminalCode.Name = criminalCodeViewModel.Name;
                criminalCode.Description = criminalCodeViewModel.Description;
                criminalCode.Penalty = criminalCodeViewModel.Penalty;
                criminalCode.PrisionTime = criminalCodeViewModel.PrisionTime;
                criminalCode.StatusId = criminalCodeViewModel.StatusId;

                criminalCode.UpdateDate = DateTime.UtcNow;
                criminalCode.UpdateUserId = userId;

                base.Update(criminalCode);
            }
        }

        /// <summary>
        /// Filter a Criminal Code list
        /// </summary>
        /// <param name="criminalCodes"></param>
        /// <param name="criminalCodesFilter"></param>
        /// <returns></returns>
        private IEnumerable<CriminalCode> FilterCriminalCodes(IEnumerable<CriminalCode> criminalCodes, CriminalCodesFilter criminalCodesFilter)
        {
            if (criminalCodesFilter.Name != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.Name.Equals(criminalCodesFilter.Name));
            }

            if (criminalCodesFilter.Description != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.Description.Equals(criminalCodesFilter.Description));
            }

            if (criminalCodesFilter.Penalty != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.Penalty.Equals(criminalCodesFilter.Penalty));
            }

            if (criminalCodesFilter.PrisionTime != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.PrisionTime.Equals(criminalCodesFilter.PrisionTime));
            }

            if (criminalCodesFilter.StatusId != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.StatusId.Equals(criminalCodesFilter.StatusId));
            }

            if (criminalCodesFilter.CreateDate != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.CreateDate.Equals(criminalCodesFilter.CreateDate));
            }

            if (criminalCodesFilter.UpdateDate != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.UpdateDate.Equals(criminalCodesFilter.UpdateDate));
            }

            if (criminalCodesFilter.CreateUserId != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.CreateUserId.Equals(criminalCodesFilter.CreateUserId));
            }

            if (criminalCodesFilter.UpdateUserId != null)
            {
                criminalCodes = criminalCodes.Where(cc => cc.UpdateUserId.Equals(criminalCodesFilter.UpdateUserId));
            }

            return OrderCriminalCodes(criminalCodes, criminalCodesFilter);
        }

        /// <summary>
        /// Orders a Criminal Code list
        /// </summary>
        /// <param name="criminalCodes"></param>
        /// <param name="criminalCodesFilter"></param>
        /// <returns></returns>
        private IEnumerable<CriminalCode> OrderCriminalCodes(IEnumerable<CriminalCode> criminalCodes, CriminalCodesFilter criminalCodesFilter)
        {
            switch (criminalCodesFilter.CriminalCodesOrderBy)
            {
                case CriminalCodesOrderBy.NAME:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.Name);
                    break;
                case CriminalCodesOrderBy.DESCRIPTION:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.Description);
                    break;
                case CriminalCodesOrderBy.PENALTY:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.Penalty);
                    break;
                case CriminalCodesOrderBy.PRISION_TIME:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.PrisionTime);
                    break;
                case CriminalCodesOrderBy.STATUS_ID:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.StatusId);
                    break;
                case CriminalCodesOrderBy.CREATE_DATE:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.CreateDate);
                    break;
                case CriminalCodesOrderBy.UPDATE_DATE:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.UpdateDate);
                    break;
                case CriminalCodesOrderBy.CREATE_USER_ID:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.CreateUserId);
                    break;
                case CriminalCodesOrderBy.UPDATE_USER_ID:
                    criminalCodes = criminalCodes.OrderBy(cc => cc.UpdateUserId);
                    break;
                case CriminalCodesOrderBy.DEFAULT:
                default:
                    break;
            }

            return criminalCodes;
        }
    }
}
