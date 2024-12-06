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
    public partial class FormPayment : Form
    {
        int currentSelectedRow = -1;
        public FormPayment()
        {
            InitializeComponent();
        }

        private void loadDgv()
        {
            dgvPayment.Rows.Clear();
            var db = new DataBaseDataContext();
            var meetingId = DataStorage.selectedMeetingId;
            lblMeetingId.Text = meetingId.ToString();
            var PaymentDetail = db.payment_details.Where(x => x.payment.meeting_id.ToString().Equals(meetingId) && x.deleted_at.Equals(null));
            foreach(var item in PaymentDetail)
            {  
                dgvPayment.Rows.Add(item.item, item.nominal, item.notes, btnDelete.Text = "Delete" ,item.payment.card_holder_name, item.payment.primary_account_number, item.payment.expiration_date, item.payment.service_code, item.payment.total_payment, item.payment.meeting_id, item.id);
                tbCardHolder.Text = item.payment.card_holder_name;
                tbPrimaryAccount.Text = item.payment.primary_account_number;
                dtDate.Value = item.payment.expiration_date;
                lblPaymentId.Text = item.payment.id.ToString();
                tbServiceCode.Text = item.payment.service_code.ToString();


                decimal totalPayment = 0;
                var payment_details = db.payment_details.Where(x => x.payment_id.Equals(item.payment.id));

                foreach (var detail in payment_details)
                {
                    totalPayment += detail.nominal;
                }

                item.payment.total_payment = totalPayment;
                tbTotalPayment.Text = item.payment.total_payment.ToString();

                db.SubmitChanges();


                tbTotalPayment.Text = item.payment.total_payment.ToString();

                tbTotalPayment.ReadOnly = true;


            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var db = new DataBaseDataContext();
            var payment = db.payments.FirstOrDefault(x => x.meeting_id.Equals(DataStorage.selectedMeetingId));

            if (DataStorage.selectedMeetingId == null)
            {
                MessageBox.Show("tidak ada meeting, ");
            }

            if (payment != null)
            {
                DataStorage.paymentId = payment.id;
            }
            else
            {
                var payments = new payment();
                payments.meeting_id = DataStorage.selectedMeetingId;
                payments.card_holder_name = tbCardHolder.Text;
                payments.primary_account_number = tbPrimaryAccount.Text;
                payments.expiration_date = DateTime.Now.AddYears(5);
                payments.service_code = Convert.ToInt32(tbServiceCode.Text);
                payments.total_payment = 0;
                payments.created_at = DateTime.Now;
                payments.last_updated_at = null;
                payments.deleted_at = null;

                db.SubmitChanges();

                DataStorage.paymentId = payments.id;
            }

            new FormNewPayment().ShowDialog();
            loadDgv();
        }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvPayment.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {

               currentSelectedRow = e.RowIndex;

                var db = new DataBaseDataContext();
                var payment_detail = db.payment_details.FirstOrDefault(x => x.id.Equals(dgvPayment.Rows[e.RowIndex].Cells[10].Value.ToString()));

                if (payment_detail != null)
                {
                    payment_detail.deleted_at = DateTime.Now;
                    db.SubmitChanges();
                    loadDgv();
                }
                loadDgv();
            }
        }

        
        private void FormPayment_Load(object sender, EventArgs e)
        {
            loadDgv();
            lblMeetingId.Visible = true;
            lblPaymentId.Visible = true;
            lblMeetingId.Text = DataStorage.selectedMeetingId.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbServiceCode.TextLength != 3 || tbServiceCode.Text.All(char.IsDigit))
            {
                MessageBox.Show("Service code should be three digit numeric");
                return;
            }

            if (!IsValidCreditCardNumber(tbPrimaryAccount.Text))
            {
                MessageBox.Show("credit card salah bos");
                return;
            }

            var db = new DataBaseDataContext();

            var payment = new payment();

            payment.meeting_id = DataStorage.selectedMeetingId;
            payment.card_holder_name = tbCardHolder.Text;
            payment.primary_account_number = tbPrimaryAccount.Text;
            payment.service_code = Convert.ToInt32(tbServiceCode.Text);
            
            payment.expiration_date = DateTime.Now.AddYears(5);
            payment.created_at = DateTime.Now;
            payment.last_updated_at = null;
            payment.deleted_at = null;

            
            db.payments.InsertOnSubmit(payment);
            db.SubmitChanges();


            Hide();
            loadDgv();
        }

        private bool IsValidCreditCardNumber(string cardNumber)
        {
            
            cardNumber = new string(cardNumber.Where(char.IsDigit).ToArray());

            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }

                sum += n;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }



        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      
    }
}
