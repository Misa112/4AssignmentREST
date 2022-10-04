namespace _4AssignmentREST.Models
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Age + " " + ShirtNumber;
        }
    }
}
