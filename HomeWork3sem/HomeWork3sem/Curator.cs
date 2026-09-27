namespace HomeWork3sem
{
    /// <summary>
    /// Класс кураторы музея
    /// </summary>
    public class Curator
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public bool IsRestorer { get { return Specialty == "Реставратор"; } }
        
        /// <summary>
        /// Представление куратора.
        /// </summary>
        /// <returns> Строка ФИ (специальность) </returns>
        public string GetInfo() => $"{FullName} ({Specialty})";
        
    }
}
