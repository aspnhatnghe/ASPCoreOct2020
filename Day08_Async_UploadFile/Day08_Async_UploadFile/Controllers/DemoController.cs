using System;
using System.Collections.Generic;
using System.Diagnostics;
using Day08_Async_UploadFile.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day08_Async_UploadFile.Controllers
{
    public class DemoController : Controller
    {
        public string DemoSync()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            stopWatch.Stop();

            return $"Chạy hết {stopWatch.ElapsedMilliseconds}ms";
        }
    }
}