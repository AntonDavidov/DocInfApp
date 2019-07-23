namespace SharedLibrary
{
    /// <summary>
    /// Интерфейс, представляющий функционал Отображения, используемый Презентером.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Метод вызывает внутри Презентера метод, вызывающий сообщение MessageBox на форме.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="caption">Текст заголовка.</param>
        void ShowMessage(string message, string caption);
    }
}
