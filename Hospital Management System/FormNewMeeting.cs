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
    public partial class FormNewMeeting : Form
    {
        public FormNewMeeting()
        {
            InitializeComponent();
        }

        private void loadCbCtg()
        {
            cbCategory.DataSource = new DataBaseDataContext().doctor_categories;
            cbCategory.ValueMember = "id";
            cbCategory.DisplayMember = "category";
        }

        private void cbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue != null)
            {
                var db = new DataBaseDataContext();
                var dtg = db.doctors.Where(x => x.doctor_category.id.ToString().Contains(cbCategory.SelectedValue.ToString()));

                cbName.DataSource = dtg;
                cbName.ValueMember = "id";
                cbName.DisplayMember = "name";
            }
        }

        private void cbName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbName.SelectedValue != null)
            {
                var doctor = new DataBaseDataContext().doctors.FirstOrDefault(x => x.id.Equals(cbName.SelectedValue));
                DataStorage.doctorId = doctor.id;
                DataStorage.doctorRoom = doctor.assigned_room;
                DataStorage.doctorName = doctor.name;

            }
        }

        private void loadPatientId()
        {
           
            var patient = new DataBaseDataContext().patients.FirstOrDefault(x => x.name.Equals(tbPatientName.Text));

            if (patient != null) { 

                DataStorage.patientId = patient.id;
                DataStorage.patientName = patient.name;
            }
        }

        private void overlap()
        {
           
        }

        private void FormNewMeeting_Load(object sender, EventArgs e)
        {
            loadCbCtg();
        }

        private void linkViewPatientData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataBaseDataContext data = new DataBaseDataContext();
            var dataPatient = data.patients.Where(x => x.name.Equals(tbPatientName.Text)).FirstOrDefault();
            if (dataPatient != null)
            {
                new FormMasterPatient(dataPatient.name).ShowDialog();
            }
            else
            {
                MessageBox.Show("User " + tbPatientName.Text + " tidak ada");
            }
        }


        private void tbPatientName_TextChanged(object sender, EventArgs e)
        {
            loadPatientId();
        }

        private void linkViewDoctorData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormMasterDoctor().ShowDialog();
        }


        private void linkViewPatientRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           new FormPatientRecord().ShowDialog();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            var db = new DataBaseDataContext();
            var meeting = new meeting();
            meeting.patient_id = DataStorage.patientId;
            meeting.doctor_id = DataStorage.doctorId;
            meeting.room = DataStorage.doctorRoom;
            meeting.date = dtMeeting.Value;
            meeting.queue_number = Convert.ToInt32(lblQuene.Text);
            meeting.created_at = DateTime.Now;
            db.meetings.InsertOnSubmit(meeting);
            db.SubmitChanges();
            MessageBox.Show("success");
            Close();

        }

        private void dtMeeting_ValueChanged(object sender, EventArgs e)
        {
            var db = new DataBaseDataContext();
            var reschedule = db.meetings.FirstOrDefault(x => x.date.Equals(dtMeeting.Value) & x.patient_id.Equals(DataStorage.patientId));
            var newSchedule = db.meetings.FirstOrDefault(x => x.date.Equals(dtMeeting.Value) && x.patient_id != DataStorage.patientId && x.room.Equals(DataStorage.doctorRoom));
            if (reschedule != null)
            {
                MessageBox.Show("Pasien sudah memiliki jadwal silahkan reschedule");
            }
            else if (newSchedule != null)
            {
                lblQuene.Text = (newSchedule.queue_number + 1).ToString();
            }
            else
            {
                lblQuene.Text = "1";
            }
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpMeeting_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
