using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjShare.Shared.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public byte[] Icon { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public string Story { get; set; }
        public string Risk { get; set; }
        public AppUser Creator { get; set; }
        public string CreatorId { get; set; }
        public double FundsGoal { get; set; }
        public double FundsTotal { get; set; }
        public int FundersCount { get; set; }
        public DateTime Created { get; set; }
        public ProjectStatus Status { get; set; }
        
    }
}