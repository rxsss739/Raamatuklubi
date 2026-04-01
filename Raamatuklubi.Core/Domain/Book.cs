using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raamatuklubi.Core.Domain
{
    public class Book
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserAddedID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime EntryCreatedAt { get; set; }
        public DateTime EntryModifiedAt { get; set; }
    }
}
