-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 29, 2021 at 01:22 AM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `xhltopuxjch6ox31`
--
CREATE DATABASE IF NOT EXISTS `xhltopuxjch6ox31` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `xhltopuxjch6ox31`;

DELIMITER $$
--
-- Procedures
--
CREATE  PROCEDURE `GetAllParkingVehiclesByTicket` (IN `ticket` varchar(10))  BEGIN
    SELECT V.LicensePlateId, V.Name, V.Phone, V.Ticket, V.Height, V.Width, V.Length, P.Id AS Lot
    FROM vehicles AS V JOIN parkinglots AS P
    ON V.licensePlateId = P.licensePlateId
    WHERE V.Ticket = ticket AND P.licensePlateId IS NOT NULL;
END$$

CREATE  PROCEDURE `InsertParkingLots` (`size` INT)  BEGIN
	DECLARE counter INT DEFAULT 1;
    
    WHILE counter <= size DO
	 INSERT INTO parkinglots VALUES(DEFAULT, NULL); 

     SET counter = counter + 1;
     END WHILE;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `parkinglots`
--

CREATE TABLE `parkinglots` (
  `Id` int(11) NOT NULL,
  `LicensePlateId` varchar(10) CHARACTER SET utf8mb4 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `parkinglots`
--

INSERT INTO `parkinglots` (`Id`, `LicensePlateId`) VALUES
(3, NULL),
(4, NULL),
(5, NULL),
(6, NULL),
(7, NULL),
(8, NULL),
(9, NULL),
(10, NULL),
(11, NULL),
(12, NULL),
(13, NULL),
(14, NULL),
(15, NULL),
(16, NULL),
(17, NULL),
(18, NULL),
(19, NULL),
(20, NULL),
(21, NULL),
(22, NULL),
(23, NULL),
(24, NULL),
(25, NULL),
(26, NULL),
(27, NULL),
(28, NULL),
(29, NULL),
(30, NULL),
(31, NULL),
(32, NULL),
(33, NULL),
(34, NULL),
(35, NULL),
(36, NULL),
(37, NULL),
(38, NULL),
(39, NULL),
(40, NULL),
(41, NULL),
(42, NULL),
(43, NULL),
(44, NULL),
(45, NULL),
(46, NULL),
(47, NULL),
(48, NULL),
(49, NULL),
(50, NULL),
(51, NULL),
(52, NULL),
(53, NULL),
(54, NULL),
(55, NULL),
(56, NULL),
(57, NULL),
(58, NULL),
(59, NULL),
(60, NULL),
(2, '6231151'),
(1, '6235124351');

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE `vehicles` (
  `LicensePlateId` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(20) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Phone` varchar(15) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Ticket` varchar(10) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Height` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `Length` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vehicles`
--

INSERT INTO `vehicles` (`LicensePlateId`, `Name`, `Phone`, `Ticket`, `Height`, `Width`, `Length`) VALUES
('6231151', 'Abcdef', '0524461159', 'Vip', 3000, 2000, 2000),
('6235124351', 'Ido', '0523661159', 'Vip', 2000, 2000, 2000);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20211128033222_InitialMigration', '3.0.0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `parkinglots`
--
ALTER TABLE `parkinglots`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_ParkingLots_LicensePlateId` (`LicensePlateId`);

--
-- Indexes for table `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`LicensePlateId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `parkinglots`
--
ALTER TABLE `parkinglots`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `parkinglots`
--
ALTER TABLE `parkinglots`
  ADD CONSTRAINT `FK_ParkingLots_Vehicles_LicensePlateId` FOREIGN KEY (`LicensePlateId`) REFERENCES `vehicles` (`LicensePlateId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
