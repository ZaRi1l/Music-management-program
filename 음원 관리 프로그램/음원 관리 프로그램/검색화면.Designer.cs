namespace 음원_관리_프로그램
{
    partial class 검색화면
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(검색화면));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buyBtn = new System.Windows.Forms.Button();
            this.circleButton1 = new CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 200;
            this.comboBox1.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "제목",
            "가수",
            "장르"});
            this.comboBox1.Location = new System.Drawing.Point(90, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 54);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "제목";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchBox.Location = new System.Drawing.Point(246, 20);
            this.searchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(450, 69);
            this.searchBox.TabIndex = 15;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(90, 147);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(538, 200);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "노래 제목";
            this.columnHeader1.Width = 222;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "장르";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "가수";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "조회수";
            this.columnHeader4.Width = 107;
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(467, 371);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(161, 57);
            this.buyBtn.TabIndex = 18;
            this.buyBtn.Text = "구매";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // circleButton1
            // 
            this.circleButton1.BackColor = System.Drawing.Color.White;
            this.circleButton1.FlatAppearance.BorderSize = 0;
            this.circleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton1.Image = ((System.Drawing.Image)(resources.GetObject("circleButton1.Image")));
            this.circleButton1.Location = new System.Drawing.Point(631, 20);
            this.circleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.circleButton1.Name = "circleButton1";
            this.circleButton1.Size = new System.Drawing.Size(63, 69);
            this.circleButton1.TabIndex = 14;
            this.circleButton1.UseVisualStyleBackColor = false;
            this.circleButton1.Click += new System.EventHandler(this.circleButton1_Click);
            // 
            // 검색화면
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 458);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.circleButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "검색화면";
            this.Text = "검색";
            this.Load += new System.EventHandler(this.검색화면_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private CircleButton circleButton1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buyBtn;
    }
}