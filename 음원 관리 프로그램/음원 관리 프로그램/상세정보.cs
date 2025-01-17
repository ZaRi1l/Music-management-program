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
    public partial class 상세정보 : Form
    {
        private DataRow dataRow;

        // 생성자에서 데이터 받기
        public 상세정보(DataRow row)
        {
            InitializeComponent();
            this.dataRow = row;

            // 상세정보 폼 초기화, 추가적으로 다른 데이터를 초기화하고 싶다면 여기에 작성
            buy_dateTxt.Text = row["buy_date"].ToString(); // 구매일자
            seller_nameTxt.Text = row["seller_name"].ToString(); // 판매자명
            seller_IdTxt.Text = row["seller_id"].ToString(); // 판매자ID
            tran_noTxt.Text = row["tran_no"].ToString(); //거래번호
            buyer_nameTxt.Text = row["buyer_name"].ToString(); //구매자명
            buyer_IdTtxt.Text = row["buyer_id"].ToString(); //구매자ID
            priceTxt.Text = row["price"].ToString(); //가격

        }

        private void 상세정보_Load(object sender, EventArgs e)
        {
            
        }
        public void BuyDate(string buyDate) // 해당 구매일자를 해당 텍스트 박스에 할당
        {
            buy_dateTxt.Text = buyDate;
        }
        public void SetSellerName(string sellerName) // 해당 판매자명을 해당 텍스트 박스에 할당
        {
            seller_nameTxt.Text = sellerName;
        }
        public void SellerId(string sellerId) // 해당 판매자명을 해당 텍스트 박스에 할당
        {
            seller_IdTxt.Text = sellerId;
        }
        public void TranNo(string tranNo) // 해당 거래번호를 해당 텍스트 박스에 할당
        {
            tran_noTxt.Text = tranNo;
        }
        public void BuyName(string buyName) // 해당 거래번호를 해당 텍스트 박스에 할당
        {
            buyer_nameTxt.Text = buyName;
        }
        public void BuyId(string buyId) // 해당 거래번호를 해당 텍스트 박스에 할당
        {
            buyer_IdTtxt.Text = buyId;
        }
        public void Price(string price) // 해당 거래번호를 해당 텍스트 박스에 할당
        {
            priceTxt.Text = price;
        }
    }
}
