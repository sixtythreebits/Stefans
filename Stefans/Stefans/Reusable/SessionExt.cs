using System.Web;
using UM;

namespace Stefans.Reusable
{
    public static class SessionExt
    {
        public static HttpSessionStateBase Session
        {
            get
            {
                return new HttpSessionStateWrapper(HttpContext.Current.Session);;
            }
        }

        public static bool IsAuthorized(this HttpSessionStateBase SessionState)
        {
            return SessionState["UserInfo"] != null;
        }

        public static bool IsAuthorized()
        {
            return Session.IsAuthorized();
        }

        public static void SetUser(this HttpSessionStateBase SessionState, User User)
        {
            SessionState["UserInfo"] = User;
        }
    }
}