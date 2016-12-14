-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: superminers
-- ------------------------------------------------------
-- Server version	5.7.12-log

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
-- Table structure for table `locksellstonesorder`
--

use superminers;

DROP TABLE IF EXISTS `locksellstonesorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `locksellstonesorder` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OrderNumber` varchar(35) NOT NULL,
  `PayUrl` varchar(300) NOT NULL,
  `LockedByUserName` varchar(64) NOT NULL,
  `LockedTime` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `OrderNumber_UNIQUE` (`OrderNumber`),
  KEY `foreign_OrderNumber_idx` (`OrderNumber`),
  CONSTRAINT `foreign_LockOrderNumber` FOREIGN KEY (`OrderNumber`) REFERENCES `sellstonesorder` (`OrderNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7709 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locksellstonesorder`
--

LOCK TABLES `locksellstonesorder` WRITE;
/*!40000 ALTER TABLE `locksellstonesorder` DISABLE KEYS */;
INSERT INTO `locksellstonesorder` VALUES (7708,'2016121408424209071111527882128932','Alipay/AlipayDefault.aspx?p=5U2IX9S%2foVsPUcuJAIY6lairgDdoDt2pkkV%2bB8BgRyeX%2fpdV24a7WiumSVh5zxv0VKdoYKs9dAA9MajkYsv%2fRFu5h90e0Mgguh2LMHP6umluhu4F9saGJs%2fXIvbEoTkBOWJo1gjnsrQ%3d','5U2IX9S/oVs8xwO3jmatag==','2016-12-14 22:56:46');
/*!40000 ALTER TABLE `locksellstonesorder` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-14 23:02:15
