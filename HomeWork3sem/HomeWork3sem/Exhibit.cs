using System.Transactions;

namespace HomeWork3sem
{
    /// <summary>
    /// Класс экспонаты музея
    /// </summary>
    public class Exhibit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CuratorId { get; set; }
        public int HallId { get; set; }
        public int Year {  get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Конструктор, проверяющий что цена строго больше 0
        /// </summary>
        /// <param name="id"> Id экспоната</param>
        /// <param name="name">  Имя экспоната</param>
        /// <param name="curatorId"> Id куратора </param>
        /// <param name="hallId"> Id зала </param>
        /// <param name="year"> Год экспоната </param>
        /// <param name="price"> Цена экспоната </param>
        /// <exception cref="ArgumentOutOfRangeException"> Исключение, где значение выходит за границы </exception>
        public Exhibit(int id, string name, int curatorId, int hallId, int year, decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Цена должна быть положительной");
            }
            Id = id;
            Name = name;
            CuratorId = curatorId;
            HallId = hallId;
            Year = year;
            Price = price;
        }
        /// <summary>
        /// Является ли экспонат древним.
        /// </summary>
        /// <returns> true, если год меньше 1000; иначе false </returns>
        public bool IsAncient()
        {
            return Year < 1000;
        }
        /// <summary>
        /// Является ли экспонат ценным.
        /// </summary>
        /// <returns> true, если цена больше 1 000 000; иначе false </returns>
        public bool IsValuable
        {
            get{ return Price > 1000000; }
        }
        /// <summary>
        /// Представление экспоната.
        /// </summary>
        /// <returns> Строка Название (год, цена) </returns>
        public string GetInfo()
        {
            string YearStr = Year < 0 ? $"{-Year} до н.э." : Year.ToString();
            return $"{Name} ({YearStr}, {Price} руб.)";
        }
        /// <summary>
        /// Конструктор, проверяющий значение цены, если отрицательно выводит исключение
        /// </summary>
        /// <param name="Price"> Значение Цены </param>
        /// <exception cref="ArgumentOutOfRangeException"> Исключение границы </exception>
        
    }
}
