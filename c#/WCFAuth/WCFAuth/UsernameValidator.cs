using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCFAuth
{
    class UsernameValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }
            if(!(userName =="seyfi" && password=="seyf"))
            {
                throw new FaultException("Incorrect password or userman");
            }
        }
    }
}
