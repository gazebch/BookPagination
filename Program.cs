// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        var mainBook = Enumerable.Range(1, 100);
        Console.WriteLine("Введите кол-во записей на одной странице");
        var pageLength = BookPageLength();
        while (true)
        {            
            Catalog();
            var checkPoint = Console.ReadLine();
            if (checkPoint == "q") break;
            switch (checkPoint)
            {
                case "1":
                    {
                        ViewPage(pageLength, mainBook);
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

    public static int BookPageLength()
    {
        int pageLength;
        while (true)
        {
            var tryPageLength = int.TryParse(Console.ReadLine(), out pageLength);
            if (!tryPageLength)
            {
                Console.WriteLine("неверно задано количество записей на странице");
                continue;
            }
            else
            {
                return pageLength;
            }
        }        
    }

    public static void ViewPage(int pageWidth, IEnumerable<int> book)  // просмотр заданной страницы
    {
        var pageCount = book.Count() / pageWidth;
        if (book.Count() % pageWidth != 0)
        {
            pageCount += 1;
        }
        Console.WriteLine($"Введите номер страницы (всего страниц {pageCount})");
        var numPage = NumberPageAccuracy(pageCount);
        PageStructure(numPage, pageWidth, book);
    }

    public static void ViewCompositionBook(IEnumerable<int> books) //вывод страницы в консоль
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public static int NumberPageAccuracy(int pageCount) //проверка существующей страницы
    {
        int numPage;
        while (true)
        {
            var tryNumPage = int.TryParse(Console.ReadLine(), out numPage);
            if (tryNumPage && pageCount >= numPage && numPage > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Такой страницы не существует. Введите верный номер страницы");
            }
        }
        return numPage;
    }

    public static void PageStructure(int numPage, int pageWidth, IEnumerable<int> book) //построение страницы
    {
        Console.WriteLine();
        var finalViewPage = book.Skip((numPage - 1) * pageWidth).Take(pageWidth);
        ViewCompositionBook(finalViewPage);
    }

    public static void Catalog()
    {
        Console.WriteLine("Команда \"1\" - просмотр книги по страницам");
        Console.WriteLine("Команда \"q\" - выйти из программы");
    }
}
