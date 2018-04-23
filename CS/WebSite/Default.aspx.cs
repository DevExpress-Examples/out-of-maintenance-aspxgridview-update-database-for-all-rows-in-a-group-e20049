using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page
{
    protected void ASPxComboBox1_Init(object sender, EventArgs e)
    {
        ASPxComboBox cb = (ASPxComboBox)sender;
        GridViewGroupRowTemplateContainer container = (GridViewGroupRowTemplateContainer)cb.NamingContainer;
        cb.DataSource = AccessDataSource2;
        cb.DataBind();
        int catID = (int)container.KeyValue;
        cb.ClientSideEvents.SelectedIndexChanged = string.Format("function(s,e){{grid.PerformCallback('{0}'+';'+s.GetSelectedItem().value);}}", catID);
        cb.SelectedIndex = cb.Items.IndexOfValue(catID);
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] indeces = e.Parameters.Split(';');
        int pIndex = Convert.ToInt32(indeces[0]);
        int nIndex = Convert.ToInt32(indeces[1]);
        AccessDataSource1.UpdateCommand = string.Format("UPDATE [Products] SET [CategoryID] = {0} WHERE [CategoryID] = {1}", nIndex, pIndex);
        // The Following Line is Necessary to Update the Database. Data modification is not allowed for examples.
        // AccessDataSource1.Update();
        grid.DataBind();
    }
}