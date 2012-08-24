using System;
using System.Runtime.Serialization;

public class InvalidMNException : Exception, ISerializable
{
    private readonly string message;
    
    public InvalidMNException()
    {
        
    }

    public InvalidMNException(string message)
    : base(message)
    {
        this.message = message;
    }

    public InvalidMNException(string message, Exception inner)
    : base(message, inner)
    {
    }

    protected InvalidMNException(SerializationInfo info, StreamingContext context)
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