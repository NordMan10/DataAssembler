using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper.Internal;
using DataAssembler1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace DataAssembler1.Controllers
{
    //[Route("/passportData")]
    public class PassportDataController : Controller
    {
        public PassportDataController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        [Route("homepage")]
        public IActionResult Index()
        {
            return Content("Hello! It's the homepage");
        }

        [Route("addPassport")]
        [HttpPost]
        public IActionResult AddPassport([FromBody] object formData)
        {
            var jObject = JObject.Parse(formData.ToString());

            var jsonPassport = jObject["passport"];
            var jsonChildren = jObject["children"];

            var passport = JsonConvert.DeserializeObject<Passport>(jsonPassport.ToString());
            var children = JsonConvert.DeserializeObject<Dictionary<string, Child>>(jsonChildren.ToString());


            if (!_db.Passports.Contains(passport))
            {
                
                foreach (var child in children.Values)
                {
                    child.PassportNumber = passport.Number;
                    child.PassportSeries = passport.Series;

                    passport.Children.Add(child);
                    _db.Child.Add(child);
                }
                _db.Passports.Add(passport);
                _db.SaveChanges();
            }
            else
            {
                return StatusCode(201);
            }


            return Ok();
        }

        [Route("download/{series}/{number}")]
        public IActionResult ExportToExcel(string series, string number)
        {
            var passport = _db.Passports.Find(series, number);
            var children = _db.Child
                .Where(p => p.PassportSeries == series && p.PassportNumber == number).ToList();

            if (passport == null) return StatusCode(500, "Passport was not found! hey");

            var passportProperties = passport.GetType().GetProperties().ToList()
                .ToDictionary(property => property.Name,
                property => property.GetValue(passport));

            var childrenProperties = children.Select(child => child.GetType()
                    .GetProperties().ToList()
                    .ToDictionary(property => property.Name,
                        property => property.GetValue(child))).ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Passport");

            

            worksheet.Cell(1, 1).Value = "Passport";
            worksheet.Cell(1, 1).Style.Font.Bold = true;

            passportProperties.Remove("Children");

            var currentRow = 2;
            var currentColumn = 1;
            FillWorksheet(passportProperties, worksheet, currentRow, currentColumn);

            //foreach (var (key, value) in passportProperties)
            //{
            //    if (key == "Children") continue;
            //    var currentRow = 1;
            //    worksheet.Cell(currentRow, currentColumn).Value = key;
            //    worksheet.Cell(++currentRow, currentColumn++).Value = value;
            //}

            worksheet.Cell(5, 1).Value = "Children";
            worksheet.Cell(5, 1).Style.Font.Bold = true;
            currentColumn = 1;

            currentRow = 6;
            FillWorksheetByChildren(childrenProperties, worksheet, currentRow, currentColumn);



            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Passport.xlsx"
            );
        }

        private IXLWorksheet FillWorksheet(Dictionary<string, object> data, IXLWorksheet worksheet, 
            int startRow, int currentColumn)
        {
            var currentRow = startRow;

            foreach (var (key, value) in data)
            {
                worksheet.Cell(currentRow, currentColumn).Value = key;
                worksheet.Cell(++currentRow, currentColumn++).Value = value;
                currentRow = startRow;
            }

            return worksheet;
        }

        private IXLWorksheet FillWorksheetByChildren(List<Dictionary<string, object>> data, IXLWorksheet worksheet,
            int startRow, int currentColumn)
        {
            var currentRow = startRow;

            for (var i = 0; i < data.Count; i++)
            {
                foreach (var (key, value) in data[i])
                {
                    if (i == 0)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = key;
                    }
                    
                    worksheet.Cell(currentRow + 1, currentColumn++).Value = value;
                }

                // Сдвигаем начальное положение ряда для следующего ребенка, с учетом отсутствия заголовков
                currentRow = startRow + 1;
                currentColumn = 1;
            }

            

            return worksheet;
        }

    }
}