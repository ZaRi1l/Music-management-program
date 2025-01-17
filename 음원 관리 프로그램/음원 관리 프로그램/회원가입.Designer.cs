namespace 음원_관리_프로그램
{
    partial class 회원가입
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
            this.ID = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.FullName = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labe2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(82, 165);
            this.ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(243, 25);
            this.ID.TabIndex = 0;
            this.ID.Text = "아이디";
            this.ID.Click += new System.EventHandler(this.ID_Click);
            this.ID.Leave += new System.EventHandler(this.ID_Leave);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(82, 210);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(243, 25);
            this.Password.TabIndex = 2;
            this.Password.Text = "비밀번호";
            this.Password.Click += new System.EventHandler(this.Password_Click);
            this.Password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // FullName
            // 
            this.FullName.Location = new System.Drawing.Point(82, 276);
            this.FullName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(243, 25);
            this.FullName.TabIndex = 3;
            this.FullName.Text = "이름";
            this.FullName.Click += new System.EventHandler(this.FullName_Click);
            this.FullName.Leave += new System.EventHandler(this.FullName_Leave);
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(82, 325);
            this.Phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(243, 25);
            this.Phone.TabIndex = 4;
            this.Phone.Text = "전화번호";
            this.Phone.Click += new System.EventHandler(this.Phone_Click);
            this.Phone.Leave += new System.EventHandler(this.Phone_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 165);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "중복체크";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(82, 428);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "회원가입";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(104, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "음악 관리 프로그램";
            // 
            // labe2
            // 
            this.labe2.AutoSize = true;
            this.labe2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labe2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labe2.Location = new System.Drawing.Point(181, 85);
            this.labe2.Name = "labe2";
            this.labe2.Size = new System.Drawing.Size(133, 40);
            this.labe2.TabIndex = 9;
            this.labe2.Text = "회원가입";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(234, 374);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "가수";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(127, 374);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "고객";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(234, 428);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(119, 36);
            this.loginBtn.TabIndex = 13;
            this.loginBtn.Text = "로그인";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // 회원가입
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 519);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labe2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.ID);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "회원가입";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.회원가입_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox FullName;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labe2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button loginBtn;
    }
}