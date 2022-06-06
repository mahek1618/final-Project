using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGDriveApplication.Models;
using CGDriveApplication.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGDriveApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly CG_DocsContext _cgfolder;
        public FolderController(CG_DocsContext cgfolder)
        {
            _cgfolder = cgfolder;
        }
        // GET: api/Folder
        [HttpGet]
        public IActionResult Get()
        {
            var getFolder = _cgfolder.Folder.ToList();
            return Ok(getFolder);
        }

        // GET: api/Folder/5
        [HttpGet("FolderId")]
        public IActionResult Get(int id)
        {
            var getFid = _cgfolder.Folder.FirstOrDefault(o => o.FolderId == id);
            return Ok(getFid);
        }

        // POST: api/Folder
        [HttpPost]
        public void Post([FromBody] FolderRequestModel value)
        {
            Folder Fd = new Folder()
            {
                FolderName = value.FolderName,
                FCreatedBy = value.FCreatedBy,
                FCreatedAt = DateTime.Now,
                IsDeleted=value.IsDeleted
            };
            _cgfolder.Folder.Add(Fd);
            _cgfolder.SaveChanges();
        }

        // PUT: api/Folder/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delfol = _cgfolder.Folder.Where(o => o.FolderId == id).ToList();
            delfol.ForEach(o => _cgfolder.Folder.Remove(o));
            _cgfolder.SaveChanges();
        }
    }
}
