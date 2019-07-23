using System;
using System.Collections.Generic;

namespace SharedLibrary
{
    /// <summary>
    /// Класс, представляющий Документ.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Document()
        {
            Positions = new HashSet<Position>();
        }
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Сумма.
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// Примечание.
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Коллекция Позиций.
        /// </summary>
        public ICollection<Position> Positions { get; set; }
    }
    /// <summary>
    /// Класс, представляющий Позицию.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Сумма.
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Номер документа.
        /// </summary>
        public int DocumentNum { get; set; }
        /// <summary>
        /// Ссылка на Документ.
        /// </summary>
        public Document Document { get; set; }
    }
}
