namespace Constructors
{
    public class Constructor
    {
        public readonly static string Name;

        static Constructor()
        {
            Name = DateTime.UtcNow.ToString("mm:ss:f");
        }

        public string GetName()
        {
            return Name;
        }
    }
}
