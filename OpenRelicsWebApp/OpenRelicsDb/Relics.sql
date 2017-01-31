CREATE TABLE [dbo].[Relics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [State] NVARCHAR(MAX) NULL, 
    [RegisterNumber] NVARCHAR(MAX) NULL, 
    [Dating] NVARCHAR(MAX) NULL, 
    [Latitude] INT NOT NULL, 
    [Longitude] INT NOT NULL, 
    [ PlaceId] INT NOT NULL, 
    [PlaceName] NVARCHAR(MAX) NOT NULL, 
    [CommuneName] NVARCHAR(MAX) NOT NULL, 
    [DistrictName] NVARCHAR(MAX) NOT NULL, 
    [VoivodeshipName] NVARCHAR(MAX) NOT NULL
)
