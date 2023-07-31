using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace myapp {
    public partial class _Default : Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadRecord();
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e) {

        }

        SqlConnection con = new SqlConnection("Data Source=MATRIX;Initial Catalog=ProgrammingDB;User ID=sa;Password=sa");
        void LoadRecord() {
            SqlCommand comm = new SqlCommand("select * from StudentInfo_Tab", con);
            SqlDataAdapter d = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e) {
            con.Open();
            //SqlCommand comm = new SqlCommand("Insert into StudentInfo_Tab values('" + int.Parse(TextBox1.Text) + "','" + TextBox2.Text + "','" + DropDownList1.SelectedValue + "','" + double.Parse(TextBox3.Text) + "','" + TextBox4.Text + "','" + TextBox5.Text "')", con);
            SqlCommand comm = new SqlCommand("INSERT INTO StudentInfo_Tab (StudentID, StudentName, Country, Age, Contact, Address) VALUES (@StudentID, @StudentName, @Country, @Age, @Contact, @Address)", con);
            comm.Parameters.AddWithValue("@StudentID", int.Parse(TextBox1.Text));
            comm.Parameters.AddWithValue("@StudentName", TextBox2.Text);
            comm.Parameters.AddWithValue("@Country", DropDownList1.SelectedValue);
            comm.Parameters.AddWithValue("@Age", double.Parse(TextBox3.Text));
            comm.Parameters.AddWithValue("@Contact", TextBox4.Text);
            comm.Parameters.AddWithValue("@Address", TextBox5.Text);

            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted')", true);
            LoadRecord();
        }
        protected void Button2_Click(object sender, EventArgs e) {
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE StudentInfo_Tab SET StudentName = @StudentName, Country = @Country, Age = @Age, Contact = @Contact, Address = @Address WHERE StudentID = @StudentID", con);
            comm.Parameters.AddWithValue("@StudentName", TextBox2.Text);
            comm.Parameters.AddWithValue("@Country", DropDownList1.SelectedValue);
            comm.Parameters.AddWithValue("@Age", double.Parse(TextBox3.Text));
            comm.Parameters.AddWithValue("@Contact", TextBox4.Text);
            comm.Parameters.AddWithValue("@Address", TextBox5.Text);
            comm.Parameters.AddWithValue("@StudentID", int.Parse(TextBox1.Text));

            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated')", true);
            LoadRecord();
        }



        protected void Button3_Click(object sender, EventArgs e) {
            con.Open();
            SqlCommand comm = new SqlCommand("Delete StudentInfo_Tab where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted User')", true);
            LoadRecord();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void Button4_Click(object sender, EventArgs e) {
            LoadRecord();
            SqlCommand comm = new SqlCommand("select * from StudentInfo_Tab where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);

            SqlDataAdapter d = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e) {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from StudentInfo_Tab where StudentID = '" + int.Parse(TextBox1.Text) + "'", con);
            SqlDataReader r = comm.ExecuteReader();
            while(r.Read()) {
                TextBox2.Text = r["StudentName"].ToString();
                DropDownList1.SelectedValue = r["Country"].ToString();
                TextBox3.Text = r["Age"].ToString();
                TextBox4.Text = r["Contact"].ToString();
                TextBox5.Text = r["Address"].ToString();
            }

        }
    }
}