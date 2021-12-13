# stratex

Its a .Net Core Web API project. 

An API is created to get FlatSchedule of User (employee) by providing an ID of user.

https://localhost:44340/user/schedule/[{id}

The database is not in a 2nd form of normalization which took me so long to figure out how to do. I would first normalize the DB and then make an application of it.
Only one table can be maintained for scheduling instead of 3 (Break, Leave, Shift) with added reference to activity Category ID to addtional table. the same reference can be added to Activities table.


At API, I couldn't do much as of time limitation and an instresting problem but I have figured out there could be 6 possible case scenarios of given messed up DB for scheduling,

  //CASE 1: if break start before shift and ends in within shift
  //CASE 2: if break start before shift and ends after shift
  //CASE 3: if break starts within shift and ends within shift
  //CASE 4: if break start within shift and ends after shift
  //CASE 5: if break start before shift and ends before shift
  //CASE 6: if break start after shift and ends after shift   
  
I could only cover case 1 but rest of them can be integrated in same module and in same way.
All of the logic besides application structure lies in GetSchedule() module in UserServices.cs file.


  
