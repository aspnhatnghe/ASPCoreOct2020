using System;
using System.Threading;

namespace Day08_Async_UploadFile.Models
{
    public class Demo
    {
        public string Test01()
        {
            Thread.Sleep(2000);
            return $"Lucky number: {new Random().Next()}";
        }
        public int Test02()
        {
            Thread.Sleep(5000);
            return new Random().Next(100, 1000);
        }
        public void Test03()
        {
            Thread.Sleep(3000);
        }
    }
}
