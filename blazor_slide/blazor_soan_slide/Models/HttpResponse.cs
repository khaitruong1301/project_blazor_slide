using System;
using System.Collections.Generic;

public partial class HttpResponse<T>
{
    public long statusCode { get; set; }

    public string message { get; set; }

    public List<T> content { get; set; }

    public DateTime dateTime { get; set; }
}