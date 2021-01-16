using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Product
{
    public class ShopCUDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "ველი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 50 სიმბოლოს")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "ველი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 50 სიმბოლოს")]
        public string Address { get; set; }

        [Required(ErrorMessage = "ველი უნდა შეიცავდეს მაქსიმუმ 255 სიმბოლოს")]
        public int TypeId { get; set; }

        public IList<ShopProductDTO> ShopProducts { get; set; }
    }
}
