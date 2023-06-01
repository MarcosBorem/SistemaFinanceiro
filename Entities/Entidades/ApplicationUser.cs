using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        //Customizar o IdentityUser
        [Column("USR_CPF")]
        public string CPF { get; set; }
    }
}
