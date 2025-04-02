-- DROP TABLE ElectricityMeterMaster
CREATE TABLE ElectricityMeterMaster
(SetMeterID int identity(1,1 )
, SetID int 
, MeterName varchar(50) not null
, MeterNo varchar(25) 
, StartReading numeric(12, 0)
, isMakeupRoom tinyint
, isActive int
, FromDate date
, ToDate date
, CreatedBy int
, CreatedOn datetime
, ModifiedBy int
, ModifiedOn datetime
)
go
ALTER PROC get_ElecMeters
AS
SELECT e.*, isnull(s.SetName,'')SetName FROM ElectricityMeterMaster e
LEFT JOIN SetMAster s ON e.SetID = s.setId
WHERE e.isActive =1

/*
InSERT INTO ElectricityMeterMaster values (Null, 'Hospital LT With Makeup Room 201,202 & 203', NULL, 1100, 1, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Hospital Out Door', NULL, 1110, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Bungalow 1 LT', NULL, 1200, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Bungalow 1 Out Door', NULL, 1210, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Office Set', NULL, 1300, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Police Station', NULL, 1400, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, '8000 sqft', NULL, 1500, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Restaurant', NULL, 1600, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Parsi Bungalow AC', NULL, 1700, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Parsi Bungalow Light', NULL, 1710, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Bungalow 2 LT', NULL, 1800, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Bungalow 2 Makeup Room', NULL, 1900, 1, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Villa Set AC', NULL, 2000, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Villa Set Light', NULL, 2010, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Villa Set Out Door', NULL, 2020, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Road Light', NULL, 2100, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Hill', NULL, 2200, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Makeup Room 204 - 206', NULL, 2300, 1, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Make up room 11-14', NULL, 2400, 1, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Old Makeup room Area 1 (4 nos room)', NULL, 2500, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Old Makeup room Area 2 (6 nos room)', NULL, 2510, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Water Pump Area', NULL, 2600, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)
InSERT INTO ElectricityMeterMaster values (Null, 'Ellora Office', NULL, 2700, NULL, 1, '20200101', NULL, 1,NULL, NULL,NULL)

*/
go
CREATE TABLE MakeupRoomMaster
(MakeupRoomId int identity(1, 1)
, MakeupRoomNo varchar(4)
, MakeupRoomArea varchar(25)
, SetId int
, FromDate date
, LastDate date
, CreatedBy int
, CreatedOn datetime
, ModifiedBy int
, ModifiedOn datetime
)
/* P2 */
go
CREATE PROC get_MakeupRoom
AS
BEGIN
	SELECT m.* , s.SetName
	FROM MakeupRoomMaster m INNER JOIN SetMaster s ON m.SetId = s.setId
END
go
CREATE PROC save_MakeupRoom
(
@makeupRoomId int
, @MakeupRoomNo varchar(4)
, @MakeupRoomArea varchar(25)
, @SetId int
, @FromDate date
, @CreatedBy int
)
AS
BEGIN
	IF EXISTS (SELECT makeupRoomId FROM MakeupRoomMaster WHERE MakeupRoomId= @makeupRoomId)
	BEGIN
		UPDATE MakeupRoomMaster SET MakeupRoomArea = @MakeupRoomArea WHERE MakeupRoomId= @makeupRoomId
	END
	ELSE
	BEGIN
		INSERT INTO MakeupRoomMaster 
		 (MakeupRoomNo 
		, MakeupRoomArea 
		, SetId 
		, FromDate 
		, CreatedBy
		, CREATEDOn)
		VALUES (
		 @MakeupRoomNo 
		, @MakeupRoomArea 
		, @SetId 
		, @FromDate 
		, @CreatedBy
		, getdate())
		SET @makeupRoomId = @@IDENTITY 
	END
	SELECT @makeupRoomId MakeupRoomId, 'SUCCESS' MSG
END

/*
exec save_MakeupRoom 0, '201', 'Hospital Location 201 - 203', 2, '20200101', 1
exec save_MakeupRoom 0, '202', 'Hospital Location 201 - 203', 2, '20200101', 1
exec save_MakeupRoom 0, '203', 'Hospital Location 201 - 203', 2, '20200101', 1
exec save_MakeupRoom 0, '204', 'Hospital Location 204 - 206', 2, '20200101', 1
exec save_MakeupRoom 0, '205', 'Hospital Location 204 - 206', 2, '20200101', 1
exec save_MakeupRoom 0, '206', 'Hospital Location 204 - 206', 2, '20200101', 1
exec save_makeupRoom 0, '11', 'Hospital Location 11 - 14', 2, '20200101', 1
exec save_MakeupRoom 0, '12', 'Hospital Location 11 - 14', 2, '20200101', 1
exec save_MakeupRoom 0, '13', 'Hospital Location 11 - 14', 2, '20200101', 1
exec save_MakeupRoom 0, '14', 'Hospital Location 11 - 14', 2, '20200101', 1
exec save_MakeupRoom 0, '301', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '302', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '303', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '304', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '305', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '306', 'Villa (301 - 308)', 8, '20200101',1
exec sav0, '307', 'Villa (301 - 308)', 8, '20200101',1
exec save_MakeupRoom 0, '308', 'Villa (301 - 308)', 8, '20200101',1

exec save_MakeupRoom 0, '601', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '602', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '603', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '604', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '605', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '606', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '607', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '608', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '609', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '610', 'Parsi (601 -611)', 5, '20200101', 1
exec save_MakeupRoom 0, '611', 'Parsi (601 -611)', 5, '20200101', 1

exec save_MakeupRoom 0, '401', '8000 sqft( 401-406)', 13, '20200101', 1
exec save_MakeupRoom 0, '402', '8000 sqft( 401-406)', 13, '20200101', 1
exec save_MakeupRoom 0, '403', '8000 sqft( 401-406)', 13, '20200101', 1
exec save_MakeupRoom 0, '404', '8000 sqft( 401-406)', 13, '20200101', 1
exec save_MakeupRoom 0, '405', '8000 sqft( 401-406)', 13, '20200101', 1
exec save_MakeupRoom 0, '406', '8000 sqft( 401-406)', 13, '20200101', 1

exec save_MakeupRoom 0, '101', 'Restaurant (101 -103)', 9, '20200101', 1
exec save_MakeupRoom 0, '102', 'Restaurant (101 -103)', 9, '20200101', 1
exec save_MakeupRoom 0, '103', 'Restaurant (101 -103)', 9, '20200101', 1

exec save_MakeupRoom 0, '701', 'Bungalow 2', 7, '20200101', 1
exec save_MakeupRoom 0, '702', 'Bungalow 2', 7, '20200101', 1

*/
SELECT * from SetMaster
go
CREATE TABLE MeterReadings
(DailyMeterID int identity(-32000, 1)
, MeterId int
, ScheduleDate date
, FROMUnits INT
, TOUnits int
, TotalUnits int
, BookingPlanId int
, WorkDetails varchar(150)
, CreatedBy int
, CreatedOn datetime
, ModifiedBy int
, ModifiedOn datetime
)

select @@SERVERNAME

update setMaster set SetCalendarId = 'bookingsys.ellora@gmail.com'


select * from GLOBAL_LIST_VALUES

--drop table ElecMeterUsage
CREATE TABLE ElecMeterUsage
(ElecMeterUsageId int identity(1, 1)
, usage_purpose varchar(40)
, usage_parent_id int
, isRevenueHead tinyint
, isActive tinyint
, CreatedBy int
, CreatedOn datetime
, ModifiedBy int
, ModifiedOn datetime
)
select * from ElecMeterUsage
INSERT INTO ElecMeterUsage values ('Shooting', null, 1, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Infra/Maint Work', null, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora HK Team', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora AC Team', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora ELE Team', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora Civil Work', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora Vendor Work', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora Utility Work', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora Reiki Usage', 2, 0, 1, 1, getdate(), null, null)
INSERT INTO ElecMeterUsage values ('Ellora Misc Usage', 2, 0, 1, 1, getdate(), null, null)
GO

ALTER PROC getElecMeterUsage
as
	SELECT ElecMeterUsageId
, usage_purpose
, isnull(usage_parent_id, ElecMeterUsageId) usage_parent_id
, isRevenueHead
FROM ElecMeterUsage WHERE isActive=1 ORDER BY usage_parent_id, ElecMeterUsageId
GO

CREATE TABLE ElecMeterReading
(ElecMeterReadingId int identity(-32000, 1)
, ReadingDate datetime
, SetMeterID int
, ElecMeterUsageId int
, BookingPlanId int
, ShiftTime date
, FromReading numeric(12, 0)
, ToReading numeric(12, 0)
, ReadingUnits int
, AdjustUnits int
, TotalUnits int
, Remarks nvarchar(250)
, isBilled tinyint
, BillID int
, CreatedBy int
, CreatedOn datetime
, ModifiedBy int
, ModifiedOn Datetime
)

GO
--- getElecMeterReading '20210901'
ALTER PROC getElecMeterReading
@ReadingDate date
as
BEGIN
	SELECT e.SetMeterID
	, e.SetID
	, e.MeterName
	, e.MeterNo
	, e.StartReading
	, e.isMakeupRoom
	, r.ElecMeterReadingId
	, r.SetMeterID
	, r.ElecMeterUsageId
	, r.BookingPlanId
	, r.ShiftTime
	, r.ElecMeterUsageId
	, r.usage_purpose
	, ISNULL(r.FromReading, e.StartReading) FromReading
	, r.ToReading
	, r.ReadingUnits
	, r.AdjustUnits
	, r.TotalUnits
	, r.Remarks
	, r.isBilled
	, r.BillID
	FROM ElectricityMeterMaster e
	LEFT JOIN (SELECT r1.*, u.usage_purpose FROM ElecMeterReading r1
	INNER JOIN ElecMeterUsage u on r1.ElecMeterUsageId = u.ElecMeterUsageId
	 WHERE ReadingDate = @REadingDate) r
	 on e.SetMeterID = r.SetMeterID
END 
