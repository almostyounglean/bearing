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
            this.groupBox2.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 315);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Построение детали";
            // 
            // SupportShuft
            // 
            this.SupportShuft.AutoSize = true;
            this.SupportShuft.Location = new System.Drawing.Point(158, 215);
            this.SupportShuft.Name = "SupportShuft";
            this.SupportShuft.Size = new System.Drawing.Size(146, 17);
            this.SupportShuft.TabIndex = 9;
            this.SupportShuft.Text = "Наличие опорного вала";
            this.SupportShuft.UseVisualStyleBackColor = true;
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(221, 286);
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
            this.label4.Location = new System.Drawing.Point(6, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Толщина подшипника";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Внутренний радиус внутреннего обода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Внешний радиус внутреннего обода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Внешний радиус внешнего обода";
            // 
            // BearingWidth
            // 
            this.BearingWidth.Location = new System.Drawing.Point(221, 170);
            this.BearingWidth.Name = "BearingWidth";
            this.BearingWidth.Size = new System.Drawing.Size(68, 20);
            this.BearingWidth.TabIndex = 3;
            this.BearingWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // InternalDiametrInRim
            // 
            this.InternalDiametrInRim.Location = new System.Drawing.Point(221, 134);
            this.InternalDiametrInRim.Name = "InternalDiametrInRim";
            this.InternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.InternalDiametrInRim.TabIndex = 2;
            this.InternalDiametrInRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // ExternalDiametrInRim
            // 
            this.ExternalDiametrInRim.Location = new System.Drawing.Point(221, 96);
            this.ExternalDiametrInRim.Name = "ExternalDiametrInRim";
            this.ExternalDiametrInRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrInRim.TabIndex = 1;
            this.ExternalDiametrInRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // ExternalDiametrOutRim
            // 
            this.ExternalDiametrOutRim.Location = new System.Drawing.Point(221, 56);
            this.ExternalDiametrOutRim.Name = "ExternalDiametrOutRim";
            this.ExternalDiametrOutRim.Size = new System.Drawing.Size(68, 20);
            this.ExternalDiametrOutRim.TabIndex = 0;
            this.ExternalDiametrOutRim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDoubleTextBoxs_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "Построение подшипника";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

