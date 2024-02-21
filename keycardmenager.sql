-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 21, 2024 at 11:59 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
  `name` varchar(255) NOT NULL,
  `serial` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accesspoint`
--

INSERT INTO `accesspoint` (`id`, `name`, `serial`) VALUES
(1, 'Glavni Ulaz', '1'),
(2, 'Zadnji Ulaz ', '2'),
(3, 'Blagajna', '3'),
(4, 'Kantina', '4'),
(5, 'Server soba', '5');

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
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(3, 1),
(3, 2),
(3, 3),
(4, 9),
(4, 10),
(5, 1),
(5, 2),
(5, 3),
(5, 4),
(5, 5),
(5, 6),
(5, 7),
(5, 8),
(5, 9),
(5, 10),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(1, 11),
(1, 12);

-- --------------------------------------------------------

--
-- Table structure for table `keycard`
--

CREATE TABLE `keycard` (
  `id` int(11) NOT NULL,
  `serial_number` varchar(255) NOT NULL,
  `user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `keycard`
--

INSERT INTO `keycard` (`id`, `serial_number`, `user_id`) VALUES
(1, 'KC1001', 1),
(2, 'KC1002', 2),
(3, 'KC1003', 3),
(4, 'KC1004', 4),
(5, 'KC1005', 5),
(6, 'KC1006', 6),
(7, 'KC1007', 7),
(8, 'KC1008', 8),
(9, 'KC1009', 9),
(10, 'KC1010', 10),
(11, 'KC1011', 11),
(12, 'KC1012', 12),
(13, 'KC1013', NULL),
(14, 'KC1014', NULL),
(15, 'KC1015', NULL),
(16, 'KC1016', NULL),
(17, 'KC1017', NULL),
(18, 'KC1018', NULL),
(19, 'KC1019', NULL),
(20, 'KC1020', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `id` int(11) NOT NULL,
  `accesspoint_id` int(11) NOT NULL,
  `keycard_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `eventdate` datetime NOT NULL,
  `successful` tinyint(1) NOT NULL COMMENT '0 = False, 1 = True',
  `number_of_scans` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id`, `accesspoint_id`, `keycard_id`, `user_id`, `eventdate`, `successful`, `number_of_scans`) VALUES
(1, 1, 1, 1, '2024-02-21 08:00:00', 1, 1),
(2, 1, 2, 2, '2024-02-21 08:05:00', 1, 1),
(3, 3, 3, 3, '2024-02-21 08:10:00', 1, 1),
(4, 2, 4, 4, '2024-02-21 08:15:00', 1, 1),
(5, 2, 5, 5, '2024-02-21 08:20:00', 1, 1),
(6, 1, 6, 6, '2024-02-21 08:25:00', 1, 1),
(7, 2, 7, 7, '2024-02-21 08:30:00', 1, 1),
(8, 2, 8, 8, '2024-02-21 08:35:00', 1, 1),
(9, 4, 9, 9, '2024-02-21 08:40:00', 1, 1);

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
(1, 'marko', 'marko@example.com', 'password123', 'Marko', 'Marković', '2024-02-01', 'Employee'),
(2, 'jelena', 'jelena@example.com', 'password123', 'Jelena', 'Jelenić', '2024-02-02', 'Employee'),
(3, 'nikola', 'nikola@example.com', 'password123', 'Nikola', 'Nikolić', '2024-02-03', 'Employee'),
(4, 'ana', 'ana@example.com', 'password123', 'Ana', 'Anić', '2024-02-04', 'Employee'),
(5, 'ivan', 'ivan@example.com', 'password123', 'Ivan', 'Ivanić', '2024-02-05', 'Employee'),
(6, 'marija', 'marija@example.com', 'password123', 'Marija', 'Marijić', '2024-02-06', 'Employee'),
(7, 'davor', 'davor@example.com', 'password123', 'Davor', 'Davorić', '2024-02-07', 'Employee'),
(8, 'sonja', 'sonja@example.com', 'password123', 'Sonja', 'Sonjić', '2024-02-08', 'Employee'),
(9, 'zoran', 'zoran@example.com', 'password123', 'Zoran', 'Zoranić', '2024-02-09', 'Employee'),
(10, 'luka', 'luka@example.com', 'password123', 'Luka', 'Lukić', '2024-02-10', 'Employee'),
(11, 'sara', 'sara@example.com', 'password123', 'Sara', 'Sarić', '2024-02-11', 'Employee'),
(12, 'petar', 'petar@example.com', 'password123', 'Petar', 'Petrić', '2024-02-12', 'Employee');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accesspoint`
--
ALTER TABLE `accesspoint`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `keycard`
--
ALTER TABLE `keycard`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_user_id` (`user_id`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_log_accesspoint` (`accesspoint_id`),
  ADD KEY `fk_log_keycard` (`keycard_id`),
  ADD KEY `fk_log_user` (`user_id`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `keycard`
--
ALTER TABLE `keycard`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `keycard`
--
ALTER TABLE `keycard`
  ADD CONSTRAINT `keycard_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `fk_log_accesspoint` FOREIGN KEY (`accesspoint_id`) REFERENCES `accesspoint` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_log_keycard` FOREIGN KEY (`keycard_id`) REFERENCES `keycard` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_log_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
