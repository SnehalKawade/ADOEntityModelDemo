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
    public partial class EmpModel : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();
        public EmpModel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                // step 1 crete object of Emp class & store application data
                Emp emp = new Emp();
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToDecimal(txtSalary.Text);
                // step 2 add data to the datacontext
                dbcontext.Emps.Add(emp);
                // step 3- update the changes to the DB
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
                Emp emp = dbcontext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtSalary.Text = emp.Salary.ToString();
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
                Emp emp = dbcontext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    emp.Name = txtName.Text;
                    emp.Salary = Convert.ToDecimal(txtSalary.Text);
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
                Emp emp = dbcontext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    dbcontext.Emps.Remove(emp);
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
            dataGridView1.DataSource = dbcontext.Emps.ToList();      
        }
    }
}
