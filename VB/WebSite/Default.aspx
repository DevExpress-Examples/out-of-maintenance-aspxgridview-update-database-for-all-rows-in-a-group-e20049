<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>ASPxGridView: Update Database for all Rows in a Group</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1"
			KeyFieldName="ProductID" ClientInstanceName="grid" OnCustomCallback="grid_CustomCallback">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryID" GroupIndex="0" SortIndex="0" SortOrder="Ascending"
					VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="3">
				</dx:GridViewDataCheckColumn>
			</Columns>
			<Templates>
				<GroupRowContent>
					Category:
					<dx:ASPxComboBox ID="ASPxComboBox1" runat="server" OnInit="ASPxComboBox1_Init" TextField="CategoryName"
						ValueField="CategoryID" ValueType="System.Int32">
					</dx:ASPxComboBox>
				</GroupRowContent>
			</Templates>
		</dx:ASPxGridView>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Northwind.mdb"
			SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [Discontinued] FROM [Products]">
		</asp:AccessDataSource>
		<asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/Northwind.mdb"
			SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]"></asp:AccessDataSource>
	</div>
	</form>
</body>
</html>