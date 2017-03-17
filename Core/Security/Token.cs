using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoNotes.Core.Security {
    /// <summary>
    // {
    //   "access_token": "", <-- token string
    //   "token_type": "bearer", <-- this is bearer auth
    //   "expires_in": 7199 <-- (in seconds)
    // }
    /// </summary>
    public class Token {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
