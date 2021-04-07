CREATE PROCEDURE [dbo].[Plants_ClearAllFlags]
	
AS

UPDATE
	Plants
SET
	Flag = NULL