using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class FormMasterPatient : Form
    {
        int currentSelectedRow = -1;
        string patient;
        
        public FormMasterPatient(string patientName = null)
        {
            InitializeComponent();
            patient = patientName;
        }

        private void loadDgv()
        {
            dgvPatient.Rows.Clear();
            var db = new DataBaseDataContext();
            var patient = db.patients.Where(x => (x.deleted_at.Equals(null)) && (x.name.Contains(tbSearch.Text)
            || x.phone_number.Contains(tbSearch.Text) || x.email.Contains(tbSearch.Text)
            || x.gender.Contains(tbSearch.Text) || x.address.Contains(tbSearch.Text)
            || x.blood_type.Contains(tbSearch.Text)));

            foreach (var Item in patient)
            {
                dgvPatient.Rows.Add(Item.name, Item.phone_number, Item.email,
                Item.date_of_birth, Item.address, Item.gender, Item.blood_type, Item.last_updated_at,Item.deleted_at);
            }
        }
         
        private void FormMasterPatient_Load(object sender, EventArgs e)
        {
            loadDgv();
            tbSearch.Text = patient;
            tbAddrees.Enabled = tbBirth.Enabled = tbEmail.Enabled = tbGender.Enabled = tbName.Enabled = tbPhoneNumber.Enabled = tbBlood.Enabled = false;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void dgvPatient_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 & e.RowIndex < dgvPatient.Rows.Count)
            {
                currentSelectedRow = e.RowIndex;
                tbName.Text = dgvPatient.Rows[e.RowIndex].Cells[0].Value?.ToString();
                tbPhoneNumber.Text = dgvPatient.Rows[e.RowIndex].Cells[1].Value?.ToString();
                tbEmail.Text = dgvPatient.Rows[e.RowIndex].Cells[2].Value?.ToString();
                tbBirth.Text = dgvPatient.Rows[e.RowIndex].Cells[3].Value?.ToString();
                tbAddrees.Text = dgvPatient.Rows[e.RowIndex].Cells[4].Value?.ToString();
                tbGender.Text = dgvPatient.Rows[e.RowIndex].Cells[5].Value?.ToString();
                tbBlood.Text = dgvPatient.Rows[e.RowIndex].Cells[6].Value?.ToString();

                if (dgvPatient.Rows[e.RowIndex].Cells[8].Value?.ToString() == null)
                {
                    lblLastUpdate.Text = "Last update at....";
                }
                else
                {
                    lblLastUpdate.Text = "Last update at " + dgvPatient.Rows[e.RowIndex].Cells[8].Value?.ToString();
                }
            }
        }
    }
}
