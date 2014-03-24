using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZ.Interfaces.Services;

namespace XYZ.Ui.Web.Controllers
{
    public class ContatosController : BaseController<IContatoService>
    {
        public ContatosController(IContatoService service)
            : base(service)
        {
        }
        //
        // GET: /Contato/
        public JsonResult Get(int take)
        {
            return Json(_service.GetContatos(take), JsonRequestBehavior.AllowGet);
        }
    }
}