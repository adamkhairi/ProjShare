using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjShare.Shared.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string CommentBody { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }
        public DateTime Created { get; set; }
    }
}
