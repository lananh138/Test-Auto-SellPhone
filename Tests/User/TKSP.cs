using OpenQA.Selenium;
using Test;
using testauto.Test.Utilities;

namespace main.Test.Tests.User
{
    public class Test_TKSP : TestBase
    {
        [Test, TestCaseSource(typeof(ExcelReportHelper), nameof(ExcelReportHelper.SearchProductTestCases))]
        [Category("TKSP")]

        public void TiemKiemSanPham(string id, string data)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"🔍 BẮT ĐẦU TEST CASE:");
            Console.WriteLine($"🆔 TestCase ID: {id}");
            Console.WriteLine($"📥 Input Data: {data}");
            Console.WriteLine("=====================================");
            // ExcelReportHelper.WriteToExcel()

        }
    }
}