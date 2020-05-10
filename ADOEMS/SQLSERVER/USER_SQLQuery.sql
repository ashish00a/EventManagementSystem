use EMS;

select DB_NAME()
GO


--creating users table
CREATE TABLE USERS
( 
user_id int IDENTITY(1000,1) PRIMARY KEY NOT NULL,
user_name varchar(100) NOT NULL,
gender varchar(100) NOT NULL check (gender IN ('MALE','FEMALE','OTHERS')),
mobile varchar(10) NOT NULL check (mobile like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
email varchar(320) NOT NULL,
user_type varchar(100) NOT NULL check (user_type IN ('ADMIN','MANAGER','CONSULTANT','CUSTOMER')),
user_login_name varchar(100) NOT NULL,
user_login_password varchar(100) NOT NULL,
);

--table description
exec sp_help users;
--retriving all users  from users table
CREATE PROCEDURE sp_getall_users
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.USERS
END  
GO  
--executing sp_getall_users
exec sp_getall_users

--admin inserting user values
CREATE PROCEDURE sp_admininsert_users
@username varchar(100),@gender varchar(50),@mobile varchar(10),@email varchar(100),
@usertype varchar(100),@userlname varchar(100),@userlpassword varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.USERS
     VALUES
           (@username,@gender,@mobile,@email,@usertype,@userlname,@userlpassword)
END
GO


--get user by userid

CREATE PROCEDURE sp_getbyid_users
@userid int
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.USERS where user_id = @userid 
END  
GO  


--update user values
CREATE PROCEDURE sp_update_users
@username varchar(100),@gender varchar(50),@mobile varchar(10),@email varchar(100),
@usertype varchar(100),@userlname varchar(100),@userlpassword varchar(100),@userid int
AS
BEGIN
	SET NOCOUNT ON;
	update dbo.USERS set user_name = @username, gender = @gender, mobile = @mobile, email = @email, user_type = @usertype,user_login_name =@userlname,
	user_login_password =@userlpassword where user_id = @userid
END
GO



--deeleting user
CREATE PROCEDURE sp_delete_users
@userid int
AS
BEGIN
	SET NOCOUNT ON;
	delete from dbo.USERS where user_id = @userid
END
GO




