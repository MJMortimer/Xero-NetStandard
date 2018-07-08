using Xero.Api.Core;
using Xero.Api.Payroll;

namespace Xero.Api
{
    public interface IXeroApi
    {
        IXeroCoreApi Core { get; set; }
        IAmericanPayroll UsPayroll { get; set; }
        IAustralianPayroll AuPayroll { get; set; }
    }
}