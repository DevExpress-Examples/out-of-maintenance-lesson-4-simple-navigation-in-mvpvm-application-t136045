Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraEditors
Imports MvpvmNavigation.ViewModels
Imports DevExpress.Mvvm
Imports MvpvmNavigation.Model
Imports System.Windows.Controls
Imports System.Windows.Forms

Namespace MvpvmNavigation.Presenter
	Public Class MainFormPresenter
		Public Sub New(ByVal modulesPanel As PanelControl, ByVal viewModel As MainFormViewModel)
			modulesCache = New Dictionary(Of ModuleType, System.Windows.Forms.UserControl)()
			Me.modulesPanel = modulesPanel
			Me.viewModelCore = viewModel
			AddHandler Me.ViewModel.SelectedModuleTypeChanged, AddressOf ViewModel_SelectedModuleTypeChanged
		End Sub

		Private viewModelCore As MainFormViewModel
		Private modulesPanel As PanelControl
		Private modulesCache As Dictionary(Of ModuleType, System.Windows.Forms.UserControl)

		Public Shared Function GetName(ByVal parameter As Object) As String
			Return parameter.ToString()
		End Function
		Public Shared Function GetDisplayText(ByVal parameter As Object) As String
			Return DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(parameter)
		End Function

		Public Sub Dispose()
			RemoveHandler ViewModel.SelectedModuleTypeChanged, AddressOf ViewModel_SelectedModuleTypeChanged
			For Each [module] As System.Windows.Forms.UserControl In modulesCache.Values
				[module].Dispose()
			Next [module]
			modulesCache.Clear()
		End Sub
		Public ReadOnly Property ViewModel() As MainFormViewModel
			Get
				Return viewModelCore
			End Get
		End Property
		Private Sub ViewModel_SelectedModuleTypeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			modulesPanel.Controls.Clear()
			Dim type As ModuleType = ViewModel.SelectedModuleType
			If type = ModuleType.None Then
				Return
			End If
			Dim [module] As System.Windows.Forms.UserControl
			If (Not modulesCache.TryGetValue(type, [module])) Then
				Select Case type
					Case ModuleType.ModuleA
						[module] = New Views.View1()
					Case ModuleType.ModuleB
						[module] = New Views.View2()
				End Select
				[module].Dock = DockStyle.Fill
				modulesCache.Add(type, [module])
			End If
			modulesPanel.Controls.Add([module])
		End Sub
	End Class
End Namespace
