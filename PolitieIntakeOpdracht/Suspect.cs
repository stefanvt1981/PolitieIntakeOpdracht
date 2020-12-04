using System;
using System.ComponentModel.DataAnnotations;

namespace PolitieIntakeOpdracht
{
    public class Suspect
    {
        public long Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int? Age { get; set;  }

        [Required]
        public string CriminalAct { get; set; }

        [Required]
        public string ArrestLocation { get; set; }

        [Required]
        public DateTime? Date { get; set; }
    }
}
