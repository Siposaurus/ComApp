CREATE PROCEDURE [dbo].[sp_InsertData]
	@Ime varchar(255),
	@Prezime varchar(255),
	@PostanskiBroj varchar(255),
	@Grad varchar(255),
	@Telefon varchar(255)
AS
DECLARE @ErrorMessage nvarchar(255)
BEGIN
	SET NOCOUNT ON;

	IF ISNUMERIC(@PostanskiBroj) = 0 BEGIN
		SET @ErrorMessage = 'Postanski broj mora biti broj'
		RAISERROR(@ErrorMessage, 10, 1) WITH LOG
	END
	
	ELSE IF EXISTS (SELECT * FROM ComAppDatabase.dbo.ComData WHERE Ime=@Ime AND prezime=@Prezime AND PostanskiBroj=@PostanskiBroj AND Grad=@Grad AND Telefon=@Telefon) BEGIN
		SET @ErrorMessage = 'Podaci nisu jedinstveni'
		RAISERROR(@ErrorMessage, 10, 1) WITH LOG
	END

	ELSE BEGIN
		INSERT INTO ComAppDatabase.dbo.ComData(Ime, Prezime, PostanskiBroj, Grad, Telefon)
		VALUES (@Ime, @Prezime, @PostanskiBroj, @Grad, @Telefon)
	END

END