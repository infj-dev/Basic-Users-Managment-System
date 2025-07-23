using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Users_Managment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(txtID.Text);
            item.SubItems.Add(txtName.Text);
            item.SubItems.Add(dtpBirthDate.Value.ToShortDateString());
            item.SubItems.Add(cbGender.SelectedItem.ToString());
            item.Font = new Font("Arial", 16, FontStyle.Bold);

            listView1.Items.Add(item);
            MessageBox.Show("User added successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    listView1.Items.Remove(listView1.SelectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.",
                    "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtID, "ID cannot be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtID, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Name cannot be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }
        }

        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {

            if (dtpBirthDate.Value >= DateTime.Now)
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpBirthDate, "Birth date must be in the past.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dtpBirthDate, "");
            }
        }

        private void cbGender_Validating(object sender, CancelEventArgs e)
        {
            if (cbGender.SelectedItem == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbGender, "Please select User Gender.");
            }
            else
            {
                e.Cancel = false;
                //errorProvider1.SetError(cbGender, "");
            }
        }
    }
}
