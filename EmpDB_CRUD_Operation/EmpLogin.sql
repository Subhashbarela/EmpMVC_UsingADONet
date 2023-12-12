
create or alter procedure spEmployeeLogin
@EmpLoginId int,
@EmpLoginName varchar(30)
as
begin
  begin try      
	select * from Employee where EmployeeId=@EmpLoginId and EmployeeName=@EmpLoginName;
  end try
  begin catch
  select
  'An error occurred: '+ ERROR_MESSAGE() AS ErrorMessage;
  end catch
end
--EXEC spEmployeeLogin @EmpLoginId = 4, @EmpLoginName = 'VinnuBhadle';
