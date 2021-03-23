using Blazorise;
using Blazorise.DataGrid;
using BlazorServerApp.ClientService;
using Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class EmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }


        #region Material Design
        //public Employee[] sortedData = null;

        //public bool _isEdit=false;
        //public bool diaglogIsOpen = false;
        //private bool _isDelete = false;
        //public bool snackBar = false;
        //public Employee employee=null;
        //public Employee selectedEmp=null;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();

            #region Material Design
            //SortData(null);
            #endregion
        }

        #region Blazorise
        
        //Employee[] employeeList;
        //public int totalEmployees;

        //public async Task OnReadData(DataGridReadDataEventArgs<Employee> e)
        //{
        //    // this can be call to anything, in this case we're calling a fictional api
        //    //var response = await Http.GetJsonAsync<Employee[]>($"some-api/employees?page={e.Page}&pageSize={e.PageSize}");

        //    //employeeList = response.Data; // an actual data for the current page
        //    //totalEmployees = response.Total; // this is used to tell datagrid how many items are available so that pagination will work

        //    //// always call StateHasChanged!
        //    //StateHasChanged();
        //}

        public Modal modalRef;

        public void ShowModal()
        {
            modalRef.Show();
        }

        public void HideModal()
        {
            modalRef.Hide();
        }

        public void OnModalClosing(CancelEventArgs e)
        {
            // just set Cancel to true to prevent modal from closing
            e.Cancel = true;
        }

        public async void EditEmployee()
        {
            await EmployeeService.Edit();
            StateHasChanged();
            await OnInitializedAsync();
        }
        #endregion

        #region Material Design
        //public void SortData(MatSortChangedEvent sort)
        //{
        //    sortedData = Employees.ToArray();
        //    if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
        //    {
        //        Comparison<Employee> comparison = null;
        //        switch (sort.SortId)
        //        {
        //            case "name":
        //                comparison = (s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.InvariantCultureIgnoreCase);
        //                break;
        //            case "email":
        //                comparison = (s1, s2) => s1.Email.CompareTo(s2.Email);
        //                break;
        //            case "department":
        //                comparison = (s1, s2) => s1.Department.CompareTo(s2.Department);
        //                break;
        //        }
        //        if (comparison != null)
        //        {
        //            if (sort.Direction == MatSortDirection.Desc)
        //            {
        //                Array.Sort(sortedData, (s1, s2) => -1 * comparison(s1, s2));
        //            }
        //            else
        //            {
        //                Array.Sort(sortedData, comparison);
        //            }
        //        }
        //    }
        //}

        //public void OpenDialog(bool isEdit)
        //{
        //    _isEdit = isEdit;
        //    if (!_isEdit) employee = new Employee();
        //    diaglogIsOpen = true;
        //}
        //public void Save()
        //{
        //    diaglogIsOpen = false;
        //    //if (!_isEdit) await this.AddEmployee(employee);
        //    //else  await this.EditEmployee(employee);
        //}

        //public void CloseDialog()
        //{
        //    diaglogIsOpen = false;
        //    if (selectedEmp != null)
        //    {
        //        employee = selectedEmp;
        //        //this.EditEmployee();
        //    }
        //}
        //public void SelectionChangedEvent(object  emp)
        //{
        //    //var currentEmp = emp as Employee;
        //    //if(currentEmp != null)
        //    //{
        //    //    employee = currentEmp;
        //    //    selectedEmp = new Employee
        //    //    (
        //    //        currentEmp.Id,
        //    //        currentEmp.Name,
        //    //        currentEmp.Email,
        //    //        currentEmp.Department
        //    //    );
        //    //}
        //    //else
        //    //{
        //    //    selectedEmp = new Employee();
        //    //}
        //    //if (_isDelete) this.DeleteEmployee();
        //}
        //public async Task AddEmployee(Employee employee)
        //{
        //    await EmployeeService.Add(employee);
        //    await OnInitializedAsync();
        //}

        //public void EditEmployee(Employee employee)
        //{

        //}

        //public void DeleteEmployee()
        //{
        //    snackBar = true;
        //}

        //public void UndoDelete()
        //{

        //}
        #endregion
    }
}
