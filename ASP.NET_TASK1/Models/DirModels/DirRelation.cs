using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_TASK1.Models.DirModels
{
    public class DirRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Parent")]
        public int Id_Parent { get; set; }

        [ForeignKey("Child")]
        public int Id_Child { get; set; }

        public Dir Parent { get; set; }
        public Dir Child { get; set; }



    }
}
