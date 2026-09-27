using System;
namespace HomeWork3sem
{
    internal class Program
    {
        /// <summary>
        /// Главное меню, с загрузкой данных и вызовами методов
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("1: InMemoryRepository");
            Console.WriteLine("2: CsvRepository");
            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Неверно введен символ.");
                return;
            }
            List<Curator> curators = new List<Curator>();
            List<Hall> halls = new List<Hall>();
            List<Exhibit> exhibits = new List<Exhibit>();
            try
            {
                switch (choice)
                {
                    case 1:
                        InMemoryRepository repository1 = new InMemoryRepository();
                        curators = repository1.GetCurators();
                        halls = repository1.GetHalls();
                        exhibits = repository1.GetExhibits();
                        break;
                    case 2:
                        CsvRepository repository2 = new CsvRepository("data");
                        curators = repository2.GetCurators();
                        halls = repository2.GetHalls();
                        exhibits = repository2.GetExhibits();
                        break;
                    default:
                        Console.WriteLine("Неверно введен символ.");
                        return;
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("1. FindCurator(Амфора):");
            Curator curator = FindCurator(exhibits, curators, "Амфора");
            Console.WriteLine(curator != null ? curator.GetInfo() : "Не найдено");

            Console.WriteLine("2. FindHall(exhibit Амфора):");
            Hall hall = FindHall(exhibits, halls, "Амфора");
            Console.WriteLine(hall != null ? hall.GetInfo() : "Не найдено");

            Console.WriteLine("3. GetTotalPrice:");
            Console.WriteLine($"{GetTotalPrice(exhibits)} руб.");

            Console.WriteLine("4. GetExhibitsByHallSortedByYear(Античность):");
            List<Exhibit> sorted = GetExhibitsByHallSortedByYear(exhibits, halls, "Античность");
            if (sorted.Count == 0)
                Console.WriteLine("Не найдено");
            else
                foreach (Exhibit exhibit in sorted)
                    Console.WriteLine($"{exhibit.Name} ({exhibit.Year})");

            Console.WriteLine("5. PrintAllExhibits:");
            PrintAllExhibits(exhibits, curators, halls);

            Console.WriteLine();
            Curator notFound = FindCurator(exhibits, curators, "Неизвестный экспонат");
            Console.WriteLine("Не найдено: FindCurator(Неизвестный экспонат) -> " +
                              (notFound == null ? "null" : notFound.GetInfo()));


        }
        /// <summary>
        /// Поиск куратора по названию экспоната.
        /// </summary>
        /// <param name="exhibits"> Список всех экспонатов </param>
        /// <param name="curators"> Список всех кураторов </param>
        /// <param name="exhibitName"> Название искомого экспоната </param>
        /// <returns> Объект Curator, либо null </returns>
        static Curator FindCurator(List<Exhibit> exhibits, List<Curator> curators, string exhibitName)
        {
            if (exhibits == null || curators == null) return null;
            Exhibit foundexhibit = null;
            foreach (Exhibit e in exhibits)
            {
                if (e.Name == exhibitName)
                {
                    foundexhibit = e;
                    break;
                }
            }
            if (foundexhibit == null) return null;

            foreach (Curator c in curators)
            {
                if (c.Id == foundexhibit.CuratorId)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Поиск зала по названию экспоната.
        /// </summary>
        /// <param name="exhibits">  Список всех экспонатов </param>
        /// <param name="halls"> Список всех залов </param>
        /// <param name="exhibitName"> Название искомого экспоната </param>
        /// <returns> Объект Hall, либо null </returns>
        static Hall FindHall(List<Exhibit> exhibits, List<Hall> halls, string exhibitName)
        {
            if (exhibits == null || halls == null) return null;
            Exhibit foundexhibit = null;
            foreach (Exhibit e in exhibits)
            {
                if (e.Name == exhibitName)
                {
                    foundexhibit = e;
                    break;
                }
            }
            if (foundexhibit == null) return null;

            foreach (Hall h in halls)
            {
                if (h.Id == foundexhibit.HallId)
                    return h;
            }
            return null;
        }
        /// <summary>
        /// Общая стоимость всех экспонатов.
        /// </summary>
        /// <param name="exhibits"> Список всех экспонатов </param>
        /// <returns> Сумма цен всех экспонатов </returns>
        static decimal? GetTotalPrice(List<Exhibit> exhibits)
        {
            if (exhibits == null) return null;
            decimal amount = 0;
            foreach (Exhibit e in exhibits)
            {
                amount += e.Price;
            }
            return amount;
        }
        /// <summary>
        /// Экспонаты указанного зала, отсортированные по году
        /// </summary>
        /// <param name="exhibits"> Список всех экспонатов </param>
        /// <param name="halls"> Список всех залов </param>
        /// <param name="hallName"> Название зала, для которого нужны экспонаты </param>
        /// <returns> Список экспонатов указанного зала, отсортированный по возрастанию года </returns>
        static List<Exhibit> GetExhibitsByHallSortedByYear(List<Exhibit> exhibits, List<Hall> halls, string hallName)
        {
            if (exhibits == null || halls == null) return null;
            int targetHallId = -1;
            foreach (Hall h in halls)
            {
                if (h.Name == hallName)
                {
                    targetHallId = h.Id;
                    break;
                }
            }
            if (targetHallId == 0) return new List<Exhibit>();

            List<Exhibit> filter = new List<Exhibit>();
            foreach (Exhibit e in exhibits)
            {
                if (e.HallId == targetHallId) filter.Add(e);
            }
            for (int i = 0; i < filter.Count - 1; i++)
            {
                for (int j = 0; j < filter.Count - 1 - i; j++)
                {
                    if (filter[j].Year > filter[j + 1].Year)
                    {
                        Exhibit temp = filter[j];
                        filter[j] = filter[j + 1];
                        filter[j + 1] = temp;
                    }
                }
            }
            return filter;
        }
        /// <summary>
        /// Вывод всех экспонатов с информацией о кураторе и зале
        /// </summary>
        /// <param name="exhibits"> Список всех экспонатов </param>
        /// <param name="curators"> Список всех кураторов </param>
        /// <param name="halls"> Список всех залов </param>
        static void PrintAllExhibits(List<Exhibit> exhibits, List<Curator> curators, List<Hall> halls)
        {
            if (exhibits == null || curators == null || halls == null) { return; }
            foreach (Exhibit e in exhibits)
            {
                Curator curator = null;
                foreach (Curator c in curators)
                {
                    if (c.Id == e.CuratorId)
                    {
                        curator = c;
                        break;
                    }
                }
                Hall hall = null;
                foreach (Hall h in halls)
                {
                    if (h.Id == e.HallId)
                    {
                        hall = h;
                        break;
                    }
                }
                string curatorName = curator != null ? curator.FullName : "Не найдено";
                string hallName = hall != null ? hall.Name : "Не найдено";
                int floor = hall != null ? hall.Floor : 0;
                Console.WriteLine($"\"{e.GetInfo()}\" - куратор {curatorName}, зал \"{hallName}\" ({floor} этаж)");
            }
        }
    }
}
