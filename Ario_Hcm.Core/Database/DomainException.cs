using System;
namespace Ario_Hcm.Core.Database
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
