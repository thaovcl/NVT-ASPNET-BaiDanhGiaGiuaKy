using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVTBaiDanhGiaGiuaKy.Models
{
    public class NvtProduct
    {
        public int NvtId { get; set; }

        [DisplayName("NVT: Họ và tên")]
        [Required(ErrorMessage = "NVT: chưa nhập dữ liệu")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "NVT: Họ tên chứa tối thiểu 5 ký tự và tối đa 100")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "NVT: Họ tên chỉ chứa các kí tự hoặc khoảng trắng")]
        public string NvtFullName { get; set; }

        [DisplayName("NVT: Ảnh")]
        [Required(ErrorMessage = "NVT: chưa nhập dữ liệu")]
        public string NvtImage { get; set; }

        [DisplayName("NVT: Số Lượng")]
        [Required(ErrorMessage = "NVT: chưa nhập dữ liệu")]
        [Range(1, 100, ErrorMessage = "NVT: Số lượng từ 1 đén 100")]
        public int NvtQuantity { get; set; }

        [DisplayName("NVT: Giá")]
        [Required(ErrorMessage = "NVT: chưa nhập dữ liệu")]
        [Range(0.01, double.MaxValue, ErrorMessage = "NVT:Giá phải lớn hơn 0")]
        public decimal NvtPrice { get; set; }


        [Required(ErrorMessage = "NVT: chưa nhập dữ liệu")]
        public bool NvtisActive { get; set; }

    }
}