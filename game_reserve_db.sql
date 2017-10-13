CREATE DATABASE  IF NOT EXISTS `game_reserve_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `game_reserve_db`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: game_reserve_db
-- ------------------------------------------------------
-- Server version	5.5.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblanimal`
--

DROP TABLE IF EXISTS `tblanimal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblanimal` (
  `animalId` int(11) NOT NULL AUTO_INCREMENT,
  `animalName` varchar(255) NOT NULL,
  `createdAt` datetime NOT NULL,
  `gpsDeviceId` varchar(255) NOT NULL,
  `categoryId` int(11) NOT NULL,
  PRIMARY KEY (`animalId`),
  UNIQUE KEY `gpsDeviceId` (`gpsDeviceId`),
  KEY `categoryId` (`categoryId`),
  CONSTRAINT `tblAnimal_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `tblcategory` (`categoryId`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblanimal`
--

LOCK TABLES `tblanimal` WRITE;
/*!40000 ALTER TABLE `tblanimal` DISABLE KEYS */;
INSERT INTO `tblanimal` VALUES (1,'Giraffe1','2017-10-13 17:20:00','GPSDevice1',1),(2,'Giraffe2','2017-10-13 17:25:00','GPSDevice2',1),(3,'Giraffe3','2017-10-13 17:25:00','GPSDevice3',1);
/*!40000 ALTER TABLE `tblanimal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcategory`
--

DROP TABLE IF EXISTS `tblcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcategory` (
  `categoryId` int(11) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(255) NOT NULL,
  `colorIndication` varchar(255) NOT NULL,
  `categoryDesc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`categoryId`),
  UNIQUE KEY `categoryName` (`categoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcategory`
--

LOCK TABLES `tblcategory` WRITE;
/*!40000 ALTER TABLE `tblcategory` DISABLE KEYS */;
INSERT INTO `tblcategory` VALUES (1,'Giraffe','#32CD32','This is a test description'),(2,'Snake','#0000ff','This is snake description');
/*!40000 ALTER TABLE `tblcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblgpstracking`
--

DROP TABLE IF EXISTS `tblgpstracking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblgpstracking` (
  `trackingId` int(11) NOT NULL AUTO_INCREMENT,
  `animalId` int(11) NOT NULL,
  `latitude` double NOT NULL,
  `longitude` double NOT NULL,
  `createdAt` datetime NOT NULL,
  PRIMARY KEY (`trackingId`),
  KEY `animalId` (`animalId`),
  CONSTRAINT `tblgpstracking_ibfk_1` FOREIGN KEY (`animalId`) REFERENCES `tblanimal` (`animalId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblgpstracking`
--

LOCK TABLES `tblgpstracking` WRITE;
/*!40000 ALTER TABLE `tblgpstracking` DISABLE KEYS */;
INSERT INTO `tblgpstracking` VALUES (1,1,26.2041,28.0473,'2017-10-13 17:20:00'),(2,2,33.9249,18.4241,'2017-10-13 17:24:00');
/*!40000 ALTER TABLE `tblgpstracking` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-13 17:26:33
