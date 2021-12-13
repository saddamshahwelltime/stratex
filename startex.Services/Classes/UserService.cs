using System;
using System.Collections.Generic;
using System.Text;
using startex.EntityModel.Models;
using startex.EntityModel.Contexts;
using startex.Repositories.Interfaces;
using startex.Repositories.Classes;
using startex.Repositories.Base;
using startex.Services.Interfaces;
using startex.EntityModel.BusinessEntities;
using System.Linq;

namespace startex.Services.Classes
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _UserRepo;
    private readonly IActivityRepository _ActivityRepo;

    public UserService(stratexDBContext context)
    {
      _UserRepo = new UserRepository(context);
      _ActivityRepo = new ActivityRepository(context);
    }

    public ScheduleEntity GetSchedule(int UserID)
    {
      ScheduleEntity empSchedule = new ScheduleEntity();
      empSchedule.Employees = new List<UserEntity>();

      UserEntity user = _UserRepo.GetUser(UserID);
      List<ActivityEntity> allActivites = _ActivityRepo.GetActivity(UserID);//.OrderBy(d => d.StartDateTime).ToList();
      
      List<ActivityEntity> shifts = allActivites.Where(a => a.ActivityType == "Shift").OrderBy(d => d.StartDateTime).ToList();
      List<ActivityEntity> breaksLeaves = allActivites.Where(a => a.ActivityType == "Break" || a.ActivityType == "Leave").ToList();

      List<ActivityEntity> flatSchedule = new List<ActivityEntity>();

      foreach (var shft in shifts)
      {
        List<ActivityEntity> overlappingBreaksLeaves = breaksLeaves.Where(bl => bl.StartDateTime < shft.StartDateTime || bl.EndDateTime > shft.StartDateTime).ToList();

        if (overlappingBreaksLeaves.Any())
        {
          foreach (var br in overlappingBreaksLeaves)
          {
            ActivityEntity shftChunk = shft;
            ActivityEntity brChunk = br;

            //CASE 1: if break start before shift and ends in within shift
            if (br.StartDateTime < shft.StartDateTime && (br.EndDateTime > shft.StartDateTime && br.EndDateTime < shft.EndDateTime))
            {
              brChunk.StartDateTime = shft.StartDateTime;
              brChunk.EndDateTime = br.StartDateTime;
              shftChunk.StartDateTime = shft.StartDateTime;
              shftChunk.EndDateTime = shft.EndDateTime;
            }

            //CASE 2: if break start before shift and ends after shift
            //CASE 3: if break starts within shift and ends within shift
            //CASE 4: if break start within shift and ends after shift




            //AFTER CALCULATIONS, ADD CALCULATED CHUNKS IN FINAL LIST TO RETURN BACK
            flatSchedule.Add(brChunk);
            flatSchedule.Add(shftChunk);

          }
          flatSchedule.Add(shft);
          flatSchedule.AddRange(overlappingBreaksLeaves);
        }
        else
        {
          flatSchedule.Add(shft);
        }

        //We are going to ignore rest of the 2 scenarios under
        //CASE 5: if break start before shift and ends before shift
        //CASE 6: if break start after shift and ends after shift

      }


      user.Activities = flatSchedule;

      empSchedule.Employees.Add(user);
      return empSchedule;
    }
  }
}
