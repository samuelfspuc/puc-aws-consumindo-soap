using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puc.Aws.Samuel.Web.Models
{
    public class AddIntegerViewModel
    {
        public AddIntegerViewModel()
        {
 
        }

        [Display(Name = "Informe o Arg 1"), Required]
        public int Arg1 { get; set; }

        [Display(Name = "Informe o Arg 2"), Required]
        public int Arg2 { get; set; }

    }
}
