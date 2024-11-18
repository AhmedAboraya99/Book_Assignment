namespace Book_Assignment.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Author>? Authors { get; set; }
    }
}
