using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Hospital
{
    [Serializable]
    public class Hospital
    {
        public List<Employee.Employee> Employees { get; private set; }
        public string HospitalName { get; private set; }
        public string SerializePath { get; private set; }
        public string SerializeFile { get; private set; }

        public Hospital(string newHospitalName)
        {
            HospitalName = newHospitalName;
            SerializePath = "../../../HospitalLibrary/SerializedObjects/";
            SerializeFile = $"{GetType().Name}_{HospitalName}.txt";

            if (File.Exists(SerializePath + SerializeFile))
            {
                using (var fs = new FileStream(SerializePath + SerializeFile, FileMode.Open, FileAccess.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Hospital newHospital = (Hospital) formatter.Deserialize(fs);
                    HospitalName = newHospital.HospitalName + "Deserialized";
                    Employees = newHospital.Employees;
                }
            }

            else
            {
                Employees = new List<Employee.Employee>();
                SerializeHospital();
            }
        }

        public void AddEmployee(Employee.Employee newEmployee)
        {
            if (EmployeeExist(newEmployee.Name, newEmployee.Surname))
                throw new EmployeeExistException("Such employee already works in this hospital.");
            Employees.Add(newEmployee);
            SerializeHospital();
        }

        public void SerializeHospital()
        {
            if (!Directory.Exists(SerializePath))
            {
                Directory.CreateDirectory(SerializePath);
            }

            using (var fs = new FileStream(SerializePath + SerializeFile, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, this);
            }
        }

        public bool EmployeeExist(string id)
        {
            return Employees.Any(employee => employee.Id == id);
        }

        public bool EmployeeExist(string id, out Employee.Employee emp)
        {
            foreach (var employee in Employees.Where(employee => employee.Id == id))
            {
                emp = employee;
                return true;
            }

            emp = null;
            return false;
        }

        public bool EmployeeExist(string name, string surname)
        {
            return Employees.Any(employee => employee.Name == name && employee.Surname == surname);
        }

        public bool CreditsExist(string username, string password)
        {
            return Employees.Any(employee => employee.Username == username && employee.Password == password);
        }

        public bool CreditsExist(string username, string password, out Employee.Employee emp)
        {
            foreach (var employee in Employees.Where(employee =>
                employee.Username == username && employee.Password == password))
            {
                emp = employee;
                return true;
            }

            emp = null;
            return false;
        }
    }
}