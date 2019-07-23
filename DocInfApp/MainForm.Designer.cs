namespace DocInfApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.docsGridView = new System.Windows.Forms.DataGridView();
            this.positionsGridView = new System.Windows.Forms.DataGridView();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.DocsGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelDocChangesButton = new System.Windows.Forms.Button();
            this.deleteDocButton = new System.Windows.Forms.Button();
            this.addDocButton = new System.Windows.Forms.Button();
            this.openDetailsButton = new System.Windows.Forms.Button();
            this.positionsGroupBox = new System.Windows.Forms.GroupBox();
            this.docForPositionsNumLabel = new System.Windows.Forms.Label();
            this.docForPositionsLabel = new System.Windows.Forms.Label();
            this.cancelPositionsChangesButton = new System.Windows.Forms.Button();
            this.deletePositionButton = new System.Windows.Forms.Button();
            this.addPositionButton = new System.Windows.Forms.Button();
            this.docsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openDetailsDocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.docsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsGridView)).BeginInit();
            this.DocsGroupBox.SuspendLayout();
            this.positionsGroupBox.SuspendLayout();
            this.docsContextMenuStrip.SuspendLayout();
            this.positionsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // docsGridView
            // 
            this.docsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docsGridView.Location = new System.Drawing.Point(6, 19);
            this.docsGridView.Name = "docsGridView";
            this.docsGridView.Size = new System.Drawing.Size(448, 150);
            this.docsGridView.TabIndex = 0;
            this.docsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DocsGridView_CellBeginEdit);
            this.docsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DocsGridView_CellDoubleClick);
            this.docsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DocsGridView_CellEndEdit);
            this.docsGridView.SelectionChanged += new System.EventHandler(this.DocsGridView_SelectionChanged);
            this.docsGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DocsGridView_UserDeletedRow);
            this.docsGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DocsGridView_UserDeletingRow);
            // 
            // positionsGridView
            // 
            this.positionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsGridView.Location = new System.Drawing.Point(7, 39);
            this.positionsGridView.Name = "positionsGridView";
            this.positionsGridView.Size = new System.Drawing.Size(448, 196);
            this.positionsGridView.TabIndex = 1;
            this.positionsGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.PositionsGridView_CellBeginEdit);
            this.positionsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionsGridView_CellDoubleClick);
            this.positionsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionsGridView_CellEndEdit);
            this.positionsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.PositionsGridView_CellValidating);
            this.positionsGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.PositionsGridView_DataError);
            this.positionsGridView.SelectionChanged += new System.EventHandler(this.PositionsGridView_SelectionChanged);
            this.positionsGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.PositionsGridView_UserDeletedRow);
            this.positionsGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.PositionsGridView_UserDeletingRow);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(13, 503);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(461, 23);
            this.saveChangesButton.TabIndex = 2;
            this.saveChangesButton.Text = "Сохранить все изменения";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // DocsGroupBox
            // 
            this.DocsGroupBox.Controls.Add(this.cancelDocChangesButton);
            this.DocsGroupBox.Controls.Add(this.deleteDocButton);
            this.DocsGroupBox.Controls.Add(this.addDocButton);
            this.DocsGroupBox.Controls.Add(this.docsGridView);
            this.DocsGroupBox.Controls.Add(this.openDetailsButton);
            this.DocsGroupBox.Location = new System.Drawing.Point(13, 13);
            this.DocsGroupBox.Name = "DocsGroupBox";
            this.DocsGroupBox.Size = new System.Drawing.Size(461, 208);
            this.DocsGroupBox.TabIndex = 3;
            this.DocsGroupBox.TabStop = false;
            this.DocsGroupBox.Text = "Редактирование/просмотр документов";
            // 
            // cancelDocChangesButton
            // 
            this.cancelDocChangesButton.Location = new System.Drawing.Point(297, 175);
            this.cancelDocChangesButton.Name = "cancelDocChangesButton";
            this.cancelDocChangesButton.Size = new System.Drawing.Size(157, 23);
            this.cancelDocChangesButton.TabIndex = 8;
            this.cancelDocChangesButton.Text = "Отменить изменения";
            this.cancelDocChangesButton.UseVisualStyleBackColor = true;
            this.cancelDocChangesButton.Click += new System.EventHandler(this.CancelDocChangesButton_Click);
            // 
            // deleteDocButton
            // 
            this.deleteDocButton.Location = new System.Drawing.Point(78, 175);
            this.deleteDocButton.Name = "deleteDocButton";
            this.deleteDocButton.Size = new System.Drawing.Size(67, 23);
            this.deleteDocButton.TabIndex = 7;
            this.deleteDocButton.Text = "Удалить";
            this.deleteDocButton.UseVisualStyleBackColor = true;
            this.deleteDocButton.Click += new System.EventHandler(this.DeleteDocButton_Click);
            // 
            // addDocButton
            // 
            this.addDocButton.Location = new System.Drawing.Point(6, 175);
            this.addDocButton.Name = "addDocButton";
            this.addDocButton.Size = new System.Drawing.Size(66, 23);
            this.addDocButton.TabIndex = 6;
            this.addDocButton.Text = "Добавить";
            this.addDocButton.UseVisualStyleBackColor = true;
            this.addDocButton.Click += new System.EventHandler(this.AddDocButton_Click);
            // 
            // openDetailsButton
            // 
            this.openDetailsButton.Location = new System.Drawing.Point(151, 175);
            this.openDetailsButton.Name = "openDetailsButton";
            this.openDetailsButton.Size = new System.Drawing.Size(140, 23);
            this.openDetailsButton.TabIndex = 5;
            this.openDetailsButton.Text = "Открыть детализацию";
            this.openDetailsButton.UseVisualStyleBackColor = true;
            this.openDetailsButton.Click += new System.EventHandler(this.OpenDocumentsDetailsButton_Click);
            // 
            // positionsGroupBox
            // 
            this.positionsGroupBox.Controls.Add(this.docForPositionsNumLabel);
            this.positionsGroupBox.Controls.Add(this.docForPositionsLabel);
            this.positionsGroupBox.Controls.Add(this.cancelPositionsChangesButton);
            this.positionsGroupBox.Controls.Add(this.deletePositionButton);
            this.positionsGroupBox.Controls.Add(this.addPositionButton);
            this.positionsGroupBox.Controls.Add(this.positionsGridView);
            this.positionsGroupBox.Location = new System.Drawing.Point(13, 227);
            this.positionsGroupBox.Name = "positionsGroupBox";
            this.positionsGroupBox.Size = new System.Drawing.Size(461, 270);
            this.positionsGroupBox.TabIndex = 4;
            this.positionsGroupBox.TabStop = false;
            this.positionsGroupBox.Text = "Редактирование/просмотр позиций (детализация указанного документа)";
            // 
            // docForPositionsNumLabel
            // 
            this.docForPositionsNumLabel.AutoSize = true;
            this.docForPositionsNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docForPositionsNumLabel.Location = new System.Drawing.Point(128, 16);
            this.docForPositionsNumLabel.Name = "docForPositionsNumLabel";
            this.docForPositionsNumLabel.Size = new System.Drawing.Size(0, 20);
            this.docForPositionsNumLabel.TabIndex = 6;
            // 
            // docForPositionsLabel
            // 
            this.docForPositionsLabel.AutoSize = true;
            this.docForPositionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docForPositionsLabel.Location = new System.Drawing.Point(6, 16);
            this.docForPositionsLabel.Name = "docForPositionsLabel";
            this.docForPositionsLabel.Size = new System.Drawing.Size(122, 20);
            this.docForPositionsLabel.TabIndex = 5;
            this.docForPositionsLabel.Text = "Документ №";
            // 
            // cancelPositionsChangesButton
            // 
            this.cancelPositionsChangesButton.Location = new System.Drawing.Point(298, 241);
            this.cancelPositionsChangesButton.Name = "cancelPositionsChangesButton";
            this.cancelPositionsChangesButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelPositionsChangesButton.Size = new System.Drawing.Size(157, 23);
            this.cancelPositionsChangesButton.TabIndex = 4;
            this.cancelPositionsChangesButton.Text = "Отменить изменения";
            this.cancelPositionsChangesButton.UseVisualStyleBackColor = true;
            this.cancelPositionsChangesButton.Click += new System.EventHandler(this.CancelPositionsChangesButton_Click);
            // 
            // deletePositionButton
            // 
            this.deletePositionButton.Location = new System.Drawing.Point(79, 241);
            this.deletePositionButton.Name = "deletePositionButton";
            this.deletePositionButton.Size = new System.Drawing.Size(67, 23);
            this.deletePositionButton.TabIndex = 3;
            this.deletePositionButton.Text = "Удалить";
            this.deletePositionButton.UseVisualStyleBackColor = true;
            this.deletePositionButton.Click += new System.EventHandler(this.DeletePositionButton_Click);
            // 
            // addPositionButton
            // 
            this.addPositionButton.Location = new System.Drawing.Point(7, 241);
            this.addPositionButton.Name = "addPositionButton";
            this.addPositionButton.Size = new System.Drawing.Size(66, 23);
            this.addPositionButton.TabIndex = 2;
            this.addPositionButton.Text = "Добавить";
            this.addPositionButton.UseVisualStyleBackColor = true;
            this.addPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // docsContextMenuStrip
            // 
            this.docsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDetailsDocsToolStripMenuItem,
            this.AddDocToolStripMenuItem,
            this.deleteDocsToolStripMenuItem});
            this.docsContextMenuStrip.Name = "contextMenuStrip1";
            this.docsContextMenuStrip.Size = new System.Drawing.Size(197, 70);
            // 
            // openDetailsDocsToolStripMenuItem
            // 
            this.openDetailsDocsToolStripMenuItem.Name = "openDetailsDocsToolStripMenuItem";
            this.openDetailsDocsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openDetailsDocsToolStripMenuItem.Text = "Открыть детализацию";
            this.openDetailsDocsToolStripMenuItem.Click += new System.EventHandler(this.OpenDocDetailsToolStripMenuItem_Click);
            // 
            // AddDocToolStripMenuItem
            // 
            this.AddDocToolStripMenuItem.Name = "AddDocToolStripMenuItem";
            this.AddDocToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.AddDocToolStripMenuItem.Text = "Добавить";
            this.AddDocToolStripMenuItem.Click += new System.EventHandler(this.AddDocToolStripMenuItem_Click);
            // 
            // deleteDocsToolStripMenuItem
            // 
            this.deleteDocsToolStripMenuItem.Name = "deleteDocsToolStripMenuItem";
            this.deleteDocsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.deleteDocsToolStripMenuItem.Text = "Удалить";
            this.deleteDocsToolStripMenuItem.Click += new System.EventHandler(this.DeleteDocToolStripMenuItem_Click);
            // 
            // positionsContextMenuStrip
            // 
            this.positionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPosToolStripMenuItem,
            this.deletePositionsToolStripMenuItem});
            this.positionsContextMenuStrip.Name = "positionsContextMenuStrip";
            this.positionsContextMenuStrip.Size = new System.Drawing.Size(127, 48);
            // 
            // AddPosToolStripMenuItem
            // 
            this.AddPosToolStripMenuItem.Name = "AddPosToolStripMenuItem";
            this.AddPosToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.AddPosToolStripMenuItem.Text = "Добавить";
            this.AddPosToolStripMenuItem.Click += new System.EventHandler(this.AddPosToolStripMenuItem_Click);
            // 
            // deletePositionsToolStripMenuItem
            // 
            this.deletePositionsToolStripMenuItem.Name = "deletePositionsToolStripMenuItem";
            this.deletePositionsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deletePositionsToolStripMenuItem.Text = "Удалить";
            this.deletePositionsToolStripMenuItem.Click += new System.EventHandler(this.DeletePosToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 538);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.positionsGroupBox);
            this.Controls.Add(this.DocsGroupBox);
            this.Name = "MainForm";
            this.Text = "Приложение для редактирования документов";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsGridView)).EndInit();
            this.DocsGroupBox.ResumeLayout(false);
            this.positionsGroupBox.ResumeLayout(false);
            this.positionsGroupBox.PerformLayout();
            this.docsContextMenuStrip.ResumeLayout(false);
            this.positionsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView docsGridView;
        private System.Windows.Forms.DataGridView positionsGridView;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.GroupBox DocsGroupBox;
        private System.Windows.Forms.GroupBox positionsGroupBox;
        private System.Windows.Forms.Button openDetailsButton;

        private System.Windows.Forms.ContextMenuStrip docsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteDocsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDetailsDocsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip positionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deletePositionsToolStripMenuItem;
        private System.Windows.Forms.Button deleteDocButton;
        private System.Windows.Forms.Button addDocButton;
        private System.Windows.Forms.Button deletePositionButton;
        private System.Windows.Forms.Button addPositionButton;
        private System.Windows.Forms.Button cancelDocChangesButton;
        private System.Windows.Forms.Button cancelPositionsChangesButton;
        private System.Windows.Forms.ToolStripMenuItem AddDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddPosToolStripMenuItem;
        private System.Windows.Forms.Label docForPositionsLabel;
        private System.Windows.Forms.Label docForPositionsNumLabel;
    }
}

