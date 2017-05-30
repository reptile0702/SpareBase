namespace SparesBaseAdministrator
{
    public class Action
    {
        public Action(int id, string name, string text)
        {
            Id = id;
            Name = name;
            Text = text;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
