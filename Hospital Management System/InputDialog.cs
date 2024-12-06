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
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            lblMeetingDate.Text = DataStorage.selectedMeetingDate.ToString();
            lblMeetingId.Text = DataStorage.selectedMeetingId.ToString();
            lblPatientId.Text = DataStorage.selectedPatientId.ToString();

            lblMeetingDate.Visible = false;
            lblMeetingId.Visible = false;
            lblPatientId.Visible = false;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var db = new DataBaseDataContext();
            var patient_record = new patient_record();


            if (tbInput.Text.Length > 0)
            {
                patient_record.patient_id = DataStorage.selectedPatientId;
                patient_record.meeting_id = DataStorage.selectedMeetingId;
                patient_record.notes = tbInput.Text;
                patient_record.date = Convert.ToDateTime(DataStorage.selectedMeetingDate);
                patient_record.created_at = DateTime.Now;
                db.patient_records.InsertOnSubmit(patient_record);
                db.SubmitChanges();
                Close();


            } else
            {
                MessageBox.Show("Notes Must be Field", "Information");
            }


        }
    }
}
