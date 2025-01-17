using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace 음원_관리_프로그램
{
    public partial class 회원가입 : Form
    {
        UserClass dbc = new UserClass();
        User_ProfileClass dbc2 = new User_ProfileClass();

        private bool isIDAvailable = false; // 아이디 중복 여부를 저장하는 플래그
        public 회원가입()
        {
            InitializeComponent();
            dbc.DB_ObjCreate();
            dbc.DB_Open();

            dbc.DS.Clear();
            dbc.DBAdapter.Fill(dbc.DS, "USERS");

            dbc2.DB_ObjCreate();
            dbc2.DB_Open();

            dbc2.DS.Clear();
            dbc2.DBAdapter.Fill(dbc2.DS, "USER_PROFILE");
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
        private void FullName_Click(object sender, EventArgs e)
        {
            if (FullName.Text == "이름")
            {
                FullName.Text = ""; // 클릭 시 텍스트를 비웁니다.
            }
        }

        // FullName 텍스트 박스 Leave 이벤트 핸들러
        private void FullName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName.Text))
            {
                FullName.Text = "이름"; // 입력이 없을 경우 "이름" 텍스트를 설정합니다.
            }
        }
        private void Phone_Click(object sender, EventArgs e)
        {
            if (Phone.Text == "전화번호")
            {
                Phone.Text = ""; // 클릭 시 텍스트를 비웁니다.
            }
        }

        // Phone 텍스트 박스 Leave 이벤트 핸들러
        private void Phone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Phone.Text))
            {
                Phone.Text = "전화번호"; // 입력이 없을 경우 "전화번호" 텍스트를 설정합니다.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string inputID = ID.Text;
                DataTable usersTable = dbc.DS.Tables["USERS"];
                isIDAvailable = true; // 기본값을 사용 가능으로 설정

                if (usersTable != null)
                {
                    foreach (DataRow row in usersTable.Rows)
                    {
                        if (row["ID"].ToString() == inputID) // "ID"는 USERS 테이블의 ID 열 이름
                        {
                            isIDAvailable = false; // 중복된 아이디 발견
                            break;
                        }
                    }
                }

                if (isIDAvailable)
                {
                    MessageBox.Show("사용 가능한 아이디입니다.", "중복 체크", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = true; // 이메일이 사용 가능할 때만 버튼 2 활성화
                }
                else
                {
                    MessageBox.Show("이미 존재하는 아이디입니다.", "중복 체크", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button2.Enabled = false; // 이메일이 중복될 경우 버튼 2 비활성화
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다11: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputID = ID.Text;
            string password = Password.Text;
            string fullName = FullName.Text;
            string phone = Phone.Text;
            try
            {
                
                DataTable usersTable = dbc.DS.Tables["USERS"];        

                if (usersTable != null)
                {

                    DataRow newRow = usersTable.NewRow();
                   
                    newRow["NAME"] = fullName;
                    newRow["TEL_NUM"] = phone;
                    newRow["PASSWORD"] = password;
                    newRow["ID"] = inputID;


                    usersTable.Rows.Add(newRow);

                    // 변경 사항을 데이터베이스에 반영
                    dbc.DBAdapter.Update(usersTable);
                    MessageBox.Show("정보가 성공적으로 추가되었습니다.", "추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              


            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다22: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DataTable userprofileTable = dbc2.DS.Tables["USER_PROFILE"];

                if (userprofileTable != null)
                {
                    DataRow newRow = userprofileTable.NewRow();

                    newRow["NAME"] = fullName;
                    newRow["USER_COMMENT"] = "";
                    newRow["PHOTO"] = "";
                    newRow["ID"] = inputID;

                    userprofileTable.Rows.Add(newRow);

                    dbc2.DBAdapter.Update(userprofileTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다33: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            로그인화면 form7 = new 로그인화면();
            form7.Show(); // Form2를 보여줍니다.
            this.Hide();
        }

        private void 회원가입_Load(object sender, EventArgs e)
        {

        }
    }
}
