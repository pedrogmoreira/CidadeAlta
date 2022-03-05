IF ((SELECT COUNT(*) FROM dbo.Users) = 0)
BEGIN
	INSERT INTO dbo.Users ("UserName", "Password") 
		VALUES('user', '81dc9bdb52d04dc20036dbd8313ed055')
END

IF ((SELECT COUNT(*) FROM dbo.Statuses) = 0)
BEGIN
	INSERT INTO dbo.Statuses ("Name") 
		VALUES('Ativo'), 
		('Inativo')
END

IF ((SELECT COUNT(*) FROM dbo.CriminalCodes) = 0)
BEGIN
	INSERT INTO dbo.CriminalCodes ("Name", "Description", "Penalty", "PrisionTime", "StatusId", "CreateUserId") 
		VALUES('Criminal 001', 'desc xxx1', 72.0123, 10, 1, 1),
		('Criminal 002', 'desc xxx2', 451.0, 41, 1, 1), 
		('Criminal 003', 'desc xxx3', 54.0, 68, 1, 1), 
		('Criminal 004', 'desc xxx4', 12.0, 89, 1, 1), 
		('Criminal 005', 'desc xxx5', 874.0, 88, 1, 1), 
		('Criminal 006', 'desc xxx6', 87.0, 62, 1, 1),
		('Criminal 007', 'desc xxx7', 5.0, 515, 1, 1),
		('Criminal 008', 'desc xxx8', 65.0, 31, 1, 1),
		('Criminal 009', 'desc xxx9', 122.0, 7671, 1, 1),
		('Criminal 010', 'desc xxx10', 55.0, 78, 1, 1),
		('Criminal 011', 'desc xxx11', 63.0, 74, 1, 1),
		('Criminal 012', 'desc xxx12', 72.01, 58, 1, 1),
		('Criminal 013', 'desc xxx13', 73.0, 98, 1, 1),
		('Criminal 014', 'desc xxx14', 77.0, 662, 1, 1),
		('Criminal 015', 'desc xxx15', 21.0, 127, 1, 1), 
		('Criminal 016', 'desc xxx16', 743.0, 6, 1, 1),
		('Criminal 017', 'desc xxx17', 772.0, 5, 1, 1),
		('Criminal 018', 'desc xxx18', 777.0, 1, 1, 1),
		('Criminal 019', 'desc xxx19', 763.0, 12, 1, 1), 
		('Criminal 020', 'desc xxx20', 342.0, 512, 1, 1);
END