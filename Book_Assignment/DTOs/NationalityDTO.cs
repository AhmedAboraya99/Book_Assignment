namespace Book_Assignment.DTOs
{
    public class NationalityDTO
    {
        public string Name {  get; set; }
        //to add
        public List<int>? AuthorsId { get; set; }

    }
    public class NationalityToReturnDTO
    {
        public string Name { get; set; }

        //to return
        public List<AuthorDTO>? Authors { get; set; }

    }

}
