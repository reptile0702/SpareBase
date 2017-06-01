namespace SparesBaseAdministrator
{
    public class Action
    {
        public Action(int id, string name, string templateText)
        {
            Id = id;
            Name = name;
            TemplateText = templateText;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TemplateText { get; set; }
    }
}
