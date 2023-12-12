Create or alter procedure spDeleteEmployee         
(          
   @EmployeeId int          
)          
as           
begin
begin try

begin transaction
   Delete from Employee where EmployeeId=@EmployeeId ; 
    commit transaction

  end try

    begin catch
    rollback transaction
    end catch
End 

