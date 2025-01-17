using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 음원_관리_프로그램
{
    public partial class 프로필수정 : Form
    {

        private string loggedInID;
        User_ProfileClass dbc2 = new User_ProfileClass();
        UserClass dbc1 = new UserClass();

        public 프로필수정(string loggedInID)
        {
            InitializeComponent();
            dbc2.DB_ObjCreate();
            dbc2.DB_Open();

            dbc2.DS.Clear();
            dbc2.DBAdapter.Fill(dbc2.DS, "USER_PROFILE");

            // 유저 이름도 바뀌게
            dbc1.DB_ObjCreate();
            dbc1.DB_Open();

            dbc1.DS.Clear();
            dbc1.DBAdapter.Fill(dbc1.DS, "USERS");

            this.loggedInID = loggedInID;
        }

        private void 프로필수정_Load(object sender, EventArgs e)
        {
            DataRow[] UserPropile = dbc2.DS.Tables["USER_PROFILE"].Select($"ID = '{loggedInID}'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("수정하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // 사용자가 "예"를 선택한 경우
                {
                    dbc2.User_ProfileTable = dbc2.DS.Tables["USER_PROFILE"];
                    DataColumn[] PrimaryKey = new DataColumn[1];
                    PrimaryKey[0] = dbc2.User_ProfileTable.Columns["ID"];
                    dbc2.User_ProfileTable.PrimaryKey = PrimaryKey;

                    DataRow currRow = dbc2.User_ProfileTable.Rows.Find(loggedInID);

                    if (currRow != null)
                    {
                        currRow.BeginEdit();
                        currRow["ID"] = loggedInID;
                        currRow["NAME"] = textBox1.Text.Trim();
                        currRow["PHOTO"] = ""; // 기본값 또는 경로 설정
                        currRow["USER_COMMENT"] = textBox2.Text.Trim();
                        currRow.EndEdit();

                        if (dbc2.DS.HasChanges(DataRowState.Modified))
                        {
                            DataSet UpdatedSet = dbc2.DS.GetChanges(DataRowState.Modified);

                            int rowsAffected = dbc2.DBAdapter.Update(UpdatedSet, "USER_PROFILE");
                            if (rowsAffected > 0)
                            {
                                dbc2.DS.AcceptChanges();

                                // Users 테이블의 이름 수정
                                dbc1.UsersTable = dbc1.DS.Tables["USERS"];
                                DataColumn[] PrimaryKey1 = new DataColumn[1];
                                PrimaryKey1[0] = dbc1.UsersTable.Columns["ID"];
                                dbc1.UsersTable.PrimaryKey = PrimaryKey1;

                                DataRow currRow1 = dbc1.UsersTable.Rows.Find(loggedInID);

                                currRow1.BeginEdit();
                                currRow1["ID"] = loggedInID;
                                currRow1["NAME"] = textBox1.Text.Trim();

                                DataRow[] User = dbc1.DS.Tables["USERS"].Select($"ID = '{loggedInID}'");
                                currRow1["tel_num"] = User[0]["tel_num"].ToString();
                                currRow1["password"] = User[0]["password"].ToString();

                                currRow1.EndEdit();

                                DataSet UpdatedSet1 = dbc1.DS.GetChanges(DataRowState.Modified);

                                int rowsAffected1 = dbc1.DBAdapter.Update(UpdatedSet1, "USERS");
                                if (rowsAffected1 > 0)
                                {
                                    dbc1.DS.AcceptChanges();

                                    MessageBox.Show("프로필이 성공적으로 업데이트되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // 프로필화면의 데이터를 다시 로드
                                    if (Owner is 프로필화면 profileForm)
                                    {
                                        profileForm.InitializeData(); // 데이터를 즉시 새로 고침
                                    }
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("수정된 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("수정된 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("해당 ID의 데이터를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}


