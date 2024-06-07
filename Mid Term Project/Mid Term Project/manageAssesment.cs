using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Term_Project
{
    public partial class manageAssesment : UserControl
    {
        public manageAssesment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = AssesmentGV.CurrentRow.Cells[2].Value.ToString();

                var con = Configuration.getInstance().getConnection();

                if (txtTitle.Text != "" && numTotalMarks.Value != 0 && numWeightage.Value != 0)
                {

                    string Title = txtTitle.Text;
                    int TotalMarks = int.Parse(numTotalMarks.Value.ToString());
                    int TotalWeightage = int.Parse(numWeightage.Value.ToString());

                    string query = "SET Title = '" + Title + "'" + ", TotalMarks = '" + TotalMarks + "', TotalWeightage = '" + TotalWeightage + "'";
                    query = "UPDATE Assessment " + query + " WHERE Id = '" + Id + "';";
                    con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    loadData();
                    txtTitle.Text = "";
                    numTotalMarks.Value = 0;
                    numWeightage.Value = 0;
                    btnSave.Enabled = false;
                    MessageBox.Show("Successfully Updated");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }
        
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AssesmentGV.DataSource = dt;
        }
        

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text != "" && numTotalMarks.Value != 0 && numWeightage.Value != 0)
                {

                    string Title = txtTitle.Text;
                    int TotalMarks = int.Parse(numTotalMarks.Value.ToString());
                    int TotalWeightage = int.Parse(numWeightage.Value.ToString());

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Assessment values (@Title, @DateCreated,@TotalMarks,@TotalWeightage)", con);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@TotalMarks", TotalMarks);
                    cmd.Parameters.AddWithValue("@TotalWeightage", TotalWeightage);
                    cmd.ExecuteNonQuery();
                    loadData();

                    MessageBox.Show("Successfully saved");


                }
                else
                {
                    MessageBox.Show("Some Fields are Empty");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }

        private void AssesmentGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (AssesmentGV.Columns["Delete"].Index == e.ColumnIndex)
                {
                    string Id = AssesmentGV.CurrentRow.Cells[2].Value.ToString();
                    string query = "DELETE FROM Assessment WHERE Id = '" + Id + "';";
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    loadData();
                    MessageBox.Show("Successfully Deleted");
                }
                else if (AssesmentGV.Columns["Edit"].Index == e.ColumnIndex)
                {
                    btnSave.Enabled = true;
                    txtTitle.Text = AssesmentGV.CurrentRow.Cells[3].Value.ToString();
                    string TotalMarks = AssesmentGV.CurrentRow.Cells[5].Value.ToString();
                    numTotalMarks.Value = int.Parse(TotalMarks);
                    string TotalWeightage = AssesmentGV.CurrentRow.Cells[6].Value.ToString();
                    numWeightage.Value = int.Parse(TotalWeightage);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void numTotalMarks_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numWeightage_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
