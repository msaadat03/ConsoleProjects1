using Domain.Common;

namespace Domain.Models
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }

        public override string ToString()
        {
            return $"Group Id: {Id}; Name: {Name}; Teacher: {Teacher}; Room: {Room}";
        }
    }
}
