namespace Academits.Karetskas.ListTask
{
    internal sealed class ListItem<T>
    {
        public T? Data { get; set; }

        public ListItem<T>? Next { get; set; }

        public ListItem() { }

        public ListItem(T data) : this(data, null) { }

        public ListItem(ListItem<T> linkToNextItem) : this(default, linkToNextItem) { }

        public ListItem(T? data, ListItem<T>? linkToNextItem)
        {
            Data = data;

            if (linkToNextItem is null)
            {
                Next = null;
            }
            else
            {
                Next = new ListItem<T>();

                Next.Data = linkToNextItem.Data;
                Next.Next = linkToNextItem.Next;
            }
        }

        public override string? ToString()
        {
            return Data is null ? "NULL" : Data.ToString();
        }
    }
}