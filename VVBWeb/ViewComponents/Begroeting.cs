using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VVBData.Models;
using VVBData.Repositories;

namespace VVBWeb.ViewComponents
{
    public class Begroeting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }     

    }

}
