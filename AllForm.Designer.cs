namespace Videorent
{
    partial class AllForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильмовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.истекшиеЗаказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черныйСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(8, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(741, 245);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.списокToolStripMenuItem,
            this.выделитьВсеToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.отчётToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.главнаяToolStripMenuItem.MergeIndex = 0;
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.главнаяToolStripMenuItem.Text = "Главная";
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.тестToolStripMenuItem.Text = "Добавить";
            this.тестToolStripMenuItem.Click += new System.EventHandler(this.Operation);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.Operation);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.Operation);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // списокToolStripMenuItem
            // 
            this.списокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентовToolStripMenuItem,
            this.заказовToolStripMenuItem,
            this.фильмовToolStripMenuItem,
            this.дисковToolStripMenuItem});
            this.списокToolStripMenuItem.MergeIndex = 2;
            this.списокToolStripMenuItem.Name = "списокToolStripMenuItem";
            this.списокToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.списокToolStripMenuItem.Text = "Список";
            // 
            // клиентовToolStripMenuItem
            // 
            this.клиентовToolStripMenuItem.Name = "клиентовToolStripMenuItem";
            this.клиентовToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.клиентовToolStripMenuItem.Text = "Клиентов";
            this.клиентовToolStripMenuItem.Click += new System.EventHandler(this.Database);
            // 
            // заказовToolStripMenuItem
            // 
            this.заказовToolStripMenuItem.Name = "заказовToolStripMenuItem";
            this.заказовToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.заказовToolStripMenuItem.Text = "Заказов";
            this.заказовToolStripMenuItem.Click += new System.EventHandler(this.Database);
            // 
            // фильмовToolStripMenuItem
            // 
            this.фильмовToolStripMenuItem.Name = "фильмовToolStripMenuItem";
            this.фильмовToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.фильмовToolStripMenuItem.Text = "Дисков";
            this.фильмовToolStripMenuItem.Click += new System.EventHandler(this.Database);
            // 
            // дисковToolStripMenuItem
            // 
            this.дисковToolStripMenuItem.Name = "дисковToolStripMenuItem";
            this.дисковToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.дисковToolStripMenuItem.Text = "Фильмов";
            this.дисковToolStripMenuItem.Click += new System.EventHandler(this.Database);
            // 
            // выделитьВсеToolStripMenuItem
            // 
            this.выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
            this.выделитьВсеToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.выделитьВсеToolStripMenuItem.Text = "Выделить все";
            this.выделитьВсеToolStripMenuItem.Click += new System.EventHandler(this.выделитьВсеToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.MergeIndex = 1;
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 20);
            this.toolStripComboBox1.Visible = false;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 20);
            this.toolStripTextBox1.Visible = false;
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // отчётToolStripMenuItem
            // 
            this.отчётToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказыToolStripMenuItem,
            this.истекшиеЗаказыToolStripMenuItem,
            this.черныйСписокToolStripMenuItem});
            this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            this.отчётToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчётToolStripMenuItem.Text = "Отчёт";
            this.отчётToolStripMenuItem.Click += new System.EventHandler(this.отчётToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.заказыToolStripMenuItem.Text = "Заказы";
            this.заказыToolStripMenuItem.Click += new System.EventHandler(this.заказыToolStripMenuItem_Click);
            // 
            // истекшиеЗаказыToolStripMenuItem
            // 
            this.истекшиеЗаказыToolStripMenuItem.Name = "истекшиеЗаказыToolStripMenuItem";
            this.истекшиеЗаказыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.истекшиеЗаказыToolStripMenuItem.Text = "Истекшие заказы";
            this.истекшиеЗаказыToolStripMenuItem.Click += new System.EventHandler(this.истекшиеЗаказыToolStripMenuItem_Click);
            // 
            // черныйСписокToolStripMenuItem
            // 
            this.черныйСписокToolStripMenuItem.Name = "черныйСписокToolStripMenuItem";
            this.черныйСписокToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.черныйСписокToolStripMenuItem.Text = "Черный список";
            this.черныйСписокToolStripMenuItem.Click += new System.EventHandler(this.черныйСписокToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // AllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 287);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AllForm";
            this.Text = "AllForm";
            this.Load += new System.EventHandler(this.AllForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильмовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисковToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem истекшиеЗаказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem черныйСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}