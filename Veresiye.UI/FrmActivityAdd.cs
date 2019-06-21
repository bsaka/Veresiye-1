using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veresiye.UI
{
   
    public partial class FrmActivityAdd : Form
    {
        private int CompanyId;
        public FrmCompanyEdit MasterForm { get; set; }
        public FrmActivityAdd()
        {
            InitializeComponent();
        }

        public void LoadForm(int companyId)
        {
            this.CompanyId = companyId;
            this.txtName.Clear();
            this.txtAmount.Clear();
            this.dtpTransactionDate.Value = DateTime.Now;
            this.cmbActivityType.SelectedIndex = -1;
        }

        private void FrmActivityAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
