namespace Angular.Web.Logging.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.IO;


    public class LogController : Controller
    {
        public ActionResult Index()
        {
            var path = @"logs\log-" + DateTime.Today.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".txt";
            if (!System.IO.File.Exists(path))
            {
                return this.Content("file not exists: " + path);
            }

            using (var fileStream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var text = streamReader.ReadToEnd();
                    return this.Content(text);
                }
            }
        }
    }
}
