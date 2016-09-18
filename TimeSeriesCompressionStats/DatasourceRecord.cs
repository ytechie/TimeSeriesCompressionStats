using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCompressionStats
{
    public class DatasourceRecord
    {
        public int DatasourceId { get; set; }
        public DateTime Timestamp { get; set; }
        public int IntervalSeconds { get; set; }
        public double Value { get; set; }
    }
}