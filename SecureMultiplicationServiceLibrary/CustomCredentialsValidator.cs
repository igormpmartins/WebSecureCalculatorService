using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSecureCalculatorServiceLibrary
{
    public class CustomCredentialsValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "test" && password == "test")
                return;

            throw new SecurityTokenException("Access Denied");
        }
    }
}
