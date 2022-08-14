namespace Sample1.Models
{
    public class User
    {
        public Gender Gender { get; set; } = null!;
    }

    // avoid magic strings.
    public class Gender
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

}
