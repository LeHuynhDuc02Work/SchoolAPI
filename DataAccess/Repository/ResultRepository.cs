using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;

namespace DataAccess.Repository
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}