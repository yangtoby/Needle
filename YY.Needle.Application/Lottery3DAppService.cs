using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application.DTO.Common;
using YY.Needle.Application.Interfaces;
using YY.Needle.Data.Context;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Service;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Application
{

    public class Lottery3DAppService : AppService<LotteryContext>, ILottery3DAppService
    {
        private readonly ILottery3DService _service;

        public Lottery3DAppService(ILottery3DService artistService)
        {
            _service = artistService;
        }

        public ValidationResult Create(Lottery3D artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Lottery3D artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Lottery3D artist)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(artist));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        //public Lottery3D Get(int id, bool @readonly = false)
        //{
        //    return _service.Get(id, @readonly);
        //}

        //public IEnumerable<Lottery3D> All(bool @readonly = false)
        //{
        //    return _service.All(@readonly);
        //}

        public IEnumerable<Lottery3D> Find(Expression<Func<Lottery3D, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PageOutput<Lottery3D> GetPage(int pageSize, int pageIndex, out int total)
        {
            var result = new PageOutput<Lottery3D>();
            var list= _service.GetPage(pageSize, pageIndex,out total);
            result.PageList = list;
            result.Total = total;
            return result;

        }
    }
}
