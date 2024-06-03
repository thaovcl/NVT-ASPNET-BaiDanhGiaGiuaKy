using NVTBaiDanhGiaGiuaKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NVTBaiDanhGiaGiuaKy.Controllers
{
    public class NVTProductController : Controller
    {
        private static List<NvtProduct> nvtProducts = new List<NvtProduct>()
        {
            new NvtProduct(){NvtId=221090012,NvtFullName="Nguyễn Văn Thạo",NvtImage="https://example.com/laptop.jpg",NvtQuantity=10,NvtPrice=1500,NvtisActive=true},
            new NvtProduct(){NvtId=221090011,NvtFullName="Nguyễn Thạo Văn",NvtImage="https://example.com/laptop.jpg",NvtQuantity=10,NvtPrice=1500,NvtisActive=true},
        };
        // GET: NVT
        public ActionResult NvtIndex()
        {
            return View(nvtProducts);
        }

        public ActionResult NvtCreate()
        {
            var nvtModel = new NvtProduct();
            return View(nvtModel);
        }

        [HttpPost]
         public ActionResult NvtCreate(NvtProduct newNvtProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newNvtProduct);
            }

            // Tạo ID mới cho sản phẩm
            if (nvtProducts.Any())
            {
                newNvtProduct.NvtId = nvtProducts.Max(p => p.NvtId) + 1;
            }
            else
            {
                newNvtProduct.NvtId = 1; // Nếu danh sách rỗng, bắt đầu với ID = 1
            }

            nvtProducts.Add(newNvtProduct);
            return RedirectToAction("NvtIndex");
        }
        public ActionResult NvtEdit(int id)
        {
            var product = nvtProducts.Find(p => p.NvtId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }
        public ActionResult NvtDetails(int id)
        {
            var product = nvtProducts.Find(p => p.LvhId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit(NvtProduct lvhProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(lvhProduct);
            }

            var product = NvtProducts.Find(p => p.LvhId == lvhProduct.LvhId);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Cập nhật các giá trị
            product.LvhFullName = lvhProduct.NvtFullName;
            product.LvhImage = lvhProduct.NvtImage;
            product.LvhQuantity = lvhProduct.NvtQuantity;
            product.LvhPrice = lvhProduct.NvtPrice;
            product.LvhIsActive = lvhProduct.NvtisActive;

            return RedirectToAction("LvhIndex");
        }
    }
}