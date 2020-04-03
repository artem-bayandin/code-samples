namespace CrossCutting.EnumExtensions
{
    public class EnumModel
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public EnumModel(int id, string name) : this(id, name, name) { }

        public EnumModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
