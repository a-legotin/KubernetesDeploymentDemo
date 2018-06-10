using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.DocumentGenerator
{
    public class DocumentGenerator
    {
        public Document GetNewDocument()
        {
            var random = new StringRandomizer();
            var subject = random.GetRandomString(10);
            var body = Encoding.UTF8.GetBytes(subject);
            return new Document {Subject = subject, Body = body, Timestamp = DateTime.Now};
        }
    }
}
