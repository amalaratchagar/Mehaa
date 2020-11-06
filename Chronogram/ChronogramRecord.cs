using System;

namespace Chronogram
{
    public class ChronogramRecord
    {
        public int RecordId { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime Time { get; set; }

        public string SourceRecord { get; set; }

        public string ModifiedRecord { get; set; }

        public int ChronogramObjectId { get; set; }

        public virtual ChronogramObject ChronogramObject { get; set; }
    }
}
