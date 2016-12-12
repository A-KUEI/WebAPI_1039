using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_1039.Models;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;

namespace WebAPI_1039.Controllers
{
    public class PreauditController : ApiController
    {

        private static readonly DbProviderFactory dbProviderFactory = OleDbFactory.Instance;

        // GET: api/Preaudit
        //public IEnumerable<string> Get()

    public IEnumerable<Preaudit> GetAllPreaudits()
        {

            return getDatafromPreaudit("","ALL");


            //List<Preaudit> Preaudits = new List<Preaudit>();
            //string connectionString = "Provider=MSDAORA;User ID=his;Data Source=TP_OPD_ORD;Persist Security Info=False;PassWord=his1160";

            ////string query = "SELECT PNO,MCODE,REMAINDER  FROM Preaudit  where pno=88001555 and mcode='21141' ";
            //string query = "SELECT  PREAUDIT.PNO,IDP.NAME AS PATNAME , PREAUDIT.MCODE, PREAUDIT.REMAINDER, PREAUDIT.REQYMD, PREAUDIT.REQQTY, PREAUDIT.APVDATE, PREAUDIT.APVQTY,ODRC.NAME AS ORDERNAME  FROM Preaudit,IDP,ODRC  where PREAUDIT.PNO=88001555 AND IDP.PNO=PREAUDIT.PNO AND ODRC.MCODE=PREAUDIT.MCODE  ";
            //query = query + "   ORDER BY    PREAUDIT.PNO,  PREAUDIT.MCODE, PREAUDIT.reqymD DESC ";
            ////**************************


            //DataTable dt = new DataTable();
            ////using (OracleConnection conn = dbProviderFactory.CreateConnection())
            ////using (OracleConnection conn = new OracleConnection())
            //using (OleDbConnection conn = new OleDbConnection())

            //{
            //    conn.ConnectionString = connectionString;//連線字串
            //    //OracleCommand cmd = conn.CreateCommand();
            //    OleDbCommand cmd = conn.CreateCommand();
            //    //↓不寫這行的話，由實作的Provider決定數值，OleDb、Odbc、SqlClient預設30秒，OracleClient為0不逾時
            //    cmd.CommandTimeout = 0;//執行SQL指令時間，0為不逾時
            //    PrepareCommand(cmd, conn, null, CommandType.Text, query, null);
            //    DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter();//DbDataAdapter自己會開/關DB連線
            //    adapter.SelectCommand = cmd;
            //    adapter.Fill(dt);
            //    cmd.Parameters.Clear();
            //    conn.Close();//自關連線
            //}


            ////'*****************************

            ////System.Data.DataTable dt = SqlHelper.GetDataTable(constr, CommandType.Text, query, null);




            ////Bind EmpModel generic list using LINQ 
            //Preaudits = (from DataRow dr in dt.Rows

            //             select new Preaudit()
            //             {
            //                 //Empid = Convert.ToInt32(dr["Id"]),
            //                 PNO = Convert.ToString(dr["PNO"]),
            //                 PATNAME= Convert.ToString(dr["PATNAME"]),
            //                  MCODE = Convert.ToString(dr["MCODE"]),
            //                 ORDERNAME = Convert.ToString(dr["ORDERNAME"]),
            //                 REQYMD = Convert.ToString(dr["REQYMD"]),
            //                 REQQTY = Convert.ToString(dr["REQQTY"]),
            //                 APVDATE = Convert.ToString(dr["APVDATE"]),
            //                 APVQTY = Convert.ToString(dr["APVQTY"]),
            //                 REMAINDER = Convert.ToString(dr["REMAINDER"]),
            //                 text = Convert.ToString(dr["MCODE"]),
            //                 done = false
            //             }).ToList();


            //return Preaudits;
        }

        // GET: api/Preaudit/5
        public IEnumerable<Preaudit> Get(string Pno)
        {
          
            return getDatafromPreaudit(Pno,"ALL");
        }

        // POST: api/Preaudit
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Preaudit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Preaudit/5
        public void Delete(int id)
        {
        }

        private static List<Preaudit>  getDatafromPreaudit(string Pno,string Mode)
        {
            string myPno;
            string myMode;
            if (Pno != "")
            {
                myPno = Pno;
            }
            else
            {
                myPno = "88001555";
            };

       
            switch (Mode)
            {
                case "D":
                    myMode= " AND ( PREAUDIT.TYPE='D' )";
                    break;
                case "N":
                    myMode = " AND ( PREAUDIT.TYPE='' OR PREAUDIT.TYPE IS NULL )";
                    break;
                case "M":
                    myMode = " AND ( PREAUDIT.TYPE='M' )";
                    break;
                default:
                    myMode = "";
                    break;
            }
            List<Preaudit> Preaudits = new List<Preaudit>();
            string connectionString = "Provider=MSDAORA;User ID=his;Data Source=TP_OPD_ORD;Persist Security Info=False;PassWord=his1160";

            //string query = "SELECT PNO,MCODE,REMAINDER  FROM Preaudit  where pno=88001555 and mcode='21141' ";
            string query = "SELECT  PREAUDIT.PNO,IDP.NAME AS PATNAME , PREAUDIT.MCODE, PREAUDIT.TYPE, PREAUDIT.REMAINDER, PREAUDIT.REQYMD, PREAUDIT.REQQTY, PREAUDIT.APVDATE, PREAUDIT.APVQTY,ODRC.NAME AS ORDERNAME  FROM Preaudit,IDP,ODRC  where PREAUDIT.PNO=" + myPno + " AND IDP.PNO=PREAUDIT.PNO AND ODRC.MCODE=PREAUDIT.MCODE  ";

            query = query + myMode;


            query = query + "   ORDER BY    PREAUDIT.PNO,  PREAUDIT.MCODE, PREAUDIT.reqymD DESC ";
            //**************************


            DataTable dt = new DataTable();
            //using (OracleConnection conn = dbProviderFactory.CreateConnection())
            //using (OracleConnection conn = new OracleConnection())
            using (OleDbConnection conn = new OleDbConnection())

            {
                conn.ConnectionString = connectionString;//連線字串
                //OracleCommand cmd = conn.CreateCommand();
                OleDbCommand cmd = conn.CreateCommand();
                //↓不寫這行的話，由實作的Provider決定數值，OleDb、Odbc、SqlClient預設30秒，OracleClient為0不逾時
                cmd.CommandTimeout = 0;//執行SQL指令時間，0為不逾時
                PrepareCommand(cmd, conn, null, CommandType.Text, query, null);
                DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter();//DbDataAdapter自己會開/關DB連線
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                cmd.Parameters.Clear();
                conn.Close();//自關連線
            }


            //'*****************************

            //System.Data.DataTable dt = SqlHelper.GetDataTable(constr, CommandType.Text, query, null);

          

           
            foreach (DataRow myRow in dt.Rows)
                {

                String myType;
                myType = Convert.ToString(myRow["TYPE"]);
                    switch (myType)
                    {
                        case "D":
                            myRow["TYPE"] = "藥委會";
                            break;
                        case "":
                            myRow["TYPE"] = "健保署";
                            break;
                        case "M":
                            myRow["TYPE"] = "院內自審";
                            break;
                    }

            }

    


            //if (dt.Rows.Count==0) {
            //    DataRow myRow;
            //    myRow = dt.NewRow();
            //    myRow["TYPE"] = "查無資料";
            //    myRow["PATNAME"] = "查無資料";
            //    myRow["MCODE"] = "查無資料";
            //    myRow["ORDERNAME"] = "查無資料";
            //    dt.Rows.Add(myRow);
            //};

            dt.AcceptChanges();
            //Bind EmpModel generic list using LINQ 
            Preaudits = (from DataRow dr in dt.Rows

                         select new Preaudit()
                         {
                             //Empid = Convert.ToInt32(dr["Id"]),
                             PNO = Convert.ToString(dr["PNO"]),
                             PATNAME = Convert.ToString(dr["PATNAME"]),
                             TYPE = Convert.ToString(dr["TYPE"]),
                             MCODE = Convert.ToString(dr["MCODE"]),
                             ORDERNAME = Convert.ToString(dr["ORDERNAME"]),
                             REQYMD = Convert.ToString(dr["REQYMD"]),
                             REQQTY = Convert.ToString(dr["REQQTY"]),
                             APVDATE = Convert.ToString(dr["APVDATE"]),
                             APVQTY = Convert.ToString(dr["APVQTY"]),
                             REMAINDER = Convert.ToString(dr["REMAINDER"]),
                             text = Convert.ToString(dr["MCODE"]),
                             done = false
                         }).ToList();



            

            return Preaudits;
            }
     


        /// <summary>
        /// 為執行命令準備參數
        /// </summary>
        /// <param name="cmd">DbCommand 命令</param>
        /// <param name="conn">資料庫連線</param>
        /// <param name="trans">交易處理</param>
        /// <param name="cmdType">DbCommand類型 (CommandType.StoredProcedure或CommandType.Text)</param>
        /// <param name="cmdText">DbCommand的T-SQL语句 例如：Select * from Products</param>
        /// <param name="cmdParms">使用到的參數集合</param>
        //private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText,
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText,
            DbParameter[] cmdParms)
        {
            //判斷資料庫連線狀態
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            //判斷是否需要交易處理
            if (trans != null) { cmd.Transaction = trans; }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (cmdParms != null && cmdParms.Length > 0)
            {
                foreach (DbParameter param in cmdParms) { cmd.Parameters.Add(param); }
            }
        }
    }
}
