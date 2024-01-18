## Controller

Là một lớp kế từ thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
Action trong controller là một phương public (không được static)
Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
Các dịch vụ inject vào controller qua hàm tạo
Tạo controller bằng CLI
dotnet aspnet-codegenerator controller -name Product -namespace App.Controllers -outDir Controllers
View
Là file .cshtml
View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
Thêm thư mục lưu trữ View:
// {0} -> ten Action
// {1} -> ten Controller
// {2} -> ten Area

options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

options.AreaViewLocationFormats.Add("/MyArea/{1}/View/{1}/{0}.cshtml");
Truyền dữ liệu sang View
Model
ViewData
ViewBag
TempData
