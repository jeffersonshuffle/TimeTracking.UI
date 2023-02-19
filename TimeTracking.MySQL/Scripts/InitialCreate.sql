---DB Create Script

CREATE DATABASE IF NOT EXISTS `time_tracking`;

use `time_tracking`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `address` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `country` varchar(100) NOT NULL,
    `city` varchar(100) NOT NULL,
    `street` varchar(250) NOT NULL,
    `house` varchar(50) NOT NULL,
    `appartment` int NOT NULL,
    `Region` varchar(250) NULL,
    `postal_code` varchar(100) NULL,
    `Phone` varchar(100) NULL,
    `fax` varchar(100) NULL,
    `email` varchar(100) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `day_mark` (
    `id` int NOT NULL AUTO_INCREMENT,
    `name` varchar(250) NOT NULL,
    `short` varchar(10) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `department` (
    `ID` BINARY(16) NOT NULL,
    `name` varchar(250) NOT NULL,
    `description` varchar(500) NULL,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `position` (
    `position_id` int NOT NULL AUTO_INCREMENT,
    `title` varchar(250) NOT NULL,
    `description` varchar(500) NULL,
    PRIMARY KEY (`position_id`)
);

CREATE TABLE `employee` (
    `ID` BINARY(16) NOT NULL,
    `first_name` varchar(50) NOT NULL,
    `last_name` varchar(50) NOT NULL,
    `personnel_number` int NOT NULL,
    `birth_date` DATETIME NOT NULL,
    `photo` BLOB NULL,
    `AddressId` int NOT NULL,
    PRIMARY KEY (`ID`),
    CONSTRAINT `FK_employee_address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `employee_calendar_item` (
    `id` int NOT NULL AUTO_INCREMENT,
    `date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `day_mark_id` int NOT NULL,
    `employee_id` BINARY(16) NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `FK_employee_calendar_item_employee_employee_id` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`ID`) ON DELETE CASCADE,
    CONSTRAINT `fk_item_day_mark` FOREIGN KEY (`day_mark_id`) REFERENCES `day_mark` (`id`) ON DELETE CASCADE
);

CREATE TABLE `position_assignment` (
    `ID` BINARY(16) NOT NULL,
    `department_ID` BINARY(16) NOT NULL,
    `employee_ID` BINARY(16) NOT NULL,
    `date_created` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `date_modified` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `position_ID` int NOT NULL,
    PRIMARY KEY (`ID`),
    CONSTRAINT `fk_department_position_assignment` FOREIGN KEY (`department_ID`) REFERENCES `department` (`ID`) ON DELETE CASCADE,
    CONSTRAINT `fk_employee_position_assignment` FOREIGN KEY (`employee_ID`) REFERENCES `employee` (`ID`) ON DELETE CASCADE,
    CONSTRAINT `fk_position_position_assignment` FOREIGN KEY (`position_ID`) REFERENCES `position` (`position_id`) ON DELETE CASCADE
);

CREATE INDEX `IX_employee_AddressId` ON `time_tracking`.`employee` (`AddressId`);

CREATE UNIQUE INDEX `IX_employee_personnel_number` ON `time_tracking`.`employee` (`personnel_number`);

CREATE INDEX `IX_employee_calendar_item_day_mark_id` ON `time_tracking`.`employee_calendar_item` (`day_mark_id`);

CREATE INDEX `IX_employee_calendar_item_employee_id` ON `time_tracking`.`employee_calendar_item` (`employee_id`);

CREATE INDEX `IX_position_assignment_department_ID` ON `time_tracking`.`position_assignment` (`department_ID`);

CREATE UNIQUE INDEX `IX_position_assignment_employee_ID` ON `time_tracking`.`position_assignment` (`employee_ID`);

CREATE INDEX `IX_position_assignment_position_ID` ON `time_tracking`.`position_assignment` (`position_ID`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230219000947_InitialCreate', '7.0.3');



