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
    public partial class Attendence : UserControl
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            attendenceDate.Format = DateTimePickerFormat.Custom;
            attendenceDate.CustomFormat = "yyyy/MM/dd";
            int res = checkDate();
            var con = Configuration.getInstance().getConnection();
            if (res == 0)
            {
                SqlCommand cmd = new SqlCommand("Select * From Student Where Status=5", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                da.Fill(d);
                attendenceGV.DataSource = d;
             
            }
        }
        private int checkDate()
        {
            attendenceDate.Format = DateTimePickerFormat.Custom;
            attendenceDate.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM ClassAttendance WHERE AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", attendenceDate.Text);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt;





        }
        private int getDateId()
        {
            attendenceDate.Format = DateTimePickerFormat.Custom;
            attendenceDate.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM ClassAttendance WHERE AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", attendenceDate.Text);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        private void saveClassAttendance()
        {
            attendenceDate.Format = DateTimePickerFormat.Custom;
            attendenceDate.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into ClassAttendance values(@AttendanceDate)", con);
            DateTime dateTimeVariable = attendenceDate.Value.Date;
            cmd.Parameters.AddWithValue("@AttendanceDate", attendenceDate.Text);
            cmd.ExecuteNonQuery();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveClassAttendance();
                attendenceDate.Format = DateTimePickerFormat.Custom;
                attendenceDate.CustomFormat = "yyyy/MM/dd";
                int dateId = getDateId();
                var con = Configuration.getInstance().getConnection();
                if (attendenceGV.RowCount > 0)
                {
                    for (int i = 0; i < attendenceGV.RowCount; i++)
                    {
                        SqlCommand cmd = new SqlCommand("Insert Into StudentAttendance values(@AttendanceId,@StudentId,@AttendaneStatus)", con);
                        DataGridViewRow selectedRow = attendenceGV.Rows[i];
                        string Attend = Convert.ToString(selectedRow.Cells["Status"].Value);
                        string SId = Convert.ToString(selectedRow.Cells["Id"].Value);
                        int status = 1;
                        if (Attend == "Present")
                        {
                            status = 1;
                        }
                        else if (Attend == "Absent")
                        {
                            status = 2;
                        }
                        else if (Attend == "Leave")
                        {
                            status = 3;
                        }
                        else if (Attend == "Late")
                        {
                            status = 4;
                        }

                        cmd.Parameters.AddWithValue("@AttendanceId", dateId);
                        cmd.Parameters.AddWithValue("@StudentId", int.Parse(SId));
                        cmd.Parameters.AddWithValue("@AttendaneStatus", status);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully Marked Attendence");
                    attendenceGV.DataSource = null;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
