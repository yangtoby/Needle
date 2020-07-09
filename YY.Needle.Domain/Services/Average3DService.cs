using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.DTO.Average3D;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Repository;
using YY.Needle.Domain.Interfaces.Service;
using YY.Needle.Domain.Services.Common;

namespace YY.Needle.Domain.Services
{
    public class Average3DService : Service<Average3D>, IAverage3DService
    {
        private readonly ILottery3DRepository _lottery3DRepository;
        public Average3DService(IAverage3DRepository repository, ILottery3DRepository lottery3DRepository)
           : base(repository)
        {
            _lottery3DRepository = lottery3DRepository;
        }
        public IEnumerable<Average3D> GetPage(int pageSize, int pageIndex, out int total)
        {
            var result = this.All().OrderByDescending(m => m.DrawDate)
                 .Skip((pageIndex - 1) * pageSize)
                 .Take(pageSize).ToList();
            total = this.All().Count();
            return result;
        }

        public void RunAverage()
        {
            var allAverage = Repository.All();
            foreach (var item in allAverage)
            {
                Repository.Delete(item);
            }
            //查询average3D最大日期
            List<Average3D> list = this.All().ToList();
            var drawDate = DateTime.MinValue;
            if (list.Any())
            {
                drawDate = list.Max(m => m.DrawDate);
            }

            var needImportList = _lottery3DRepository.Find(m => m.DrawDate > drawDate).ToList();
            foreach (var item in needImportList)
            {
                var averageItem = new Average3D()
                {
                    AllChar = item.AllChar,
                    Number = item.Number,
                    DrawDate = item.DrawDate
                };
                var intAllChar = Convert.ToInt32(item.AllChar);
                var avg = 1000 / 8;
                if (intAllChar < avg)
                {
                    averageItem.EightAvg = 1;
                    averageItem.FourAvg = 1;
                    averageItem.TwoAvG = 1;
                }
                else if (intAllChar < avg * 2)
                {
                    averageItem.EightAvg = 2;
                    averageItem.FourAvg = 1;
                    averageItem.TwoAvG = 1;
                }
                else if (intAllChar < avg * 3)
                {
                    averageItem.EightAvg = 3;
                    averageItem.FourAvg = 2;
                    averageItem.TwoAvG = 1;
                }
                else if (intAllChar < avg * 4)
                {
                    averageItem.EightAvg = 4;
                    averageItem.FourAvg = 2;
                    averageItem.TwoAvG = 1;
                }
                else if (intAllChar < avg * 5)
                {
                    averageItem.EightAvg = 5;
                    averageItem.FourAvg = 3;
                    averageItem.TwoAvG = 2;
                }
                else if (intAllChar < avg * 6)
                {
                    averageItem.EightAvg = 6;
                    averageItem.FourAvg = 3;
                    averageItem.TwoAvG = 2;
                }
                else if (intAllChar < avg * 7)
                {
                    averageItem.EightAvg = 7;
                    averageItem.FourAvg = 4;
                    averageItem.TwoAvG = 2;
                }
                else if (intAllChar < avg * 8)
                {
                    averageItem.EightAvg = 8;
                    averageItem.FourAvg = 4;
                    averageItem.TwoAvG = 2;
                }
                this.Add(averageItem);
            }
            //set avg


            //给2分法赋值
            var twoStart = this.All().OrderBy(m => m.DrawDate).FirstOrDefault(m => m.TwoStep == 0);
            var twoStartDrawDate = DateTime.MinValue;
            if (twoStart != null)
            {
                twoStartDrawDate = twoStart.DrawDate;
            }
            var twoList = Repository.Find(m => m.DrawDate >= twoStartDrawDate).OrderBy(m => m.DrawDate).ToList();
            for (int i = 0; i < twoList.Count - 1; i++)
            {
                for (int j = i + 1; j < twoList.Count; j++)
                {
                    if (twoList[i].TwoAvG == twoList[j].TwoAvG)
                    {
                        twoList[i].TwoStep = j - i;
                        Repository.Update(twoList[i]);
                        break;
                    }
                }
            }

            //给4分法赋值
            var fourStart = this.All().OrderBy(m => m.DrawDate).FirstOrDefault(m => m.FourStep == 0);
            var fourStartDrawDate = DateTime.MinValue;
            if (fourStart != null)
            {
                fourStartDrawDate = fourStart.DrawDate;
            }
            var fourList = Repository.Find(m => m.DrawDate >= fourStartDrawDate).OrderBy(m => m.DrawDate).ToList();
            for (int i = 0; i < fourList.Count - 1; i++)
            {
                for (int j = i + 1; j < fourList.Count; j++)
                {
                    if (fourList[i].FourAvg == fourList[j].FourAvg)
                    {
                        fourList[i].FourStep = j - i;
                        Repository.Update(fourList[i]);
                        break;
                    }
                }
            }

            //给8分法赋值
            var eightStart = this.All().OrderBy(m => m.DrawDate).FirstOrDefault(m => m.EightStep == 0);
            var eightStartDrawDate = DateTime.MinValue;
            if (eightStart != null)
            {
                eightStartDrawDate = eightStart.DrawDate;
            }
            var eightList = Repository.Find(m => m.DrawDate >= eightStartDrawDate).OrderBy(m => m.DrawDate).ToList();
            for (int i = 0; i < eightList.Count - 1; i++)
            {
                for (int j = i + 1; j < eightList.Count; j++)
                {
                    if (eightList[i].EightAvg == eightList[j].EightAvg)
                    {
                        eightList[i].EightStep = j - i;
                        Repository.Update(eightList[i]);
                        break;
                    }
                }
            }
        }

        public GetEchartsBarOutput GetEchartsBarTwo()
        {
            var result = new GetEchartsBarOutput();
            var resultTwo = from s in Repository.All()
                            where s.TwoStep > 0
                            group s by s.TwoAvG
             into g
                            select new EChartsBarDto
                            {
                                XName = g.Key.ToString(),
                                YCount = g.Count()
                            };
            result.TwoEchartsBar = resultTwo.ToList();

            var resultFour = from s in Repository.All()
                             where s.TwoStep > 0
                             group s by s.FourAvg
             into g
                             select new EChartsBarDto
                             {
                                 XName = g.Key.ToString(),
                                 YCount = g.Count()
                             };
            result.FourEchartsBar = resultFour.ToList();

            var resultEight = from s in Repository.All()
                              where s.TwoStep > 0
                              group s by s.EightAvg
             into g
                              select new EChartsBarDto
                              {
                                  XName = g.Key.ToString(),
                                  YCount = g.Count()
                              };
            result.EightEchartsBar = resultEight.ToList();
            return result;
        }

        public List<AvgStepDto> GetStepList(StepEnum stepName)
        {
            IEnumerable<AvgStepDto> result= new List<AvgStepDto>();
            switch (stepName)
            {
                case StepEnum.AvgTwo:
                    result = from s in Repository.All()
                             group s by s.TwoStep
                     into g
                             select new AvgStepDto
                             {
                                 AverageStep = g.Key,
                                 AvgStepCount = g.Count()
                             };
                    break;
                case StepEnum.AvgFour:
                    result = from s in Repository.All()
                             group s by s.FourStep
                   into g
                             select new AvgStepDto
                             {
                                 AverageStep = g.Key,
                                 AvgStepCount = g.Count()
                             };
                    break;
                case StepEnum.AvgEight:
                    result = from s in Repository.All()
                             group s by s.EightStep
                   into g
                             select new AvgStepDto
                             {
                                 AverageStep = g.Key,
                                 AvgStepCount = g.Count()
                             };
                    break;
                   
            }
            var sumCount = result.Sum(m => m.AvgStepCount);
            var resultList = result.OrderByDescending(m => m.AverageStep).ToList();
            foreach (var item in resultList)
            {
                item.Percent = Convert.ToDouble(item.AvgStepCount) / Convert.ToDouble(sumCount);
            }
          
            return resultList;
        }
    }
}
