using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Product
{
    public class ProductCUDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "ველი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 10 სიმბოლოს")]
        public string Code { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "ველი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 50 სიმბოლოს")]
        public string Name { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "ველი უნდა შეიცავდეს მაქსიმუმ 255 სიმბოლოს")]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "ველი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 25 სიმბოლოს")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "ველი აუცილებელია")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ImportDate { get; set; }

        public IFormFile File { get; set; }
    }
}
