using Dapper;

using DapperApp.Data;
using DapperApp.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public class CompanyRepositoryContrib : ICompanyRepository
    {
        private IDbConnection db;

        public CompanyRepositoryContrib(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        
        //Add with Dapper Contrib
        public Company Add(Company company)
        {
            var id = db.Insert(company);
            company.CompanyId = (int)id;
            return company;
        }

        public Company Find(int id)
        {
            return db.Get<Company>(id);
        }

        public List<Company> GetAll()
        {
            return db.GetAll<Company>().ToList();
        }


        //Remove with Dapper Contrib
        public void Remove(int id)
        {
            db.Delete(new Company { CompanyId = id });
        }


        //Update with Dapper Contrib
        public Company Update(Company company)
        {
            db.Update(company);
            return company;
        }
    }
}
