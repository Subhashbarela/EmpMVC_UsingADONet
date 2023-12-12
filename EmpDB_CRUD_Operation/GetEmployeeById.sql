Create or alter procedure spGetEmployeesById 
  @EmployeeId int   
as      
Begin      
   begin try
   begin transaction
   select * from Employee where EmployeeId=@EmployeeId
   commit transaction
   end try

   begin catch
   rollback transaction
   end catch
End  
