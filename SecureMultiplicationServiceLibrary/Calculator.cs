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
        public int Add(int a, int b)
        {
            try
            {
                /*var currentIdentity = Thread.CurrentPrincipal.Identity;
                Console.WriteLine($"Client user: {currentIdentity.Name}");

                if (currentIdentity is WindowsIdentity windowsIdentity)
                {
                    var principal = new WindowsPrincipal(windowsIdentity);
                    //if (!principal.IsInRole("Administrator"))
                    //    throw new Exception("Oh no, you can't do that!");
                }*/

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
