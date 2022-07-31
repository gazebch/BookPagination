// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        var mainBook = Enumerable.Range(1, 100);
        Console.WriteLine("Введите кол-во записей на одной странице");
        var pageWidth = int.Parse(Console.ReadLine());
        while (true)
        {
            Catalog();
            var checkPoint = Console.ReadLine();
            if (checkPoint == "q") break;
            switch (checkPoint)
            {
                case "1":
                    {
                        ViewPage(pageWidth, mainBook);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введите нужную вам команду");
                        break;
                    }
            }
        }
    }

    public static void ViewPage(int pageWidth, IEnumerable<int> book)  //
    {
        var pageCount = book.Count() / pageWidth;
        if (book.Count() % pageWidth != 0) pageCount += 1;
        Console.WriteLine($"Введите номер страницы (всего страниц {pageCount})");
        int numPage;
        while (true)
        {
            numPage = int.Parse(Console.ReadLine());
            if (pageCount >= numPage) break;
            else Console.WriteLine("Такой страницы не существует. Введите верный номер страницы");
        }
        Console.WriteLine();
        if (numPage == 1)
        {
            var finalViewPage = book.Take(pageWidth);
            ViewCompositionBook(finalViewPage);
        }
        else
        {
            var finalViewPage = book.Skip((numPage - 1) * pageWidth).Take(pageWidth);
            ViewCompositionBook(finalViewPage);
        }
    }

    public static void ViewCompositionBook(IEnumerable<int> book)
    {
        foreach (var bookItem in book)
        {
            Console.WriteLine(bookItem);
        }
    }

    public static void Catalog()
    {
        Console.WriteLine("Команда \"1\" - просмотр книги по страницам");
        Console.WriteLine("Команда \"q\" - выйти из программы");
    }
}
