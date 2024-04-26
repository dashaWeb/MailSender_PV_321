using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender_PV_321
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string server = "smtp.gmail.com";
        int port = 587;

        string username = "dashakonopelko@gmail.com";
        string password = "iwnl bofr kwnn hwom";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(fromObj.Text,toObj.Text,themeObj.Text,bodyObj.Text);

            /*using(StreamReader sr = new StreamReader(@"../../../mail.html")) {
                message.Body = sr.ReadToEnd();
            }
            message.IsBodyHtml = true;*/

            message.Priority = MailPriority.High;
            message.Attachments.Add(new Attachment("../../../Files/nuts.jpg"));
            message.Attachments.Add(new Attachment("../../../Files/text.txt"));

            SmtpClient client = new SmtpClient(server,port);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(username, password);

            client.SendCompleted += Client_SendCompleted;

            client.SendAsync(message, message);
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState;
            MessageBox.Show($"Message was sent! Subject : {state.Subject}");
        }
    }
}