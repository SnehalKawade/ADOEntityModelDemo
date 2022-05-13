using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDataModelDemo
{
    public partial class StudentDataModel : Form
    {
        StudentEntities dbcontext=new StudentEntities();
        public StudentDataModel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                Stud stud = new Stud();
                stud.Name= txtName.Text;
                stud.Percentage = Convert.ToInt32(txtPercentage.Text);
                stud.Branch = txtBranch.Text;
               
                dbcontext.Studs.Add(stud);
               
                dbcontext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerach_Click(object sender, EventArgs e)
        {
            try
            {
                Stud stud = dbcontext.Studs.Find(Convert.ToInt32(txtId.Text));
                if (stud != null)
                {
                    txtName.Text = stud.Name;
                    txtBranch.Text = stud.Branch;
                    txtPercentage.Text = stud.Percentage.ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Stud stud = dbcontext.Studs.Find(Convert.ToInt32(txtId.Text));
                if (stud != null)
                {
                    stud.Name= txtName.Text;
                    stud.Branch=txtBranch.Text;
                    stud.Percentage = Convert.ToInt32(txtPercentage.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Stud stud = dbcontext.Studs.Find(Convert.ToInt32(txtId.Text));
                if (stud != null)
                {
                    dbcontext.Studs.Remove(stud);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.Studs.ToList();
        }

       
    }
}
