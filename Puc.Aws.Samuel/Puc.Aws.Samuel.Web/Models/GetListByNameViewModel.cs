using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puc.Aws.Samuel.Web.Models
{
    public class GetListByNameViewModel
    {
        public GetListByNameViewModel(string id, string nome, string ssn, string dob)
        {
            Id = id;
            Nome = nome;
            Ssn = ssn;
            Dob = dob;
        }

        [Display(Name = "ID")]
        public string Id { get; private set; }

        [Display(Name = "Name"), Required]
        public string Nome { get; private set; }

        [Display(Name = "SSN"), Required]
        public string Ssn { get; private set; }

        [Display(Name = "DOB"), Required]
        public string Dob { get; private set; }

    }
}
