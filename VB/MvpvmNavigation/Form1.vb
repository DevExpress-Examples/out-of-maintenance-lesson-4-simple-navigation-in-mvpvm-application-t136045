Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports MvpvmNavigation.Model
Imports DevExpress.Mvvm
Imports DevExpress.XtraNavBar
Imports DevExpress.Mvvm.POCO
Imports MvpvmNavigation.ViewModels
Imports MvpvmNavigation.Presenter
Imports DevExpress.XtraBars.Navigation


Namespace MvpvmNavigation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Me.viewModelCore = ViewModelSource.Create(Of MainFormViewModel)()
			Me.presenterCore = CreatePresenter()
		End Sub

		Private viewModelCore As MainFormViewModel
		Private presenterCore As MainFormPresenter

		Public ReadOnly Property ViewModel() As MainFormViewModel
			Get
				Return viewModelCore
			End Get
		End Property

		Public ReadOnly Property Presenter() As MainFormPresenter
			Get
				Return presenterCore
			End Get
		End Property

		Protected Overridable Function CreatePresenter() As MainFormPresenter
			Return New MainFormPresenter(panelControl1, ViewModel)
		End Function

		Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
			MyBase.OnLoad(e)
			Dim modules() As ModuleType = { ModuleType.ModuleA, ModuleType.ModuleB }
			ViewModel.SelectedModuleType = modules(0)
			RegisterNavigationItems(modules)
		End Sub
		Private Sub RegisterNavigationItems(ByVal modules() As ModuleType)
			Dim groups(modules.Length - 1) As NavBarGroup
			For i As Integer = 0 To modules.Length - 1
				Dim navGroup As New NavBarGroup()
				navGroup.Tag = modules(i)
				navGroup.Name = "navGroup" & MainFormPresenter.GetName(modules(i))
				navGroup.Caption = MainFormPresenter.GetDisplayText(modules(i))
				groups(i) = navGroup
			Next i
			navBarControl1.Groups.AddRange(groups)
		End Sub

		Private Sub officeNavigationBar1_RegisterItem(ByVal sender As Object, ByVal e As NavigationBarNavigationClientItemEventArgs) Handles officeNavigationBar1.RegisterItem
			Dim navGroup As NavBarGroup = CType(e.NavigationItem, NavBarGroup)
			Dim type = CType(navGroup.Tag, ModuleType)
			e.Item.Tag = type
			e.Item.Text = MainFormPresenter.GetDisplayText(type)
			e.Item.Name = "navItem" & MainFormPresenter.GetName(type)
            e.Item.BindCommand(Sub(t) ViewModel.SelectModule(t), ViewModel, Function() type)
		End Sub
	End Class
End Namespace
