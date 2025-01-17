using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;



namespace 음원_관리_프로그램
{
    public partial class 메인화면 : Form
    {

        TrackAsClass dbc = new TrackAsClass();  //*****DBClass 객체 생성
        private string loggedInID;

        public String pSelectedTrack_no = "";  // 그리드 식별 기본키 (부모)

        public String searchText = "";  // 검색 정보
        public String searchComboBox = "";  // 검색 메뉴


        public 메인화면(string userID)
        {
            InitializeComponent();
            loggedInID = userID; // 전달된 ID를 저장
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//**
        }

        public void InitializeData()
        {
            try
            {
                dbc.DB_ObjCreate(); //*****
                dbc.DB_Open();//*****
                dbc.DS.Clear(); // 기존 데이터를 초기화
            
                dbc.DBAdapter.Fill(dbc.DS, "TRACK"); // TRACK 테이블 데이터 로드

                // 인기차트: 조회수 내림차순 정렬
                DataView popularView = dbc.DS.Tables["TRACK"].DefaultView;
                popularView.Sort = "조회수 DESC";
                DBPopularGrid.DataSource = popularView.ToTable(); // 인기차트 데이터 설정

                // 최신차트: 발행일 내림차순 정렬
                DataView dateView = dbc.DS.Tables["TRACK"].DefaultView;
                dateView.Sort = "발행일 DESC";
                DBDateGrid.DataSource = dateView.ToTable(); // 최신차트 데이터 설정
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message, "데이터 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            음원업로드 form2 = new 음원업로드(loggedInID);
            form2.Owner = this; // 현재 메인화면을 소유자로 설정
            form2.ShowDialog(); // 음원 폼 열기
            form2.Dispose(); // 폼 자원 해제
        }


        private void BuyBtn1_Click(object sender, EventArgs e)
        {
            프로필화면 form4 = new 프로필화면(loggedInID);
            form4.Owner = this;
            form4.ShowDialog(); // Form2를 보여줍니다.
            form4.Dispose(); // Form2를 보여줍니다.
        }


        private void button5_Click(object sender, EventArgs e)
        {
            프로필화면 form4 = new 프로필화면(loggedInID);
            form4.Owner = this;
            form4.ShowDialog(); // Form2를 보여줍니다.
            form4.Dispose(); // Form2를 보여줍니다.
        }

        private void button6_Click(object sender, EventArgs e)
        {
            구매내역 form9 = new 구매내역(loggedInID);
            form9.Owner = this;
            form9.ShowDialog(); // Form2를 보여줍니다.
            form9.Dispose(); // Form2를 보여줍니다.
        }

        private void DBDateGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataView dv = dbc.DS.Tables["TRACK"].DefaultView;
                dv.Sort = "발행일 DESC";


                if (e.RowIndex < 0)
                {
                    // DBGrid의 컬럼 헤더를 클릭하면 컬럼을 정렬하므로
                    // 아무 메시지도 띄우지 않습니다.
                    return;
                }
                else if (e.RowIndex > dv.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                // 클릭한 행의 데이터 가져오기
                DataRow currRow = dv[e.RowIndex].Row;

                // 선택된 트랙 정보 출력
                pSelectedTrack_no = currRow["노래번호"].ToString();

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

        private void DBPopularGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataView dv = dbc.DS.Tables["TRACK"].DefaultView;
                dv.Sort = "조회수 DESC";

                // 유효한 클릭인지 확인
                if (e.RowIndex < 0)
                {
                    // 컬럼 헤더 클릭 시 무시
                    return;
                }

                if (e.RowIndex > dv.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                // 클릭한 행의 데이터 가져오기
                DataRow currRow = dv[e.RowIndex].Row;

                // 선택된 트랙 정보 출력
                pSelectedTrack_no = currRow["노래번호"].ToString();
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

        private void searchBtn1_Click(object sender, EventArgs e)
        {
            searchComboBox = comboBox1.Text.Trim();
            검색화면 form3 = new 검색화면(loggedInID);
            form3.Owner = this;
            form3.ShowDialog(); // Form2를 보여줍니다.
            form3.Dispose(); // Form2를 보여줍니다.
        }

        private void searchText1_TextChanged(object sender, EventArgs e)
        {
            searchText = searchText1.Text.Trim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchComboBox = comboBox1.Text.Trim();
        }

        private void 구매하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            구매화면 form5 = new 구매화면(loggedInID);
            form5.Owner = this;
            form5.ShowDialog(); // Form2를 보여줍니다.
            form5.Dispose(); // Form2를 보여줍니다.
        }
    }
}