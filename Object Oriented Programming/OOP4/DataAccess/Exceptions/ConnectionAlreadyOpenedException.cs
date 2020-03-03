
using System;
using System.Runtime.Serialization;

[Serializable]

public class ConnectionAlreadyOpenedException : Exception
{
    public ConnectionAlreadyOpenedException()
    {
    }
    public ConnectionAlreadyOpenedException(string message)
        : base(message)
    {
    }
    public ConnectionAlreadyOpenedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConnectionAlreadyOpenedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
