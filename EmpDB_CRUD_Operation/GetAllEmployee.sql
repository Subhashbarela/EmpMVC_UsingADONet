Create or alter procedure spGetAllEmployees      
as      
Begin      
   begin try
   begin transaction

   select * from Employee
   commit transaction

   end try

   begin catch
   rollback transaction
   end catch
End 

