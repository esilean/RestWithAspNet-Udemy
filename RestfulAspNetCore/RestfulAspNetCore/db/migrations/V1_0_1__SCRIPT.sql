drop table books

CREATE TABLE `persons` (
    `Id` int (10) AUTO_INCREMENT PRIMARY KEY,
    `FirstName` VARCHAR(50) not NULL,
    `LastName` VARCHAR(50) not NULL,
    `Address` VARCHAR(50) not NULL,
    `Gender` VARCHAR(50) not NULL 
)
ENGINE=InnoDB
;

CREATE TABLE IF NOT EXISTS `books` (
    `Id` int (10) AUTO_INCREMENT NOT NULL,
    `Author` longtext not null,
    `LaunchDate` datetime(6) not null,
    `Price` decimal(65,2) not null,
    `Title` longtext not null,
    PRIMARY KEY(`id`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1
;

CREATE TABLE IF NOT EXISTS `users` (
    `Email` varchar (100) NOT NULL,
    `PasswordHash` varbinary(64) not null,
    `PasswordSalt` varbinary(128) not null,
    `ClientSecret` varbinary(32) not null,
    `RefreshToken` varchar(100) null,
    `Created` datetime(6) not null,
    `IsActive` bit not null,
    
    PRIMARY KEY(`Email`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1
;