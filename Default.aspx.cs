using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myapp {
    public partial class _Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            // Retrieve the password from the session variable
            string expectedPassword = "admin"; // Replace this with your actual password
            string storedPassword = Session["UserPassword"] as string;

            if (storedPassword == expectedPassword) {
                mainContentPanel.Visible = true; // Show the main content if the password matches
                passwordPanel.Visible = false; // Hide the password input panel
            }
            else {
                mainContentPanel.Visible = false; // Hide the main content if the password doesn't match
                passwordPanel.Visible = true; // Show the password input panel
            }

            if (!IsPostBack) {
                if (storedPassword == null) {
                    // Password not provided yet, hide the main content
                    mainContentPanel.Visible = false;
                }
                LoadRecord();
            }
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

        protected void Button6_Click(object sender, EventArgs e) {
            string enteredPassword = passwordInput.Text.Trim();
            string expectedPassword = "admin"; // Replace this with your actual password

            if (enteredPassword == expectedPassword) {
                // Store the correct password in the session variable for future use
                Session["UserPassword"] = enteredPassword;
                mainContentPanel.Visible = true; // Show the main content
                passwordPanel.Visible = false; // Hide the password input panel
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Invalid password! Please enter the correct password to proceed.');", true);
                mainContentPanel.Visible = false; // Hide the main content
                passwordPanel.Visible = true; // Show the password input panel
            }
        }
        protected void Button1_Click(object sender, EventArgs e) {
            // Check if the provided password matches the expected password
            string expectedPassword = "admin"; // Replace this with your actual password
            string enteredPassword = passwordInput.Text.Trim();

            if (enteredPassword != expectedPassword) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Invalid password! Please enter the correct password to proceed.');", true);
                return;
            }
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