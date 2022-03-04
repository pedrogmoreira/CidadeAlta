IF ((SELECT COUNT(Id) FROM dbo.Users) = 0)
BEGIN
	INSERT INTO dbo.Users ("UserName", "Password") VALUES('admin', '0192023a7bbd73250516f069df18b500')
END
