using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YY.Needle.Domain.DTO.Account;
using YY.Needle.Domain.DTO.Common;

namespace YY.Needle.Web.Controllers
{
    public class AccountController : BaseController
    {
       
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Login(LoginInput input)
        {
            var accountDto = AutoMapper.Mapper.Map<AccountInfoDto>(input);
            return Json(accountDto,JsonRequestBehavior.AllowGet);
        }

       
        
    }
}