using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application.DTO.Common;
using YY.Needle.Application.Interfaces;
using YY.Needle.Data.Context;
using YY.Needle.Domain.DTO.Average3D;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Service;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Application
{
    public class Average3DAppService : AppService<LotteryContext>, IAverage3DAppService
    {
        private readonly IAverage3DService _service;

        public Average3DAppService(IAverage3DService artistService)
        {
            _service = artistService;
        }
        public ValidationResult Create(Average3D orderDetail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Average3D> Find(Expression<Func<Average3D, bool>> predicate, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(Average3D orderDetail)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Average3D orderDetail)
        {
            throw new NotImplementedException();
        }

        public PageOutput<Average3D> GetPage(int pageSize, int pageIndex, out int total)
        {
            var result = new PageOutput<Average3D>();
            var list = _service.GetPage(pageSize, pageIndex, out total);
            result.PageList = list;
            result.Total = total;
            return result;

        }
        public void RunAverage()
        {
            _service.RunAverage();
        }

        public GetEchartsBarOutput GetEchartsBarTwo()
        {
            return _service.GetEchartsBarTwo();
        }

        public List<AvgStepDto> GetStepList(StepEnum stepName)
        {
            return _service.GetStepList(stepName);
        }
    }
}
