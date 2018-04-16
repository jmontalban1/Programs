using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Star_TED.Data.Entities
{
    [Table("Schools")]
    public class School
    {
        [Key]
        [StringLength(10, ErrorMessage = "School Code is is only 10 characters")]

        public string SchoolCode { get; set; }

        [StringLength(50, ErrorMessage = "School Name is is only 50 characters")]
        [Required(ErrorMessage = "SchoolCode Tuition is required!")]
        public string SchoolName { get; set; }

    }
}
