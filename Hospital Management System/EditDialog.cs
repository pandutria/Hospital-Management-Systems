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
    public partial class EditDialog : Form
    {
        public EditDialog()
        {
            InitializeComponent();
            tbEdit.Text = DataStorage.record;
            lblRecordId.Text = DataStorage.recordId.ToString();
            label1.Text = DataStorage.recordMeetingId.ToString();
            label2.Text = DataStorage.recordPatientId.ToString();

            label1.Visible = false;
            label2.Visible = false;
            lblRecordId.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var db = new DataBaseDataContext();
            var patient_record =db.patient_records.FirstOrDefault(x => x.id.Equals(lblRecordId.Text));

            if (patient_record != null)
            {
                patient_record.notes = tbEdit.Text;
                patient_record.patient_id = DataStorage.recordPatientId;
                patient_record.meeting_id = DataStorage.recordMeetingId;
                patient_record.last_updated_at = DateTime.Now;

                db.SubmitChanges();

                Hide();
            }

           
            
        }

        private void tbEdit_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
