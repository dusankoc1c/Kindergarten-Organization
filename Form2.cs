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

namespace PRODUZENIBORAVAKA5.MATURA
{
    public partial class Form2 : Form
    {
        SqlConnection kon= new SqlConnection("Data Source=.;Initial Catalog=Produzeni_boravak;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kon.Open();
            string upit = "select Aktivnosti.Dan, count(DeteID) as [Broj dece] from Aktivnosti join Registar_Aktivnosti on Aktivnosti.AktivnostID = Registar_Aktivnosti.AktivnostID group by Aktivnosti.Dan";

            SqlCommand kom = new SqlCommand(upit, kon);
            SqlDataAdapter da = new SqlDataAdapter(kom);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataRow row in dt.Rows)
            {
                chart1.Series[0].Points.AddXY(row[0].ToString(), row[1].ToString());
            }

            kon.Close();
        }
    }
}
