namespace Study_Mosh_CSharp_Advanced.Lambda
{
    public class BookRepository
    {
        public static List<Book2> GetBooks()
        {
            return new List<Book2>
            {
                new Book2() {Title = "Title 1", Price = 15},
                new Book2() {Title = "Title 2", Price = 40},
                new Book2() {Title = "Title 3", Price = 9}
            };
        }
    }
}
