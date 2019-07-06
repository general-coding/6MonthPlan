using System;

namespace EDEH.BasicWebEvents
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CountriesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputLabel.Text = CountriesDropDown.SelectedIndex.ToString();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            OutputLabel.Text = "Clicked me";
        }
    }
}