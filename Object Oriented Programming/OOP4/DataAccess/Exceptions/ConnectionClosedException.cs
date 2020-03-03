using System;
using System.Runtime.Serialization;

[Serializable]

public class ConnectionClosedException : Exception
{
    public ConnectionClosedException()
    {
    }
    public ConnectionClosedException(string message)
        : base(message)
    {
    }
    public ConnectionClosedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConnectionClosedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
