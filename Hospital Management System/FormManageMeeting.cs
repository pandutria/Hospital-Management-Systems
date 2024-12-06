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
    public partial class FormManageMeeting : Form
    {

        int currenteSelectedRow = -1;
        public FormManageMeeting()
        {
            InitializeComponent();
        }

        private void loadDgv()
        {
            dgvPayment.Rows.Clear();
            var db = new DataBaseDataContext();
            var mngMeeting = db.meetings.Where(x => x.deleted_at.Equals(null));

            foreach (var item in mngMeeting)
            {
                dgvPayment.Rows.Add(item.date, item.patient.name, item.doctor.doctor_category.category, item.doctor.name, item.queue_number, btnPayment.Text = "Payment", item.id, item.patient_id);
            }

            
        }

        private void loadDgvPatientRecord()
        {
            dgvPatientRecord.Rows.Clear();

            var db = new DataBaseDataContext();
            var patientRecord = db.patient_records.Where(x => x.meeting_id.ToString().Equals(lblMeetingId.Text) && x.deleted_at.Equals(null));

            foreach (var item in patientRecord)
            {
                dgvPatientRecord.Rows.Add(item.notes, btnEdit.Text = "Edit", btnDelete.Text = "Delete", item.id , item.meeting_id, item.patient_id);
               
            }

            var isDone = db.payments.FirstOrDefault(x => x.meeting_id.ToString().Equals(lblMeetingId.Text));

            if (isDone != null)
            {
                dgvPatientRecord.ReadOnly = true;
                btnAddNewPatient.Enabled = false;

                foreach (DataGridViewRow row in dgvPatientRecord.Rows)
                {
                    row.Cells["btnEdit"].ReadOnly = true;
                    row.Cells["btnDelete"].ReadOnly  =true;
                }
                
            } else
            {
                dgvPatientRecord.ReadOnly = false;
                btnAddNewPatient.Enabled = true;

                foreach (DataGridViewRow row in dgvPatientRecord.Rows)
                {
                    row.Cells["btnEdit"].ReadOnly = false;
                    row.Cells["btnDelete"].ReadOnly = false;
                }
            }
        }

        private void FormManageMeeting_Load(object sender, EventArgs e)
        {
            loadDgv();
            loadDgvPatientRecord();
            lblMeetingId.Visible = false;
            lblPatientId.Visible = false;
            lblMeetingDate.Visible = false;

        }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPayment.Columns["btnPayment"].Index && e.RowIndex >= 0)
            {
                

                DataStorage.meetingId = dgvPayment.Rows[e.RowIndex].Cells[6].Value.ToString();

                new FormPayment().ShowDialog();


            }

            if (e.RowIndex >= 0)
            {
                currenteSelectedRow = e.RowIndex;

                lblMeetingDate.Text = dgvPayment.Rows[e.RowIndex].Cells[0].Value?.ToString();
                lblMeetingId.Text = dgvPayment.Rows[e.RowIndex].Cells[6].Value.ToString();
                lblPatientId.Text = dgvPayment.Rows[e.RowIndex ].Cells[7].Value.ToString();
                loadDgvPatientRecord();

                DataStorage.selectedMeetingDate = lblMeetingDate.Text;
                DataStorage.selectedMeetingId = Convert.ToInt32(lblMeetingId.Text);
                DataStorage.selectedPatientId = Convert.ToInt32(lblPatientId.Text);




            }

           
        }

        private void dgvPatientRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPatientRecord.Columns["btnEdit"].Index && e.RowIndex >= 0)
            {

                DataStorage.recordId = Convert.ToInt32(dgvPatientRecord.Rows[e.RowIndex].Cells[3].Value);
                DataStorage.record = dgvPatientRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                DataStorage.recordMeetingId = Convert.ToInt32(dgvPatientRecord.Rows[e.RowIndex].Cells[4].Value.ToString());
                DataStorage.recordPatientId = Convert.ToInt32(dgvPatientRecord.Rows[e.RowIndex].Cells[5].Value);
                new EditDialog().ShowDialog();
                loadDgvPatientRecord();
            }

            if (e.ColumnIndex == dgvPatientRecord.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                currenteSelectedRow = e.RowIndex;
                var db = new DataBaseDataContext();
                var patientd_record = db.patient_records.FirstOrDefault(x => x.id.Equals(dgvPatientRecord.Rows[e.RowIndex].Cells[3].Value.ToString()));

                if (patientd_record != null)
                {
                    patientd_record.deleted_at = DateTime.Now;
                    loadDgvPatientRecord();
                    db.SubmitChanges();
                }

                loadDgvPatientRecord();

            }

            loadDgvPatientRecord();
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            new InputDialog().ShowDialog();
            loadDgv();
            loadDgvPatientRecord();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
