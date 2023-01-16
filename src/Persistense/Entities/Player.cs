namespace Persistense.Entities
{
    public class Player
    {
        // ----------------------------------------------------------------------------------------------------
        // Public fields / properties
        // ----------------------------------------------------------------------------------------------------
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Id { get; set; }

        // ----------------------------------------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------------------------------------
        public Player() { }

        public Player(string userName, string firstName, string lastName, string color, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Color = color;
            Id = id;
        }
    }
}