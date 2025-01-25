using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ObjectModel;

public class DBRoleProvider: RoleProvider
{
	public override string ApplicationName
	{
		get {return "/";}
		set {}
	}

	public override void AddUsersToRoles(string[] usernames, string[] roleNames)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			string username, roleName;
			for (int i = 0; i < usernames.Length; i++)
			{
				username = usernames[i];
				User u = ctx.UserSet.FirstOrDefault(user => user.Username.Equals(username));

				if (u != null)
				{
					for (int j = 0; j < roleNames.Length; j++)
					{
						roleName = roleNames[i];
						Role r = ctx.RoleSet.FirstOrDefault(role => role.RoleName.Equals(roleName));
						u.Roles.Add(r);
					}
				}
			}

			ctx.SaveChanges();
		}
	}

	public override void CreateRole(string roleName)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			ctx.AddToRoleSet(new Role() { RoleName = roleName });
			ctx.SaveChanges();
		}
	}

	public override bool IsUserInRole(string username, string roleName)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			return ctx.RoleSet.Include("Users").Where(u => u.RoleName.Equals(roleName)).SelectMany(x => x.Users).Count(x => x.Username.Equals(username)) > 0;
		}
	}
	
	public override string[] GetAllRoles()
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			return ctx.RoleSet.Select(x => x.RoleName).ToArray();
		}
	}

	public override string[] GetRolesForUser(string username)
	{
		using (UsersEntities ctx = new UsersEntities())
		{
			return ctx.UserSet.Include("Roles").Where(x=>x.Username.Equals(username)).SelectMany(x => x.Roles.Select(y=>y.RoleName)).ToArray();
		}
	}

    public override bool RoleExists(string roleName)
    {
        using (UsersEntities ctx = new UsersEntities())
        {
            return ctx.RoleSet.Count(x => x.RoleName.Equals(roleName)) > 0;
        }
    }
	
	public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
	{
		throw new NotImplementedException();
	}

	public override string[] FindUsersInRole(string roleName, string usernameToMatch)
	{
		throw new NotImplementedException();
	}

	public override string[] GetUsersInRole(string roleName)
	{
		throw new NotImplementedException();
	}

	public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
	{
		throw new NotImplementedException();
	}

}
