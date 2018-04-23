Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub ASPxComboBox1_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim cb As ASPxComboBox = CType(sender, ASPxComboBox)
		Dim container As GridViewGroupRowTemplateContainer = CType(cb.NamingContainer, GridViewGroupRowTemplateContainer)
		cb.DataSource = AccessDataSource2
		cb.DataBind()
		Dim catID As Integer = CInt(Fix(container.KeyValue))
		cb.ClientSideEvents.SelectedIndexChanged = String.Format("function(s,e){{grid.PerformCallback('{0}'+';'+s.GetSelectedItem().value);}}", catID)
		cb.SelectedIndex = cb.Items.IndexOfValue(catID)
	End Sub
	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim indeces() As String = e.Parameters.Split(";"c)
		Dim pIndex As Integer = Convert.ToInt32(indeces(0))
		Dim nIndex As Integer = Convert.ToInt32(indeces(1))
		AccessDataSource1.UpdateCommand = String.Format("UPDATE [Products] SET [CategoryID] = {0} WHERE [CategoryID] = {1}", nIndex, pIndex)
		' The Following Line is Necessary to Update the Database. Data modification is not allowed for examples.
		' AccessDataSource1.Update();
		grid.DataBind()
	End Sub
End Class