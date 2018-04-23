Imports Microsoft.VisualBasic
Imports System
Namespace MvpvmNavigation
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
			Me.officeNavigationBar1 = New DevExpress.XtraBars.Navigation.OfficeNavigationBar()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.officeNavigationBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013"
			' 
			' navBarControl1
			' 
			Me.navBarControl1.ActiveGroup = Nothing
			Me.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left
			Me.navBarControl1.Location = New System.Drawing.Point(0, 0)
			Me.navBarControl1.Name = "navBarControl1"
			Me.navBarControl1.OptionsNavPane.ExpandedWidth = 140
			Me.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
			Me.navBarControl1.Size = New System.Drawing.Size(140, 248)
			Me.navBarControl1.TabIndex = 0
			Me.navBarControl1.Text = "navBarControl1"
			' 
			' officeNavigationBar1
			' 
			Me.officeNavigationBar1.AutoSize = False
			Me.officeNavigationBar1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.officeNavigationBar1.Location = New System.Drawing.Point(0, 248)
			Me.officeNavigationBar1.Name = "officeNavigationBar1"
			Me.officeNavigationBar1.NavigationClient = Me.navBarControl1
			Me.officeNavigationBar1.Size = New System.Drawing.Size(589, 45)
			Me.officeNavigationBar1.TabIndex = 1
			Me.officeNavigationBar1.Text = "officeNavigationBar1"
'			Me.officeNavigationBar1.RegisterItem += New DevExpress.XtraBars.Navigation.NavigationBarNavigationClientItemEventHandler(Me.officeNavigationBar1_RegisterItem);
			' 
			' panelControl1
			' 
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panelControl1.Location = New System.Drawing.Point(140, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(449, 248)
			Me.panelControl1.TabIndex = 2
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(589, 293)
			Me.Controls.Add(Me.panelControl1)
			Me.Controls.Add(Me.navBarControl1)
			Me.Controls.Add(Me.officeNavigationBar1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.officeNavigationBar1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private navBarControl1 As DevExpress.XtraNavBar.NavBarControl
		Private WithEvents officeNavigationBar1 As DevExpress.XtraBars.Navigation.OfficeNavigationBar
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
	End Class
End Namespace

