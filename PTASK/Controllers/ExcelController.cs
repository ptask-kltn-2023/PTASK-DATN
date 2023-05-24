using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OfficeOpenXml;
using PTASK.Interface;
using System;

namespace PTASK.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IWorkService _work;
        private readonly ITaskService _task;
        private IMemoryCache _cache;
        public ExcelController(IProjectService project, IWorkService work, ITaskService task, ITeamService team, IMemoryCache cache)
        {
            _work = work;
            _task = task;
            _cache = cache;
        }

        public async Task<IActionResult> Export()
        {
            var id = _cache.Get<string>("ProjectID");
            var resultWork = await _work.GetAllWorkByIdProject(id);
            var resultTask = await _task.GetAllTasks(id);

            // Tạo một package Excel mới
            using (var package = new ExcelPackage())
            {
                // Tạo một sheet Excel
                var worksheet = package.Workbook.Worksheets.Add("Thống kê");

                // Merge các ô và đặt giá trị cho title
                var titleRange = worksheet.Cells[1, 1, 1, 6];
                titleRange.Merge = true;
                titleRange.Value = "THỐNG KÊ CÔNG VIỆC";

                // Đặt kiểu font và định dạng cho title
                titleRange.Style.Font.Bold = true;
                titleRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Đặt tên cột
                worksheet.Cells[5, 1].Value = "Danh sách công việc";

                worksheet.Cells[6, 1].Value = "Tên công việc";
                worksheet.Cells[6, 2].Value = "Nhóm thực hiện";
                worksheet.Cells[6, 3].Value = "Thời gian bắt đầu";
                worksheet.Cells[6, 4].Value = "Thời gian kết thúc";
                worksheet.Cells[6, 5].Value = "Trạng thái";
                string teamName = "";
                int workSuccess = 0;
                // Đổ dữ liệu vào sheet
                for (int i = 0; i < resultWork.Count(); i++)
                {
                    worksheet.Cells[i + 7, 1].Value = resultWork[i].name;

                    if (resultWork[i].teamName.Count() > 0)
                    {
                        teamName = string.Join(", ", resultWork[i].teamName);
                    }
                    else
                    {
                        teamName = "Chưa có nhóm thực hiện";
                    }
                    worksheet.Cells[i + 7, 2].Value = teamName;
                    string startTime = resultWork[i].startTime.ToString("dd/MM/yyyy");
                    string endTime = resultWork[i].endTime.ToString("dd/MM/yyyy");

                    worksheet.Cells[i + 7, 3].Value = startTime;
                    worksheet.Cells[i + 7, 4].Value = endTime;

                    if (resultWork[i].status)
                    {
                        workSuccess++;
                        worksheet.Cells[i + 7, 5].Value = "Hoàn thành";
                    }
                    else
                    {
                        worksheet.Cells[i + 7, 5].Value = "Đang thực hiện";
                    }
                }

                // Định dạng cột
                //worksheet.Column(2).Style.Numberformat.Format = "#0";

                // Thiết lập header và định dạng cho header
                var headerTitleWork = worksheet.Cells[5, 1, 5, 1];
                headerTitleWork.Style.Font.Bold = true;

                var headerTableWork = worksheet.Cells[6, 1, 6, 5];
                headerTableWork.Style.Font.Bold = true;
                headerTableWork.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                headerTableWork.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                // Auto fit các cột
                worksheet.Cells.AutoFitColumns();

                int rowCount = resultWork.Count() + 8;
                // Đặt tên cột
                worksheet.Cells[rowCount, 1].Value = "Danh sách nhiệm vụ";
                worksheet.Cells[rowCount + 1, 1].Value = "Tên nhiệm vụ";
                worksheet.Cells[rowCount + 1, 2].Value = "Mô tả";
                worksheet.Cells[rowCount + 1, 3].Value = "Người thực hiện";
                worksheet.Cells[rowCount + 1, 4].Value = "Thuộc công việc";
                worksheet.Cells[rowCount + 1, 5].Value = "Thời gian bắt đầu";
                worksheet.Cells[rowCount + 1, 6].Value = "Thời gian kết thúc";
                worksheet.Cells[rowCount + 1, 7].Value = "Ngày bắt đầu";
                worksheet.Cells[rowCount + 1, 8].Value = "Ngày bắt đầu";
                worksheet.Cells[rowCount + 1, 9].Value = "Trạng thái";

                string memberName = "";
                int taskSucces = 0;

                // Đổ dữ liệu vào sheet
                for (int i = 0; i < resultTask.Count(); i++)
                {
                    worksheet.Cells[i + rowCount + 2, 1].Value = resultTask[i].name;
                    worksheet.Cells[i + rowCount + 2, 2].Value = resultTask[i].description;

                    if (resultTask[i].members.Count() > 0)
                    {
                        memberName = string.Join(", ", resultTask[i].members[i].name);
                    }
                    else
                    {
                        memberName = "Chưa có thành viên thực hiện";
                    }

                    worksheet.Cells[i + rowCount + 2, 3].Value = memberName;
                    worksheet.Cells[i + rowCount + 2, 4].Value = resultTask[i].workName;

                    string startHour = resultTask[i].startHour.ToString("hh:mm:ss tt");
                    string endHour = resultTask[i].endHour.ToString("hh:mm:ss tt");

                    worksheet.Cells[i + rowCount + 2, 5].Value = startHour;
                    worksheet.Cells[i + rowCount + 2, 6].Value = endHour;

                    string startDay = resultTask[i].startDay.ToString("dd/MM/yyyy"); ;
                    string endDay = resultTask[i].endDay.ToString("dd/MM/yyyy"); ;

                    worksheet.Cells[i + rowCount + 2, 7].Value = startDay;
                    worksheet.Cells[i + rowCount + 2, 8].Value = endDay;

                    if (resultTask[i].status)
                    {
                        taskSucces++;
                        worksheet.Cells[i + rowCount + 2, 9].Value = "Hoàn thành";
                    }
                    else
                    {
                        worksheet.Cells[i + rowCount + 2, 9].Value = "Đang thực hiện";
                    }
                }

                var headerTitleTask = worksheet.Cells[rowCount, 1, rowCount, 1];
                headerTitleTask.Style.Font.Bold = true;

                var headerTableTask = worksheet.Cells[rowCount + 1, 1, rowCount + 1, 9];
                headerTableTask.Style.Font.Bold = true;
                headerTableTask.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                headerTableTask.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                worksheet.Cells[2, 1].Value = "Số lượng công việc hoàn thành: " + workSuccess;
                worksheet.Cells[3, 1].Value = "Số lượng nhiệm vụ hoàn thành: " + taskSucces;
                // Auto fit các cột
                worksheet.Cells.AutoFitColumns();

                // Xuất file Excel
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Trả về file Excel
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Thống kê("+DateTime.Now+").xlsx");
            }
        }
    }
}
