using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TASK1.Models.DirModels
{
    public class Dir
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(55)]
        public string Name { get; set; }

    }
}
