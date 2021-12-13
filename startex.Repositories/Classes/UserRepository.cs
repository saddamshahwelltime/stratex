using System;
using startex.EntityModel.Models;
using startex.EntityModel.Contexts;
using startex.Repositories.Interfaces;
using startex.Repositories.Base;
using startex.EntityModel.BusinessEntities;
using System.Collections.Generic;
using System.Linq;

namespace startex.Repositories.Classes
{
  public class UserRepository : RepositoryBase, IUserRepository
  {
    private readonly stratexDBContext _stratexDBContext = new stratexDBContext();

    public UserRepository(stratexDBContext context)
    {
      _stratexDBContext = context;
    }

    public List<UserEntity> GetUsers()
    {
      var employees = _stratexDBContext.Employees;
      List<UserEntity> userEntities = new List<UserEntity>();
      foreach (var emp in employees)
      {
        UserEntity user = new UserEntity
        {
          EmployeeID = emp.Id,
          EmployeeName = emp.Name
        };
        userEntities.Add(user);
      }
      return userEntities;
    }

    public UserEntity GetUser(int UserID)
    {
      var emp = _stratexDBContext.Employees.Where(e => e.Id == UserID).FirstOrDefault();
      UserEntity userEntities = new UserEntity
      {
        EmployeeID = emp.Id,
        EmployeeName = emp.Name
      };
      return userEntities;
    }



  }
}