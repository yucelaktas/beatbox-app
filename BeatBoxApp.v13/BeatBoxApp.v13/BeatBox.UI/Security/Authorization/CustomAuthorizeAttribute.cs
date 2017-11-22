using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeatBox.UI.Security.Authorization
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        string[] _authorizedRoles;

        public CustomAuthorizeAttribute(string roles)
        {
            _authorizedRoles = roles.Split(',');
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] _currentUserRoles;

            CustomRoleProvider provider = new CustomRoleProvider();

            _currentUserRoles = provider.GetRolesForUser(HttpContext.Current.User.Identity.Name);

            bool _autorize = false;

            foreach (var role in _authorizedRoles)
            {
                if (_currentUserRoles.Contains(role))
                {
                    _autorize = true;
                    break;
                }
            }

            if (!_autorize)
            {
                filterContext.Result = new RedirectResult("/account/signin");
            }
        }
    }
}