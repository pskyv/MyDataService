using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Models
{
    public class QueryParameters
    {
        public string Mark { get; set; }

        public ContinuationToken ContinuationToken { get; set; }
    }

    public class ContinuationToken
    {
        public string NextPartitionKey { get; set; }

        public string NextRowKey { get; set; }
    }
}
