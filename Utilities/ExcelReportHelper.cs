
using System;
using System.IO;
using ClosedXML.Excel;
using System.Linq;

namespace testauto.Test.Utilities
{

    // Định nghĩa lớp TestCase chứa các thuộc tính cần thiết


    public class ExcelReportHelper
    {
        public class TestCase
        {
            public required string Id { get; set; }
            public string Data { get; set; }
            // Bạn có thể bổ sung thêm các thuộc tính khác nếu cần
        }
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Report", "TestManual.xlsx");
        public static void WriteToExcel(string sheetName, string numberTest, string status, string actualResult = "")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"❌ Không tìm thấy file: {filePath}");
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name == sheetName);
                    if (worksheet == null)
                    {
                        Console.WriteLine($"❌ Sheet '{sheetName}' không tồn tại.");
                        return;
                    }

                    var row = worksheet.RowsUsed().Skip(8)
                                    .FirstOrDefault(r => r.Cell(2).GetValue<string>().Trim() == numberTest.Trim());

                    if (row != null)
                    {
                        row.Cell(9).Value = actualResult; // Cập nhật Actual Result vào cột H
                        row.Cell(10).Value = status;       // Cập nhật Status vào cột I

                        workbook.SaveAs(filePath);
                        Console.WriteLine($"✅ Đã lưu file Excel");
                    }
                    else
                    {
                        Console.WriteLine($"❌ Không tìm thấy TestCase có ID {numberTest}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Lỗi: {ex.Message}");
            }
        }

        // Hàm đọc dữ liệu từ Excel và trả về danh sách các TestCase
        public static List<TestCase> GetTestCases(string worksheetName)
        {
            var testCases = new List<TestCase>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(worksheetName);
                Console.WriteLine($"📂 Đọc dữ liệu từ sheet: {worksheetName}");

                // Giả sử 8 dòng đầu là header, bỏ qua chúngx
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    // Kiểm tra nếu dòng rỗng thì bỏ qua
                    if (row.IsEmpty())
                        continue;

                    // Giả sử cột 2 chứa ID và cột 3 chứa dữ liệu cần thiết
                    // Bạn có thể điều chỉnh chỉ số cột tùy theo cấu trúc của file Excel của bạn
                    {
                        // Giả sử cột 2 chứa ID và cột 10 chứa trạng thái
                        string id = row.Cell(2).GetValue<string>();
                        string data = row.Cell(3).GetValue<string>();

                        var testCase = new TestCase
                        {
                            Id = id,
                            Data = data
                        };

                        testCases.Add(testCase);
                    }
                }

                return testCases;
            }
        }

        public static IEnumerable<object[]> GetTestCasesForNUnit(string worksheetName)
        {
            // Sử dụng tên sheet 
            var testCases = GetTestCases(worksheetName);
            foreach (var testCase in testCases)
            {
                yield return new object[] { testCase.Id, testCase.Data };
            }
        }
        public static IEnumerable<object[]> RegisterTestCases => GetTestCasesForNUnit("Register");
        public static IEnumerable<object[]> SearchProductTestCases => GetTestCasesForNUnit("TestData_TKSP");
    }
}