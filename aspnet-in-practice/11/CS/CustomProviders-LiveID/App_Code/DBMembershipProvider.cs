using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ObjectModel;

public class DBMembershipProvider: MembershipProvider
{

	public override string ApplicationName
	{
		get {return "/";}
		set {}
	}

	public override bool ValidateUser(string username, string password)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			return ctx.UserSet.Count(user => user.Username.Equals(username) && user.Password.Equals(password))==1;
		}
	}

	public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			// let's compose the user
			MembershipUser u = new MembershipUser(this.Name, username, username, email, passwordQuestion, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);

			User user = new User();
			user.Username = username;
			user.Password = password;
			user.Email = email;
			ctx.AddToUserSet(user);

			// TODO: check for e-mail and username availability

			// updating...
			try
			{
				ctx.SaveChanges();
			}
			catch
			{
				// there was an error
				status = MembershipCreateStatus.ProviderError;
				return null;
			}

			// successfully created
			status = MembershipCreateStatus.Success;
			return u;
		}
	}
	public override MembershipUser GetUser(string username, bool userIsOnline)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			User u = ctx.UserSet.FirstOrDefault(x => x.Username.Equals(username));
			if (u == null)
				return null;

			return new MembershipUser(this.Name, username, username, u.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
		}
	}

	public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
	{
		return GetUser(providerUserKey.ToString(), userIsOnline);
	}

	public override bool EnablePasswordReset
	{
		get { return false; }
	}

	public override bool EnablePasswordRetrieval
	{
		get { return false; }
	}

	public override int MaxInvalidPasswordAttempts
	{
		get { return 0; }
	}

	public override int MinRequiredNonAlphanumericCharacters
	{
		get { return 1; }
	}

	public override int MinRequiredPasswordLength
	{
		get { return 5; }
	}

	public override int PasswordAttemptWindow
	{
		get { return 0; }
	}

	public override MembershipPasswordFormat PasswordFormat
	{
		get { return MembershipPasswordFormat.Clear; }
	}

	public override string PasswordStrengthRegularExpression
	{
		get { return string.Empty; }
	}

	public override bool RequiresQuestionAndAnswer
	{
		get { return false; }
	}

	public override bool RequiresUniqueEmail
	{
		get { return true; }
	}

	public override bool ChangePassword(string username, string oldPassword, string newPassword)
	{
		throw new NotImplementedException();
	}

	public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
	{
		throw new NotImplementedException();
	}

	public override bool DeleteUser(string username, bool deleteAllRelatedData)
	{
		throw new NotImplementedException();
	}
	public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}

	public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}

	public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}

	public override int GetNumberOfUsersOnline()
	{
		throw new NotImplementedException();
	}

	public override string GetPassword(string username, string answer)
	{
		throw new NotImplementedException();
	}



	public override string GetUserNameByEmail(string email)
	{
		throw new NotImplementedException();
	}

	public override string ResetPassword(string username, string answer)
	{
		throw new NotImplementedException();
	}

	public override bool UnlockUser(string userName)
	{
		throw new NotImplementedException();
	}

	public override void UpdateUser(MembershipUser user)
	{
		throw new NotImplementedException();
	}
}
