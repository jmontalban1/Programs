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
    [Table("Programs")]
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }


        [Required(ErrorMessage = "Program Name is required!")]
        [StringLength(100, ErrorMessage = "School Name is is only 100 characters")]
        public string ProgramName { get; set; }



        [Required(ErrorMessage = "Diploma Name is required!")]
        [StringLength(100, ErrorMessage = "Diploma Name is is only 100 characters")]

        private string _DiplomaName { get; set; }



        public string DiplomaName

        {
            get
            {
                return _DiplomaName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _DiplomaName = value;
                }
                else
                {
                    _DiplomaName = string.Empty;
                }
            }

        }


        [StringLength(10, ErrorMessage = "School Code is is only 10 characters")]
        [Required(ErrorMessage = "School Code is required!")]
        //[ForeignKey("SchoolCode")]
        public string SchoolCode { get; set; }




        [Required(ErrorMessage = "Tuition is required!")]

        public decimal Tuition { get; set; }

        [Required(ErrorMessage = "Internationl Tuition is required!")]

        public decimal InternationalTuition { get; set; }

        //public bool Discontinued { get; set; } 

    }
}
