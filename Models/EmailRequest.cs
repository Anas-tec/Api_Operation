using System.Net.Mail;

namespace Api_Test.Models
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        //atachment path
        public string AttachmentPath {  get; set; }
    }
}
