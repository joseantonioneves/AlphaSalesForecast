-- Create AppPortifolio table
CREATE TABLE AppPortifolio (
    AppId BIGINT PRIMARY KEY, 
    ApplicationName NVARCHAR(150), 
    IsActive BIT
);
GO

-- Create BillModel table
CREATE TABLE BillModel (
    BillId BIGINT PRIMARY KEY, 
    Tipo NVARCHAR(3), 
    UrlAPI NVARCHAR(255)
);
GO

-- Extended property for BillModel
EXEC sp_addextendedproperty 'MS_Description', 'Tipo do meio de pagamento...', 'SCHEMA', 'dbo', 'TABLE', 'BillModel', 'COLUMN', 'Tipo';
GO

-- Create CityModel table
CREATE TABLE CityModel (
    CityId BIGINT PRIMARY KEY, 
    Name NVARCHAR(50), 
    IBGE NVARCHAR(7), 
    StateModel_StateId BIGINT NOT NULL
);
GO

-- Create CountryModel table
CREATE TABLE CountryModel (
    CountryId BIGINT PRIMARY KEY, 
    Name NVARCHAR(100), 
    Codigo NVARCHAR(3), 
    Fone NVARCHAR(4), 
    ISO NVARCHAR(2), 
    ISO3 NVARCHAR(3), 
    NomeFormal NVARCHAR(150)
);
GO

-- Create EnrollmentModel table
CREATE TABLE EnrollmentModel (
    EnrollmentId BIGINT NOT NULL, 
    AppPortifolio_AppId BIGINT NOT NULL, 
    SignatureModel_SignatureId BIGINT NOT NULL, 
    UserModel_UserId BIGINT NOT NULL,
    PRIMARY KEY (EnrollmentId, UserModel_UserId)
);
GO

-- Create OrganizationModel table
CREATE TABLE OrganizationModel (
    OrganizationId BIGINT NOT NULL, 
    Razao NVARCHAR(250), 
    CNPJ NVARCHAR(15) NOT NULL, 
    IsActive BIT, 
    Address NVARCHAR(250), 
    NumberAddr NVARCHAR(6), 
    ZipCode NVARCHAR(8), 
    District NVARCHAR(150), 
    CreditCardNumber NVARCHAR(16), 
    CV NVARCHAR(3), 
    EmailContact NVARCHAR(255), 
    CityModel_CityId BIGINT NOT NULL,
    PRIMARY KEY (OrganizationId, CNPJ)
);
GO

-- Create RoleModel table
CREATE TABLE RoleModel (
    RoleId BIGINT PRIMARY KEY, 
    RoleName NVARCHAR(100)
);
GO

-- Create SignatureModel table
CREATE TABLE SignatureModel (
    SignatureId BIGINT PRIMARY KEY, 
    KeySignature NVARCHAR(128), 
    IsActive BIT, 
    OrganizationModel_OrganizationId BIGINT NOT NULL, 
    BillModel_BillId BIGINT NOT NULL, 
    AppId BIGINT NOT NULL, 
    OrganizationModel_CNPJ NVARCHAR(15) NOT NULL
);
GO

-- Create StateModel table
CREATE TABLE StateModel (
    StateId BIGINT PRIMARY KEY, 
    Name NVARCHAR(50), 
    UF NVARCHAR(2), 
    IBGECode NVARCHAR(7), 
    DDD NVARCHAR(3), 
    CountryModel_CountryId BIGINT NOT NULL
);
GO

-- Create UserLogin table
CREATE TABLE UserLogin (
    UserLoginId BIGINT PRIMARY KEY, 
    CreateLogin DATETIME, 
    LogTime DATETIME, 
    AuthenticateResult BIT, 
    LOG NVARCHAR(255), 
    UserModel_UserId BIGINT NOT NULL
);
GO

-- Create UserModel table
CREATE TABLE UserModel (
    UserId BIGINT PRIMARY KEY, 
    UserName NVARCHAR(150), 
    Password NVARCHAR(250), 
    EmailAddress NVARCHAR(150), 
    Role NVARCHAR(100), 
    Surname NVARCHAR(150), 
    GivenName NVARCHAR(150), 
    IsActive BIT, 
    RoleModel_RoleId BIGINT NOT NULL
);
GO

-- Add foreign keys (please ensure these are added in the right sequence to avoid dependency errors)
ALTER TABLE CityModel ADD FOREIGN KEY (StateModel_StateId) REFERENCES StateModel(StateId);
GO

ALTER TABLE EnrollmentModel ADD FOREIGN KEY (AppPortifolio_AppId) REFERENCES AppPortifolio(AppId);
ALTER TABLE EnrollmentModel ADD FOREIGN KEY (SignatureModel_SignatureId) REFERENCES SignatureModel(SignatureId);
ALTER TABLE EnrollmentModel ADD FOREIGN KEY (UserModel_UserId) REFERENCES UserModel(UserId);
GO

ALTER TABLE OrganizationModel ADD FOREIGN KEY (CityModel_CityId) REFERENCES CityModel(CityId);
GO

ALTER TABLE SignatureModel ADD FOREIGN KEY (BillModel_BillId) REFERENCES BillModel(BillId);
ALTER TABLE SignatureModel ADD FOREIGN KEY (OrganizationModel_OrganizationId, OrganizationModel_CNPJ) REFERENCES OrganizationModel(OrganizationId, CNPJ);
GO

ALTER TABLE StateModel ADD FOREIGN KEY (CountryModel_CountryId) REFERENCES CountryModel(CountryId);
GO

ALTER TABLE UserLogin ADD FOREIGN KEY (UserModel_UserId) REFERENCES UserModel(UserId);
GO

ALTER TABLE UserModel ADD FOREIGN KEY (RoleModel_RoleId) REFERENCES RoleModel(RoleId);
GO
