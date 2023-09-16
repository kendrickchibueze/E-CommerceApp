namespace Core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        //Navigation property back to our identity user. Each AppUser would have one address so its one to one relationship
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}