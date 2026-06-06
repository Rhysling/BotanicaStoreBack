CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE "Calendar" (
	"ItemId"	INTEGER NOT NULL,
	"BeginDate"	TEXT NOT NULL,
	"EndDate"	TEXT,
	"EventTime"	TEXT,
	"Title"	TEXT NOT NULL,
	"Location"	TEXT,
	"Description"	TEXT,
	"IsSpecial"	INTEGER NOT NULL DEFAULT 0,
	"BeginDateStr"	TEXT,
	"EndDateStr"	TEXT,
	PRIMARY KEY("ItemId")
);
CREATE TABLE "Plants" (
	"PlantId"	INTEGER,
	"Genus"	TEXT NOT NULL,
	"Species"	TEXT NOT NULL,
	"Family"	TEXT,
	"Description"	TEXT,
	"Notes"	TEXT,
	"PlantSize"	TEXT,
	"PlantType"	TEXT,
	"PlantZone"	TEXT,
	"PictureLocation"	TEXT,
	"IsNwNative"	INTEGER NOT NULL DEFAULT 0,
	"Pics"	TEXT NOT NULL DEFAULT '[]',
	"IsListed"	INTEGER NOT NULL DEFAULT 0,
	"IsFeatured"	INTEGER NOT NULL DEFAULT 0,
	"Slug"	TEXT NOT NULL DEFAULT '',
	"LastUpdate"	TEXT NOT NULL,
	"Flag"	TEXT,
	"IsDeleted"	INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY("PlantId")
);
CREATE TABLE Keys(
	KeyName TEXT NOT NULL,
	KeyValue TEXT NULL,

 PRIMARY KEY("KeyName") 
);
CREATE TABLE Links(
	LinkId INTEGER NOT NULL,
	Title TEXT NOT NULL,
	Description TEXT NOT NULL,
	Url TEXT NOT NULL,
	SortOrder INTEGER NOT NULL,
	IsDeleted INTEGER NOT NULL DEFAULT 0,

 PRIMARY KEY("LinkId") 
);
CREATE TABLE PlantPrices(
	PlantId INTEGER NOT NULL,
	PotSizeId INTEGER NOT NULL,
	Price REAL NOT NULL,
	IsAvailable INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY("PlantId","PotSizeId") 
);
CREATE TABLE PlantStatusEnum(
	Id INTEGER NOT NULL,
	Name TEXT NOT NULL,
	Description TEXT NULL,
	PRIMARY KEY("Id") 
);
CREATE TABLE PotSizes(
	Id INTEGER NOT NULL,
	PotDescription TEXT NOT NULL,
	PotShorthand TEXT NOT NULL,
	SortOrder INTEGER NOT NULL,
	PRIMARY KEY("Id") 
);
CREATE TABLE ResourceIcons(
	FileType TEXT NOT NULL,
	IconGroup INTEGER NOT NULL,
	PRIMARY KEY("FileType") 
);
CREATE TABLE ResourceItems(
	ItemId INTEGER NOT NULL,
	KeyString TEXT NULL,
	Description TEXT NULL,
	FileName TEXT NULL,
	FileType TEXT NULL,
	FileData BLOB NULL,
	FileDataByteLength INTEGER NULL,
	FileSize TEXT NULL,
	IconGroup INTEGER NULL,
	LastUpdate TEXT NULL,
	UpdatedBy INTEGER NULL,
	IsDeleted INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY("ItemId") 
);
CREATE TABLE Subscribers(
	ItemId INTEGER NOT NULL,
	FirstName TEXT NULL,
	LastName TEXT NULL,
	ExtraName TEXT NULL,
	Email TEXT NULL,
	Address1 TEXT NULL,
	Address2 TEXT NULL,
	City TEXT NULL,
	State TEXT NULL,
	ZipCode TEXT NULL,
	SendNotices INTEGER NOT NULL DEFAULT 0,
	MailCalendar INTEGER NOT NULL DEFAULT 0,
	IsDeleted INTEGER NOT NULL DEFAULT 0,
	Notes TEXT NULL,
	AddedDate TEXT NULL,
	LastUpdate TEXT NULL,
	PRIMARY KEY("ItemId") 
);
CREATE TABLE Users(
	UserId INTEGER NOT NULL,
	Email TEXT NOT NULL,
	FullName TEXT NULL,
	IsAdmin INTEGER NOT NULL DEFAULT 0,
	CreatedDate TEXT NOT NULL,
	LastLoginDate TEXT NOT NULL,
	LoginCount INTEGER NOT NULL,
	PRIMARY KEY("UserId") 
);
CREATE TABLE WishListItems(
	WlId INTEGER NOT NULL,
	PlantId INTEGER NOT NULL,
	PotSizeId INTEGER NOT NULL,
	Price REAL NOT NULL,
	Qty INTEGER NOT NULL,
	PRIMARY KEY("WlId","PlantId","PotSizeId") 
);
CREATE TABLE WishLists(
	WlId INTEGER NOT NULL,
	UserId INTEGER NOT NULL,
	CreatedDate TEXT NOT NULL,
	LastUpdateDate TEXT NOT NULL,
	EmailedDate TEXT NULL,
	IsClosed INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY("WlId") 
);
CREATE VIEW vwFlagSummary
AS

SELECT
	Flag,
	COUNT(PlantId) AS PlantCount,
	MAX(LastUpdate) AS LastUpdate

FROM
	Plants

WHERE
	(Flag is not null) AND (IsDeleted = 0)

GROUP BY
	Flag
/* vwFlagSummary(Flag,PlantCount,LastUpdate) */;
CREATE VIEW vwUserDetails
AS
SELECT
	u.UserId,
	u.Email,
	u.FullName,
	u.IsAdmin,
	u.CreatedDate,
	u.LastLoginDate,
	u.LoginCount,
	coalesce(w.CountAll, 0) AS CountAll,
	coalesce(w.CountPending, 0) AS CountPending,
	coalesce(w.CountClosed, 0) AS CountClosed

FROM
	Users u

	LEFT OUTER JOIN
	(
		SELECT
			UserId,
			sum(1) AS CountAll,
			sum(CASE WHEN EmailedDate is null THEN 1 ELSE 0 END) AS CountPending,
			sum(CASE WHEN IsClosed = 1 THEN 1 ELSE 0 END) AS CountClosed
		FROM
			WishLists
		GROUP BY
			UserId
	) w
	ON (u.UserId = w.UserId)
/* vwUserDetails(UserId,Email,FullName,IsAdmin,CreatedDate,LastLoginDate,LoginCount,CountAll,CountPending,CountClosed) */;
