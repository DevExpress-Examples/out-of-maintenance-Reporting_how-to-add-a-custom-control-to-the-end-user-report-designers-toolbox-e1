using System;
using System.Windows.Forms;
using System.Drawing.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
// ...

namespace ToolboxAddControl {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create an End-User Designer form.
            XRDesignForm designForm = new XRDesignForm();

            // Handle the DesignPanelLoaded event.
            designForm.DesignMdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(DesignMdiController_DesignPanelLoaded);

            // Load a report into the Designer.
            designForm.OpenReport(new XtraReport1());

            // Show the End-User Designer form, modally.
            designForm.ShowDialog();
        }

        void DesignMdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e) {
            // Get the Toolbox service from the Designer host.
            IToolboxService ts =
                (IToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));

            // Add a new category to the Toolbox,
            // and place the custom control into it.
            ts.AddToolboxItem(new ToolboxItem(typeof(MyControl)), "New Category");

            // Add the custom control to the Standard category.
            ts.AddToolboxItem(new ToolboxItem(typeof(MyControl)));
        }

        // A custom control.
        public class MyControl : XRControl {
            // ...
        }

    }
}
