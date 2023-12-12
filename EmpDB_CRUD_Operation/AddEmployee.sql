create or alter procedure spAddEmployee         
(        
 @EmployeeName varchar(50),
@ProfileImage varchar(255),
@Department varchar(50),
@Gender varchar(30),
@Salary bigInt,
@StartDate date,
@Notes varchar(Max)
)        
as         
Begin
begin try

begin transaction
    Insert into Employee(EmployeeName,ProfileImage,Department,Gender,Salary,StartDate ,Notes)         
    Values (@EmployeeName,@ProfileImage,@Department, @Gender,@Salary,@StartDate,@Notes) 
 commit transaction
  end try

    begin catch
    rollback transaction
    end catch
End 

