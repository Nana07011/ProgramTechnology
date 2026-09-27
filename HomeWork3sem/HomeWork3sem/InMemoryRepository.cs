using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HomeWork3sem
{
    /// <summary>
    /// Репозиторий с данными в памяти.
    /// </summary>
    public class InMemoryRepository
    {
        private List<Curator> _curators;
        private List<Hall> _halls;
        private List<Exhibit> _exhibits;
        /// <summary>
        /// Конструктор, заполняющий списки исходными данными.
        /// </summary>
        public InMemoryRepository()
        {
            _curators = new List<Curator>
            {
                new Curator { Id = 1, FullName = "Смирнова Е.В.", Specialty = "Реставратор"},
                new Curator { Id = 2, FullName = "Орлова М.И.", Specialty = "Искусствовед"},
                new Curator { Id = 3, FullName = "Петров А.С.", Specialty = "Историк"},
                new Curator { Id = 4, FullName = "Иванов И.И.", Specialty = "Реставратор"},
                new Curator { Id = 5, FullName = "Сидорова А.А.", Specialty = "Хранитель"}
            };
            _halls = new List<Hall>
            {
                new Hall {Id = 1, Name = "Античность", Floor = 2, Area = 200},
                new Hall {Id = 2, Name = "Средневековье", Floor = 1, Area = 150},
                new Hall {Id = 3, Name = "Ренессанс", Floor = 3, Area = 300},
                new Hall {Id = 4, Name = "Древний Египет", Floor = 1, Area = 120},
                new Hall {Id = 5, Name = "Cовременное искусство", Floor = 4, Area = 250}
            };
            _exhibits = new List<Exhibit>
            {
                new Exhibit(1, "Амфора",1,1,-500,50000),
                new Exhibit(2,"Статуя", 1, 1,-200,80000),
                new Exhibit (3,"Икона",2,2,1500,200000),
                new Exhibit (4,"Саркофаг",3, 4,-1000,1500000),
                new Exhibit (5,"Картина", 5, 5, 2020, 5000)
            };
        }
        /// <summary>
        /// Возвращает список кураторов.
        /// </summary>
        /// <returns> Список объектов Curator</returns>
        public List<Curator> GetCurators() { return _curators; }
        /// <summary>
        /// Возвращает список залов.
        /// </summary>
        /// <returns> Список объектов Hall </returns>
        public List<Hall> GetHalls() { return _halls; }
        /// <summary>
        /// Возвращает список экспонатов.
        /// </summary>
        /// <returns> Список объектов Exhibit </returns>
        public List<Exhibit> GetExhibits() { return _exhibits; }
    }
}
