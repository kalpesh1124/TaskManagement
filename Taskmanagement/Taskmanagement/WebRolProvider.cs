using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Taskmanagement.Models;

namespace Taskmanagement
{
    public class WebRolProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var context = new TaskManagementEntities2())
            {
                //var result = (from Userinfo in context.Userinfoes 
                //              join Roles in context.UserRoles on Userinfo.uid equals Roles.Uid
                //              where Userinfo.UserName == username 
                //              select Roles.Role).ToArray();

                var result = (from user in context.Userinfoes
                             join Roles in context.UserRoles on user.uid equals Roles.Uid
                             where user.UserName == username
                             select Roles.Role).ToArray();

                return result;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}