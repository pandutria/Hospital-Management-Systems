using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hospital_Management_System
{
    public partial class FormMasterDoctor : Form
    {
        int currentSelectedRow = -1;
        private string name;
    
        public FormMasterDoctor(string name = null)
        {
            InitializeComponent();
            this.name = name;
        }

        private void loadDgv()
        {
            dgvDoctor.Rows.Clear();
            var db = new DataBaseDataContext();
            var selectedCategory = cbCategory.SelectedValue?.ToString();
   
            var doctor = db.doctors.Where(x => (x.deleted_at.Equals(null)) && (selectedCategory == null ||
            x.doctor_category.id.ToString().Contains(selectedCategory)) && (x.name.Contains(tbSearch.Text)
            || x.phone_number.Contains(tbSearch.Text) || x.email.Contains(tbSearch.Text)
            || x.gender.Contains(tbSearch.Text) || x.address.Contains(tbSearch.Text)) && (DataStorage.doctorName == null || x.name.Contains(DataStorage.doctorName)));

            foreach (var Item in doctor)
            {   
                dgvDoctor.Rows.Add(Item.name, Item.phone_number, Item.email,
                Item.date_of_birth, Item.doctor_category.category, Item.address,
                Item.gender, Item.assigned_room, Item.last_updated_at, Item.deleted_at);
            }
        }

        private void loadCbCategory()
        {
            cbCategory.DataSource = new DataBaseDataContext().doctor_categories;
            cbCategory.ValueMember = "id";
            cbCategory.DisplayMember = "category";
        }

        private void dgvDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 & e.RowIndex < dgvDoctor.Rows.Count)
            {
                currentSelectedRow = e.RowIndex;
                tbName.Text = dgvDoctor.Rows[e.RowIndex].Cells[0].Value?.ToString();
                tbPhoneNumber.Text = dgvDoctor.Rows[e.RowIndex].Cells[1].Value?.ToString();
                tbEmail.Text = dgvDoctor.Rows[e.RowIndex].Cells[2].Value?.ToString();
                tbBirth.Text = dgvDoctor.Rows[e.RowIndex].Cells[3].Value?.ToString();
                tbCategory.Text = dgvDoctor.Rows[e.RowIndex].Cells[4].Value?.ToString();
                tbAddrees.Text = dgvDoctor.Rows[e.RowIndex].Cells[5].Value?.ToString();
                tbGender.Text = dgvDoctor.Rows[e.RowIndex].Cells[6].Value?.ToString();
                tbAsign.Text = dgvDoctor.Rows[e.RowIndex].Cells[7].Value?.ToString();
              

                if (dgvDoctor.Rows[e.RowIndex].Cells[8].Value?.ToString() == null)
                {
                    lblLastUpdate.Text = "Last update at....";
                } else
                {
                    lblLastUpdate.Text = "Last update at " + dgvDoctor.Rows[e.RowIndex].Cells[8].Value?.ToString();
                }
            }
        }

        private void FormMasterDoctor_Load(object sender, EventArgs e)
        {
            loadDgv();
            loadCbCategory();
            cbCategory.SelectedValue = 0;
            tbSearch.Text = name;
            tbAddrees.Enabled = tbAsign.Enabled = tbBirth.Enabled = tbCategory.Enabled = tbEmail.Enabled = tbGender.Enabled = tbName.Enabled = tbPhoneNumber.Enabled = false;
        }

        private void cbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
