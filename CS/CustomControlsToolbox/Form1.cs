using System;
using System.Windows.Forms;
using System.Drawing.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
// ...

namespace CustomControlsToolbox {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            xrDesignPanel1.DesignerHostLoaded += new DesignerLoadedEventHandler(OnDesignerLoaded);
            xrDesignPanel1.ExecCommand(ReportCommand.NewReport);
        }

        private void OnDesignerLoaded(object sender, DesignerLoadedEventArgs e) {
            IToolboxService ts = 
                (IToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));

            // Add a custom control.
            // Note that if there is no category specified for it,
            // the control will be displayed in the Standard Toolbox Bar.
            // In this example, we've added a custom Bar, 
            // with its Text set to the name of the category, and its ToolboxType
            // set to Custom. So, the custom control resides in its own Toolbox.
            ts.AddToolboxItem(new ToolboxItem(typeof(MyControl)), "Custom Controls");
        }

        // A custom control.
        public class MyControl : XRControl {
            // ...
        }
    }
}