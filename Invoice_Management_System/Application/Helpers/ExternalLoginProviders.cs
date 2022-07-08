using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
   
    public class ExternalLoginProviders
    {
        public Facebook Facebook { get; set; }
        public Twitter Twitter { get; set; }
        public Google Google { get; set; }
        public Microsoft Microsoft { get; set; }
    }

    public class Facebook
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }

    public class Google
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class Microsoft
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class Twitter
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
    }


}
