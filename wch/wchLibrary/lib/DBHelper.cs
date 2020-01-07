using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace wch.lib
{
    
    public class DBHelper
    {
        public static Random random = new Random();

        #region 获取数据库连接字符串
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns>返回数据库连接字符串</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["wch"].ToString();
        }
        #endregion

        #region 测试数据库连接
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns>返回状态码,-1表示出错</returns>
        public static int ConnectionTest()
        {
            try
            {
                SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString());
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region 执行sql语句并返回受影响的行数
        /// <summary>
        /// 执行sql语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">要查询的语句</param>
        /// <param name="paraList">变量列表Sqlparameters(可选)</param>
        /// <param name="commType">要查询语句的类型</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, List<SqlParameter> paraList = null, CommandType commType = CommandType.Text)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString());
                conn.Open();
                SqlCommand comm = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = commType,
                    CommandText = sql,
                    CommandTimeout = 600,
                };
                if (paraList != null)
                {
                    foreach (var para in paraList)
                    {
                        comm.Parameters.Add(para);
                    }
                }
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //throw;
                return -1;
            }
        }
        #endregion

        #region 绑定下拉栏-暂时不用
        /// <summary>
        /// 用来绑定下拉菜单ComboBox
        /// </summary>
        /// <param name="cb">需要绑定的ComboBox名字</param>
        /// <param name="table">被绑定的表单</param>
        /// <param name="valueField">被绑定的表单的实际值</param>
        /// <param name="displayField">被绑定表单的显示值</param>
        /// <param name="hasTip">是否有"请选择"提示</param>
        //public static void BindCombo(ComboBox cb, DataTable table, string valueField, string displayField, bool hasTip)
        //{
        //    if (hasTip)
        //    {
        //        DataRow row = table.NewRow();
        //        row[valueField] = "0";
        //        row[displayField] = "请选择";
        //        table.Rows.InsertAt(row, 0);
        //    }
        //    cb.ValueMember = valueField;
        //    cb.DisplayMember = displayField;
        //    cb.DataSource = table;
        //}
        #endregion

        #region 执行事务
        /// <summary>
        /// 事务方法
        /// </summary>
        /// <param name="sqlList">命令集合</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQueryTransaction(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection();
            SqlTransaction trans = null; // 定义事务
            int cnt = 0;
            try
            {
                conn.ConnectionString = DBHelper.GetConnectionString();
                conn.Open();
                trans = conn.BeginTransaction(); // 创建事务
                foreach (string sql in sqlList)
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = sql;
                    comm.Transaction = trans; //命令事务对象
                    cnt += comm.ExecuteNonQuery();
                }
                trans.Commit(); //  提交事务
                return cnt;
            }
            catch (Exception)
            {
                trans.Rollback();//  回滚事务
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        #endregion

        #region 离线查询数据DataTable(返回表)
        /// <summary>
        /// 离线查询数据DataTable(返回表)
        /// </summary>
        /// <param name="sql">要查询的语句</param>
        /// <param name="paraList">变量列表Sqlparameters(可选)</param>
        /// <param name="commType">要查询语句的类型</param>
        /// <returns>返回查询得到的DataTable</returns>
        public static DataTable ExecuteReaderDataTable(string sql, List<SqlParameter> paraList = null, CommandType commType = CommandType.Text)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString());
                SqlCommand comm = new SqlCommand
                {
                    CommandText = sql,
                    CommandType = commType,
                    Connection = conn,
                    CommandTimeout = 600,
                };
                if (paraList != null)
                {
                    foreach (var para in paraList)
                    {
                        comm.Parameters.Add(para);
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                return table;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
                throw;
            }
        }
        #endregion

        #region 离线查询数据DataTable(返回表的第一行DataRow)
        /// <summary>
        /// 离线查询数据DataTable(返回表的第一行DataRow)
        /// </summary>
        /// <param name="sql">要查询的语句</param>
        /// <param name="paraList">变量列表Sqlparameters(可选)</param>
        /// <param name="commType">要查询语句的类型</param>
        /// <returns>返回查询结果的第一行DataRow</returns>
        public static DataRow ExecuteReaderDataRow(string sql, List<SqlParameter> paraList = null, CommandType commType = CommandType.Text)
        {
            DataTable data = DBHelper.ExecuteReaderDataTable(sql, paraList, commType);
            return (data.Rows.Count > 0) ? data.Rows[0] : null;
        }
        #endregion

        #region 判断是否存在行
        /// <summary>
        /// 查询语句结果是否存在行
        /// </summary>
        /// <param name="sql">要查询的语句</param>
        /// <param name="paraList">变量列表Sqlparameters(可选)</param>
        /// <param name="commType">要查询语句的类型</param>
        /// <returns>返回bool值</returns>
        public static bool ExcuteExist(string sql, List<SqlParameter> paraList = null, CommandType commType = CommandType.Text)
        {
            DataTable data = DBHelper.ExecuteReaderDataTable(sql, paraList, commType);
            return (data.Rows.Count > 0) ? true : false;
        }
        #endregion

        #region 创建para语句
        /// <summary>
        /// 创建para语句
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="sqlDbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="paraValue">参数值</param>
        /// <param name="paraSize">参数长度</param>
        /// <returns>返回SqlParameter</returns>
        public static SqlParameter CreatePara(string paraName, SqlDbType sqlDbType,
            ParameterDirection direction = ParameterDirection.Input, object paraValue = null, int paraSize = 0)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = paraName; //参数名
            sqlParameter.SqlDbType = sqlDbType; //参数类型
            sqlParameter.Direction = direction; //参数方向
            if (paraValue != null) sqlParameter.Value = paraValue;
            if (paraSize != 0) sqlParameter.Size = paraSize;
            return sqlParameter;
        }
        #endregion

        #region 特殊查询（汇总）
        /// <summary>
        /// 汇总查询
        /// </summary>
        /// <param name="sql">要查询的语句</param>
        /// <param name="paraList">变量列表Sqlparameters(可选)</param>
        /// <param name="commandType">要查询语句的类型</param>
        /// <returns>返回第一行的第一个字段</returns>
        public static object ExecuteScalar(string sql, List<SqlParameter> paraList = null, CommandType commandType = CommandType.Text)
        {
            object cnt;
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DBHelper.GetConnectionString();
                conn.Open();
                SqlCommand comm = new SqlCommand()
                {
                    Connection = conn,
                    CommandText = sql,
                    CommandTimeout = 600,
                    CommandType = commandType,
                };
                if (paraList != null)
                {
                    foreach (SqlParameter para in paraList)
                        comm.Parameters.Add(para);
                }
                cnt = comm.ExecuteScalar();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return cnt;
        }
        #endregion

        #region 字符串MD5加密
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="txt">待加密的文本</param>
        /// <returns>返回加密文本</returns>

        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        #endregion
        /*
        #region 将DataGridView数据导出到Excel
        /// <summary>
        /// 将DataGridView数据导出到Excel
        /// </summary>
        /// <param name="dataGridView">导出的DataGridView对象</param>
        /// <param name="fileName">文件名</param>
        public static void DataGridViewToExcel(DataGridView dataGridView, string fileName)
        {
            try
            {
                ExcelControl exportToExcel = new ExcelControl();
                exportToExcel.OutputAsExcelFile(dataGridView, fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 将Excel数据导出到DataGridView
        public static void ExcelToDataGridView(DataGridView DGV)
        {
            ExcelControl input = new ExcelControl();
            DGV.DataSource = input.InputToDataGridView();
        }
        #endregion

        #region 订单号自动生成
        /// <summary>
        /// 自动生成订单号
        /// </summary>
        /// <returns>返回订单号</returns>
        public static string GetOrderID()
        {
            string sql = "select OrderID from Orders order by OrderDate desc";
            string rear = ((Convert.ToInt32(DBHelper.ExecuteScalar(sql).ToString().Substring(8, 4)) + 10) % 10000).ToString("0000");
            string head = DateTime.Now.ToString("yyyyMMdd");
            return head + rear;
        }
        #endregion

        #region 获取随机文本
        /// <summary>
        /// 获取随机文本GuGuGu-中间字符串-四位Random
        /// </summary>
        /// <param name="category">中间字符串</param>
        /// <returns>返回随机文本</returns>
        public static string GetFileName(string category)
        {
            string head = "GuGuGu-";
            string middle = category + "-";
            string time = DateTime.Now.ToString("yyyyMMdd");
            string rear = random.Next(0000, 9999).ToString("0000");
            return head + middle + time + rear;
        }
        #endregion

        #region 获取当前时间
        public static string GetNowTime()
        {
            return DateTime.Now.ToString();
        }
        #endregion

        #region 类别号自动生成
        /// <summary>
        /// 自动生成类别号
        /// </summary>
        /// <returns>返回类别号</returns>
        public static string GetCategoryID()
        {
            string sql = "select CategoryID from Categories order by CategoryID desc";
            string rear = (Convert.ToInt32(DBHelper.ExecuteScalar(sql).ToString().Substring(4, 6)) + 1).ToString("000000");
            string head = "CATE";
            return head + rear;
        }
        #endregion

        #region 顾客编号自动生成
        /// <summary>
        /// 顾客编号自动生成
        /// </summary>
        /// <returns>返回生成的顾客编号</returns>
        public static string GetCustomerID()
        {
            string sql = "select CustomerID from Customers order by CustomerID desc";
            string head = "CUS";
            string rear = (Convert.ToInt32(DBHelper.ExecuteScalar(sql).ToString().Substring(3, 6)) + 1).ToString("000000");
            return head + rear;
        }
        #endregion

        #region 商品号自动生成
        /// <summary>
        /// 商品编号自动生成
        /// </summary>
        /// <returns>返回自动生成的商品编号</returns>
        public static string GetProductID()
        {
            string sql = "select ProductID from Products order by ProductID desc";
            string rear = (Convert.ToInt32(DBHelper.ExecuteScalar(sql).ToString().Substring(1, 6)) + 1).ToString("000000");
            string head = "P";
            return head + rear;
        }
        #endregion

        #region 判断选择的行号在DataGridView的有效范围内
        /// <summary>
        /// 判断选择的行号在DataGridView的有效范围内
        /// </summary>
        /// <param name="selectRow">当前行号</param>
        /// <param name="dataGridView">判断的DataGridView</param>
        /// <returns>返回bool值</returns>
        public static bool IsInDataGridView(int selectRow, DataGridView dataGridView)
        {
            return (selectRow >= 0 && selectRow < dataGridView.RowCount - 1);
        }
        #endregion
 */
    }
}
