ALTER PROC get_MakeupRoom
@MakeRoomArea varchar(50) = null
AS
BEGIN
	DECLARE @filter varchar(50)
	IF @MakeRoomArea is NULL
		SET @filter = '%%'
	ELSE
		SET @filter = @MakeRoomArea + '%'
	SELECT m.* , s.SetName
	FROM MakeupRoomMaster m 
	INNER JOIN SetMaster s ON m.SetId = s.setId
	WHERE MakeupRoomArea LIKE @filter
END
GO

CREATE PROC get_MakeupRoomArea
AS
BEGIN
	SELECT makeupRoomId,  MakeupRoomArea
	FROM MakeupRoomMaster m 
	inner join (select min(MakeuproomId) k from MakeupRoomMaster group by MakeupRoomArea) m1
	on m1.k = m.MakeupRoomId
	order by 1
END
GO
CREATE PROC get_MakeupRoomData
@MakeupRoomId int
AS
BEGIN
	SELECT * FROM MakeupRoomMaster WHERE MakeupRoomId = @MakeupRoomId
END
