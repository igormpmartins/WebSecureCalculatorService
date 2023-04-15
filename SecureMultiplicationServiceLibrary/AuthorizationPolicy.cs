using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebSecureCalculatorServiceLibrary
{
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        public ClaimSet Issuer => ClaimSet.System;

        public string Id => Guid.NewGuid().ToString();

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            if (!evaluationContext.Properties.TryGetValue("Identities", out var obj))
                return false;

            var identities = obj as IList<IIdentity>;
            if (identities == null || identities.Count <= 0) 
                return false;

            evaluationContext.Properties["Principal"] = new CustomPrincipal(identities.FirstOrDefault());
            return true;
        }
    }

    public class CustomPrincipal : IPrincipal
    {
        private IIdentity identity;

        public CustomPrincipal(IIdentity identity)
        {
            this.identity = identity;
        }

        public IIdentity Identity => identity;

        public bool IsInRole(string role)
        {
            var userName = Identity.Name.ToString();
            return (userName == "test" && role == "Admin");
        }
    }
}
