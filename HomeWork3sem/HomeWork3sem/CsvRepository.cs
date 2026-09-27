using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork3sem
{
    /// <summary>
    /// Репозиторий для данных из CSV-файлов
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;
        /// <summary>
        /// Конструктор, задающий папку с CSV-файлами.
        /// </summary>
        /// <param name="basePath"> Путь к папке с файлами </param>
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }
        /// <summary>
        /// Загружает кураторов из файла curator.csv.
        /// </summary>
        /// <returns> Список объектов Curator </returns>
        public List<Curator> GetCurators()
        {
            List<Curator> result = new List<Curator>();
            string path = Path.Combine(_basePath, "curator.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 3) continue;
                Curator c = new Curator();
                c.Id = int.Parse(parts[0]);
                c.FullName = parts[1].Replace('_', ' ');
                c.Specialty = parts[2].Replace('_', ' ');
                result.Add(c);
            }
            return result;
        }
        /// <summary>
        /// Загружает залы из файла hall.csv.
        /// </summary>
        /// <returns> Список объектов Hall </returns>
        public List<Hall> GetHalls()
        {
            List<Hall> result = new List<Hall>();
            string path = Path.Combine(_basePath, "hall.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 4) continue;
                Hall h = new Hall();
                h.Id = int.Parse(parts[0]);
                h.Name = parts[1].Replace('_', ' ');
                h.Floor = int.Parse(parts[2]);
                h.Area = int.Parse(parts[3]);
                result.Add(h);
            }
            return result;
        }
        /// <summary>
        /// Загружает экспонаты из файла exhibit.csv.
        /// </summary>
        /// <returns> Список объектов Exhibit </returns>
        public List<Exhibit> GetExhibits()
        {
            List<Exhibit> result = new List<Exhibit>();
            string path = Path.Combine(_basePath, "exhibit.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 6) continue;
                int id = int.Parse(parts[0]);
                string name = parts[1].Replace('_', ' ');
                int curatorId = int.Parse(parts[2]);
                int hallId = int.Parse(parts[3]);
                int year = int.Parse(parts[4]);
                decimal price = decimal.Parse(parts[5]);

                Exhibit e = new Exhibit(id, name, curatorId, hallId, year, price);
                result.Add(e);
            }
            return result;
        }
    }
}
