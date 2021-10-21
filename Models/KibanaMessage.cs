
using System;

public class KibanaMessage
{
    public int took { get; set; }
    public bool timed_out { get; set; }
    public _Shards _shards { get; set; }
    public Hits hits { get; set; }
    public Aggregations aggregations { get; set; }
    public int status { get; set; }
}

public class _Shards
{
    public int total { get; set; }
    public int successful { get; set; }
    public int skipped { get; set; }
    public int failed { get; set; }
}

public class Hits
{
    public int total { get; set; }
    public object max_score { get; set; }
    public Hit[] hits { get; set; }
}

public class Hit
{
    public string _index { get; set; }
    public string _type { get; set; }
    public string _id { get; set; }
    public int _version { get; set; }
    public object _score { get; set; }
    public _Source _source { get; set; }
    public Fields1 fields { get; set; }
    public Highlight highlight { get; set; }
    public long[] sort { get; set; }
}

public class _Source
{
    public DateTime timestamp { get; set; }
    public string level { get; set; }
    public string messageTemplate { get; set; }
    public string message { get; set; }
    public Exceptions[] exceptions { get; set; }
    public Fields fields { get; set; }
}

public class Fields
{
    public string SourceContext { get; set; }
}

public class Exceptions
{
    public int Depth { get; set; }
    public string ClassName { get; set; }
    public string Message { get; set; }
    public string Source { get; set; }
    public string StackTraceString { get; set; }
    public object RemoteStackTraceString { get; set; }
    public int RemoteStackIndex { get; set; }
    public int HResult { get; set; }
    public object HelpURL { get; set; }
}

public class Fields1
{
    public DateTime[] timestamp { get; set; }
}

public class Highlight
{
    public string[] message { get; set; }
}

public class Aggregations
{
    public _2 _2 { get; set; }
}

public class _2
{
    public Bucket[] buckets { get; set; }
}

public class Bucket
{
    public DateTime key_as_string { get; set; }
    public long key { get; set; }
    public int doc_count { get; set; }
}
