alter table ElectricityMeterMaster add MultiplyingFactor numeric(7, 2);

alter table MakeupRoomMaster add active tinyint;
GO
CREATE Procedure save_ElecMeterMaster
@SetMeterID int,
@SetID int,
@MeterName varchar(50),
@MeterNo varchar(25),
@factor numeric(7,2),
@StartReading numeric(9),
@isMakeupRoom tinyint,
@isActive tinyint,
@ToDate varchar(100),
@FromDate varchar(100),
@CreatedBy int
AS
BEGIN
If(@SetMeterID = 0)
BEGIN
	insert into ElectricityMeterMaster(SetID,MeterName,MeterNo,StartReading,isMakeupRoom,isActive,FromDate,ToDate,CreatedBy,CreatedOn,MultiplyingFactor)
	values(@SetID,@MeterName,@MeterNo,@StartReading,@isMakeupRoom,@isActive,@FromDate,@ToDate,@CreatedBy,SYSDATETIME(),@factor);
END
ELSE
BEGIN
	update ElectricityMeterMaster set
	SetID=@SetID,MeterName=@MeterName,MeterNo=@MeterNo,StartReading=@StartReading,isMakeupRoom=@isMakeupRoom,isActive=@isActive
	,FromDate=@FromDate,ToDate=@ToDate,ModifiedBy=@CreatedBy,ModifiedOn=SYSDATETIME(),MultiplyingFactor=@factor
	where SetMeterID=@SetMeterID;
END
END;




GO
ALTER procedure save_MakeupRoomMaster
@MakeupRoomId int,
@MakeupRoomNo varchar(4),
@MakeupRoomArea varchar(25),
@SetId int,
@FromDate varchar(100),
@LastDate varchar(100),
@CreatedBy int,
@active tinyint = 1
AS
BEGIN
If (@MakeupRoomId=0)
BEGIN
/*
WHILE 
BEGIN
   
END
*/
	insert into MakeupRoomMaster(MakeupRoomNo,MakeupRoomArea,SetId,FromDate,LastDate,CreatedBy,CreatedOn,active)
	values(@MakeupRoomNo,@MakeupRoomArea,@SetId,@FromDate,NULL,@CreatedBy,SYSDATETIME(),@active);
END
Else
BEGIN
	update MakeupRoomMaster set MakeupRoomNo=@MakeupRoomNo
	,SetId=@SetId
	,FromDate=@FromDate
	,LastDate=@LastDate
	,ModifiedBy=@CreatedBy
	,ModifiedOn=SYSDATETIME()
	,active=@active
	where MakeupRoomId=MakeupRoomId;
END
END