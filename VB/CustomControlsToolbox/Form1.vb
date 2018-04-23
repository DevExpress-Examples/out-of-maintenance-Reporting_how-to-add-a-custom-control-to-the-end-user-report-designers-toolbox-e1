Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing.Design
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
' ...

Namespace CustomControlsToolbox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			AddHandler xrDesignPanel1.DesignerHostLoaded, AddressOf OnDesignerLoaded
			xrDesignPanel1.ExecCommand(ReportCommand.NewReport)
		End Sub

		Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
			Dim ts As IToolboxService = CType(e.DesignerHost.GetService(GetType(IToolboxService)), IToolboxService)

			' Add a custom control.
			' Note that if there is no category specified for it,
			' the control will be displayed in the Standard Toolbox Bar.
			' In this example, we've added a custom Bar, 
			' with its Text set to the name of the category, and its ToolboxType
			' set to Custom. So, the custom control resides in its own Toolbox.
			ts.AddToolboxItem(New ToolboxItem(GetType(MyControl)), "Custom Controls")
		End Sub

		' A custom control.
		Public Class MyControl
			Inherits XRControl
			' ...
		End Class
	End Class
End Namespace