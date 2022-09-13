namespace Academits.Karetskas.ListTask
{
    internal sealed class ListItem<T>
    {
        public T? Data { get; set; }

        public ListItem<T>? Next { get; set; }

        public ListItem(T? data) : this(data, null) { }

        public ListItem(T? data, ListItem<T>? next)
        {
            Data = data;
            Next = next;
        }
    }
}