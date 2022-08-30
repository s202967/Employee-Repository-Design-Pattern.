using EmployeesWeb.Data;
using EmployeesWeb.Models;
using EmployeesWeb.Repository;

namespace EmployeesWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id).ConfigureAwait(false);
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            var resp = await _employeeRepository.GetAllAsync();
            return resp.ToList();

        }

        public async Task<bool> CreateAsync(Employee employee)

        {
            await _employeeRepository.AddAsync(employee);
            _employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> EditAsync(Employee employee)
        {
            _employeeRepository.Update(employee);
            _employeeRepository.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await FindByIdAsync(id).ConfigureAwait(false);
            _employeeRepository.Remove(employee);
            _employeeRepository.SaveChanges(); 
            return true;
        }

        /*

                    public async Task<bool> EditAsync(Employee employee)
                    {
                        _employeeRepository.Update(employee);
                        return true;

                    }

                    public async Task<Employee> DetailsAsync(int? id)
                    {
                        return await _employeeRepository.GetByIdAsync(id.Value).ConfigureAwait(false);

                    }

                    public async Task<bool> DeleteAsync(int id)
                    {
                        var employee = await FindByIdAsync(id).ConfigureAwait(false);
                        _employeeRepository.Remove(employee);
                        return true;
                    }*/
    }


}
