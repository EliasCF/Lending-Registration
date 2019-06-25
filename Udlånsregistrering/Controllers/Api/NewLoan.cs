using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Controllers.Api
{
    public class NewLoan
    {
        [JsonProperty("computerId")]
        public int ComputerId { get; set; }

        [JsonProperty("loaned_Date")]
        public DateTime Loaned_Date { get; set; }

        [JsonProperty("loanExpiration_Date")]
        public DateTime LoanExpiration_Date { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
