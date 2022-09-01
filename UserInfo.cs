namespace BookingSystem
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name {
            get { return FirstName + " " + LastName; }
            set {}
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int MobileNumber { get; set; }
    }
}
