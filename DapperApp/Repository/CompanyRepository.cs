﻿using Dapper;

using DapperApp.Data;
using DapperApp.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IDbConnection db;

        public CompanyRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            
           
        }

        public Company Find(int id)
        {
            
        }

        public List<Company> GetAll()
        {
            var sql = "SELECT * FROM Companies";
            return db.Query<Company>(sql).ToList();
        }

        public void Remove(int id)
        {
           
        }

        public Company Update(Company company)
        {
            
        }
    }
}
