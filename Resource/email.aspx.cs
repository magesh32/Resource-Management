using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class email : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        Session["emailid"] = TextBox1.Text;
        Sendemail(id);
        Response.Redirect("login.aspx");
    }
    public void Sendemail(string id)
    {
        string ActivationUrl;
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ananth.ameex@gmail.com", "ANANTH");
            message.To.Add(id);
            message.Subject = "Verification Email";
            ActivationUrl = Server.HtmlEncode("http://dev.resourcemanagement/newpass.aspx");
            message.Body = "<a href='" + ActivationUrl + "'>Click Here to verify your acount</a>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("ananth.ameex@gmail.com", "jeyalakshmi");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }

    public int emailid { get; set; }

}
