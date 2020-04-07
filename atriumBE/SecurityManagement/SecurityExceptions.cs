using System;

namespace atSecurity
{
	/// <summary>
	/// Summary description for SecurityExceptions.
	/// </summary>
	public class SecurityException:ApplicationException
	{
		protected string message;
		public SecurityException()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override string Message
		{
			get
			{
				return message;
			}
		}

	}

	public class BadPasswordException:SecurityException
	{
		public BadPasswordException()
		{
			base.message="Bad password.";
		}
	}
	public class PasswordLengthException:SecurityException
	{
		public PasswordLengthException()
		{
			base.message="Password must greater than 6 characters long.";
		}
	}
	public class InvalidUserId:SecurityException
	{
		public InvalidUserId()
		{
			base.message="Invalid user ID.";
		}
	}
	public class InvalidAccount:SecurityException
	{
		public InvalidAccount()
		{
			base.message="Invalid account.";
		}
	}
}
