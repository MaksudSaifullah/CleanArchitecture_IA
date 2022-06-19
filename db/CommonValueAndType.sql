--EMAILTYPE
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='EMAILTYPE' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'EMAILTYPE',NULL,1,'Commencement Letter (Branch Audit)',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='EMAILTYPE' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'EMAILTYPE',NULL,2,'Commencement Letter (Process & Control Audit)',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='EMAILTYPE' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'EMAILTYPE',NULL,3,'ToR',30)
END

--LEVELOFLIKELIHOOD
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFLIKELIHOOD' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFLIKELIHOOD',NULL,1,'Almost Certain',10)
END

IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFLIKELIHOOD' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFLIKELIHOOD',NULL,2,'Likely',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFLIKELIHOOD' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFLIKELIHOOD',NULL,3,'Moderate',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFLIKELIHOOD' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFLIKELIHOOD',NULL,4,'Unlikely',40)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFLIKELIHOOD' AND [Value]= 5 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFLIKELIHOOD',NULL,5,'Rare',50)
END




--LEVELOFIMPACT
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFIMPACT' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFIMPACT',NULL,1,'Insignificant',10)
END

IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFIMPACT' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFIMPACT',NULL,2,'Minor',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFIMPACT' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFIMPACT',NULL,3,'Moderate',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LEVELOFIMPACT' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LEVELOFIMPACT',NULL,4,'Major',40)
END



--RISKRATING
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATING' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATING',NULL,1,'High',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATING' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATING',NULL,2,'Low',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATING' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATING',NULL,3,'Moderate',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATING' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATING',NULL,4,'Significant',40)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATING' AND [Value]= 5 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATING',NULL,5,'Extreme',50)
END



--RISKRATINGNAME
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATINGNAME' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATINGNAME',NULL,1,'Overdue',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATINGNAME' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATINGNAME',NULL,2,'Collection',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='RISKRATINGNAME' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'RISKRATINGNAME',NULL,3,'Disbursement',30)
END


--LOPRODUCTIVITY
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LOPRODUCTIVITY' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LOPRODUCTIVITY',NULL,1,'Not Available',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LOPRODUCTIVITY' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LOPRODUCTIVITY',NULL,2,'Strong',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LOPRODUCTIVITY' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LOPRODUCTIVITY',NULL,3,'Good',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='LOPRODUCTIVITY' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'LOPRODUCTIVITY',NULL,4,'Bad',40)
END


--YEAR
DECLARE @i int = 1,
        @year int =YEAR(GETDATE()) -2
WHILE @i < 10 
BEGIN
    IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='YEAR' AND [Value]= @i )
    BEGIN
      INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
    VALUES('admin', GETDATE(), 'YEAR', NULL, @i, @year, @i*10)
    END
	SET @i = @i + 1
END

--SAMPLEDMONTH
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,1,'January',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,2,'February',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,3,'March',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,4,'April',40)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 5 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,5,'May',50)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 6 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,6,'June',60)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 7 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,7,'July',70)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 8 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,8,'August',80)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 9 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,9,'September',90)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 10 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,10,'October',100)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 11 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,11,'November',110)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLEDMONTH' AND [Value]= 12 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLEDMONTH',NULL,12,'December',120)
END


--SAMPLESELECTIONMETHOD 
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLESELECTIONMETHOD' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLESELECTIONMETHOD',NULL,1,'Random',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLESELECTIONMETHOD' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLESELECTIONMETHOD',NULL,2,'Judgmental',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='SAMPLESELECTIONMETHOD' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'SAMPLESELECTIONMETHOD',NULL,3,'Haphazard',30)
END


--NATUREOFCONTROLACTIVITY
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='NATUREOFCONTROLACTIVITY' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'NATUREOFCONTROLACTIVITY',NULL,1,'Cyclic Controls',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='NATUREOFCONTROLACTIVITY' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'NATUREOFCONTROLACTIVITY',NULL,2,'Ad Hoc Controls',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='NATUREOFCONTROLACTIVITY' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'NATUREOFCONTROLACTIVITY',NULL,3,'Automated Controls',30)
END




--CONTROLFREQUENCY 
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,1,'Annually',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,2,'quarterly',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,3,'monthly',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,4,'weekly',40)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 5 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,5,'daily',50)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 6 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',1,6,'multiple times per day',60)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 7 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',2,7,'1 to 4',70)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 8 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',2,8,'5 to 12',80)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 9 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',2,9,'13 to 52',90)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 10 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',2,10,'53 to 260',100)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='CONTROLFREQUENCY' AND [Value]= 11 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'CONTROLFREQUENCY',2,11,'greater than 260',110)
END





--ISSUESTATUS
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='ISSUESTATUS' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'ISSUESTATUS',NULL,1,'Pending Validation',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='ISSUESTATUS' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'ISSUESTATUS',NULL,2,'Open',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='ISSUESTATUS' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'ISSUESTATUS',NULL,3,'Closed',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='ISSUESTATUS' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'ISSUESTATUS',NULL,4,'Closed & Validated',40)
END



--AUDITCONDUCTED
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='AUDITCONDUCTED' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'AUDITCONDUCTED',NULL,1,'Quarter-1',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='AUDITCONDUCTED' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'AUDITCONDUCTED',NULL,2,'Quarter-2',20)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='AUDITCONDUCTED' AND [Value]= 3 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'AUDITCONDUCTED',NULL,3,'Quarter-3',30)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='AUDITCONDUCTED' AND [Value]= 4 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'AUDITCONDUCTED',NULL,4,'Quarter-4',40)
END


--DETESTCONCLUSION
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='DETESTCONCLUSION' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'DETESTCONCLUSION',NULL,1,'Pass',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='DETESTCONCLUSION' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'DETESTCONCLUSION',NULL,2,'Fail',20)
END



--YESNO
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='YESNO' AND [Value]= 1 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'YESNO',NULL,1,'Yes',10)
END
IF NOT EXISTS (SELECT * FROM CommonValueAndType WHERE [Type] ='YESNO' AND [Value]= 2 )
BEGIN
  INSERT INTO CommonValueAndType(CreatedBy,CreatedOn,[Type],SubType,[Value],[Text],SortOrder) 
  VALUES('admin', GETDATE(),'YESNO',NULL,2,'No',20)
END



