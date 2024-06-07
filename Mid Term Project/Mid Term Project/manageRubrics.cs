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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Mid_Term_Project
{
    public partial class manageRubrics : UserControl
    {
        public manageRubrics()
        {
            InitializeComponent();
            loadCLOs();
            loadData();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadCLOs()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name,Id from Clo", con);
    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds,"Name");
            cmbCLOs.DisplayMember= "Name";
            cmbCLOs.ValueMember= "Id";
            cmbCLOs.DataSource = ds.Tables["Name"];

            
        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT R.Id,Details,C.Name as CLO\r\nFROM Rubric R\r\nJoin Clo C\r\nON C.Id = R.CloId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            RubricsGV.DataSource = dt;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtrubricsDetails.Text != "" && cmbCLOs.Text != "")
                {

                    int Id = 0;
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM Rubric", con);
                    if (cmd.ExecuteScalar() != null)
                    {
                        Id= (int)cmd.ExecuteScalar();
                    }

                    con = Configuration.getInstance().getConnection();
                    cmd = new SqlCommand("SELECT Id FROM Clo WHERE Name = '" + cmbCLOs.Text + "'", con);
                    int CloId = (int)cmd.ExecuteScalar();
                    
                    con = Configuration.getInstance().getConnection();
                    cmd = new SqlCommand("Insert into Rubric values (@Id, @Details,@CloId)", con);
                    cmd.Parameters.AddWithValue("@Id", Id+1);
                    cmd.Parameters.AddWithValue("@Details", txtrubricsDetails.Text);
                    cmd.Parameters.AddWithValue("@CloId", CloId);
                    cmd.ExecuteNonQuery();
                    loadData();
                    txtrubricsDetails.Text = "";
                    MessageBox.Show("Successfully saved");


                }
                else
                {
                    MessageBox.Show("Some Fields are Empty");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
            }
        }

        private void RubricsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RubricsGV.Columns["Delete"].Index == e.ColumnIndex)
                {
                    string Id = RubricsGV.CurrentRow.Cells[2].Value.ToString();
                    string query = "DELETE FROM Rubric WHERE Id = '" + Id + "';";
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    loadData();
                    MessageBox.Show("Successfully Deleted");
                }
                else if (RubricsGV.Columns["Edit"].Index == e.ColumnIndex)
                {
                    btnSave.Enabled = true;
                    txtrubricsDetails.Text = RubricsGV.CurrentRow.Cells[3].Value.ToString();
                    cmbCLOs.Text = RubricsGV.CurrentRow.Cells[4].Value.ToString();

                }

            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = RubricsGV.CurrentRow.Cells[2].Value.ToString();
                string CLO= RubricsGV.CurrentRow.Cells[4].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT Id FROM Clo WHERE Name = '" + cmbCLOs.Text + "'", con);
                int CloId = (int)cmd.ExecuteScalar();
                string details = txtrubricsDetails.Text;
                if (details != "")
                {
                    string query = "SET Details = '" + details+ "'" + ", CloId = '" + CloId+ "'";
                    query = "UPDATE Rubric " + query + " WHERE Id = '" + Id + "';";
                    con = Configuration.getInstance().getConnection();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    loadData();
                    txtrubricsDetails.Text = "";
                    btnSave.Enabled = false;
                    MessageBox.Show("Successfully Updated");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCLOs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtrubricsDetails_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
