using LocalizeCulture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Repositories
{
    
    public static class Repository
    {
        private static List<WebinarInvites> responses = new List<WebinarInvites>();

        public static IEnumerable<WebinarInvites> Response => responses;// porperty get

        public static void AddResponses(WebinarInvites reponse)
        {
            responses.Add(reponse);
        }

    }
}
