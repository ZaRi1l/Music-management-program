using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 음원_관리_프로그램
{
    public partial class 구매내역 : Form
    {
        private string loggedInID;

        TranTrackUsersJoinClass dbc = new TranTrackUsersJoinClass();
        UserClass dbc1 = new UserClass();

        public 구매내역(string loggedInID)
        {
            InitializeComponent();
            dbc.DB_ObjCreate();
            dbc.DB_Open();

            dbc1.DB_ObjCreate();
            dbc1.DB_Open();

            this.loggedInID = loggedInID;
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

        private void 구매내역_Load(object sender, EventArgs e)
        {

          


            try
            {

                dbc.DS.Tables.Clear();  // 모든 테이블 초기화
                dbc.DS.Clear();         // 데이터 초기화
                dbc.DBAdapter.Fill(dbc.DS, "Tran");


                // DataTable에서 데이터를 가져와서 ListView에 추가
                DataTable trackTable = dbc.DS.Tables["Tran"];
                listView1.Items.Clear(); // 기존 아이템들 초기화

                foreach (DataRow row in trackTable.Rows)
                {
                    // 새로운 ListViewItem 생성
                    ListViewItem item = new ListViewItem(row["track_name"].ToString()); // 첫 번째 컬럼 (track_name)
                    item.SubItems.Add(row["seller_name"].ToString()); // 두 번째 컬럼 (name)
                    item.SubItems.Add(row["genre"].ToString()); // 세 번째 컬럼 (genre)
                    item.SubItems.Add(row["buy_date"].ToString()); // 네 번째 컬럼 (buy_date)

                    // DataRow를 Tag에 저장
                    item.Tag = row;

                    // ListView에 아이템 추가
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 로드하는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 이름 로드
            dbc1.DS.Tables.Clear();  // 모든 테이블 초기화
            dbc1.DS.Clear();         // 데이터 초기화
            dbc1.DBAdapter.Fill(dbc1.DS, "USERS");

            DataRow[] User = dbc1.DS.Tables["USERS"].Select($"ID = '{loggedInID}'");
            string userName = User[0]["NAME"].ToString();
            label1.Text = userName;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                DataRow row = (DataRow)selectedItem.Tag; // Tag에서 DataRow 가져오기

                // 새로운 폼으로 데이터 전달
                상세정보 detailForm = new 상세정보(row);
                detailForm.BuyDate(row["buy_date"].ToString());
                detailForm.SetSellerName(row["seller_name"].ToString());
                detailForm.SellerId(row["seller_id"].ToString());
                detailForm.TranNo(row["tran_no"].ToString());
                detailForm.BuyName(row["buyer_name"].ToString());
                detailForm.BuyId(row["buyer_id"].ToString());
                detailForm.Price(row["price"].ToString());
                detailForm.Show();
            }
        }
    }
}
