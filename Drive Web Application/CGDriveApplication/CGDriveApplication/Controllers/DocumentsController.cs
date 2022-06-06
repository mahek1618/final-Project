using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CGDriveApplication.Models;
using CGDriveApplication.RequestModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CGDriveApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly CG_DocsContext _cgDocument;
            private readonly IHostingEnvironment _environment;
        public DocumentsController(CG_DocsContext cgDocument, IHostingEnvironment environment)
        {
            _cgDocument = cgDocument;
            _environment = environment;
        }
        // GET: api/Documents
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Documents/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Documents
        [HttpPost]
        public IActionResult Upload(List<IFormFile> files)
        {
            long fsize = files.Sum(f => f.Length);
            var RootPath = Path.Combine(_environment.ContentRootPath, "Resources", "Documents");
            if(!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);
                foreach(var file in files)
                {
                    var filePath = Path.Combine(RootPath, file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        var Documents = new Documents()
                        {
                            DocName = file.FileName,
                            ContentType = file.ContentType,
                            Size = (int)file.Length,
                        };
                        file.CopyTo(stream);
                        _cgDocument.Documents.Add(Documents);
                        _cgDocument.SaveChanges();
                    }
                }
            return Ok(new { count = files.Count, fsize });
        }
        //[HttpPost]
        //public IActionResult Download(int id)
        //{
        //    var Provider = new FileExtensionContentTypeProvider();
        //    var document = _cgDocument.Documents.Find(id);
        //    if (document == null)
        //        return NotFound();
        //    var file = Path.Combine(_environment.ContentRootPath, "Resources", "Documents", document.DocName);
        //    if (!Provider.TryGetContentType(file, out string ContentType))
        //    {
        //        ContentType = "application/octet-stream";
        //    }
        //    byte[] fileBytes;
        //    if (System.IO.File.Exists(file))
        //    {
        //        fileBytes = System.IO.File.ReadAllBytes(file);
        //    }
        //    else
        //        return NotFound();
        //    return File(fileBytes, ContentType, document.DocName);
        //}
        // PUT: api/Documents/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
