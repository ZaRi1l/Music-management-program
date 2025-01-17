using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace 음원_관리_프로그램
{
    public partial class 프로필화면 : Form
    {
        UserClass dbc1 = new UserClass();
        User_ProfileClass dbc2 = new User_ProfileClass();
        TrackAsClass dbc3 = new TrackAsClass();
        PlaylistAsClass dbc4 = new PlaylistAsClass();

        private string loggedInID;
        public 프로필화면(string loggedInID)
        {
           
            dbc1.DB_ObjCreate();
            dbc1.DB_Open();

            dbc1.DS.Clear();
            dbc1.DBAdapter.Fill(dbc1.DS, "USERS");

            dbc2.DB_ObjCreate();
            dbc2.DB_Open();

            dbc2.DS.Clear();
            dbc2.DBAdapter.Fill(dbc2.DS, "USER_PROFILE");

            dbc3.DB_ObjCreate();
            dbc3.DB_Open();

            dbc3.DS.Clear();
            dbc3.DBAdapter.Fill(dbc3.DS, "TRACK");

            dbc4.DB_ObjCreate();
            dbc4.DB_Open();

            dbc4.DS.Clear();
            dbc4.DBAdapter.Fill(dbc4.DS, "PLAYLIST");

            this.loggedInID = loggedInID;
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            메인화면 form1 = new 메인화면(loggedInID);

            // Form1을 보여줍니다.

            this.Close();
        }

        private void 프로필화면_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            프로필수정 form8 = new 프로필수정(loggedInID);
            // Form2을 보여줍니다.
            form8.Show();
        }

        private void circleButton1_Click(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            노래수정 frm2 = new 노래수정(loggedInID);
            frm2.Owner = this; // 현재 폼(프로필화면)을 소유자로 설정
            frm2.ShowDialog();
            frm2.Dispose();
        }
        public void InitializeData()
        {

            dbc1.DB_ObjCreate();
            dbc1.DB_Open();

            dbc1.DS.Clear();
            dbc1.DBAdapter.Fill(dbc1.DS, "USERS");

            dbc2.DB_ObjCreate();
            dbc2.DB_Open();

            dbc2.DS.Clear();
            dbc2.DBAdapter.Fill(dbc2.DS, "USER_PROFILE");

            dbc3.DB_ObjCreate();
            dbc3.DB_Open();

            dbc3.DS.Clear();
            dbc3.DBAdapter.Fill(dbc3.DS, "TRACK");

            dbc4.DB_ObjCreate();
            dbc4.DB_Open();

            dbc4.DS.Clear();
            dbc4.DBAdapter.Fill(dbc4.DS, "PLAYLIST");

            DataRow[] User = dbc1.DS.Tables["USERS"].Select($"ID = '{loggedInID}'");
            label1.Text = User[0]["NAME"].ToString();

            DataRow[] UserProfile = dbc2.DS.Tables["USER_PROFILE"].Select($"ID = '{loggedInID}'");
            label2.Text = UserProfile[0]["USER_COMMENT"].ToString();

            DataTable trackTable = dbc3.DS.Tables["TRACK"];
            DataRow[] filteredRows = trackTable.Select($"가수 = '{loggedInID}'");

            // 내가 올린 음악
            DataTable filteredTrackTable = trackTable.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredTrackTable.ImportRow(row);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredTrackTable.DefaultView;

            // 내가 듣는 음악
            DataTable PlaylistTable = dbc4.DS.Tables["PLAYLIST"];
            DataRow[] filteredRows2 = PlaylistTable.Select($"구매자 = '{loggedInID}'");

            List<string> trackNoList = new List<string>();
            foreach (DataRow row in filteredRows2)
            {
                trackNoList.Add(row["노래번호"].ToString());
            }

            string[] trackNoArray = trackNoList.ToArray();
            DataTable filteredTrackTable2 = trackTable.Clone();
            foreach (string trackNo in trackNoArray)
            {
                DataRow[] matchingRows = trackTable.Select($"노래번호 = '{trackNo}'");
                foreach (DataRow row in matchingRows)
                {
                    filteredTrackTable2.ImportRow(row);
                }
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = filteredTrackTable2.DefaultView;

            dataGridView1.Refresh();
            dataGridView2.Refresh();

            if (Owner is 메인화면 mainForm)
            {
                mainForm.InitializeData(); // 데이터를 즉시 새로 고침
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            노래수정 frm2 = new 노래수정(loggedInID);
            frm2.Owner = this; // 현재 폼(프로필화면)을 소유자로 설정
            frm2.ShowDialog();
            frm2.Dispose();
        }
    }
}

