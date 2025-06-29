# ✅ Test-Auto-SellPhone

Dự án kiểm thử tự động cho hệ thống bán điện thoại trực tuyến, được phát triển bằng .NET và Selenium WebDriver.  
Mục tiêu của dự án là kiểm tra chức năng toàn diện của hệ thống thông qua các kịch bản thực tế như đăng nhập, mua hàng và quản lý tài khoản.

---

## 📌 Mục tiêu

- Tự động hóa các bài kiểm thử giao diện web (UI Test), chức năng project
- Kiểm tra tính ổn định của hệ thống sau mỗi lần cập nhật từ project chính
- Tích hợp vào quy trình CI/CD để đảm bảo chất lượng phần mềm liên tục

---

## 🛠️ Công nghệ sử dụng

| Công nghệ          | Mô tả                          |
| ------------------ | ------------------------------ |
| .NET 8/9           | Framework chính                |
| C#                 | Ngôn ngữ lập trình             |
| NUnit3             | Framework viết Unit Test       |
| Selenium WebDriver | Tự động hóa trình duyệt        |
| Page Object Model  | Thiết kế giúp tái sử dụng code |
| GitHub Actions     | Tích hợp CI/CD                 |

---

## 📁 Cấu trúc thư mục

Test-Auto-SellPhone/<br>
├── pageObjects/ # Các lớp đại diện trang web<br>
├── Tests/ # Các test case NUnit<br>
│ └── User/ # Test chức năng người dùng<br>
├── Utilities/ # Config, helpers, base test<br>
├── TestBase.cs # Khởi tạo Selenium driver<br>
├── main.csproj # File project<br>
├── Test-Auto-SellPhone.sln # File solution<br>

---

## ▶️ Hướng dẫn chạy test cục bộ

```bash
# Bước 1: Cài package và khôi phục dependencies
dotnet restore Test-Auto-SellPhone.sln

# Bước 2: Build project
build

# Bước 3: Chạy toàn bộ test
test

# Hoặc chạy theo Category
testcategory Login // Truyền category hợp lệ
```
