using Catalyst.Business.Model.ModUserMaster;
using Catalyst.DataAccess.DataManagers.ModUserMaster;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalystClientUI
{
    public partial class UserDetail : System.Web.UI.Page
    {
        UserMaster obj;
        UserMasterDataManager obj1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();

            }
        }

        protected void grdUserMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdUserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserMaster.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void grdUserMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdUserMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DateTime dt;
            GridViewRow grid = grdUserMaster.Rows[e.NewSelectedIndex];
            lblUserID.Text = ((Label)grid.FindControl("lblID")).Text;
            lblUser.Text = ((Label)grid.FindControl("lblName")).Text;
            txtEmail.Text = ((Label)grid.FindControl("lblEmailID")).Text;
            if (((Label)grid.FindControl("lblAccountStatus")).Text.Equals("ACTIVE") || ((Label)grid.FindControl("lblAccountStatus")).Text.Equals("INACTIVE"))
                ddlAccountStatus.SelectedValue = ((Label)grid.FindControl("lblAccountStatus")).Text;
            else
                ddlAccountStatus.SelectedIndex = 0;
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidFrom")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidFrom.Text = dt.ToString("dd/MM/yyyy");
            if (DateTime.TryParseExact(((Label)grid.FindControl("lblValidTo")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                txtValidTo.Text = dt.ToString("dd/MM/yyyy");
        }

        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (lblUserID.Text.Equals("-1"))
            {
                msgbox("Select the user to update first");
                return;
            }

            DateTime dt, dt1;
            obj = new UserMaster();
            obj.UserName = lblUser.Text;
            obj.UserId = lblUserID.Text;
            obj.AccountStatus = ddlAccountStatus.SelectedValue;
            obj.Email = txtEmail.Text;
            if (DateTime.TryParseExact(txtValidFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                obj.ValidFrom = dt;
            else
            {
                msgbox("Invalid from  date!!!");
                return;
            }
            if (DateTime.TryParseExact(txtValidTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt1))
                obj.ValidTo = dt1;
            else
            {
                msgbox("Invalid to  date!!!");
                return;
            }

            if (dt.Date >= dt1.Date)
            {
                msgbox("From date should be less than To date!!!");
                return;
            }

            if (lblUserID.Text.Equals("-1"))
            { }
            else
            {
                obj1 = new UserMasterDataManager();
                obj1.UpdateUserDetail(obj);
                msgbox("User updated successfully!!!");
            }
            bind();
            Clear();
        }

        private void bind()
        {
            obj1 = new UserMasterDataManager();
            grdUserMaster.DataSource = obj1.GetUserList();
            grdUserMaster.DataBind();
        }

        private void Clear()
        {
            lblUserID.Text = "-1";
            txtEmail.Text = "";
            txtValidFrom.Text = "";
            txtValidTo.Text = "";
            lblUser.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}