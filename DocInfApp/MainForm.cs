using SharedLibrary;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocInfApp
{
    /// <summary>
    /// Класс представляющий главную форму приложения
    /// </summary>
    public partial class MainForm : Form, IView
    {
        #region Fields
        /// <summary>
        /// Сссылка а Презентер.
        /// </summary>
        [Import]
        IPresenter presenter;

        /// <summary>
        /// Список ссылок на добавленные ряды Документов(используется для закраски
        /// фона ячейки зелёным цветом).
        /// </summary>
        List<DataGridViewRow> addedDocGridViewRows = new List<DataGridViewRow>();
        /// <summary>
        /// Список ссылок на измененные ряды Документов(используется для закраски
        /// фона ячейки серым цветом).
        /// </summary>
        List<DataGridViewRow> changedDocGridViewRows = new List<DataGridViewRow>();
        /// <summary>
        /// Текущий изменяемый документ.
        /// </summary>
        Document curChangingDoc;

        /// <summary>
        /// Список ссылок на добавленные ряды Позиций(используется для закраски
        /// фона ячейки зелёным цветом).
        List<DataGridViewRow> addedPosGridViewRows = new List<DataGridViewRow>();
        /// <summary>
        /// Список ссылок на измененные ряды Позиций(используется для закраски
        /// фона ячейки серым цветом).
        /// </summary>
        List<DataGridViewRow> changedPosGridViewRows = new List<DataGridViewRow>();
        /// <summary>
        /// Текущая изменяемая позиция.
        /// </summary>
        Position curChangingPos;
        /// <summary>
        /// Установщик даты.
        /// </summary>
        DateTimePicker datePicker = new DateTimePicker();
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            string catalogPath = directoryInfo.Parent
                                              .Parent
                                              .Parent.FullName + "\\AppPresenter\\bin\\Debug\\AppPresenter.dll";
            if (File.Exists(catalogPath))
            {
                AssemblyCatalog catalog = new AssemblyCatalog(Assembly.LoadFrom(catalogPath));
                CompositionContainer container = new CompositionContainer(catalog);
                container.SatisfyImportsOnce(this);
            }
            else
            {
                MessageBox.Show("Необходимо распаковать сборки AppPresenter.dll, AppModel.dll, Entities.dll и EntityFramework.dll(версии 6.2.61023.0) по адресу 'AppPresenter\\bin\\Debug\\' относительно корневой папки проекта.", "Ошибка загрузки");
                Close();
                return;
            }

            presenter.View = this;
            #region docsGridView configuration

            docsGridView.DataSource = presenter.Documents;
            docsGridView.AutoGenerateColumns = false;
            docsGridView.AllowUserToAddRows = false;
            docsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            docsGridView.AllowUserToResizeColumns = true;
            docsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            docsGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            docsGridView.Columns[0].HeaderText = "Номер";
            docsGridView.Columns[1].HeaderText = "Дата";
            docsGridView.Columns[2].HeaderText = "Сумма";
            docsGridView.Columns[3].HeaderText = "Примечание";
            docsGridView.Columns[4].Visible = false;
            docsGridView.ContextMenuStrip = docsContextMenuStrip;

            datePicker.Visible = false;
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.ValueChanged += (s, eArgs) =>
            {
                docsGridView.CurrentCell.Value = datePicker.Value;
            };
            docsGridView.Controls.Add(datePicker);
            #endregion
            #region positionsGridView configurstion
            positionsGridView.DataSource = presenter.Positions;
            positionsGridView.AllowUserToAddRows = false;
            positionsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            positionsGridView.AllowUserToResizeColumns = true;
            positionsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            positionsGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            positionsGridView.Columns[0].HeaderText = "Номер";
            positionsGridView.Columns[1].HeaderText = "Наименование";
            positionsGridView.Columns[2].HeaderText = "Сумма";
            positionsGridView.Columns[3].Visible = false;
            positionsGridView.Columns[4].Visible = false;
            positionsGridView.ContextMenuStrip = positionsContextMenuStrip;
            #endregion

            presenter.LoadDocuments();
            positionsGroupBox.Enabled = false;
        }
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            if (presenter.IsDocumentsChanged() || presenter.IsPositionsChanged())
            {
                presenter.SaveAllChanges();

                ClearDocumentsGraphics();
                ClearPositions();
                DisablePositionsGroupBox();

                //для подгрузки сущностей с изменившейся суммой
                presenter.LoadDocuments();
                docsGridView.Sort(docsGridView.Columns[0], ListSortDirection.Ascending);
            }
            else
                MessageBox.Show("Необходимо внести изменения для сохранения дванных в базу данных", "Сообщение");
        }

        #region Documents DataGridView
        private void DocsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (docsGridView.CurrentRow != null)
                presenter.SelectedDocument = docsGridView.CurrentRow.DataBoundItem as Document;
        }
        private void DocsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы собираетесь удалить документ. Продолжить?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
        private void DocsGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            addedDocGridViewRows.Remove(e.Row);
            changedDocGridViewRows.Remove(e.Row);
        }
        private void DocsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Если происходит редактирование, а не добаление документа
            if (docsGridView.CurrentRow.DataBoundItem != null)
                curChangingDoc = new Document()
                {
                    Date = presenter.SelectedDocument.Date,
                    Sum = presenter.SelectedDocument.Sum,
                    Note = presenter.SelectedDocument.Note
                };
            if (docsGridView.Columns[e.ColumnIndex].HeaderText == "Дата")
            {
                docsGridView.VirtualMode = true;
                Rectangle rectangle = docsGridView.GetCellDisplayRectangle(e.ColumnIndex,
                                                                         e.RowIndex, true);
                datePicker.Location = rectangle.Location;
                datePicker.Size = new Size(rectangle.Width, rectangle.Height);
                datePicker.Visible = true;
            }
        }
        private void DocsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Если происходит редактирование, а не добаление документа
            if (curChangingDoc != null &&
                !addedDocGridViewRows.Contains(docsGridView.Rows[e.RowIndex]))
                if (curChangingDoc.Date != presenter.SelectedDocument.Date ||
                    curChangingDoc.Sum != presenter.SelectedDocument.Sum ||
                    curChangingDoc.Note != presenter.SelectedDocument.Note)
                {
                    docsGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    changedDocGridViewRows.Add(docsGridView.Rows[e.RowIndex]);
                }
            if (docsGridView.Columns[e.ColumnIndex].HeaderText == "Дата")
            {
                datePicker.Visible = false;
                docsGridView.VirtualMode = false;
            }
        }
        private void DocsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex != 2)
                docsGridView.BeginEdit(false);
        }
        #endregion
        #region Documents ContextMenu Buttons
        private void OpenDocDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocumentDetails();
        }
        private void AddDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDocument();
        }
        private void DeleteDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDocument();
        }
        #endregion
        #region Documents Buttons
        private void AddDocButton_Click(object sender, EventArgs e)
        {
            AddDocument();
        }
        private void DeleteDocButton_Click(object sender, EventArgs e)
        {
            DeleteDocument();
        }
        private void OpenDocumentsDetailsButton_Click(object sender, EventArgs e)
        {
            OpenDocumentDetails();
        }
        private void CancelDocChangesButton_Click(object sender, EventArgs e)
        {
            if (presenter.IsDocumentsChanged())
                if (MessageBox.Show("Все внесённые изменения в документы будут потеряны. Продолжить?",
                    "Сообщение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    addedDocGridViewRows.ForEach(row => row.DefaultCellStyle.BackColor = Color.White);
                    changedDocGridViewRows.ForEach(row => row.DefaultCellStyle.BackColor = Color.White);
                    addedDocGridViewRows.Clear();
                    changedDocGridViewRows.Clear();
                    presenter.CancelDocumentsChanges();

                    docsGridView.Sort(docsGridView.Columns[0], ListSortDirection.Ascending);
                }
        }
        #endregion

        #region Positions DataGridView
        private void PositionsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (positionsGridView.CurrentRow != null)
                presenter.SelectedPosition = positionsGridView.CurrentRow.DataBoundItem as Position;
        }
        private void PositionsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы собираетесь удалить позицию. Продолжить?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
        private void PositionsGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            addedPosGridViewRows.Remove(e.Row);
            changedPosGridViewRows.Remove(e.Row);
        }
        private void PositionsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Если происходит редактирование, а не удаление позиции
            if (positionsGridView.CurrentRow.DataBoundItem != null)
                curChangingPos = new Position()
                {
                    Name = presenter.SelectedPosition.Name,
                    Sum = presenter.SelectedPosition.Sum
                };
        }
        private void PositionsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Если происходит редактирование, а не удаление позиции
            if (curChangingPos != null &&
                !addedPosGridViewRows.Contains(positionsGridView.Rows[e.RowIndex]))
                if (curChangingPos.Name != presenter.SelectedPosition.Name ||
                    curChangingPos.Sum != presenter.SelectedPosition.Sum)
                {
                    positionsGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    changedPosGridViewRows.Add(positionsGridView.Rows[e.RowIndex]);
                }
        }
        private void PositionsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                positionsGridView.BeginEdit(false);
        }
        private void PositionsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (positionsGridView.Columns[e.ColumnIndex].HeaderText == "Сумма")
            {
                double result;
                if (!double.TryParse(e.FormattedValue.ToString(), out result))
                    MessageBox.Show("Необходимо ввестии целое положительное число", "Ошибка валидации");
            }
        }
        private void PositionsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion
        #region Positions ContextMenu Buttons
        private void AddPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPosition();
        }
        private void DeletePosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }
        #endregion
        #region Positions Buttons
        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            AddPosition();
        }
        private void DeletePositionButton_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }
        private void CancelPositionsChangesButton_Click(object sender, EventArgs e)
        {
            if (presenter.IsPositionsChanged())
                if (MessageBox.Show("Все внесённые изменения в позиции для выбранного документа будут потеряны. Продолжить?",
                    "Сообщение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    addedPosGridViewRows.ForEach(row => row.DefaultCellStyle.BackColor = Color.White);
                    changedPosGridViewRows.ForEach(row=> row.DefaultCellStyle.BackColor = Color.White);
                    addedPosGridViewRows.Clear();
                    changedPosGridViewRows.Clear();
                    presenter.CancelPositionsChanges();
                }
        }
        #endregion

        #region Support Methods
        void OpenDocumentDetails()
        {
            if (presenter.Documents.Count != 0)
            {
                if (presenter.SelectedDocument == null)
                    MessageBox.Show("Нет выбранного докумета для открытия детализации", "Сообщение");
                else if (presenter.IsSelectedDocumentAdded())
                    MessageBox.Show("Нельзя открыть детализацию докумета, не добавленного в базу данных", "Сообщение");
                else
                {
                    positionsGroupBox.Enabled = true;
                    if (presenter.IsPositionsChanged())
                        if (MessageBox.Show("Все внесённые изменения в позиции для предыдущего выбранного документа будут потеряны. Продолжить?",
                                            "Сообщение",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            addedPosGridViewRows.Clear();
                            changedPosGridViewRows.Clear();
                        }
                        else
                            return;
                        
                    presenter.ClearPositions();

                    presenter.DocumentForPositions = presenter.SelectedDocument;
                    docForPositionsNumLabel.Text = presenter.DocumentForPositions.Number.ToString();

                    presenter.LoadPositionsBySelectedDocument();

                }
            }
            else
                MessageBox.Show("Необходимо добавить документ для открытия по нему детализации", "Сообщение");
        }
        void AddDocument()
        {
            presenter.Documents.Add(new Document());
            docsGridView.Rows[docsGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
            addedDocGridViewRows.Add(docsGridView.Rows[docsGridView.Rows.Count - 1]);
        }
        void DeleteDocument()
        {
            if (MessageBox.Show("Вы собираетесь удалить документ. Продолжить?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                addedDocGridViewRows.Remove(docsGridView.CurrentRow);
                changedDocGridViewRows.Remove(docsGridView.CurrentRow);
                presenter.Documents.Remove(presenter.SelectedDocument);

                if (presenter.Documents.Count == 0 ||
                    !presenter.Documents.Contains(presenter.DocumentForPositions))
                {
                    ClearPositions();
                    DisablePositionsGroupBox();
                }                   
            }
        }
        void ClearDocumentsGraphics()
        {
            addedDocGridViewRows.ForEach(row => row.DefaultCellStyle.BackColor = Color.White);
            changedDocGridViewRows.ForEach(row => row.DefaultCellStyle.BackColor = Color.White);
            addedDocGridViewRows.Clear();
            changedDocGridViewRows.Clear();
            docsGridView.ClearSelection();
        }

        void AddPosition()
        {
            Position newPos = new Position();
            presenter.Positions.Add(newPos);
            newPos.Document = presenter.DocumentForPositions;
            positionsGridView.Rows[positionsGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
            addedPosGridViewRows.Add(positionsGridView.Rows[positionsGridView.Rows.Count - 1]);
        }
        void DeletePosition()
        {
            if (MessageBox.Show("Вы собираетесь удалить позицию. Продолжить?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                addedPosGridViewRows.Remove(positionsGridView.CurrentRow);
                changedPosGridViewRows.Remove(positionsGridView.CurrentRow);
                presenter.Positions.Remove(presenter.SelectedPosition);
            }
        }
        void ClearPositions()
        {
            addedPosGridViewRows.Clear();
            changedPosGridViewRows.Clear();
            presenter.ClearPositions();
        }
        void DisablePositionsGroupBox()
        {
            presenter.DocumentForPositions = null;
            positionsGroupBox.Enabled = false;
            docForPositionsNumLabel.Text = "";
        }
        #endregion
        #endregion

        #region IView Implementation
        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }
        #endregion

    }
}
