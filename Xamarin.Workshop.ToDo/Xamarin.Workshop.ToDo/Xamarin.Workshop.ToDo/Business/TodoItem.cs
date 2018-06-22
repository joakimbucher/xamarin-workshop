using SQLite;

namespace Xamarin.Workshop.ToDo.Business
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDone { get; set; }
    }
}
