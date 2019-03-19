using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CProxy
{
    public partial class Main : Form
    {
        private const string SUBKEY = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        public Main()
        {
            //Ao abrir o app ja altera automaticamente
            InitializeComponent();
            GetStatusProxy();
            Application.Run();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
            Application.Exit();
        }

        void GetStatusProxy()
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey(SUBKEY, true);
            var p_ = registry.GetValue("ProxyEnable");
            if (Convert.ToInt32(p_) != 1)
            {
                registry.SetValue("ProxyEnable", 1);
                ntfMain.Icon = new Icon("green.ico");
                return;
            }
            registry.SetValue("ProxyEnable", 0);
            ntfMain.Icon = new Icon("red.ico");
        }

        private void ntfMain_DoubleClick(object sender, EventArgs e)
        {
            GetStatusProxy();
        }
    }
}
