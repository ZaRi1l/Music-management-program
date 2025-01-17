using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 음원_관리_프로그램
{   

    public partial class 로그인화면 : Form
    {
        UserClass dbc = new UserClass();


        public static string inputID;
        public 로그인화면()
        {
            InitializeComponent();
            dbc.DB_ObjCreate();
            dbc.DB_Open();

            dbc.DS.Clear();
            dbc.DBAdapter.Fill(dbc.DS, "USERS");


        }


        private void ID_Click(object sender, EventArgs e)
        {
            if (ID.Text == "아이디")
            {
                ID.Text = ""; // 클릭 시 텍스트를 비웁니다.
            }
        }
        private void ID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                ID.Text = "아이디"; // 입력이 없을 경우 "아이디" 텍스트를 설정합니다.
            }
        }
        private void Password_Click(object sender, EventArgs e)
        {
            if (Password.Text == "비밀번호")
            {
                Password.Text = ""; // 클릭 시 텍스트를 비웁니다.
                Password.PasswordChar = '*'; // 입력된 내용이 '*'로 표시됩니다.
            }
        }
        // Password 텍스트 박스 Leave 이벤트 핸들러
        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password.Text))
            {
                Password.PasswordChar = '\0'; // '*' 표시를 제거합니다.
                Password.Text = "비밀번호"; // 입력이 없을 경우 "비밀번호" 텍스트를 설정합니다.
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            회원가입 form6 = new 회원가입();
            form6.Show(); // Form6을 엽니다

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 입력된 ID와 Password를 변수에 저장합니다.
                inputID = ID.Text;
                string inputPassword = Password.Text;

                // 데이터베이스에서 입력된 ID 확인
                DataRow[] idRows = dbc.DS.Tables["USERS"].Select($"ID = '{inputID}'");

                if (idRows.Length > 0) // ID가 존재하는 경우
                {
                    // ID가 존재하므로 비밀번호 확인
                    DataRow[] foundRows = dbc.DS.Tables["USERS"].Select($"ID = '{inputID}' AND Password = '{inputPassword}'");

                    if (foundRows.Length > 0) // ID와 비밀번호가 맞는 경우
                    {
                        // 로그인 성공 시 음원업로드에 전송
                        음원업로드 uploadForm = new 음원업로드(inputID); // 로그인된 ID를 전달

                        MessageBox.Show("로그인 성공!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        메인화면 form1 = new 메인화면(inputID);
                        form1.Show(); // Form1을 엽니다
                        this.Hide();
                    }
                    else // 비밀번호가 틀린 경우
                    {
                        MessageBox.Show("비밀번호가 올바르지 않습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else // ID가 존재하지 않는 경우
                {
                    MessageBox.Show("존재하지 않는 아이디입니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) // 예외 처리
            {
                MessageBox.Show($"로그인 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 로그인화면_Load(object sender, EventArgs e)
        {

        }
    }
}
