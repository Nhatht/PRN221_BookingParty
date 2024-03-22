--Create database BookingParty;
Use BookingParty
CREATE TABLE "FeedBack"(
    "Id" INT NOT NULL identity(1,1) ,
    "GuestId" INT NOT NULL,
    "PartyId" INT NOT NULL,
    "Comment" NVARCHAR(255) NOT NULL,
    "ReviewDate" DATETIME NOT NULL
);
ALTER TABLE
    "FeedBack" ADD CONSTRAINT "feedback_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Accounts"(
    "id" INT NOT NULL identity(1,1),
    "Email" NVARCHAR(255) NOT NULL,
    "Password" NVARCHAR(255) NOT NULL,
    "UserName" NVARCHAR(255) NOT NULL,
    "Phone" NVARCHAR(255),
    "Gender" NVARCHAR(255),
    "Role" NVARCHAR(255),
    "Status" BIT NOT NULL
);
ALTER TABLE
    "Accounts" ADD CONSTRAINT "accounts_id_primary" PRIMARY KEY("id");
CREATE TABLE "BlogPost"(
    "Id" INT NOT NULL identity(1,1),
    "Account_Id" INT NOT NULL,
    "Heading" NVARCHAR(255) NOT NULL,
    "PageTitle" NVARCHAR(255) NOT NULL,
    "Content" NVARCHAR(255) NOT NULL,
    "Short_Description" NVARCHAR(255) NOT NULL,
    "ImageUrl" NVARCHAR(255) NOT NULL,
    "PublishedDate" DATETIME NOT NULL,
    "Visible" BIT NOT NULL
);
ALTER TABLE
    "BlogPost" ADD CONSTRAINT "blogpost_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Booking"(
    "Id" INT NOT NULL identity(1,1),
    "GuestId" INT NOT NULL,
    "PartyId" INT NOT NULL,
    "TotalPrice" DECIMAL(8, 2) NOT NULL,
    "NumberOfPeople" INT NOT NULL,
    "Inquiry" NVARCHAR(255),
    "StartDate" DATETIME NOT NULL,
    "Status" BIT NOT NULL
);
ALTER TABLE
    "Booking" ADD CONSTRAINT "booking_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Party"(
    "Id" INT NOT NULL identity(1,1),
    "HostId" INT NOT NULL,
    "Description" NVARCHAR(255),
    "Name" NVARCHAR(255) NOT NULL,
    "City" NVARCHAR(255) NOT NULL,
    "Price" DECIMAL(8, 2) NOT NULL,
    "Theme" NVARCHAR(255),
    "Package" NVARCHAR(255),
    "Max_People" INT NOT NULL,
    "Image_Url" VARCHAR(255) NOT NULL,
    "Request" INT NOT NULL DEFAULT '0',
    "Status" BIT NOT NULL
);
ALTER TABLE
    "Party" ADD CONSTRAINT "party_id_primary" PRIMARY KEY("Id");
ALTER TABLE
    "Booking" ADD CONSTRAINT "booking_gusetid_foreign" FOREIGN KEY("GuestId") REFERENCES "Accounts"("id");
ALTER TABLE
    "Booking" ADD CONSTRAINT "booking_partyid_foreign" FOREIGN KEY("PartyId") REFERENCES "Party"("Id");
ALTER TABLE
    "FeedBack" ADD CONSTRAINT "feedback_guestid_foreign" FOREIGN KEY("GuestId") REFERENCES "Accounts"("id");
ALTER TABLE
    "Party" ADD CONSTRAINT "party_hostid_foreign" FOREIGN KEY("HostID") REFERENCES "Accounts"("id");
ALTER TABLE
    "BlogPost" ADD CONSTRAINT "blogpost_account_id_foreign" FOREIGN KEY("Account_Id") REFERENCES "Accounts"("id");
ALTER TABLE
    "FeedBack" ADD CONSTRAINT "feedback_partyid_foreign" FOREIGN KEY("PartyId") REFERENCES "Party"("Id");