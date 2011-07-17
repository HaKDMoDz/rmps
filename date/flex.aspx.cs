using System;
using System.Data;
using System.Text;
using System.Web.UI;

using MySql.Data.MySqlClient;

public partial class date_flex : Page
{
    public const String OP_DELETE = "delete"; //删除
    public const String OP_INSERT = "insert"; //插入
    public const String OP_SELECT = "select"; //查询
    public const String OP_UPDATE = "update"; //更新

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * 获取页面参数，获取方法为：Request["{0}"]。
         * 其中{0}为您要获取的参数名称。
         */
        switch (Request["op"]) // 数据操作类型
        {
            case OP_SELECT: //查询
                {
                    Response.Write(SelecteNote());
                    Response.End();
                    break;
                }
            case OP_UPDATE: //更新
                {
                    Response.Write(UpdateNote());
                    Response.End();
                    break;
                }
            case OP_INSERT: //插入
                {
                    Response.Write(InsertNote());
                    Response.End();
                    break;
                }
            case OP_DELETE: //删除
                {
                    Response.Write(DeleteNote());
                    Response.End();
                    break;
                }
            default: //容错
                {
                    break;
                }
        }
    }

    private String SelecteNote()
    {
        StringBuilder data = new StringBuilder();

        // 声明XML头信息
        data.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

        // 查询结果数据拼接
        data.Append("<Notes>");

        // 获取页面传入参数
        String noteName = Request["nm"];
        // 判断NoteName是否为合适的数据，没有这个参数或者传入的参数不包含有效的字符时，不进行后面的处理。
        if (noteName != null && noteName.Trim() != "")
        {
            // 此处即为正常的数据查询语句，noteName变量为用户传进来的数据，看一下这里是怎么拼接起来的。
            // 再一个也可以从此处看出：脚本文件中字符串要使用单引号的好处，即可以直接在其它语言中书写，而不需要做转意处理，格式也简单明了。
            String sqlSelect = "SELECT * FROM asunnote WHERE NOTENAME LIKE '%" + noteName + "%'";

            DataView dataView = Select(sqlSelect); // 调用Select方法，即可查询出数据
            data.Append("<size>");
            data.Append(dataView.Count);
            data.Append("</size>");
            // 对查询到的数据进行循环处理，可以用于处理有多条返回数据的情况。
            for (int i = 0; i < dataView.Count; i += 1)
            {
                data.Append("<Note>");

                data.Append("<id>");
                data.Append(dataView[i]["id"]);
                data.Append("</id>");

                data.Append("<NoteName>"); //此处的NoteName为XML的一个节点，用于表示结果数据的意义，可以任意写，只要你自己看得懂即可。
                data.Append(dataView[i]["notename"]); //此处的notename为你的表格的字段名称，不区分大小写。
                data.Append("</NoteName>"); //XML节点结束标记，不需要多讲

                data.Append("<NoteDsp>"); //同上
                data.Append(dataView[i]["notedsp"]); //同上
                data.Append("</NoteDsp>"); //同上

                data.Append("<NoteCtx>"); //同上
                data.Append(dataView[i]["notectx"]); //同上
                data.Append("</NoteCtx>"); //同上

                data.Append("</Note>");
            }
        }

        data.Append("</Notes>");

        return data.ToString();
    }

    private String InsertNote()
    {
        StringBuilder data = new StringBuilder();

        // 声明XML头信息
        data.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

        // 查询结果数据拼接
        data.Append("<Notes>");

        // 获取页面传入参数
        String noteName = Request["nm"];
        String summary = Request["sm"];
        String cont = Request["cont"];
        if (noteName != null && noteName.Trim() != "")
        {
            String sqlSelect = "insert into asunnote values(null,'" + noteName + "','" + summary + "','" + cont + "',now(),now())";

            int size = Insert(sqlSelect);

            data.Append("<insert>");
            data.Append(size);
            data.Append("</insert>");
        }

        data.Append("</Notes>");

        return data.ToString();
    }

    private String UpdateNote()
    {
        StringBuilder data = new StringBuilder();

        // 声明XML头信息
        data.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

        // 查询结果数据拼接
        data.Append("<Notes>");

        // 获取页面传入参数
        String obj_id = Request["id"];
        String cont = Request["cont"];
        if (obj_id != null && obj_id.Trim() != "")
        {
            String sqlSelect = "update asunnote set NoteCtx ='" + cont + "' where id='" + obj_id + "'";
            int size = Update(sqlSelect);

            data.Append("<insert>");
            data.Append(size);
            data.Append("</insert>");
        }

        data.Append("</Notes>");

        return data.ToString();
    }

    private String DeleteNote()
    {
        StringBuilder data = new StringBuilder();

        // 声明XML头信息
        data.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

        // 查询结果数据拼接
        data.Append("<Notes>");

        // 获取页面传入参数
        String noteName = Request["id"];
        String sqlDelete = "delete from asunnote where id='" + noteName + "'";

        int size = Delete(sqlDelete);

        data.Append("<del>");
        data.Append(size);
        data.Append("</del>");

        data.Append("</Notes>");

        return data.ToString();
    }

    private DataView Select(String sqlSelect)
    {
        DataSet dataSet = new DataSet();

        MySqlConnection mySqlConn = getConnection();
        MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlSelect, mySqlConn);
        mySqlAdapter.Fill(dataSet, "MySQL_Table");
        mySqlAdapter.Dispose();
        mySqlConn.Close();

        return dataSet.Tables["MySQL_Table"].DefaultView;
    }

    private int Delete(String sqlDelete)
    {
        MySqlConnection mySqlConn = getConnection();
        MySqlCommand mySqlComm = new MySqlCommand();
        mySqlComm.Connection = mySqlConn;
        mySqlComm.CommandType = CommandType.Text;
        mySqlComm.CommandText = sqlDelete;

        int n = mySqlComm.ExecuteNonQuery();
        mySqlComm.Dispose();
        mySqlConn.Close();

        return n;
    }

    private int Update(String sqlUpdate)
    {
        MySqlConnection mySqlConn = getConnection();
        MySqlCommand mySqlComm = new MySqlCommand();
        mySqlComm.Connection = mySqlConn;
        mySqlComm.CommandType = CommandType.Text;
        mySqlComm.CommandText = sqlUpdate;

        int n = mySqlComm.ExecuteNonQuery();
        mySqlComm.Dispose();
        mySqlConn.Close();

        return n;
    }

    private int Insert(String sqlInsert)
    {
        MySqlConnection mySqlConn = getConnection();
        MySqlCommand mySqlComm = new MySqlCommand();
        mySqlComm.Connection = mySqlConn;
        mySqlComm.CommandType = CommandType.Text;
        mySqlComm.CommandText = sqlInsert;

        int n = mySqlComm.ExecuteNonQuery();
        mySqlComm.Dispose();
        mySqlConn.Close();

        return n;
    }

    private int Execute(String sql)
    {
        MySqlConnection mySqlConn = getConnection();
        MySqlCommand mySqlComm = new MySqlCommand();
        mySqlComm.Connection = mySqlConn;
        mySqlComm.CommandType = CommandType.Text;
        mySqlComm.CommandText = sql;

        int n = mySqlComm.ExecuteNonQuery();
        mySqlComm.Dispose();
        mySqlConn.Close();

        return n;
    }

    private MySqlConnection getConnection()
    {
        MySqlConnection mySqlConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=Amon;database=amon;charset=utf8");
        mySqlConn.Open();
        return mySqlConn;
    }
}