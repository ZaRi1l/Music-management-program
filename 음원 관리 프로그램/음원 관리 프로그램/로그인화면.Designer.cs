namespace 음원_관리_프로그램
{
    partial class 로그인화면
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
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labe2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(81, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "음악 관리 프로그램";
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ID.Location = new System.Drawing.Point(96, 162);
            this.ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(227, 25);
            this.ID.TabIndex = 1;
            this.ID.Text = "아이디";
            this.ID.Click += new System.EventHandler(this.ID_Click);
            this.ID.Leave += new System.EventHandler(this.ID_Leave);
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Password.Location = new System.Drawing.Point(96, 214);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(227, 25);
            this.Password.TabIndex = 2;
            this.Password.Text = "비밀번호";
            this.Password.Click += new System.EventHandler(this.Password_Click);
            this.Password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(96, 328);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "회원가입";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labe2
            // 
            this.labe2.AutoSize = true;
            this.labe2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labe2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labe2.Location = new System.Drawing.Point(165, 101);
            this.labe2.Name = "labe2";
            this.labe2.Size = new System.Drawing.Size(104, 40);
            this.labe2.TabIndex = 10;
            this.labe2.Text = "로그인";
            // 
            // 로그인화면
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(439, 476);
            this.Controls.Add(this.labe2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "로그인화면";
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.로그인화면_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labe2;
    }
}