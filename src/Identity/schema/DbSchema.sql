CREATE TABLE IF NOT EXISTS ApplicationUser(
    Id                      INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    UserName                VARCHAR(255) NOT NULL,
    NormalizedUserName      VARCHAR(255) NOT NULL,
    Email                   VARCHAR(255) NOT NULL,
    NormalizedEmail         VARCHAR(255) NOT NULL,
    EmailConfirmed          BIT NOT NULL,
    PasswordHash            VARCHAR(255) NULL,
    PhoneNumber             VARCHAR(50) NULL,
    PhoneNumberConfirmed    BIT NOT NULL,
    TwoFactorEnabled        BIT NOT NULL
);

CREATE TABLE IF NOT EXISTS ApplicationRole(
    Id              INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    [Name]          VARCHAR(255) NOT NULL,
    NormalizedName  VARCHAR(255) NOT NULL
);
