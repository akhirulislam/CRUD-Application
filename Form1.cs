using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CURD_application
{
    public partial class CURD : Form
    {
        public CURD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into empt values (@id,@name,@salary)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@salary", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update empt set id=@id,name=@name,salary=@salary where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@salary", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete empt where id=@id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Deleted");
        }

         private void button4_Click(object sender, EventArgs e)
         {
             SqlConnection con = new SqlConnection("Data Source=AKHIRUL\\SQLEXPRESS;Initial Catalog=\"CURD application\";Integrated Security=True;TrustServerCertificate=True");
             con.Open();
             SqlCommand cmd = new SqlCommand("select * from empt where id=@id", con);
             cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
            da.Fill(dt);

             dataGridView1.DataSource= dt;

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Found");
        }
    }


}

