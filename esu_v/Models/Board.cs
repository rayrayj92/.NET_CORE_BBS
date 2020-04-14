using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace esu_v.Models
{
    public class Board
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Title { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Content { get; set; }
        public string EsuDate { get; set; }
        public int NumViews { get; set; }
        public string EsuFile { get; set; }
        public string EsuFileURL { get; set; }

        public string EsuFile2 { get; set; }
        public string EsuFile2URL { get; set; }

        public string EsuFile3 { get; set; }
        public string EsuFile3URL { get; set; }

        [NotMapped]
        public IFormFile EsuUpload { get; set; }
        [NotMapped]
        public IFormFile EsuUpload2 { get; set; }
        [NotMapped]
        public IFormFile EsuUpload3 { get; set; }
    }
}
