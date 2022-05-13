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
    public partial class ProductDataModel : Form
    {
        ProductEntities dbcontext=new ProductEntities();    
        public ProductDataModel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
            
                dbcontext.Products.Add(prod);

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
                Product prod = dbcontext.Products.Find(Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    txtName.Text = prod.Name;
                    txtPrice.Text = prod.Price.ToString();
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
                Product prod = dbcontext.Products.Find(Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    prod.Name = txtName.Text;
                    prod.Price= Convert.ToInt32(txtPrice.Text);
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
                Product prod= dbcontext.Products.Find(Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    dbcontext.Products.Remove(prod);
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
            dataGridView1.DataSource = dbcontext.Products.ToList();
        }
    }
}
