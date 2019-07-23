using System.ComponentModel;

namespace SharedLibrary
{
    /// <summary>
    /// Интерфейс, представляющий функционал Презентера
    /// </summary>
    public interface IPresenter
    {
        #region Properties
        /// <summary>
        /// Ссылка на отображение(главную форму приложения)
        /// </summary>
        IView View { get; set; }
        /// <summary>
        /// Список Документов для привязки к контексту данных в главной форме.
        /// </summary>
        BindingList<Document> Documents { get; set; }
        /// <summary>
        /// Выбранный Документ.
        /// </summary>
        Document SelectedDocument { get; set; }
        /// <summary>
        /// Документ, установленный для работы с Позициями.
        /// </summary>
        Document DocumentForPositions { get; set; }
        /// <summary>
        /// Список Позиций для привязки к контексту данных в главной форме.
        /// </summary>
        BindingList<Position> Positions { get; set; }
        /// <summary>
        /// Выбранная Позиция.
        /// </summary>
        Position SelectedPosition { get; set; }
        #endregion

        #region Methods
        #region Documents

        /// <summary>
        /// Загрузка Документов из базы данных, либо подгрузка Документов, у которых пользователь изменил значения Позиций.
        /// </summary>
        void LoadDocuments();
        /// <summary>
        /// Поверка, является ли выбранный пользователем Документ добавленным.
        /// </summary>
        /// <returns>true, если выбранный Документ является добавленным, иначе false.</returns>
        bool IsSelectedDocumentAdded();
        /// <summary>
        /// Проверка, изменен ли пользователем хоть один Документ.
        /// </summary>
        /// <returns>true, если есть хоть одно изменившееся значение, иначе false.</returns>
        bool IsDocumentsChanged();
        /// <summary>
        /// Отмена всех изменений в Документах.
        /// </summary>
        void CancelDocumentsChanges();
        #endregion
        #region Positions

        /// <summary>
        /// Очистка всех Позиций.
        /// </summary>
        void ClearPositions();
        /// <summary>
        /// Загрузка всех Позиций в соответствии с выбранным в данный момент Документом.
        /// </summary>
        void LoadPositionsBySelectedDocument();
        /// <summary>
        /// Проверка, изменена ли пользователем хоть одна Позиция.
        /// </summary>
        /// <returns>true, если есть хоть одно изменившееся значение, иначе false.</returns>
        bool IsPositionsChanged();
        /// <summary>
        /// Отмена всех изменений в Позициях
        /// </summary>
        void CancelPositionsChanges();
        #endregion

        /// <summary>
        /// Сохранение всех изменений в базу данных.
        /// </summary>
        void SaveAllChanges();
        #endregion
    }
}