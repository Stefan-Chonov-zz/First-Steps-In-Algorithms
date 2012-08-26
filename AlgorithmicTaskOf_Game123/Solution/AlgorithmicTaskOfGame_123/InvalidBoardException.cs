using System;
using System.Runtime.Serialization;

public class InvalidBoardException : Exception, ISerializable
{
    private readonly string message;

    public InvalidBoardException()
    {
    }

    public InvalidBoardException(string message)
    : base(message)
    {
        this.message = message;
    }

    public InvalidBoardException(string message, Exception inner)
    : base(message, inner)
    {
    }

    protected InvalidBoardException(SerializationInfo info, StreamingContext context)
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