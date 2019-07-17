using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpWebApi.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeController : ApiController
    {
        UserEntities obj = new UserEntities();
        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IQueryable<Employee> GetEmaployee()
        {
            try
            {
                return obj.Employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId}")]
        public IHttpActionResult GetEmaployeeById(string employeeId)
        {
            Employee objEmp = new Employee();
            int ID = Convert.ToInt32(employeeId);
            try
            {
                objEmp = obj.Employees.Find(ID);
                if (objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IHttpActionResult PostEmaployee(Employee data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                obj.Employees.Add(data);
                obj.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }



            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmaployeeMaster(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee objEmp = new Employee();
                objEmp = obj.Employees.Find(employee.Emp_Id);
                if (objEmp != null)
                {
                    objEmp.Emp_Name = employee.Emp_Name;
                    objEmp.Address = employee.Address;
                    objEmp.EmailId = employee.EmailId;
                    objEmp.Date_of_Birth = employee.Date_of_Birth;
                    objEmp.Gender = employee.Gender;
                    objEmp.Position = employee.Position;

                }
                int i = this.obj.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            
            Employee emaployee = obj.Employees.Find(id);
            if (emaployee == null)
            {
                return NotFound();
            }

            obj.Employees.Remove(emaployee);
            obj.SaveChanges();

            return Ok(emaployee);
        }

    }

}
