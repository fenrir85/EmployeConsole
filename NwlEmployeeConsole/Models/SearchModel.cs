using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NwlEmployeeConsole.Models
{
    public class SearchModel
    {
        
        [Required]
        [StringLength(18)]
        public string WordKey { get; set; }
    }
}
