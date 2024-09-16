using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;

namespace Cms.Shared.Bases.Base
{
    public class BaseHandler
    {
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}
