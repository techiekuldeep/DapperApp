﻿using DapperApp.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Repository
{
    public interface IBonusRepository
    {
        List<Employee> GetEmployeeWithCompany(int id);
        Company GetCompanyWithEmployees(int id);

        List<Company> GetAllCompanyWithEmployees();
        void AddTestCompanyWithEmployees(Company objComp);
        void RemoveRange(int[] companyId);
        List<Company> FilterCompanyByName(string name);
    }
}
