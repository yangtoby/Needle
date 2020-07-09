using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YY.Needle.Application.Interfaces;
using YY.Needle.Domain.DTO.Average3D;
using YY.Needle.Web.Models;

namespace YY.Needle.Web.Controllers
{
    public class Average3DController : BaseController
    {
        private readonly IAverage3DAppService _average3dAppService;

        public Average3DController(IAverage3DAppService average3dAppService)
        {
            _average3dAppService = average3dAppService;

        }
        // GET: Average3D
        public ActionResult Index()
        {
            if(CurrentAccountInfo == null)
            {
                return View("/Account/Index");
            }
            return View();
        }

        public JsonResult GetTableData(int pageIndex, int pageSize)
        {
            int total = 0;
            var result = _average3dAppService.GetPage(pageSize, pageIndex, out total);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RunAverage()
        {
            _average3dAppService.RunAverage();
            var result = new ResultJson<string>();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ViewResult Echarts()
        {
            return View();
        }

        public JsonResult GetEchartsBar()
        {
            var list= _average3dAppService.GetEchartsBarTwo();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ViewResult StepListShow()
        {
            return View();
        }

        public JsonResult GetStepList(string stepName)
        {
            StepEnum step = StepEnum.AvgTwo;
            switch (stepName)
            {
                case "avgTwo":
                    step = StepEnum.AvgTwo;
                    break;
                case "avgFour":
                    step = StepEnum.AvgFour;
                    break;
                case "avgEight":
                    step = StepEnum.AvgEight;
                    break;
            }
            var list = _average3dAppService.GetStepList(step);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}