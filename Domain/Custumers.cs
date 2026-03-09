namespace Domain
{
    public class Custumers
    {
public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Profile { get; set; }
    }
}
