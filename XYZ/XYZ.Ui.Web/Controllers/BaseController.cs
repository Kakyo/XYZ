using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZ.Interfaces.Services;

namespace XYZ.Ui.Web.Controllers
{
    public class BaseController<TService> : Controller
        where TService : IService
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            this._service = service;
        }
    }
}