using AppModel;
using SharedLibrary;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;

namespace AppPresenter
{
    /// <summary>
    /// Класс, представляющий логику работы с данными в форме(Презентер).
    /// </summary>
    [Export(typeof(IPresenter))]
    public class Presenter : IPresenter
    {
        #region Fields
        /// <summary>
        /// Ссылка на контекст данных Документов.
        /// </summary>
        DocContext docContext = new DocContext();
        /// <summary>
        /// Выполнена ли загрузка Документов в форму.
        /// </summary>
        bool docsLoaded;
        /// <summary>
        /// Массив номеров изменённых Документов.
        /// </summary>
        int[] changedDocNums;
        #endregion

        #region Properties
        /// <summary>
        /// Ссылка на отображение(главную форму приложения)
        /// </summary>
        public IView View { get; set; }
        /// <summary>
        /// Список Документов для привязки к контексту данных в главной форме.
        /// </summary>
        public BindingList<Document> Documents { get; set; } =
            new BindingList<Document>();
        /// <summary>
        /// Выбранный Документ.
        /// </summary>
        public Document SelectedDocument { get; set; }
        /// <summary>
        /// Документ, установленный для работы с Позициями.
        /// </summary>
        public Document DocumentForPositions { get; set; }
        /// <summary>
        /// Список Позиций для привязки к контексту данных в главной форме.
        /// </summary>
        public BindingList<Position> Positions { get; set; } =
            new BindingList<Position>();
        /// <summary>
        /// Выбранная Позиция.
        /// </summary>
        public Position SelectedPosition { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Presenter()
        {
            docContext.Configuration.ProxyCreationEnabled = false;

            Documents = docContext.Documents.Local.ToBindingList();
            Positions = docContext.Positions.Local.ToBindingList();
        }
        #endregion

        #region Methods
        #region Documents
        /// <summary>
        /// Загрузка Документов из базы данных, либо подгрузка Документов, у которых пользователь изменил значения Позиций.
        /// </summary>
        public void LoadDocuments()
        {
            try
            {
                if (changedDocNums != null && changedDocNums.Length != 0)
                {
                    string sqlString = "SELECT * FROM [dbo].[Documents] WHERE Number IN (";
                    for (int i = 0; i < changedDocNums.Length; i++)
                    {
                        docContext.Entry(Documents.First(d => d.Number == changedDocNums[i])).State = EntityState.Detached;
                        sqlString += "{" + i + "}, ";
                    }

                    sqlString = sqlString.Replace(", ", ")");
                    foreach (var doc in docContext.Database.SqlQuery<Document>(
                                                                    sqlString,
                                                                    changedDocNums.Cast<object>()
                                                                    .ToArray()))
                        docContext.Documents.Attach(doc);
                }
                else
                if (!docsLoaded)
                {
                    docContext.Documents.Load();
                    docsLoaded = true;
                }
            }
            catch (Exception ex)
            {
                CallMessageBox(ex.Message, "Ошибка!");
            }
        }
        /// <summary>
        /// Проверка, изменен ли пользователем хоть один Документ.
        /// </summary>
        /// <returns>true, если есть хоть одно изменившееся значение, иначе false.</returns>
        public bool IsDocumentsChanged()
        {
            return docContext.ChangeTracker
                             .Entries<Document>()
                             .Any(d => d.State == EntityState.Added ||
                                       d.State == EntityState.Modified ||
                                       d.State == EntityState.Deleted);
        }
        /// <summary>
        /// Поверка, является ли выбранный пользователем Документ добавленным.
        /// </summary>
        /// <returns>true, если выбранный Документ является добавленным, иначе false.</returns>
        public bool IsSelectedDocumentAdded()
        {
            return docContext.Entry(SelectedDocument).State == EntityState.Added;
        }
        /// <summary>
        /// Отмена всех изменений в Документах.
        /// </summary>
        public void CancelDocumentsChanges()
        {
            foreach (var entry in docContext.ChangeTracker.Entries<Document>())
            {
                switch (entry.State)
                {
                    case EntityState.Added: { entry.State = EntityState.Detached; break; }
                    case EntityState.Modified: { entry.State = EntityState.Unchanged; break; }
                    case EntityState.Deleted: { entry.State = EntityState.Unchanged; break; }
                    default: { break; }
                }
            }
        }
        #endregion
        #region Positions
        /// <summary>
        /// Загрузка всех Позиций в соответствии с выбранным в данный момент Документом.
        /// </summary>
        public void LoadPositionsBySelectedDocument()
        {
            if (DocumentForPositions != null)
            {
                if (docContext.Entry(DocumentForPositions).State != EntityState.Added)
                    try
                    {
                        docContext.Entry(DocumentForPositions).Collection(d => d.Positions).Load();
                    }
                    catch (Exception ex)
                    {
                        CallMessageBox(ex.Message, "Ошибка!");
                    }
            }
        }
        /// <summary>
        /// Очистка всех Позиций.
        /// </summary>
        public void ClearPositions()
        {
            int entriesCount = docContext.ChangeTracker.Entries<Position>().Count();
            for (int i = 0; i < entriesCount; i++)
                docContext.ChangeTracker
                          .Entries<Position>()
                          .First()
                          .State = EntityState.Detached;
        }
        /// <summary>
        /// Проверка, изменена ли пользователем хоть одна Позиция.
        /// </summary>
        /// <returns>true, если есть хоть одно изменившееся значение, иначе false.</returns>
        public bool IsPositionsChanged()
        {
            return docContext.ChangeTracker
                 .Entries<Position>()
                 .Any(p => p.State == EntityState.Added ||
                           p.State == EntityState.Modified ||
                           p.State == EntityState.Deleted);
        }
        /// <summary>
        /// Отмена всех изменений в Позициях
        /// </summary>
        public void CancelPositionsChanges()
        {
            foreach (var entry in docContext.ChangeTracker.Entries<Position>())
            {
                switch (entry.State)
                {
                    case EntityState.Added: { entry.State = EntityState.Detached; break; }
                    case EntityState.Modified: { entry.State = EntityState.Unchanged; break; }
                    case EntityState.Deleted: { entry.State = EntityState.Unchanged; break; }
                    default: { break; }
                }
            }
        }
        #endregion
        /// <summary>
        /// Сохранение всех изменений в базу данных.
        /// </summary>
        public void SaveAllChanges()
        {
            try
            {
                changedDocNums = docContext.ChangeTracker.Entries<Position>()
                                                    .Where(d => d.State == EntityState.Added ||
                                                                d.State == EntityState.Modified ||
                                                                d.State == EntityState.Deleted)
                                                    .Select(d => d.Entity.DocumentNum)
                                                    .Distinct().ToArray();
                docContext.SaveChanges();
            }
            catch (Exception ex)
            {
                CallMessageBox(ex.Message, "Ошибка!");
            }

        }
        /// <summary>
        /// Метод вызывает внутри Презентера метод, вызывающий сообщение MessageBox на форме.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="caption">Текст заголовка.</param>
        void CallMessageBox(string message, string caption)
        {
            if (View != null)
                View.ShowMessage(message, caption);
        }
        #endregion
    }
}
