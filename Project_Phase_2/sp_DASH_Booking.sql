create proc DASH_BookingView
@FromDate datetime
as
BEGIN
	SELECT 
	BookingPlanId
, convert(varchar(10), BookingDate, 103) BookingDate
,convert(varchar(10), BookingFromDate, 103) BookingFromDate
,convert(varchar(10), BookingToDate, 103) BookingToDate
,bp.SetId
, bp.SetName + '(' + sm.SetCode + ')'SetName
,CategoryId
,CategoryName
,ShiftTime
,datediff(d, @FromDate,  BookingToDate)+1  TotalShifts
,CustomerId
,CustomerName
,CustomerAlias
,RefNo
,Remarks
,Instructions
,isBooked
,BookingStatus
,list_text
,EnquiryContactPerson
,EnquiryContactDesg
,EnquiryContactPhone 
	from vu_BookingPlan bp
	INNER JOIN SetMaster sm on bp.SetId = sm.setId 
	where @FromDate between BookingFromDate AND BookingToDate
	and BookingStatus >0
	ORDER BY SetId
END