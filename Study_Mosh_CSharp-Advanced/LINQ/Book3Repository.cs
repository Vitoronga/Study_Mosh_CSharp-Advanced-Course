namespace Study_Mosh_CSharp_Advanced.LINQ
{
    public class Book3Repository
    {
        public IEnumerable<Book3> GetBooks()
        {
            return new List<Book3>()
            {
                new Book3() { Title = "Adventures of PI", Price = 4},
                new Book3() { Title = "Cracking the coding interview", Price = 15},
                new Book3() { Title = "C# Player's Guide", Price = 8},
                new Book3() { Title = "Computer Networks", Price = 5.50f},
                new Book3() { Title = "Computer Networks", Price = 9.99f}
            };
        }
    }
}
