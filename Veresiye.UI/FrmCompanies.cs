using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmCompanies : Form
    {
        private readonly ICompanyService companyService;
        private readonly FrmCompanyAdd frmCompanyAdd;
        private readonly FrmCompanyEdit frmCompanyEdit;
        public FrmCompanies(ICompanyService companyService, FrmCompanyAdd frmCompanyAdd, FrmCompanyEdit frmCompanyEdit)
        {
            this.companyService = companyService;
            this.frmCompanyAdd = frmCompanyAdd;
            this.frmCompanyEdit = frmCompanyEdit;
            InitializeComponent();
            this.frmCompanyAdd.MdiParent = this.MdiParent;
            this.frmCompanyAdd.MasterForm = this;
            this.frmCompanyEdit.MdiParent = this.MdiParent;
            this.frmCompanyEdit.MasterForm = this;
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }

        public void LoadCompanies()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = companyService.GetAll();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.frmCompanyAdd.Show();
            this.frmCompanyAdd.LoadForm();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int selectedId = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                this.frmCompanyEdit.Show();
                this.frmCompanyEdit.LoadForm(selectedId);
            } else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz firmayı seçiniz.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bu firmayı silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { 
                    int selectedId = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    companyService.Delete(selectedId);
                    LoadCompanies();
                }
            }
            else {
                MessageBox.Show("Lütfen silmek istediğiniz firmayı seçiniz.");
            }
        }
    }
}
