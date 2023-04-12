using Study_Mosh_CSharp_Advanced.Delegates;
using Study_Mosh_CSharp_Advanced.Events;
using Study_Mosh_CSharp_Advanced.ExceptionHandling;
//using Study_Mosh_CSharp_Advanced.ExtensionMethods;
using Study_Mosh_CSharp_Advanced.Generics;
using Study_Mosh_CSharp_Advanced.Lambda;
using Study_Mosh_CSharp_Advanced.LINQ;

namespace Study_Mosh_CSharp_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestGenerics1();
            //TestGenerics2();
            //TestDelegate();
            //TestLambda();
            //TestEvents();
            //TestExtensionMethods();
            //TestLINQ();
            //TestNullable();
            //TestDynamics();

            TestExceptionHandling();
        }


        // Test starters/components:


        private static void TestGenerics1()
        {
            MyUtilities<int> myUtilities = new MyUtilities<int>();
            Console.WriteLine(myUtilities.Max(10, 78));
            Console.WriteLine(myUtilities.Min(10, 78));
            Console.WriteLine(myUtilities.AreEqual(10, 78));

            MyUtilities<float> myUtilities2 = new MyUtilities<float>();
            Console.WriteLine(myUtilities2.Max(10.0999f, 82.09f));
            Console.WriteLine(myUtilities2.Min(10.0999f, 82.09f));
            Console.WriteLine(myUtilities2.AreEqual(10.0999f, 82.09f));
        }
        private static void TestGenerics2()
        {
            var number = new MyNullable<int>(5);
            Console.WriteLine("HasValue ? " + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());

            var character = new MyNullable<char>('i');
            Console.WriteLine("HasValue ? " + character.HasValue);
            Console.WriteLine("Value: " + character.GetValueOrDefault());

            var doubleNum = new MyNullable<double>();
            Console.WriteLine("HasValue ? " + doubleNum.HasValue);
            Console.WriteLine("Value: " + doubleNum.GetValueOrDefault());
        }
    

        private static void TestDelegate()
        {
            PhotoProcessor photoProcessor = new PhotoProcessor();
            PhotoFilters filters = new PhotoFilters();
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness; // using custom delegate
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;

            photoProcessor.Process("photo.jpg", filterHandler);
        }
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
        }


        private static void TestLambda()
        {
            // Example 1:
            //Func<int, int> square = number => number * number;
            //Func<int, int> square = Square;
            //Console.WriteLine(square(4));

            // Example 2:
            //const int factor = 5;
            //Func<int, int> multiplier = num => num * factor;
            //int result = multiplier(12);
            //Console.WriteLine(result);

            // Example 3:
            List<Book2> books = BookRepository.GetBooks();
            //List<Book2> cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            List<Book2> cheapBooks = books.FindAll(b => b.Price < 10);

            foreach (Book2 book in cheapBooks)
            {
                Console.WriteLine(book.Title + " - " + book.Price);
            }
        }
        private static int Square(int number)
        {
            return number * number;
        }
        private static bool IsCheaperThan10Dollars(Book2 book2)
        {
            return book2.Price < 10;
        }


        private static void TestEvents()
        {
            Video video = new Video() { Title = "Video 1" };
            VideoEncoder videoEncoder = new VideoEncoder(); // publisher 
            MailService mailService = new MailService(); // subscriber 
            MessageService messageService = new MessageService(); // subscriber 

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    
    
        private static void TestExtensionMethods()
        {
            string post = "This is supposed to be a very long sequence of words in a blog post.";
            string shortenedPost = post.Shorten(10);

            Console.WriteLine(shortenedPost);
        }


        private static void TestLINQ()
        {
            //TestLINQ1();
            //TestLINQ2();
            //TestLINQ3();
            //TestLINQ4();
            TestLINQ5();
        }
        private static void TestLINQ1()
        {
            var books = new Book3Repository().GetBooks();

            // Without LINQ:
            var cheapBooks = new List<Book3>();

            foreach (Book3 book in books)
            {
                if (book.Price < 10) cheapBooks.Add(book);
            }

            foreach (Book3 book in cheapBooks)
            {
                Console.WriteLine(book.Title + " " + book.Price);
            }

            // ---
            Console.WriteLine();

            // With LINQ:

            // LINQ Extension Methods
            var cheapBooks2 = books.Where(b => b.Price < 10) // Filters by the price
                                   .OrderBy(b => b.Title) // Orders by the title name
                                   .Select(b => b.Title) // Select the title property of all items
                                   .ToList(); // Convert the IEnumerable to a List

            foreach (var book in cheapBooks2)
            {
                Console.WriteLine(book);
                //Console.WriteLine(book.Title + " " + book.Price);
            }

            // LINQ Query Operators
            var cheapBooks3 =
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;

            foreach (var book in cheapBooks3)
            {
                Console.WriteLine(book);
            }
        }
        private static void TestLINQ2()
        {
            var books = new Book3Repository().GetBooks();

            var book = books.Single(b => b.Title.Equals("C# Player's Guide"));
            Console.WriteLine(book.Title + "\t" + book.Price);

            book = books.SingleOrDefault(b => b.Title.Equals("C# Player's Guiders"));
            Console.WriteLine(book == null);
        }
        private static void TestLINQ3()
        {
            var books = new Book3Repository().GetBooks();

            var book = books.First(b => b.Title.Equals("Computer Networks"));
            Console.WriteLine(book.Title + "\t" + book.Price);

            book = books.LastOrDefault(b => b.Title.Equals("Computer Networks"));
            Console.WriteLine(book.Title + "\t" + book.Price);
        }
        private static void TestLINQ4()
        {
            var books = new Book3Repository().GetBooks();

            var pagedBooks = books
                .Skip(2)
                .Take(3);

            foreach (var book in pagedBooks)
            {
                Console.WriteLine(book.Title + "\t" + book.Price);
            }
        }
        private static void TestLINQ5()
        {
            var books = new Book3Repository().GetBooks();

            var count = books.Count();
            Console.WriteLine(count);

            var max = books.Max(b => b.Price);
            var min = books.Min(b => b.Price);
            Console.WriteLine(max);
            Console.WriteLine(min);

            var maxBook = books.Single(b => b.Price == books.Max(b => b.Price));
            Console.WriteLine(maxBook.Title);

            var totalPrice = books.Sum(b => b.Price);
            Console.WriteLine(totalPrice);
        }
    

        private static void TestNullable()
        {
            DateTime? dateTime = new DateTime(2023, 1, 1);
            DateTime dateTime2 = dateTime.GetValueOrDefault();
            DateTime? dateTime3 = dateTime2;

            Console.WriteLine(dateTime3.GetValueOrDefault());

            DateTime? dateTime4 = null;
            DateTime dateTime5;

            if (dateTime4 != null)
                dateTime5 = dateTime4.GetValueOrDefault();
            else
                dateTime5 = DateTime.Today;

            Console.WriteLine(dateTime5);
        }


        private static void TestDynamics()
        {
            // Testing Reflection vs Dynamic:
            object obj = "Mosh";
            //obj.GetHashCode();

            // Calling method with Reflection:
            //var methodInfo = obj.GetType().GetMethod("GetHashCode");
            //methodInfo.Invoke(null, null);

            // Calling method with Dynamic:
            //dynamic excelObject = "Mosh";
            //excelObject.Optimize();

            //TestDynamics1();
            //TestDynamics2();
            TestDynamics3();
        }
        private static void TestDynamics1()
        {
            dynamic name = "Mosh";
            Console.WriteLine(name);

            name = 10;
            Console.WriteLine(name);
        }
        private static void TestDynamics2()
        {
            dynamic a = 10;
            dynamic b = 10;
            var c = a + b;
        }
        private static void TestDynamics3()
        {
            int i = 5;
            dynamic d = i;
            long l = d;
        }

        private static void TestExceptionHandling()
        {
            //TestExceptionHandling1();
            TestExceptionHandling2();
        }
        private static void TestExceptionHandling1()
        {
            StreamReader streamReader = null;
            //try
            //{
            //    //Calculator calculator = new Calculator();
            //    //int result = calculator.Divide(5, 0);
            //    streamReader = new StreamReader(@"c:\file.zip");
            //    streamReader.ReadToEnd();
            //    throw new Exception("Oops!");
            //}
            ////catch (DivideByZeroException ex)
            ////{
            ////    Console.WriteLine("You cannot divide by 0.");
            ////}
            ////catch (ArithmeticException ex)
            ////{
            ////    Console.WriteLine("");
            ////}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("An unexpected error ocurred.");
            //}
            //finally
            //{
            //    if (streamReader != null) streamReader.Dispose();
            //}


            // With "using" keyword:
            try
            {
                using (StreamReader streamReader2 = new StreamReader(@"c:\file.zip"))
                {
                    string content = streamReader2.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error ocurred.");
            }
        }

        private static void TestExceptionHandling2()
        {
            try
            {
                YoutubeAPI api = new YoutubeAPI();
                api.GetVideos("user");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}