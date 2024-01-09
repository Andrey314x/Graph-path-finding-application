namespace GraphPaths
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.FordBellman = new System.Windows.Forms.RadioButton();
            this.Floyd = new System.Windows.Forms.RadioButton();
            this.Deykstra = new System.Windows.Forms.RadioButton();
            this.distances = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.MatrixButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.IsOriented = new System.Windows.Forms.CheckBox();
            this.redact = new System.Windows.Forms.RadioButton();
            this.IsLetters = new System.Windows.Forms.CheckBox();
            this.floydMatrix = new System.Windows.Forms.Button();
            this.roundButton1 = new GraphPaths.RoundButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.distances);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.MatrixButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.IsOriented);
            this.groupBox1.Controls.Add(this.redact);
            this.groupBox1.Controls.Add(this.IsLetters);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(642, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 561);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Опции";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.floydMatrix);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.FordBellman);
            this.groupBox3.Controls.Add(this.Floyd);
            this.groupBox3.Controls.Add(this.Deykstra);
            this.groupBox3.Location = new System.Drawing.Point(13, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 171);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Алгоритм:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 131);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(210, 34);
            this.button5.TabIndex = 11;
            this.button5.Text = "Вывод";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FordBellman
            // 
            this.FordBellman.AutoSize = true;
            this.FordBellman.Location = new System.Drawing.Point(16, 96);
            this.FordBellman.Name = "FordBellman";
            this.FordBellman.Size = new System.Drawing.Size(182, 28);
            this.FordBellman.TabIndex = 10;
            this.FordBellman.Text = "Форда-Беллмана";
            this.FordBellman.UseVisualStyleBackColor = true;
            this.FordBellman.CheckedChanged += new System.EventHandler(this.FordBellman_CheckedChanged);
            // 
            // Floyd
            // 
            this.Floyd.AutoSize = true;
            this.Floyd.Location = new System.Drawing.Point(16, 62);
            this.Floyd.Name = "Floyd";
            this.Floyd.Size = new System.Drawing.Size(98, 28);
            this.Floyd.TabIndex = 9;
            this.Floyd.Text = "Флойда";
            this.Floyd.UseVisualStyleBackColor = true;
            this.Floyd.CheckedChanged += new System.EventHandler(this.Floyd_CheckedChanged);
            // 
            // Deykstra
            // 
            this.Deykstra.AutoSize = true;
            this.Deykstra.Checked = true;
            this.Deykstra.Location = new System.Drawing.Point(16, 28);
            this.Deykstra.Name = "Deykstra";
            this.Deykstra.Size = new System.Drawing.Size(117, 28);
            this.Deykstra.TabIndex = 8;
            this.Deykstra.TabStop = true;
            this.Deykstra.Text = "Дейкстры";
            this.Deykstra.UseVisualStyleBackColor = true;
            this.Deykstra.CheckedChanged += new System.EventHandler(this.Deykstra_CheckedChanged);
            // 
            // distances
            // 
            this.distances.AutoSize = true;
            this.distances.Location = new System.Drawing.Point(6, 344);
            this.distances.Name = "distances";
            this.distances.Size = new System.Drawing.Size(184, 28);
            this.distances.TabIndex = 6;
            this.distances.Text = "Кратчайшие пути";
            this.distances.UseVisualStyleBackColor = true;
            this.distances.CheckedChanged += new System.EventHandler(this.distances_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(230, 33);
            this.button3.TabIndex = 5;
            this.button3.Text = "Очистить граф";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MatrixButton
            // 
            this.MatrixButton.Location = new System.Drawing.Point(6, 62);
            this.MatrixButton.Name = "MatrixButton";
            this.MatrixButton.Size = new System.Drawing.Size(230, 33);
            this.MatrixButton.TabIndex = 4;
            this.MatrixButton.Text = "Метрица смежности";
            this.MatrixButton.UseVisualStyleBackColor = true;
            this.MatrixButton.Click += new System.EventHandler(this.MatrixButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 144);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сохранение";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(69, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "Файл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 29);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // IsOriented
            // 
            this.IsOriented.AutoSize = true;
            this.IsOriented.Checked = true;
            this.IsOriented.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsOriented.Enabled = false;
            this.IsOriented.Location = new System.Drawing.Point(6, 28);
            this.IsOriented.Name = "IsOriented";
            this.IsOriented.Size = new System.Drawing.Size(99, 28);
            this.IsOriented.TabIndex = 2;
            this.IsOriented.Text = "Орграф";
            this.IsOriented.UseVisualStyleBackColor = true;
            // 
            // redact
            // 
            this.redact.AutoSize = true;
            this.redact.Checked = true;
            this.redact.Location = new System.Drawing.Point(6, 310);
            this.redact.Name = "redact";
            this.redact.Size = new System.Drawing.Size(178, 28);
            this.redact.TabIndex = 1;
            this.redact.TabStop = true;
            this.redact.Text = "редактирование";
            this.redact.UseVisualStyleBackColor = true;
            this.redact.CheckedChanged += new System.EventHandler(this.redact_CheckedChanged);
            // 
            // IsLetters
            // 
            this.IsLetters.AutoSize = true;
            this.IsLetters.Location = new System.Drawing.Point(125, 28);
            this.IsLetters.Name = "IsLetters";
            this.IsLetters.Size = new System.Drawing.Size(105, 28);
            this.IsLetters.TabIndex = 0;
            this.IsLetters.Text = "Буквами";
            this.IsLetters.UseVisualStyleBackColor = true;
            this.IsLetters.CheckedChanged += new System.EventHandler(this.IsLetters_CheckedChanged);
            // 
            // floydMatrix
            // 
            this.floydMatrix.Location = new System.Drawing.Point(120, 58);
            this.floydMatrix.Name = "floydMatrix";
            this.floydMatrix.Size = new System.Drawing.Size(96, 36);
            this.floydMatrix.TabIndex = 12;
            this.floydMatrix.Text = "матрица";
            this.floydMatrix.UseVisualStyleBackColor = true;
            this.floydMatrix.Click += new System.EventHandler(this.floydMatrix_Click);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.RosyBrown;
            this.roundButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton1.Location = new System.Drawing.Point(12, 12);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(40, 40);
            this.roundButton1.TabIndex = 2;
            this.roundButton1.Text = "Жопа";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Visible = false;
            this.roundButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roundButton1_MouseClick);
            this.roundButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.roundButton1_MouseDown);
            this.roundButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.roundButton1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.roundButton1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Граф";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundButton roundButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IsLetters;
        private System.Windows.Forms.RadioButton redact;
        private System.Windows.Forms.CheckBox IsOriented;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button MatrixButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Deykstra;
        private System.Windows.Forms.RadioButton distances;
        private System.Windows.Forms.RadioButton FordBellman;
        private System.Windows.Forms.RadioButton Floyd;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button floydMatrix;
    }
}

