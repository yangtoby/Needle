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
    public class BaseController : Controller
    {
        protected const string accountKey = "AccountInfo";
        public AccountInfoDto CurrentAccountInfo
        {
            get { return GetCurrentAccount(); }
        }
        public AccountInfoDto GetCurrentAccount()
        {
            HttpCookie cookie = HttpContext.Request.Cookies[accountKey];
            if (cookie == null)
                return null;
            string cookieStr = cookie[accountKey];
            string userInfoStr = FormsAuthentication.Decrypt(cookieStr).UserData;
            var userInfo = JsonConvert.DeserializeObject<AccountInfoDto>(userInfoStr);

            if (userInfo == null)
                return null;

            return userInfo;
        }

        public void SetAccountInfoCookie(AccountInfoDto dto)
        {
            HttpContext.Response.Cookies.Remove(accountKey);
            HttpContext.Request.Cookies.Remove(accountKey);
            var timeout = DateTime.Now.AddDays(10000);
            var inputJson = JsonConvert.SerializeObject(dto);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, dto.AccountName, DateTime.Now, timeout, true, inputJson);
            HttpCookie cookie = new HttpCookie(accountKey);
            cookie[accountKey] = FormsAuthentication.Encrypt(ticket);
            cookie.HttpOnly = false;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = timeout;
            HttpContext.Response.Cookies.Add(cookie);
            HttpContext.Request.Cookies.Add(cookie);
        }
    }
}