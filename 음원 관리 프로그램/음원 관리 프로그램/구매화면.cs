using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 음원_관리_프로그램
{
    public partial class 구매화면 : Form
    {
        private string loggedInID;
        new 메인화면 Parent;

        TrackUserJoinClass dbc1 = new TrackUserJoinClass();  //  dbc1 == TRACK테이블
        TranClass dbc2 = new TranClass();  //dbc2 == TRAN테이블
        PlaylistClass dbc3 = new PlaylistClass();   //dbc3 == PLAYLIST테이블

        public 구매화면(string loggedInID)
        {
            InitializeComponent();
            dbc1.DB_ObjCreate(); //*****
            dbc1.DB_Open();//****
            dbc2.DB_ObjCreate(); //*****
            dbc2.DB_Open();//****
            dbc3.DB_ObjCreate(); //*****
            dbc3.DB_Open();//****
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Parent = (메인화면)Owner;
            if (Parent == null)
            {
                MessageBox.Show("Parent is null");
            }

            dbc1.DS.Clear();
            dbc1.DBAdapter.Fill(dbc1.DS, "Track_Users");
            dbc1.TrackUserJoinTable = dbc1.DS.Tables["Track_Users"];

            DataRow ResultRow = dbc1.TrackUserJoinTable.Select("track_no like '%" + Parent.pSelectedTrack_no + "%'")[0];
            nameLabel.Text = ResultRow["track_name"].ToString();
            //Cover = ResultRow["track_cover"].ToString();
            genreLabel.Text = ResultRow["genre"].ToString();
            userNameLabel.Text = ResultRow["name"].ToString();

            DateTime dt = Convert.ToDateTime(ResultRow["rel_date"]);
            dateLabel.Text = dt.ToString("yyyy-MM-dd");
            priceLabel.Text = ResultRow["price"].ToString();
        }

        private void BuyBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dbc1.DS == null || dbc1.DBAdapter == null)
                {
                    MessageBox.Show("DB 객체가 초기화되지 않았습니다.");
                    return;
                }

                dbc1.DS.Clear();  // 초기화

                dbc1.DBAdapter.Fill(dbc1.DS, "track");  // track 데이터 로드

                dbc1.TrackUserJoinTable = dbc1.DS.Tables["track"];

                DataRow ResultRow = dbc1.TrackUserJoinTable.Select("track_no like '%" + Parent.pSelectedTrack_no + "%'")[0];


                dbc2.DS.Clear();  // TRAN 테이블 초기화

                dbc2.DBAdapter.Fill(dbc2.DS, "tran");

                dbc2.TranTable = dbc2.DS.Tables["tran"];


                dbc3.DS.Clear();  // PLAYLIST 테이블 초기화

                dbc3.DBAdapter.Fill(dbc3.DS, "playlist");

                dbc3.PlaylistTable = dbc3.DS.Tables["playlist"];


                DataRow newRow = dbc2.TranTable.NewRow();           // TRAN 테이블 새로 만들 튜플
                DataRow newRow2 = dbc3.PlaylistTable.NewRow();       // PLAYLIST 테이블 새로 만들 튜플

                int tranTableLen = dbc2.TranTable.Rows.Count;       // 테이블 길이 가져오기
                string tranTableNo = Convert.ToString(tranTableLen + 1).PadLeft(3, '0');     // 길이에 1더하고 앞에 0붙이기

                newRow["TRAN_NO"] = "T" + tranTableNo + tranTableNo;     // 임의로 적어 놓음 나중에 데이터 베이스에서 자동을 올라가게 해야하나?
                newRow["ID"] = 로그인화면.inputID;      // 로그인한 아이디에 따른 동적 할당
                newRow["sell_qty"] = 1;            // 임의로 적어 놓음 (노래는 하나씩 밖에 못사니까 1로 설정)
                newRow["last_month_sell"] = DateTime.Now.Month.ToString();
                newRow["track_no"] = ResultRow["track_no"].ToString();
                newRow["buy_date"] = DateTime.Now;

                newRow2["ID"] = 로그인화면.inputID;
                newRow2["track_no"] = ResultRow["track_no"].ToString();
                newRow2["track_name"] = ResultRow["track_name"].ToString();
                newRow2["genre"] = ResultRow["genre"].ToString();

                dbc2.TranTable.Rows.Add(newRow);        // TRAN과 PLAYLIST에 각각 추가
                dbc3.PlaylistTable.Rows.Add(newRow2);

                dbc2.DBAdapter.Update(dbc2.DS, "TRAN");
                dbc2.DS.AcceptChanges();

                dbc3.DBAdapter.Update(dbc3.DS, "PLAYLIST");
                dbc3.DS.AcceptChanges();

                MessageBox.Show("구매 되었습니다", "구매 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Form1의 인스턴스를 생성합니다.
            메인화면 form1 = new 메인화면(loggedInID);

            // Form1을 보여줍니다.



            if (form1.IsDisposed == false)          // form1이 열려있는지 알려여 있는지 따라 뒤로가는 버튼 다르게
            {
                this.Close();
            }
            else
            {
                form1.Show();
                this.Close();
            }

        }
    }
}