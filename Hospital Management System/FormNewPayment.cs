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
    public partial class FormNewPayment : Form
    {
        public FormNewPayment()
        {
            InitializeComponent();
        }

        private void FormNewPayment_Load(object sender, EventArgs e)
        {
            lblPaymentId.Text = DataStorage.paymentId.ToString();
            lblPaymentId.Visible = true;
        }

        private void clearField()
        {
            tbItem.Text = tbNominal.Text = tbNotes.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            var db = new DataBaseDataContext();
            var payment_detail = new payment_detail();

            payment_detail.notes = tbNotes.Text;
            payment_detail.nominal = Convert.ToDecimal(tbNominal.Text);
            payment_detail.item = tbItem.Text;
            payment_detail.payment_id = DataStorage.paymentId;
            payment_detail.created_at = DateTime.Now;
            payment_detail.deleted_at = null;

            db.payment_details.InsertOnSubmit(payment_detail);
            db.SubmitChanges();

            Close();


            //var payment = db.payments.FirstOrDefault(x => x.id.Equals(DataStorage.paymentId));

            //if (payment != null)
            //{
            //    payment_detail.notes = tbNotes.Text;
            //    payment_detail.nominal = Convert.ToDecimal(tbNominal.Text);
            //    payment_detail.item = tbItem.Text;
            //    payment_detail.payment_id = DataStorage.paymentId;
            //    payment_detail.created_at = DateTime.Now;
            //    payment_detail.deleted_at = null;

            //    db.payment_details.InsertOnSubmit(payment_detail);
            //    db.SubmitChanges();

            //    Close();

            //}


        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

