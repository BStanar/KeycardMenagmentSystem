-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2024 at 03:12 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `keycardmenager`
--

-- --------------------------------------------------------

--
-- Table structure for table `accesspoint`
--

CREATE TABLE `accesspoint` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accesspoint`
--

INSERT INTO `accesspoint` (`id`, `name`) VALUES
(1, 'Main Entrance'),
(2, 'Back Entrance');

-- --------------------------------------------------------

--
-- Table structure for table `accesspoint_keycard`
--

CREATE TABLE `accesspoint_keycard` (
  `accesspoint_id` int(11) NOT NULL,
  `keycard_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accesspoint_keycard`
--

INSERT INTO `accesspoint_keycard` (`accesspoint_id`, `keycard_id`) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(2, 3);

-- --------------------------------------------------------

--
-- Table structure for table `keycard`
--

CREATE TABLE `keycard` (
  `id` int(11) NOT NULL,
  `serial_number` varchar(255) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `activated` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `keycard`
--

INSERT INTO `keycard` (`id`, `serial_number`, `user_id`, `activated`) VALUES
(1, 'KC1001', 1, 1),
(2, 'KC1002', 2, 1),
(3, 'KC1003', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `date_of_employment` date NOT NULL,
  `role` varchar(255) NOT NULL DEFAULT 'Employee'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `email`, `password`, `name`, `lastname`, `date_of_employment`, `role`) VALUES
(1, 'jdoe', 'jdoe@example.com', 'password123', 'John', 'Doe', '2020-01-01', 'Manager'),
(2, 'asmith', 'asmith@example.com', 'password123', 'Alice', 'Smith', '2020-02-01', 'Employee'),
(3, 'bjones', 'bjones@example.com', 'password123', 'Bob', 'Jones', '2020-03-01', 'Employee');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accesspoint`
--
ALTER TABLE `accesspoint`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `accesspoint_keycard`
--
ALTER TABLE `accesspoint_keycard`
  ADD PRIMARY KEY (`accesspoint_id`,`keycard_id`),
  ADD KEY `keycard_id` (`keycard_id`);

--
-- Indexes for table `keycard`
--
ALTER TABLE `keycard`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accesspoint`
--
ALTER TABLE `accesspoint`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `keycard`
--
ALTER TABLE `keycard`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `accesspoint_keycard`
--
ALTER TABLE `accesspoint_keycard`
  ADD CONSTRAINT `accesspoint_keycard_ibfk_1` FOREIGN KEY (`accesspoint_id`) REFERENCES `accesspoint` (`id`),
  ADD CONSTRAINT `accesspoint_keycard_ibfk_2` FOREIGN KEY (`keycard_id`) REFERENCES `keycard` (`id`);

--
-- Constraints for table `keycard`
--
ALTER TABLE `keycard`
  ADD CONSTRAINT `keycard_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
