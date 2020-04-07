using System;

namespace atLogic
{
	/// <summary>
	/// Summary description for ClasmateException.
	/// </summary>
	/// 
	public class LoginException:AtriumException
	{
        public LoginException(string message, params string[] label)
            : base(message, label)
        {}
	}

    public class DeleteException : ApplicationException
    {
        string _message = "";
        public DeleteException(string label)
        {
            _message = String.Format(atLogic.Properties.Resources.Delete, label);
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }

    }
    public class RequiredException : ApplicationException
    {
        string _message = "";
        public RequiredException(string label)
        {
            _message = String.Format(atLogic.Properties.Resources.RequiredField, label);
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }

    }
    public class RelatedException : ApplicationException
    {
        string _message = "";
        public RelatedException(string label1,string label2)
        {
            _message = String.Format(atLogic.Properties.Resources.RelatedField, label1,label2);
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }

    }
    public class ValidationException : AtriumException
    {
         public ValidationException(string message, params string[] label)
            : base(message, label)
        {}
   }
    public class DateException : AtriumException
    {
        public DateException(string message, params string[] label)
            : base(message, label)
        { }
    }
      public class DateBetweenException : AtriumException
      {
          public DateBetweenException(params string[] label)
            : base(atLogic.Properties.Resources.DateMustBeBetween, label)
        { }
    }

    public class UpdateFailedException : AtriumException
    {
        public UpdateFailedException(string message, Exception x)
            : base(message, x)
        { }
    }
    public class ConcurrencyException : AtriumException
    {
        public ConcurrencyException(string message, Exception x)
            : base(message, x)
        { }
    }
    public class AtriumException : ApplicationException
	{
        //string _message="";

        public AtriumException(string message, Exception x)
            : base(message, x)
        {
        }
        public AtriumException(string message, params string[] label):base(String.Format(message,label))
        {
           // _message = String.Format(message, label);
        }

        //public override string Message
        //{
        //    get
        //    {
        //        return _message;
        //    }
        //}
	}
}
