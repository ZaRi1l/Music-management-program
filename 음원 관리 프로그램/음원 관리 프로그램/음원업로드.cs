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
    public partial class 음원업로드 : Form

    {
        TrackClass dbc = new TrackClass();
        private string loggedInID;

        public 음원업로드(string loggedInID)
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****

            this.loggedInID = loggedInID; // 전달받은 ID를 필드에 저장
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Form1의 인스턴스를 생성합니다.
            메인화면 form1 = new 메인화면(loggedInID);

            // Form1을 보여줍니다.
            form1.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 다이얼로그 제목과 필터 설정
            openFileDialog.Title = "파일을 선택하세요";
            openFileDialog.Filter = "모든 파일 (*.*)|*.*"; // 필요한 경우 필터를 변경할 수 있습니다.

            // 다이얼로그를 열고 사용자가 파일을 선택했는지 확인합니다.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 선택된 파일의 경로를 label3에 표시합니다.
                label3.Text = openFileDialog.FileName; // label3에 파일 경로 추가

                // 버튼의 텍스트를 파일 이름으로 변경
                button2.Text = System.IO.Path.GetFileName(openFileDialog.FileName); // 버튼 텍스트를 파일 이름으로 설정
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) ComboBox에서 선택된 장르 값 가져오기
                string genre = comboBox1.SelectedItem.ToString();  // ComboBox에서 선택된 장르 값
                // 2) 트랙 이름은 titleTxt에서 가져오기
                string title = titleTxt.Text;  // titleTxt.Text에 입력된 트랙 이름 값

                // 3) track_no 자동 생성
                string track_no = GenerateTrackNo(genre);  // 장르에 맞게 track_no 생성

                // 4) ARTIST는 loggedInID 값 사용
                string artist = loggedInID;

                // 5) PLAY_COUNT는 기본값 0
                int playCount = 0;

                // 6) REL_DATE는 현재 시간
                DateTime relDate = DateTime.Now;

                // 새로운 데이터 삽입을 위해 DataTable에 추가
                dbc.DBAdapter.Fill(dbc.DS, "TRACK");
                DataRow newRow = dbc.DS.Tables["TRACK"].NewRow();
                newRow["TRACK_NO"] = track_no;
                newRow["TRACK_NAME"] = title;
                newRow["GENRE"] = genre;
                newRow["ID"] = artist;  // ARTIST 필드에 loggedInID 입력
                newRow["PLAY_COUNT"] = playCount;  // 기본값 0
                newRow["REL_DATE"] = relDate;  // 현재 시간
                newRow["PRICE"] = priceTxt.Text;

                // DataTable에 추가된 새 행을 DataSet에 반영
                dbc.DS.Tables["TRACK"].Rows.Add(newRow);

                // OracleCommandBuilder 사용하여 자동으로 명령어 생성
                dbc.MyCommandBuilder = new OracleCommandBuilder(dbc.DBAdapter);

                // 변경사항을 DB에 업데이트
                dbc.DBAdapter.Update(dbc.DS, "TRACK");

                MessageBox.Show("음원이 성공적으로 업로드 되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생: " + ex.Message);
            }
        }

        private string GenerateTrackNo(string genre)
        {
            // 장르별 첫 번째 숫자 설정 (1000번대, 5000번대 등)
            int genrePrefix = 0;

            switch (genre)
            {
                case "팝송":
                    genrePrefix = 1000;
                    break;
                case "발라드":
                    genrePrefix = 2000;
                    break;
                case "힙합":
                    genrePrefix = 3000;
                    break;
                case "록":
                    genrePrefix = 4000;
                    break;
                case "인디음악":
                    genrePrefix = 5000;
                    break;
                default:
                    genrePrefix = 5000;  // 기본값으로 인디음악
                    break;
            }

            try
            {
                // 연결 상태 확인
                if (dbc.DbConnection.State != ConnectionState.Open)
                {
                    dbc.DbConnection.Open(); // 연결 열기
                }

                // 장르별 트랙 개수 구하기
                string query = $"SELECT COUNT(*) FROM TRACK WHERE genre = '{genre}'";
                using (OracleCommand cmd = new OracleCommand(query, dbc.DbConnection))
                {
                    int trackCount = Convert.ToInt32(cmd.ExecuteScalar());  // 해당 장르의 트랙 개수

                    // 새로운 track_no는 (장르별 번호 + 트랙 개수 + 1)
                    int newTrackNo = genrePrefix + trackCount + 1;

                    // track_no는 4자리로 맞추기 위해 0으로 채움
                    return newTrackNo.ToString("D4");  // D4는 4자리로 0을 채우는 포맷
                }
            }
            catch (Exception ex)
            {
                throw new Exception("트랙 번호 생성 중 오류 발생: " + ex.Message);
            }
            finally
            {
                // 사용 후 연결 닫기 (필요에 따라 결정)
                if (dbc.DbConnection.State == ConnectionState.Open)
                {
                    dbc.DbConnection.Close();
                }
            }
        }


        private void 음원업로드_Load(object sender, EventArgs e)
        {

            // ComboBox에 항목을 추가합니다.
            comboBox1.Items.Add("팝송");
            comboBox1.Items.Add("발라드");
            comboBox1.Items.Add("힙합");
            comboBox1.Items.Add("록");
            comboBox1.Items.Add("인디음악");

            // ComboBox의 기본값을 "인디음악"으로 설정합니다.
            comboBox1.SelectedItem = "인디음악";

            // label5에 loggedInID 표시
            label5.Text = $"{loggedInID}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
