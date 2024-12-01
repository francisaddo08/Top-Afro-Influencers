
   -- Create a new table called '[Admin]' in schema '[dbo]'
   -- Drop the table if it already exists
   IF OBJECT_ID('[dbo].[Admin]', 'U') IS NOT NULL
   DROP TABLE [dbo].[Admin]
   GO
   -- Create the table in the specified schema
   CREATE TABLE [dbo].[Admin]
   (
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
     [Password] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL UNIQUE
    -- Specify more columns here
   );
   GO