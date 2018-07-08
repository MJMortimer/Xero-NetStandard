using System.Collections.Generic;
using System.Threading.Tasks;
using Xero.Api.Payroll.Australia.Endpoints;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll
{
    public interface IAustralianPayroll
    {
        string BaseUri { get; }
        string UserAgent { get; set; }

        SuperFundsEndpoint SuperFunds { get; set; }
        SuperFundProductsEndpoint SuperFundProducts { get; set; }
        LeaveApplicationsEndpoint LeaveApplications { get; set; }
        PayslipsEndpoint Payslips { get; }
        EmployeesEndpoint Employees { get; }
        PayRunsEndpoint PayRuns { get; }
        TimesheetsEndpoint Timesheets { get; }
        PayItemsEndpoint PayItems { get; }
        PayrollCalendarsEndpoint PayrollCalendars { get; }
        SettingsEndpoint Settings { get; }
        
        Task<IEnumerable<LeaveApplication>> CreateAsync(IEnumerable<LeaveApplication> items);
        Task<IEnumerable<Payslip>> CreateAsync(IEnumerable<Payslip> items);
        Task<IEnumerable<SuperFund>> CreateAsync(IEnumerable<SuperFund> items);
        Task<IEnumerable<Employee>> CreateAsync(IEnumerable<Employee> items);
        Task<IEnumerable<PayRun>> CreateAsync(IEnumerable<PayRun> items);
        Task<IEnumerable<Timesheet>> CreateAsync(IEnumerable<Timesheet> items);
        Task<IEnumerable<PayrollCalendar>> CreateAsync(IEnumerable<PayrollCalendar> items);
        Task<LeaveApplication> CreateAsync(LeaveApplication item);
        Task<Payslip> CreateAsync(Payslip item);
        Task<SuperFund> CreateAsync(SuperFund item);
        Task<Employee> CreateAsync(Employee item);
        Task<PayRun> CreateAsync(PayRun item);
        Task<Timesheet> CreateAsync(Timesheet item);
        Task<PayItems> CreateAsync(PayItems item);
        Task<PayrollCalendar> CreateAsync(PayrollCalendar item);
        Task<IEnumerable<LeaveApplication>> UpdateAsync(IEnumerable<LeaveApplication> items);
        Task<IEnumerable<Payslip>> UpdateAsync(IEnumerable<Payslip> items);
        Task<IEnumerable<SuperFund>> UpdateAsync(IEnumerable<SuperFund> items);
        Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> items);
        Task<IEnumerable<PayRun>> UpdateAsync(IEnumerable<PayRun> items);
        Task<IEnumerable<Timesheet>> UpdateAsync(IEnumerable<Timesheet> items);
        Task<IEnumerable<PayrollCalendar>> UpdateAsync(IEnumerable<PayrollCalendar> items);
        Task<LeaveApplication> UpdateAsync(LeaveApplication item);
        Task<Payslip> UpdateAsync(Payslip item);
        Task<SuperFund> UpdateAsync(SuperFund item);
        Task<Employee> UpdateAsync(Employee item);
        Task<PayRun> UpdateAsync(PayRun item);
        Task<Timesheet> UpdateAsync(Timesheet item);
        Task<PayItems> UpdateAsync(PayItems item);
        Task<PayrollCalendar> UpdateAsync(PayrollCalendar item);
    }
}