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
    public partial class FormMaster_ICD_11 : Form
    {
        public FormMaster_ICD_11()
        {
            InitializeComponent();
        }

        private void loadCbName()
        {
            cbName.DataSource = new DataBaseDataContext().icd_11s;
            cbName.ValueMember = "id";
            cbName.DisplayMember = "name";

            cbName.SelectedItem = cbName.SelectedValue;
        }

        private void cbName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbName.SelectedValue != null)
            {
                var db = new DataBaseDataContext();
                var icdDesc = db.icd_11s.Where(x => x.id.Equals(cbName.SelectedValue)).FirstOrDefault()?.description;
                tbDesc.Text = icdDesc;

                var icdEsc = db.icd_11_exclusions.Where(x => x.icd_11_id.Equals(cbName.SelectedValue)).FirstOrDefault()?.exclusion;
                tbExclusions.Text = icdEsc;

                var doctorRecom = db.icd_11_doctor_recommendations.Where(x => x.icd_11_id.Equals(cbName.SelectedValue)).FirstOrDefault()?.doctor_category_id;
                var doctor = db.doctors.Where(x => x.doctor_category_id.Equals(doctorRecom)).ToList();

                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.Controls.Clear();

                foreach (var item in doctor)
                {
                    var subPanel = new FlowLayoutPanel {  FlowDirection = FlowDirection.LeftToRight, AutoSize = true };

                    var docCtg = new Label { Text = item.doctor_category.category, AutoSize = true };
                    var docName = new LinkLabel { Text = item.name, AutoSize = true };

                    docName.LinkClicked += (s, args) =>
                    {
                        new FormMasterDoctor(item.name).ShowDialog();
                    };

                    subPanel.Controls.Add(docCtg);
                    subPanel.Controls.Add(docName);
            
                    flowLayoutPanel1.Controls.Add(subPanel);
                }

            }
        }

        private void lblName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FormMaster_ICD_11_Load(object sender, EventArgs e)
        {
            loadCbName();
            tbDesc.Enabled = false;
        }


        private void tbDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbName_ValueMemberChanged(object sender, EventArgs e)
        {


        }


    }
}
