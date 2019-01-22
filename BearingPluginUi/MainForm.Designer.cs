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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SupportShuft = new System.Windows.Forms.CheckBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BearingWidth = new System.Windows.Forms.TextBox();
            this.InternalDiametrInRim = new System.Windows.Forms.TextBox();
            this.ExternalDiametrInRim = new System.Windows.Forms.TextBox();
            this.ExternalDiametrOutRim = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rollRadioButton = new System.Windows.Forms.RadioButton();
            this.ballRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SupportShuft);
            this.groupBox2.Controls.Add(this.BuildButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BearingWidth);
            this.groupBox2.Controls.Add(this.InternalDiametrInRim);
            this.groupBox2.Controls.Add(this.ExternalDiametrInRim);
            this.groupBox2.Controls.Add(this.ExternalDiametrOutRim);
            this.groupBox2.Location = new System.Drawing.Point(9, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 241);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Построение детали";
            // 
            // SupportShuft
            // 
            this.SupportShuft.AutoSize = true;
            this.SupportShuft.Location = new System.Drawing.Point(152, 175);
            this.SupportShuft.Name = "SupportShuft";
            this.SupportShuft.Size = new System.Drawing.Size(146, 17);
            this.SupportShuft.TabIndex = 9;
            this.SupportShuft.Text = "Наличие опорного вала";
            this.SupportShuft.UseVisualStyleBackColor = true;
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(223, 212);
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
            this.label4.Location = new System.Drawing.Point(6, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Толщина подшипника";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Внутренний радиус внутреннего обода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Внешний радиус внутреннего обода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Внешний радиус внешнего обода";
            // 
            // BearingWidth
            // 
            this.BearingWidth.Location = new System.Drawing.Point(221, 149);
            this.BearingWidth.Name = "BearingWidth";
            this.BearingWidth.Size = new System.Drawing.Size(68, 20);
            this.BearingWidth.TabIndex = 3;
            this.BearingWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // InternalDiametrInRim
            // 
            this.InternalDiametrInRim.Location = new System.Drawing.Point(221, 113);
            this.InternalDiametrInRim.Name = "InternalDiametrInRim";
            this.InternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.InternalDiametrInRim.TabIndex = 2;
            this.InternalDiametrInRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // ExternalDiametrInRim
            // 
            this.ExternalDiametrInRim.Location = new System.Drawing.Point(221, 77);
            this.ExternalDiametrInRim.Name = "ExternalDiametrInRim";
            this.ExternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrInRim.TabIndex = 1;
            this.ExternalDiametrInRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // ExternalDiametrOutRim
            // 
            this.ExternalDiametrOutRim.Location = new System.Drawing.Point(221, 37);
            this.ExternalDiametrOutRim.Name = "ExternalDiametrOutRim";
            this.ExternalDiametrOutRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrOutRim.TabIndex = 0;
            this.ExternalDiametrOutRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rollRadioButton);
            this.groupBox1.Controls.Add(this.ballRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип подшипника";
            // 
            // rollRadioButton
            // 
            this.rollRadioButton.AutoSize = true;
            this.rollRadioButton.Location = new System.Drawing.Point(189, 29);
            this.rollRadioButton.Name = "rollRadioButton";
            this.rollRadioButton.Size = new System.Drawing.Size(82, 17);
            this.rollRadioButton.TabIndex = 1;
            this.rollRadioButton.Text = "Роликовый";
            this.rollRadioButton.UseVisualStyleBackColor = true;
            // 
            // ballRadioButton
            // 
            this.ballRadioButton.AutoSize = true;
            this.ballRadioButton.Checked = true;
            this.ballRadioButton.Location = new System.Drawing.Point(40, 29);
            this.ballRadioButton.Name = "ballRadioButton";
            this.ballRadioButton.Size = new System.Drawing.Size(84, 17);
            this.ballRadioButton.TabIndex = 0;
            this.ballRadioButton.TabStop = true;
            this.ballRadioButton.Text = "Шариковый";
            this.ballRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(341, 378);
            this.MinimumSize = new System.Drawing.Size(341, 378);
            this.Name = "MainForm";
            this.Text = "Построение подшипника";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.CheckBox SupportShuft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ballRadioButton;
        private System.Windows.Forms.RadioButton rollRadioButton;
    }
}

