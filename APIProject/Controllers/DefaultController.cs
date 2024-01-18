using APIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;

namespace APIProject.Controllers
{
    public class DefaultController : ApiController
    {
        List<Employee> list;
        public DefaultController() 
        {
            list = new List<Employee>();
            list.Add(new Employee(1, "Chuc Du Dy", "Thai Binh", 2000));
            list.Add(new Employee(2, "Nguyen Min Hai", "Ha Noi", 3000));
            list.Add(new Employee(3, "Tran Phuong Anh", "Thai Binh", 2500));
            list.Add(new Employee(4, "Ho Quang Hieu", "Nam Dinh", 2100));
            list.Add(new Employee(5, "Pham Gia Khanh", "Vinh Phuc", 1800));
            list.Add(new Employee(6, "Pham Linh Anh", "Hai Phong", 1600));
            list.Add(new Employee(7, "Ha Thanh Chuc", "Ha Noi", 2000));
        }
        [HttpGet]
        [Route("api/default/list")]
        public List<Employee> GetAllEmployees()
        {
            return list;
        }
        [HttpGet]
        [Route("api/default/findbyaddress")]
        public List<Employee> GetAllEmployeesByAddress(String address)
        {
            List<Employee>list2 = new List<Employee>();
            foreach (Employee item in list) 
            { 
                if(item.address== address)
                {
                    list2.Add(item);
                }
            }
            return list2;
        }
        [HttpGet]
        [Route("api/default/findbyempid")]
        public Employee findEmpid(int empid)
        {
            Employee e = new Employee();
            e.empid = empid;
            int index = list.IndexOf(e);
            if(index != -1)
            {
                return list[index];
            }
            else
            {
                return null;
            }
            
        }
        [HttpGet]
        [Route("api/default/convert")]
        public double convertTemperature(int temp)
        {
            return temp * 9.0 / 5 + 32;
        }

        [HttpPost]
        [Route("api/default/hello")]
        public string Hello(string msg)
        {
            return "Hello " + msg;
        }
        [HttpPost]
        [Route("api/default/add")]
        public int addEmp([FromBody] Employee emp)
        {
            list.Add(emp);
            return list.Count;
        }
        [HttpPut]
        [Route("api/default/update")]
        public string testPut()
        {
            return "Test Put method!";
        }
        [HttpDelete]
        [Route("api/default/delete")]
        public string testDelete()
        {
            return "Test Delete method!";
        }
    }
}
