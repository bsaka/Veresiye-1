using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Model;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmCompanyAdd : Form
    {
        public FrmCompanies MasterForm { get; set; }
        private readonly ICompanyService companyService;
        public FrmCompanyAdd(ICompanyService companyService)
        {
            this.companyService = companyService;
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // validasyonlar
            if (txtName.Text == "")
            {
                MessageBox.Show("Firma adı gereklidir.");
                return;
            } else if (txtPhone.Text == "")
            {
                MessageBox.Show("Telefon alanı gereklidir.");
                return;
            }
            var company = new Company();
            company.Name = txtName.Text;
            company.Phone = txtPhone.Text;
            company.City = txtCity.Text;
            company.Region = txtRegion.Text;
            companyService.Insert(company);
            MessageBox.Show("Firma başarıyla eklendi.");
            MasterForm.LoadCompanies();
            this.Hide();

        }
        public void LoadForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtCity.Clear();
            txtRegion.Clear();
        }
        private void FrmCompanyAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
