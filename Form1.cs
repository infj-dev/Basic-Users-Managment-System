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

        private bool CheckData()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text) &&
                   !string.IsNullOrWhiteSpace(txtID.Text) &&
                   !string.IsNullOrWhiteSpace(cbGender.SelectedItem.ToString()) &&
                   dtpBirthDate.Value < DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                ListViewItem item = new ListViewItem(txtID.Text);
                item.SubItems.Add(txtName.Text);
                item.SubItems.Add(dtpBirthDate.Value.ToShortDateString());
                item.SubItems.Add(cbGender.SelectedItem.ToString());
                item.Font = new Font("Arial", 16, FontStyle.Bold);

                listView1.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.",
                    "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
    }
}
