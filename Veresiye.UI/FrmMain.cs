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
    public partial class FrmMain : Form
    {
        private readonly IUserService userService;
        private readonly FrmRegister frmRegister;
        public FrmMain(IUserService userService, FrmRegister frmRegister)
        {
            this.userService = userService;
            this.frmRegister = frmRegister;
            InitializeComponent();

            this.frmRegister.MdiParent = this;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var userCount = userService.GetAll().Count();

            if (userCount >= 0)
            {
                frmRegister.Show();
            }
        }
    }
}
