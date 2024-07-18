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
using System.Net.NetworkInformation;

namespace PRODUZENIBORAVAKA5.MATURA
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Produzeni_boravak;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            string upit = "select * from Aktivnosti";
            SqlCommand cmd = new SqlCommand(upit, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                listView1.Items.Add(item);
            }
            conn.Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string upit1 = "INSERT INTO Aktivnosti(aktivnostID, nazivAktivnosti, dan, pocetak, zavrsetak) VALUES(@aktivnostID, @nazivAktivnosti, @dan, @pocetak, @zavrsetak)";
            SqlCommand cmd1 = new SqlCommand(upit1,conn);
            cmd1.Parameters.AddWithValue("@aktivnostID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@nazivAktivnosti", textBox2.Text);
            cmd1.Parameters.AddWithValue("@dan", comboBox1.Text);
            cmd1.Parameters.AddWithValue("@pocetak", textBox3.Text);
            cmd1.Parameters.AddWithValue("@zavrsetak", textBox4.Text);
            cmd1.ExecuteNonQuery();
            //NE RADI OPET ??????
            string upit = "select * from Aktivnosti";
            SqlCommand cmd = new SqlCommand(upit, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                listView1.Items.Add(item);
            }
            conn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
