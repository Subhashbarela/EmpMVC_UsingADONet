CREATE OR ALTER PROCEDURE spUpdateEmployee          
(          
   @EmployeeId INT,        
   @EmployeeName VARCHAR(50),
   @ProfileImage VARCHAR(255),
   @Department VARCHAR(50),
   @Gender VARCHAR(30),
   @Salary BIGINT,
   @StartDate DATE,
   @Notes VARCHAR(MAX)
)          
AS      
BEGIN 
   BEGIN TRY
           IF CAST(@StartDate AS DATE) > CAST(GETDATE() AS DATE)
      BEGIN
         BEGIN TRANSACTION;
         
         UPDATE Employee         
         SET 
            EmployeeName = @EmployeeName, 
            Department = @Department, 
            Gender = @Gender,
            Salary = @Salary,
            StartDate = @StartDate,
            Notes = @Notes
         WHERE EmployeeId = @EmployeeId;
         
         COMMIT TRANSACTION;
      END
      ELSE
      BEGIN
         Print('Start Date should be greater than today.');
      END
   END TRY
   BEGIN CATCH
      ROLLBACK TRANSACTION;
      DECLARE @ErrorMessage NVARCHAR(MAX);
      DECLARE @ErrorNumber INT;

      SET @ErrorMessage = ERROR_MESSAGE();
      SET @ErrorNumber = ERROR_NUMBER();

       PRINT 'Error: ' + @ErrorMessage;

       THROW;
   END CATCH;
END;
