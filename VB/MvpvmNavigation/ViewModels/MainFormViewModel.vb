Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm.DataAnnotations
Imports MvpvmNavigation.Model
Imports DevExpress.Mvvm.POCO

Namespace MvpvmNavigation.ViewModels
	Public Class MainFormViewModel
		Private privateSelectedModuleType As ModuleType
		Public Overridable Property SelectedModuleType() As ModuleType
			Get
				Return privateSelectedModuleType
			End Get
			Set(ByVal value As ModuleType)
				privateSelectedModuleType = value
			End Set
		End Property
		Protected Overridable Sub OnSelectedModuleTypeChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.SelectModule(ModuleType.None))
			RaiseSelectedModuleTypeChanged()
		End Sub

		Public Event SelectedModuleTypeChanged As EventHandler

		Private Sub RaiseSelectedModuleTypeChanged()
			Dim handler = SelectedModuleTypeChangedEvent
			If handler IsNot Nothing Then
				handler(Me, EventArgs.Empty)
			End If
		End Sub

		<Command(UseCommandManager := False)> _
		Public Sub SelectModule(ByVal type As ModuleType)
			SelectedModuleType = type
		End Sub
		Public Function CanSelectModule(ByVal type As ModuleType) As Boolean
			Return type <> SelectedModuleType
		End Function
	End Class
End Namespace
