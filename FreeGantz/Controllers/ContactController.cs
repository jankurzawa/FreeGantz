namespace FreeGantz.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View();

        [HttpPost]
        public IActionResult SendBtnClick(string name, string email, string message)
        {
            MailMessage mail = new();
            mail.To.Add("freegantzrestaurant@gmail.com");
            mail.From = new MailAddress(email, name, System.Text.Encoding.UTF8);
            mail.ReplyToList.Add(new MailAddress(email));
            mail.Subject = "E-mail from FreeGantz website";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = email + "<br>" + message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new()
            {
                Credentials = new System.Net.NetworkCredential("freegantzrestaurant@gmail.com", "kzfrwcogicgwoqpi"),
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception? ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
            return RedirectToAction("Contact", "Home");
        }
    }
}
