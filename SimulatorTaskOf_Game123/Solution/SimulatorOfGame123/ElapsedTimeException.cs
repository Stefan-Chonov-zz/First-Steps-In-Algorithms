using System;
using System.Runtime.Serialization;

public class ElapsedTimeException : Exception, ISerializable
{
    private readonly string message;

    public ElapsedTimeException()
    {
    }

    public ElapsedTimeException(string message)
    : base(message)
    {
        this.message = message;
    }

    public ElapsedTimeException(string message, Exception inner)
    : base(message, inner)
    {
    }

    protected ElapsedTimeException(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
        if (info != null)
        {
            this.message = info.GetString("message");
        }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);

        if (info != null)
        {
            info.AddValue("message", this.message);
        }
    }

    public override string Message
    {
        get
        {
            return this.message;
        }
    }
}