using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace 음원_관리_프로그램
{
    public partial class 검색화면 : Form
    {

        TrackUserJoinClass dbc = new TrackUserJoinClass();  //*****DBClass 객체 생성
        private string loggedInID;

        private DataTable currentTable;         // 현재 리스트뷰에 있는 table 저장
        private int selectedIndex;              // 현재 리스트뷰에서 선택된 노래의 인덱스 저장

        new 메인화면 Parent;

        public 검색화면(string loggedInID)
        {
            InitializeComponent();
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = string.Empty; // index 변수 초기화

            // 선택된 항목에 따라 index 변수에 값 할당
            switch (comboBox1.SelectedItem.ToString())
            {
                case "제목":
                    index = "제목";
                    break;
                case "가수":
                    index = "가수";
                    break;
                case "장르":
                    index = "장르";
                    break;
                default:
                    index = string.Empty; // 기본값 설정
                    break;
            }


        }

        private void circleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // 검색어와 검색 기준 가져오기
                string searchText = searchBox.Text.Trim();
                string selectedCriteria = comboBox1.SelectedItem?.ToString() ?? "";

                // 검색 조건 유효성 검사
                if (string.IsNullOrEmpty(selectedCriteria))
                {
                    MessageBox.Show("검색 기준을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("검색어를 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 데이터 불러오기
                dbc.DS.Clear(); // DataSet 초기화
                dbc.DBAdapter2.Fill(dbc.DS, "Track_Users");

                // TRACK 테이블 가져오기
                DataTable trackTable = dbc.DS.Tables["Track_Users"];


                // DataView를 통해 필터링
                DataView dv = trackTable.DefaultView;
                string query = "";

                switch (selectedCriteria)
                {
                    case "제목":
                        query = $"track_name LIKE '%{searchText}%'";
                        break;
                    case "가수":
                        query = $"name LIKE '%{searchText}%'";
                        break;
                    case "장르":
                        query = $"genre LIKE '%{searchText}%'";
                        break;
                    default:
                        MessageBox.Show("잘못된 검색 기준입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                dv.RowFilter = query;

                // 필터링 결과 DataGridView에 표시
                //dataGridView1.DataSource = dv;

                // 필터링 결과 listview에 표시
                listView1.Items.Clear();
                for (int i = 0; i < dv.ToTable().Rows.Count; i++)
                {

                    ListViewItem item = new ListViewItem(dv.ToTable().Rows[i]["TRACK_NAME"].ToString());
                    // 다른 컬럼 값 추가 (예: SubItems)
                    item.SubItems.Add(dv.ToTable().Rows[i]["genre"].ToString());
                    item.SubItems.Add(dv.ToTable().Rows[i]["name"].ToString());
                    item.SubItems.Add(dv.ToTable().Rows[i]["play_count"].ToString());

                    listView1.Items.Add(item);
                }

                currentTable = dv.ToTable();


                // 필터링 결과가 없는 경우 메시지 출력
                if (dv.Count == 0)
                {
                    MessageBox.Show("검색 결과가 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DataException de)
            {
                MessageBox.Show($"데이터 오류: {de.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void 검색화면_Load(object sender, EventArgs e)
        {
            Parent = (메인화면)Owner;
            if (Parent == null)
            {
                MessageBox.Show("Parent is null");
            }

            searchBox.Text = Parent.searchText;
            comboBox1.Text = Parent.searchComboBox;
            circleButton1_Click(sender, e);
        }



        private void buyBtn_Click(object sender, EventArgs e)
        {
            구매화면 form5 = new 구매화면(loggedInID);
            form5.Owner = Parent;
            form5.ShowDialog(); // Form2를 보여줍니다.
            form5.Dispose(); // Form2를 보여줍니다.
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                selectedIndex = listView1.SelectedIndices[0];
            }

            try
            {
                if (selectedIndex < 0)
                {
                    // DBGrid의 컬럼 헤더를 클릭하면 컬럼을 정렬하므로
                    // 아무 메시지도 띄우지 않습니다.
                    return;
                }
                else if (selectedIndex > currentTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                DataRow currRow = currentTable.Rows[selectedIndex];
                Parent.pSelectedTrack_no = currRow["track_no"].ToString();      // 트랙테이블에 넣기 
                Console.WriteLine(currRow["track_no"].ToString());

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
    }
}