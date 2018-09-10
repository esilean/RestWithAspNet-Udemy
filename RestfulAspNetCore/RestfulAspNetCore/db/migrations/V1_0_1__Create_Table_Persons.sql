CREATE TABLE `persons` (
	`Id` int (10) AUTO_INCREMENT PRIMARY KEY,
    `FirstName` VARCHAR(50) NULL DEFAULT NULL,
    `LastName` VARCHAR(50) NULL DEFAULT NULL,
    `Address` VARCHAR(50) NULL DEFAULT NULL,
    `Gender` VARCHAR(50) NULL DEFAULT NULL
)
ENGINE=InnoDB
;

CREATE TABLE IF NOT EXISTS `books` (
    `Id` int (10) AUTO_INCREMENT NOT NULL,
    `Author` longtext,
    `LaunchDate` datetime(6) not null,
    `Price` decimal(65,2) not null,
    `Title` longtext,
    PRIMARY KEY(`id`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1
;