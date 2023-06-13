using praktika.Domain;

namespace praktika.DTO
{
    public class ReadUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public ReadUserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Phone = user.PhoneNumber;
            Adress = user.AreaName;
        }
    }
}
