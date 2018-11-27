namespace BearingPluginUi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CloseCompasButton = new System.Windows.Forms.Button();
            this.OpenCompasButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BearingWidth = new System.Windows.Forms.TextBox();
            this.InternalDiametrInRim = new System.Windows.Forms.TextBox();
            this.ExternalDiametrInRim = new System.Windows.Forms.TextBox();
            this.ExternalDiametrOutRim = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CloseCompasButton);
            this.groupBox1.Controls.Add(this.OpenCompasButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Компас 3D";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CloseCompasButton
            // 
            this.CloseCompasButton.Location = new System.Drawing.Point(90, 24);
            this.CloseCompasButton.Name = "CloseCompasButton";
            this.CloseCompasButton.Size = new System.Drawing.Size(75, 23);
            this.CloseCompasButton.TabIndex = 1;
            this.CloseCompasButton.Text = "Закрыть";
            this.CloseCompasButton.UseVisualStyleBackColor = true;
            this.CloseCompasButton.Click += new System.EventHandler(this.CloseCompasButton_Click);
            // 
            // OpenCompasButton
            // 
            this.OpenCompasButton.Location = new System.Drawing.Point(9, 24);
            this.OpenCompasButton.Name = "OpenCompasButton";
            this.OpenCompasButton.Size = new System.Drawing.Size(75, 23);
            this.OpenCompasButton.TabIndex = 0;
            this.OpenCompasButton.Text = "Открыть";
            this.OpenCompasButton.UseVisualStyleBackColor = true;
            this.OpenCompasButton.Click += new System.EventHandler(this.OpenCompasButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.BuildButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BearingWidth);
            this.groupBox2.Controls.Add(this.InternalDiametrInRim);
            this.groupBox2.Controls.Add(this.ExternalDiametrInRim);
            this.groupBox2.Controls.Add(this.ExternalDiametrOutRim);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Построение детали";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(152, 160);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Наличие опорного вала";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(214, 227);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 8;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Толщина подшипника";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Внутренний диаметр внутреннего обода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Внешний диаметр внутреннего обода";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Внешний диаметр внешнего обода";
            // 
            // BearingWidth
            // 
            this.BearingWidth.Location = new System.Drawing.Point(221, 124);
            this.BearingWidth.Name = "BearingWidth";
            this.BearingWidth.Size = new System.Drawing.Size(68, 20);
            this.BearingWidth.TabIndex = 3;
            // 
            // InternalDiametrInRim
            // 
            this.InternalDiametrInRim.Location = new System.Drawing.Point(221, 98);
            this.InternalDiametrInRim.Name = "InternalDiametrInRim";
            this.InternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.InternalDiametrInRim.TabIndex = 2;
            // 
            // ExternalDiametrInRim
            // 
            this.ExternalDiametrInRim.Location = new System.Drawing.Point(221, 72);
            this.ExternalDiametrInRim.Name = "ExternalDiametrInRim";
            this.ExternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrInRim.TabIndex = 1;
            // 
            // ExternalDiametrOutRim
            // 
            this.ExternalDiametrOutRim.Location = new System.Drawing.Point(221, 46);
            this.ExternalDiametrOutRim.Name = "ExternalDiametrOutRim";
            this.ExternalDiametrOutRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrOutRim.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Построение подшипника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CloseCompasButton;
        private System.Windows.Forms.Button OpenCompasButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BearingWidth;
        private System.Windows.Forms.TextBox InternalDiametrInRim;
        private System.Windows.Forms.TextBox ExternalDiametrInRim;
        private System.Windows.Forms.TextBox ExternalDiametrOutRim;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

