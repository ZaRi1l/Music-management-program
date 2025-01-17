using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;//ADO.Net 개체 참조
using System.Data; //DataSet 개체 참조
using System.Windows.Forms; //MessageBox 개체 참조

namespace 음원_관리_프로그램
{
    internal class TranTrackUsersJoinClass
    {
        private int selectedRowIndex;//수정하거나 삭제하기 위해 선택된 행의 인덱스를 저장한다. 

        private int selectedKeyValue; // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드

        OracleDataAdapter dBAdapter; // Data Provider인 DBAdapter 입니다.

        DataSet dS;// DataSet 객체입니다.

        OracleCommandBuilder myCommandBuilder; // 추가, 수정, 삭제시에 필요한 명령문을 자동으로 작성해주는 객체

        OracleCommand myCommand; //조인 연산할 때, BuilderCommand 못 쓰니까 일단 넣어놈

        DataTable TRANTable;// DataTable 객체입니다.

        public int SelectedRowIndex
        {
            get { return selectedRowIndex; }
            set { selectedRowIndex = value; }
        }
        public int SelectedKeyValue
        {
            get { return selectedKeyValue; }
            set { selectedKeyValue = value; }
        }

        public OracleDataAdapter DBAdapter
        {
            get { return dBAdapter; }
            set { dBAdapter = value; }
        }

        public DataSet DS
        {
            get { return dS; }
            set { dS = value; }
        }

        public OracleCommandBuilder MyCommandBuilder
        {
            get { return myCommandBuilder; }
            set { myCommandBuilder = value; }
        }

        public OracleCommand MyCommand
        {
            get { return myCommand; }
            set { myCommand = value; }
        }

        public DataTable TranTable
        {
            get { return TRANTable; }
            set { TRANTable = value; }
        }

        public void DB_Open()
        {
            try
            {
                string connectionString = "User Id=asd; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";

                string commandString = "SELECT TO_CHAR(TR.buy_date, 'YYYY-MM-DD') AS buy_date, T.track_name, T.id AS seller_id, T.genre, TR.tran_no, U.name AS buyer_name, U.id AS buyer_id, U2.name AS seller_name, T.price " +
                    "FROM TRAN TR JOIN TRACK T ON TR.track_no = T.track_no JOIN USERS U ON TR.ID = U.ID JOIN USERS U2 ON T.ID = U2.ID " +
                    "WHERE TR.ID = :inputID";

                OracleConnection conn = new OracleConnection(connectionString);

                DBAdapter = new OracleDataAdapter();

                DBAdapter.SelectCommand = new OracleCommand(commandString, conn);

                DBAdapter.SelectCommand.Parameters.Add("inputID", OracleDbType.Varchar2, 20);

                DBAdapter.SelectCommand.Parameters["inputID"].Value = 로그인화면.inputID;

                DS = new DataSet(); //TRAN 테이블

            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        public void DB_ObjCreate()
        {
            try
            {
                TRANTable = new DataTable();
            }

            catch (Exception ex)
            {
                MessageBox.Show("DB_ObjCreate 오류: " + ex.Message);
            }
        }
    }
}
