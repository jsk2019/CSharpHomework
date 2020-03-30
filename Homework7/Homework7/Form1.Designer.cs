namespace Homework7
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.leftAngle = new System.Windows.Forms.TextBox();
            this.rightAngle = new System.Windows.Forms.TextBox();
            this.leftLength = new System.Windows.Forms.TextBox();
            this.rightLength = new System.Windows.Forms.TextBox();
            this.mainLength = new System.Windows.Forms.TextBox();
            this.depth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.clearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorComboBox);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.leftAngle);
            this.groupBox1.Controls.Add(this.rightAngle);
            this.groupBox1.Controls.Add(this.leftLength);
            this.groupBox1.Controls.Add(this.rightLength);
            this.groupBox1.Controls.Add(this.mainLength);
            this.groupBox1.Controls.Add(this.depth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(67, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 463);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // colorComboBox
            // 
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "红色",
            "黑色",
            "蓝色"});
            this.colorComboBox.Location = new System.Drawing.Point(216, 355);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(177, 38);
            this.colorComboBox.TabIndex = 14;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.colorComboBox_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 47);
            this.button2.TabIndex = 13;
            this.button2.Text = "颜色";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // leftAngle
            // 
            this.leftAngle.Location = new System.Drawing.Point(216, 293);
            this.leftAngle.Name = "leftAngle";
            this.leftAngle.Size = new System.Drawing.Size(177, 42);
            this.leftAngle.TabIndex = 12;
            this.leftAngle.Text = "20";
            // 
            // rightAngle
            // 
            this.rightAngle.Location = new System.Drawing.Point(216, 245);
            this.rightAngle.Name = "rightAngle";
            this.rightAngle.Size = new System.Drawing.Size(177, 42);
            this.rightAngle.TabIndex = 11;
            this.rightAngle.Text = "30";
            // 
            // leftLength
            // 
            this.leftLength.Location = new System.Drawing.Point(216, 194);
            this.leftLength.Name = "leftLength";
            this.leftLength.Size = new System.Drawing.Size(177, 42);
            this.leftLength.TabIndex = 10;
            this.leftLength.Text = "0.7";
            // 
            // rightLength
            // 
            this.rightLength.Location = new System.Drawing.Point(216, 136);
            this.rightLength.Name = "rightLength";
            this.rightLength.Size = new System.Drawing.Size(177, 42);
            this.rightLength.TabIndex = 9;
            this.rightLength.Text = "0.6";
            // 
            // mainLength
            // 
            this.mainLength.Location = new System.Drawing.Point(216, 78);
            this.mainLength.Name = "mainLength";
            this.mainLength.Size = new System.Drawing.Size(177, 42);
            this.mainLength.TabIndex = 8;
            this.mainLength.Text = "100";
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(216, 18);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(177, 42);
            this.depth.TabIndex = 7;
            this.depth.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "左分支角度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "右分支长度比";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "左分支长度比";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "右分支角度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "主干长度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "递归深度";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(85, 116);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(128, 55);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(487, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 773);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 770);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox leftAngle;
        private System.Windows.Forms.TextBox rightAngle;
        private System.Windows.Forms.TextBox leftLength;
        private System.Windows.Forms.TextBox rightLength;
        private System.Windows.Forms.TextBox mainLength;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Panel panel1;
    }
}

