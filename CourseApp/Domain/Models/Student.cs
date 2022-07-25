using Domain.Common;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Group Group { get; set; }

        public override string ToString()
        {
            return $"Student Id: {Id}; Name: {Name}; Surname: {Surname}; Age: {Age}; Group [{(Group == null ? "<Empty>" : Group.ToString())}]";
        }
    }
}
