using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Email
{
    public class EmailSettings
    {
        public string From { get; set; } = null!; 
        public string BulkSmtpHost { get; set; } = null!; 
        public string SmtpHost { get; set; } = null!; 
        public int SmtpPort { get; set; }  
        public string FromName { get; set; } = null!; 
        public string UserName { get; set; } = null!; 
        public string Password { get; set; } = null!;
    }
}
