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
                _db.Passports.Add(passport);
                foreach (var child in children.Values)
                {
                    child.PassportNumber = passport.Number;
                    child.PassportSeries = passport.Series;

                    _db.Child.Add(child);
                }
                
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

            if (passport == null) return StatusCode(500, "Table was not found! hey");

            var properties = passport.GetType().GetProperties().ToList().ToDictionary(property => property.Name,
                property => property.GetValue(passport).ToString());


            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Passport");
                
            var currentColumn = 1;

            foreach (var propertyKey in properties.Keys)
            {
                var currentRow = 1;
                worksheet.Cell(currentRow, currentColumn).Value = propertyKey;
                worksheet.Cell(++currentRow, currentColumn).Value = properties[propertyKey];
                    
                currentColumn++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Passport.xlsx"
            );
        }

    }
}