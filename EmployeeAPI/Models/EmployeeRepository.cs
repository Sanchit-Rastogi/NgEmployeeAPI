using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace EmployeeAPI.Models
{
    public class EmployeeRepository
    {
        private string connectionString;

        public EmployeeRepository()
        {
            connectionString = "Data Source=.;Initial Catalog=EmployeeDB;user=sa;password=Sanchit123@sql#;Trusted_Connection=false";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Employee emp)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = "INSERT INTO Employee(FirstName, LastName, PreferredName, JobTitle, Department, PhoneNumber, Email,Office, SkypeId ) VALUES (@FirstName, @LastName, @PreferredName, @JobTitle, @Department, @PhoneNumber, @Email, @Office, @SkypeId)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, emp);
        }

        public IEnumerable<Employee> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = "SELECT * FROM Employee";
            dbConnection.Open();
            return dbConnection.Query<Employee>(sQuery);
        }

        public Employee GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = "SELECT * FROM Employee WHERE EmployeeId=@Id";
            dbConnection.Open();
            return dbConnection.Query<Employee>(sQuery, new {Id = id}).FirstOrDefault();
        }

        public void Delete(int id)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = "DELETE FROM Employee WHERE EmployeeId=@Id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { Id = id });
        }

        public void Update(Employee emp)
        {
            using IDbConnection dbConnection = Connection;
            string sQuery = "UPDATE Employee SET FirstName=@FirstName, LastName=@LastName, PreferredName=@PreferredName, JobTitle=@JobTitle, Department=@Department, PhoneNumber=@PhoneNumber, Email=@Email, Office=@Office, SkypeId=@SkypeId WHERE EmployeeId=@EmployeeId";
            dbConnection.Open();
            dbConnection.Query(sQuery,emp);
        }
    }
}
