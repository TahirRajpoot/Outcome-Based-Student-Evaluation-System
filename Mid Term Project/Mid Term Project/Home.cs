

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using System.IO;


namespace Mid_Term_Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            manageStudents1.loadData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            attendence1.Show();

            attendence1.BringToFront();
            HeaderText.Text = "Mark Attendence";
            btnHome.BackColor = Color.FromArgb(48, 195, 203);
            btnHome.ForeColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            manageStudents1.Show();
            manageStudents1.loadData();
            manageStudents1.BringToFront();
            HeaderText.Text = "Manage Students";
            btnManageStudents.BackColor = Color.FromArgb(48, 195, 203);
            btnManageStudents.ForeColor = Color.White;
        }

        private void manageStudents1_Load(object sender, EventArgs e)
        {

        }

        private void allScreenPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageStudents1.Show();
            manageStudents1.loadData();
            manageStudents1.BringToFront();
            HeaderText.Text = "Manage Students";
            btnManageStudents.BackColor = Color.FromArgb(48, 195, 203);
            btnManageStudents.ForeColor = Color.White;
        }

        private void btnManageCLOs_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageStudents1.Hide();
            manageCLOs1.loadData();
            manageCLOs1.BringToFront();
            HeaderText.Text = "Manage CLOs";
            btnManageCLOs.BackColor = Color.FromArgb(48, 195, 203);
            btnManageCLOs.ForeColor = Color.White;
        }

        private void btnManageRubrics_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageRubrics1.BringToFront();
            manageRubrics1.loadCLOs();
            manageRubrics1.loadData();
            
            HeaderText.Text = "Manage Rubrics";
            btnManageRubrics.BackColor = Color.FromArgb(48, 195, 203);
            btnManageRubrics.ForeColor = Color.White;

        }

        private void btnMarkEvaluations_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageRubricLevel1.BringToFront();
            manageRubricLevel1.loadEveryThing();
            HeaderText.Text = "Manage Rubric Level";
            btnMarkEvaluations.BackColor = Color.FromArgb(48, 195, 203);
            btnMarkEvaluations.ForeColor = Color.White;
        }

        private void manageRubricLevel1_Load(object sender, EventArgs e)
        {

        }

        private void Home_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void btnManageAssessment_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageAssesment1.BringToFront();
            manageAssesment1.loadData();
            HeaderText.Text = "Manage Assessments";
            btnManageAssessment.BackColor = Color.FromArgb(48, 195, 203);
            btnManageAssessment.ForeColor = Color.White;
        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageAssessmentComponent1.BringToFront();
            manageAssessmentComponent1.loadData();
            manageAssessmentComponent1.loadRubrics();
            HeaderText.Text = "Manage Assessments Component";
            btnComponent.BackColor = Color.FromArgb(48, 195, 203);
            btnComponent.ForeColor = Color.White;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnMarkEvaluation_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageEvaluation1.BringToFront();
            HeaderText.Text = "Mark Evaluation";
            manageEvaluation1.loadEveryThing();
            
        }
        public void clearButtonSelectionColor()
        {
            

            btnComponent.BackColor = Color.FromArgb(25, 57, 86);
            btnComponent.ForeColor = Color.Gainsboro; 

            btnManageAssessment.BackColor = Color.FromArgb(25, 57, 86);
            btnManageAssessment.ForeColor = Color.Gainsboro;

            btnMarkEvaluations.BackColor = Color.FromArgb(25, 57, 86);
            btnMarkEvaluations.ForeColor = Color.Gainsboro;

            btnManageRubrics.BackColor = Color.FromArgb(25, 57, 86);
            btnManageRubrics.ForeColor = Color.Gainsboro;

            btnManageCLOs.BackColor = Color.FromArgb(25, 57, 86);
            btnManageCLOs.ForeColor = Color.Gainsboro;

            btnManageStudents.BackColor = Color.FromArgb(25, 57, 86);
            btnManageStudents.ForeColor = Color.Gainsboro;

            BtnMarkEvalluation.BackColor = Color.FromArgb(25, 57, 86);
            BtnMarkEvalluation.ForeColor = Color.Gainsboro;

            btnReport.BackColor = Color.FromArgb(25, 57, 86);
            btnReport.ForeColor = Color.Gainsboro;


        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            Reports r = new Reports();
            r.ShowDialog();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearButtonSelectionColor();
            manageEvaluation1.BringToFront();
            HeaderText.Text = "Mark Evaluation";
            BtnMarkEvalluation.BackColor = Color.FromArgb(48, 195, 203);
            BtnMarkEvalluation.ForeColor = Color.White;
        }
    }
}
