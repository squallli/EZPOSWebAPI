using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EZPOSWebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EZPOSWebAPI.Controllers
{
    /// <summary>
    /// This class is used as an Demo.
    /// </summary>
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private POSContext db = null;
        public InventoryController(POSContext context)
        {
            db = context;
        }

       /// <summary>
       /// get all items
       /// </summary>
       /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var invs = (from ep in db.invs
                              join e in db.cataLog on ep.CatalogId equals e.CataLogId
                              where ep.CatalogId == e.CataLogId
                              select new
                              {
                                  ProductNo = ep.ProductNo,
                                  Desc = ep.Desc,
                                  img = ep.Img,
                                  ProductName = ep.ProductName,
                                  SaleQty = ep.SaleQty,
                                  StartQty = ep.StartQty,
                                  UnitPrice = ep.UnitPrice,
                                  CataLogId = ep.CatalogId,
                                  CataLogName = e.CataLogName
                              }).ToList();

            if (invs.Count > 0)return new ObjectResult(invs);
            else return NoContent();
        }


        /// <summary>
        /// 根據品號取得產品
        /// </summary>
        /// <param name="id">品號</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("api/[controller]/ProductId/{id}")]
        public IActionResult GetById(string id)
        {
            ICollection<Inventory> invs = db.invs.Where(e => e.ProductNo == id).ToList<Inventory>();
            if (invs.Count > 0) return new ObjectResult(invs);
            else return  NoContent();
        }

        /// <summary>
        /// 用產品類別取得產品
        /// </summary>
        /// <param name="cataLog">產品類別代碼</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("api/[controller]/CataLog/{cataLog}")]
        public IActionResult GetByCataLog(string cataLog)
        {
            ICollection<Inventory> invs = db.invs.Where(e => e.CatalogId == cataLog).ToList<Inventory>();


            if (invs.Count > 0) return new ObjectResult(invs);
            else return NoContent();
        }

        /// <summary>
        /// 新增新產品
        /// </summary>
        /// <param name="item">Inventory</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Inventory item)
        {
            try
            {
                db.invs.Add(item);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
            
        }
    }
}
