using System;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;

namespace WebSecureCalculatorServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator
    {
        [PrincipalPermission(SecurityAction.Demand, Role ="Admin")]
        public int Add(int a, int b)
        {
            try
            {
                return a + b;
            }
            catch (Exception)
            {

                throw new FaultException("Access denied");
            }
        }

        public int Multiply(int a, int b)
        {
            try
            {
                return a * b;
            }
            catch (Exception)
            {

                throw new FaultException("Access denied");
            }
        }
    }
}
