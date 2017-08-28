using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotApplicationBoiler.URLEndPoints
{
    public static  class EndPointUrl
    {

        //Change According to your conversation JSON file.
        public static string ConversationEndpoint { get; set; } = "https://raw.githubusercontent.com/muhammad92/BotApplicationBoiler/master/Messages.json";
    }
}