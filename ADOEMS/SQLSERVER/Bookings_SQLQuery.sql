use EMS;

--creating bookigs table
CREATE table BOOKINGS
(
booking_id int IDENTITY(3000,1) PRIMARY KEY NOT NULL,
event_id int FOREIGN KEY REFERENCES EVENTS(event_id),
user_id int FOREIGN KEY REFERENCES USERS(user_id),
booking_date DATETIME NOT NULL,
payment_status varchar(100) NOT NULL
);

--table description
exec sp_help bookings

--retriving all bookings  from nookings table
CREATE PROCEDURE sp_getall_bookings
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.BOOKINGS
END  
GO  


--executing sp_getall_bookings
exec sp_getall_bookings

--inserting bookings values
CREATE PROCEDURE sp_insert_bookings
@eventid int,@userid int,@bookingdate Datetime,@pstatus varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.BOOKINGS
     VALUES
           (@eventid,@userid,@bookingdate,@pstatus)
END
GO

--get booking by bookingid

CREATE PROCEDURE sp_getbyid_bookings
@bookingid int
AS  
BEGIN
    SET NOCOUNT ON;   
    Select * from dbo.BOOKINGS where booking_id = @bookingid 
END  
GO 


--updateevent wallet value
CREATE PROCEDURE sp_updatepaystatus_bookings
@paystatus varchar(100),@bookingid int
AS
BEGIN
	SET NOCOUNT ON;
	update dbo.BOOKINGS set payment_status = @paystatus where booking_id = @bookingid
END
GO

--deleting bookings
CREATE PROCEDURE sp_delete_boookings
@bookingid int
AS
BEGIN
	SET NOCOUNT ON;
	delete from dbo.BOOKINGS where booking_id = @bookingid
END
GO