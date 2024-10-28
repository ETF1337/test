
using Microsoft.AspNetCore.Mvc;
using MySpaApp.Models;
using MySpaApp.Repositories;
using OfficeOpenXml;
using System.IO;

namespace MySpaApp.Controllers

{   
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _repository.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Item item)
        {
            if (id != item.Id) return BadRequest();
            _repository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
     [HttpPost("export")]
public IActionResult ExportToExcel([FromBody] List<Item> items) 
{   
     { if (items == null || items.Count == 0) {
        return BadRequest("Нет данных для экспорта");
    }
    using (var package = new ExcelPackage()) {

        var worksheet = package.Workbook.Worksheets.Add("Items");
        worksheet.Cells[1, 1].Value = "Значение 1";
        worksheet.Cells[1, 2].Value = "Значение 2";

        int row = 2;
        foreach (var item in items)
        {
            worksheet.Cells[row, 1].Value = item.Id;
            worksheet.Cells[row, 2].Value = item.Name;
            row++;
        }

        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;
        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "items.xlsx");
    }
}
}}}