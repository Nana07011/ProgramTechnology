namespace HomeWork3sem
{
    /// <summary>
    /// Класс зал музея
    /// </summary>
    public class Hall
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int Floor {  get; set;}
        public int Area { get; set;}
        /// <summary>
        ///  Находится ли зал выше первого этажа.
        /// </summary>
        /// <returns> true, если этаж больше 1; иначе false </returns>
        public bool IsUpper
        {
            get{ return Floor > 1; }
        }
        /// <summary>
        /// Представление зала.
        /// </summary>
        /// <returns> Строка Название (этаж, Площадь) </returns>
        public string GetInfo()
        {
            return $"{Name} ({Floor} этаж, {Area} м2)";
        }
    }
}
