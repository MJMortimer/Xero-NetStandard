using System.Collections.Generic;
using System.Threading.Tasks;
using Xero.Api.Payroll.America.Endpoints;
using Xero.Api.Payroll.America.Model;

namespace Xero.Api.Payroll
{
    public interface IAmericanPayroll
    {
        string BaseUri { get; }
        string UserAgent { get; set; }

        WorkLocationsEndpoint WorkLocations { get; }
        PayItemsEndpoint PayItems { get; }
        PayStubsEndpoint PayStubs { get; }
        PaySchedulesEndpoint PaySchedules { get; }
        EmployeesEndpoint Employees { get; }
        PayRunsEndpoint PayRuns { get; }
        TimesheetsEndpoint Timesheets { get; }
        SettingsEndpoint Settings { get; }
        
        Task<IEnumerable<PaySchedule>> CreateAsync(IEnumerable<PaySchedule> items);
        Task<IEnumerable<WorkLocation>> CreateAsync(IEnumerable<WorkLocation> items);
        Task<IEnumerable<PayStub>> CreateAsync(IEnumerable<PayStub> items);
        Task<IEnumerable<Employee>> CreateAsync(IEnumerable<Employee> items);
        Task<IEnumerable<PayRun>> CreateAsync(IEnumerable<PayRun> items);
        Task<IEnumerable<Timesheet>> CreateAsync(IEnumerable<Timesheet> items);
        Task<PaySchedule> CreateAsync(PaySchedule item);
        Task<WorkLocation> CreateAsync(WorkLocation item);
        Task<PayStub> CreateAsync(PayStub item);
        Task<Employee> CreateAsync(Employee item);
        Task<PayRun> CreateAsync(PayRun item);
        Task<Timesheet> CreateAsync(Timesheet item);
        Task<IEnumerable<PaySchedule>> UpdateAsync(IEnumerable<PaySchedule> items);
        Task<IEnumerable<WorkLocation>> UpdateAsync(IEnumerable<WorkLocation> items);
        Task<IEnumerable<PayStub>> UpdateAsync(IEnumerable<PayStub> items);
        Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> items);
        Task<IEnumerable<PayRun>> UpdateAsync(IEnumerable<PayRun> items);
        Task<IEnumerable<Timesheet>> UpdateAsync(IEnumerable<Timesheet> items);
        Task<PaySchedule> UpdateAsync(PaySchedule item);
        Task<WorkLocation> UpdateAsync(WorkLocation item);
        Task<PayStub> UpdateAsync(PayStub item);
        Task<Employee> UpdateAsync(Employee item);
        Task<PayRun> UpdateAsync(PayRun item);
        Task<Timesheet> UpdateAsync(Timesheet item);
    }
}