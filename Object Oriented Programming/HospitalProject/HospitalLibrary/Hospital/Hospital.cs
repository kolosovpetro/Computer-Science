using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HospitalLibrary
{
    [Serializable]
    public class Hospital
    {
        public List<Employee> Employees { get; private set; }
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
                using (FileStream fs = new FileStream(SerializePath + SerializeFile, FileMode.Open, FileAccess.Read))
                {
                    IFormatter Formatter = new BinaryFormatter();
                    Hospital NewHospital = (Hospital)Formatter.Deserialize(fs);
                    HospitalName = NewHospital.HospitalName + "Deserialized";
                    Employees = NewHospital.Employees;
                }
            }

            else
            {
                Employees = new List<Employee>();
                SerializeHospital();
            }
        }

        public void AddEmployee(Employee newEmployee)
        {
            if (!EmployeeExist(newEmployee.Name, newEmployee.Surname))
            {
                Employees.Add(newEmployee);
                SerializeHospital();
                return;
            }

            throw new EmployeeExistException("Such employee already works in this hospital.");

        }

        public void SerializeHospital()
        {
            if (!Directory.Exists(SerializePath))
            {
                Directory.CreateDirectory(SerializePath);
            }

            using (FileStream fs = new FileStream(SerializePath + SerializeFile, FileMode.Create, FileAccess.Write))
            {
                IFormatter Formatter = new BinaryFormatter();
                Formatter.Serialize(fs, this);
            }
        }

        public bool EmployeeExist(string Id)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Id == Id)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool EmployeeExist(string Id, out Employee Employee)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Id == Id)
                {
                    Employee = employee;
                    return true;
                }
            }

            Employee = default;
            return false;
        }

        public bool EmployeeExist(string Name, string Surname)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Name == Name && employee.Surname == Surname)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CreditsExist(string Username, string Password)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Username == Username && employee.Password == Password)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool CreditsExist(string Username, string Password, out Employee Employee)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Username == Username && employee.Password == Password)
                {
                    Employee = employee;
                    return true;
                }
            }

            Employee = default;
            return false;
        }


    }
}
