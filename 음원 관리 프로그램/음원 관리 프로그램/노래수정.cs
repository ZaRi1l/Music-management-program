using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 음원_관리_프로그램
{
    public partial class 노래수정 : Form
    {
        TrackClass dbc = new TrackClass();
        DataTable trackTable;
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox3.Clear();
            
        }
         private 메인화면 mainForm;
        private string loggedInID;
        public 노래수정(string loggedInID)
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            this.loggedInID = loggedInID;
        }

        private void 노래수정_Load(object sender, EventArgs e)
        {
            // Track 테이블 데이터를 초기화하고 채우기
            dbc.DS.Clear(); // DataSet 초기화
            dbc.DBAdapter.Fill(dbc.DS, "TRACK"); // TRACK 테이블 데이터 로드

            trackTable = dbc.DS.Tables["TRACK"]; // TRACK 테이블 가져오기

            // listBox1 초기화
            listBox1.Items.Clear();

            // 로그인된 ID를 기준으로 TRACK 테이블에서 필터링
            DataRow[] filteredRows = trackTable.Select($"ID = '{loggedInID}'");

            // 필터링된 행에서 이름, 장르, 가격 정보를 listBox1에 추가
            foreach (DataRow row in filteredRows)
            {
                string trackno = row["TRACK_NO"].ToString();
                string trackName = row["TRACK_NAME"].ToString();
                string genre = row["GENRE"].ToString();
                string price = row["PRICE"].ToString();

                // 이름, 장르, 가격 형식으로 추가
                listBox1.Items.Add($"{trackno}   |{trackName} | {genre} | {price}");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // 선택된 항목에서 TRACK_NO 추출
                string selectedItem = listBox1.SelectedItem.ToString();
                string[] parts = selectedItem.Split('|');

                if (parts.Length > 0)
                {
                    string trackNo = parts[0].Trim(); // TRACK_NO

                    // Primary Key를 설정하여 Find 사용 가능
                    if (trackTable.PrimaryKey.Length == 0)
                    {
                        DataColumn[] primaryKey = new DataColumn[1];
                        primaryKey[0] = trackTable.Columns["TRACK_NO"];
                        trackTable.PrimaryKey = primaryKey;
                    }

                    DataRow currRow = trackTable.Rows.Find(trackNo);

                    if (currRow != null)
                    {
                        // 선택된 데이터를 텍스트 박스에 표시
                        textBox1.Text = currRow["TRACK_NAME"].ToString();
                        comboBox1.Text = currRow["GENRE"].ToString();
                        textBox3.Text = currRow["PRICE"].ToString();
                        textBox4.Text = currRow["TRACK_NO"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("선택된 항목을 찾을 수 없습니다.", "오류");
                    }
                }
                else
                {
                    MessageBox.Show("선택된 항목이 올바르지 않습니다.", "오류");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("수정하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // 사용자가 "예"를 선택한 경우
                {
                    // 텍스트 박스에서 값 가져오기
                    string trackNo = textBox4.Text.Trim(); // TRACK_NO
                    string trackName = textBox1.Text.Trim(); // TRACK_NAME
                    string genre = comboBox1.Text.Trim(); // GENRE
                    string price = textBox3.Text.Trim(); // PRICE

                    // TRACK_NO를 기준으로 행 검색
                    DataRow currRow = trackTable.Rows.Find(trackNo);

                    if (currRow != null)
                    {
                        // DataRow 업데이트
                        currRow["TRACK_NAME"] = trackName;
                        currRow["GENRE"] = genre;
                        currRow["PRICE"] = price;

                        // 데이터베이스에 변경사항 반영
                        dbc.DBAdapter.Update(dbc.DS, "TRACK");

                        MessageBox.Show("수정이 완료되었습니다.", "성공");

                        // 프로필화면의 데이터를 다시 로드
                        if (Owner is 프로필화면 profileForm)
                        {
                            profileForm.InitializeData(); // 데이터를 즉시 새로 고침
                        }
                       

                        // 현재 폼 닫기
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("수정할 데이터를 찾을 수 없습니다.", "오류");
                    }
                }
                else
                {
                    MessageBox.Show("수정이 취소되었습니다.", "알림");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"수정 중 오류가 발생했습니다: {ex.Message}", "오류");
            }
        }
    }
}

