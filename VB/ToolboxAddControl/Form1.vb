Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing.Design
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
' ...

Namespace ToolboxAddControl
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create an End-User Designer form.
            Dim designForm As New XRDesignForm()

            ' Handle the DesignPanelLoaded event.
            AddHandler designForm.DesignMdiController.DesignPanelLoaded, _
                AddressOf DesignMdiController_DesignPanelLoaded

            ' Load a report into the Designer.
            designForm.OpenReport(New XtraReport1())

            ' Show the End-User Designer form, modally.
            designForm.ShowDialog()
        End Sub

        Private Sub DesignMdiController_DesignPanelLoaded(ByVal sender As Object, _
        ByVal e As DesignerLoadedEventArgs)
            ' Get the Toolbox service from the Designer host.
            Dim ts As IToolboxService = CType(e.DesignerHost.GetService(GetType(IToolboxService)), IToolboxService)

            ' Add a new category to the Toolbox,
            ' and place the custom control into it.
            ts.AddToolboxItem(New ToolboxItem(GetType(MyControl)), "New Category")

            ' Add the custom control to the Standard category.
            ts.AddToolboxItem(New ToolboxItem(GetType(MyControl)))
        End Sub

        ' A custom control.
        Public Class MyControl
            Inherits XRControl
            ' ...
        End Class

    End Class
End Namespace
