using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Messenger
{
    public partial class fMain : MaterialForm
    {
        private static fMain _instance;
        public static fMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance =new fMain();
                return _instance;
            }
        }
        public fMain()
        {
            InitializeComponent();
            
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(Primary.BlueGrey200, Primary.BlueGrey300, Primary.BlueGrey300, Accent.LightBlue200,
                TextShade.WHITE);
        }
        public Panel Content
        {
            get { return MainContainer; }
            set { MainContainer = value; }
        }
        private void fMain_Load(object sender, EventArgs e)
        {
            _instance = this;
            MainContainer.Controls.Add(new ucLogin() { Dock = DockStyle.Fill });
        }
    }
}
