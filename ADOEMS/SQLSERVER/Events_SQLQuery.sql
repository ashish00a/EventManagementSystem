use EMS;
--creating events table
CREATE table EVENTS
(
event_id int IDENTITY(2000,1) PRIMARY KEY NOT NULL,
event_name varchar(100) NOT NULL,
event_type varchar(100) NOT NULL,
event_price int NOT NULL,
event_consultant_price int NOT NULL,
event_managment_price int NOT NULL,
event_wallet int NOT NULL
);


--table description
exec sp_help events

--retriving all events  from events table
CREATE PROCEDURE sp_getall_events
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.EVENTS
END  
GO  


--executing sp_getall_events
exec sp_getall_events

--admin inserting events values
CREATE PROCEDURE sp_insert_events
@eventname varchar(100),@eventtype varchar(50),@eventprice int,@ecprice int,
@emprice varchar(100),@ewallet int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.EVENTS
     VALUES
           (@eventname,@eventtype,@eventprice,@ecprice,@emprice,@ewallet)
END
GO

--get user by eventid

CREATE PROCEDURE sp_getbyid_events
@eventid int
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.EVENTS where event_id = @eventid 
END  
GO 

--updateevent wallet value
CREATE PROCEDURE sp_updatewallet_events
@ewallet int,@eventid int
AS
BEGIN
	SET NOCOUNT ON;
	update dbo.EVENTS set event_wallet = event_wallet + @ewallet where event_id = @eventid
END
GO

--deleting events
CREATE PROCEDURE sp_delete_events
@eventid int
AS
BEGIN
	SET NOCOUNT ON;
	delete from dbo.EVENTS where event_id = @eventid
END
GO