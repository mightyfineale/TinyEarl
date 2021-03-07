create table UrlAliases
(
    Url   nvarchar(2000) not null,
    Alias nvarchar(15)   not null,
    constraint UrlAliases_pk
        primary key nonclustered (Url, Alias)
)
go

create unique index UrlAliases_Url_uindex
    on UrlAliases (Url)
go

create unique index UrlAliases_Alias_uindex
    on UrlAliases (Alias)
go

CREATE PROCEDURE GetAlias @Url nvarchar(2000), @GeneratedAlias nvarchar(15)
AS
DECLARE @StoredAlias NVARCHAR(15)
    SET @StoredAlias = (SELECT TOP (1) Alias
                        FROM UrlAliases
                        WHERE Url = @Url)
    IF NULLIF(@StoredAlias, '') IS NULL
        BEGIN
            IF EXISTS(SELECT Alias
                      FROM UrlAliases
                      WHERE Alias = @GeneratedAlias)
                BEGIN
                    SELECT 'Alias Already Used'
                    RETURN
                END

            EXECUTE InsertAlias @Url, @GeneratedAlias
            SELECT @GeneratedAlias
        END
    ELSE
        BEGIN
            SELECT @StoredAlias
        END
go

CREATE PROCEDURE GetUrl @Alias nvarchar(15)
AS
DECLARE @PossibleUrl NVARCHAR(2000)
    SET @PossibleUrl = (SELECT TOP (1) Url
                        from UrlAliases
                        where Alias = @Alias)
    IF NULLIF(@PossibleUrl, '') IS NULL
        BEGIN
            SELECT 'Record Not Found'
        END
    ELSE
        BEGIN
            SELECT @PossibleUrl
        END
go

CREATE PROCEDURE InsertAlias @Url nvarchar(2000), @Alias nvarchar(15)
AS

INSERT INTO UrlAliases
VALUES (@Url, @Alias)
go

