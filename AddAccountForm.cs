using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEXCTools
{
    public partial class AddAccountForm : Form
    {
        public delegate void AddAccountEventHandler(MEXCApi api);
        public AddAccountEventHandler AddAccountHandler;
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string apikey = txtApiKey.Text;
            string apisecret = txtApiSecret.Text;

            if(email == "" || apikey =="" || apisecret =="")
                return;

            MEXCApi api = new MEXCApi(email, apikey, apisecret);
            if (AddAccountHandler != null)
            {
                AddAccountHandler.Invoke(api);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
