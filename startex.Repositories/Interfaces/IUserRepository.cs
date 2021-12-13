using System;
using System.Collections.Generic;
using System.Text;
using startex.EntityModel.BusinessEntities;
using startex.EntityModel.Models;

namespace startex.Repositories.Interfaces
{
  public interface IUserRepository
  {
    public List<UserEntity> GetUsers();
    public UserEntity GetUser (int UserID);


  }
}
