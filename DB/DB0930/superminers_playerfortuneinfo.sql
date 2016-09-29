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
-- Table structure for table `playerfortuneinfo`
--

DROP TABLE IF EXISTS `playerfortuneinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `playerfortuneinfo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `userId` int(10) unsigned NOT NULL,
  `Exp` float NOT NULL DEFAULT '0',
  `RMB` float NOT NULL DEFAULT '0',
  `FreezingRMB` float unsigned NOT NULL DEFAULT '0',
  `GoldCoin` float NOT NULL DEFAULT '0',
  `MinesCount` float NOT NULL DEFAULT '0',
  `StonesReserves` float NOT NULL DEFAULT '0' COMMENT '矿石储量。该值为累计值，即每次购买矿山，将矿山储量值累加到该值上。',
  `TotalProducedStonesCount` float NOT NULL DEFAULT '0' COMMENT '累计总产出矿石数。和StonesReserves的差值，为当前可开采的矿石数。',
  `MinersCount` float NOT NULL DEFAULT '0' COMMENT '矿工数',
  `StockOfStones` float NOT NULL DEFAULT '0',
  `TempOutputStonesStartTime` datetime DEFAULT NULL,
  `TempOutputStones` float NOT NULL DEFAULT '0' COMMENT '临时生产矿石数，数据库字段，记录玩家当前生产出来的矿石，在玩家点击收取，时会调用方法把产量值保存到数据库中。',
  `FreezingStones` float unsigned NOT NULL DEFAULT '0',
  `StockOfDiamonds` float NOT NULL DEFAULT '0',
  `FreezingDiamonds` float NOT NULL DEFAULT '0',
  `FirstRechargeGoldCoinAward` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `userId_UNIQUE` (`userId`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  CONSTRAINT `UserID` FOREIGN KEY (`userId`) REFERENCES `playersimpleinfo` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=334 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playerfortuneinfo`
--

LOCK TABLES `playerfortuneinfo` WRITE;
/*!40000 ALTER TABLE `playerfortuneinfo` DISABLE KEYS */;
INSERT INTO `playerfortuneinfo` VALUES (1,1,61,8.7,0,15909,0.6,60000,14555.1,310,25407,'2016-09-29 20:49:28',0,0,0,0,1),(2,2,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(3,3,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(4,4,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(5,5,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(6,6,0,0,0,0,0.6,60000,0,70,0,'2016-09-01 15:49:43',0,0,0,0,0),(7,7,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(8,8,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(9,9,0,282,0,0,0.6,60000,3872.81,70,757,'2016-09-29 19:10:45',0,0,0,0,0),(10,10,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(11,11,0,0,0,0,0.6,60000,650.356,70,648,'2016-09-05 18:47:06',0,0,0,0,0),(12,12,49,168,0,21000,0.6,60000,4332.38,125,3200,'2016-09-25 21:16:45',0,0,0,0,1),(13,13,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(14,14,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(15,15,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(16,16,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(17,17,0,25.65,0,0,0.6,60000,454.989,70,183,'2016-09-14 18:33:41',0,0,0,0,0),(18,18,0,117,0,0,0.6,60000,1491.77,70,186,'2016-09-21 11:37:47',0,0,0,0,0),(19,19,0,207,0,0,0.6,60000,2317.06,70,8,'2016-09-21 11:40:49',0,0,0,0,0),(20,20,10,0,0,0,0.6,60000,1940.44,75,1933,'2016-09-28 11:16:48',0,0,0,0,0),(21,21,10,12.7,0,1273,0.6,60000,4580.19,93,3136,'2016-09-29 21:09:18',0,3000,0,0,1),(23,23,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(24,24,0,216.51,0,0,0.6,60000,2619.88,70,216,'2016-09-28 09:41:27',0,0,0,0,0),(25,25,0,0,0,0,0.6,60000,0,70,0,'2016-09-03 18:24:41',0,0,0,0,0),(26,26,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(27,27,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(28,28,0,0,0,0,0.6,60000,0,70,0,'2016-09-03 19:02:53',0,0,0,0,0),(29,29,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(30,30,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(31,31,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(32,32,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(33,33,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(34,34,0,0,0,0,0.6,60000,327.163,70,324,'2016-09-07 08:11:54',0,0,0,0,0),(35,35,1,316.415,0,500,0.6,60000,3557.19,71,192,'2016-09-29 12:26:26',0,0,0,0,0),(36,36,5,85.5,0,2500,0.6,60000,1461.9,70,556,'2016-09-26 20:16:22',0,0,0,0,0),(37,37,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(38,38,0,64.715,0,0,0.6,60000,1046.28,70,345,'2016-09-28 09:01:50',0,345,0,0,0),(39,39,0,64.62,0,0,0.6,60000,1044.92,70,345,'2016-09-28 09:02:15',0,345,0,0,0),(40,40,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 16:14:33',0,0,0,0,0),(41,41,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 16:18:41',0,0,0,0,0),(42,42,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 17:03:28',0,0,0,0,0),(43,43,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(44,44,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(45,45,50,5,0,0,0.6,60000,12569,285,5556,'2016-09-29 12:41:20',0,0,0,0,1),(46,46,0,185,0,0,0.6,60000,3650.72,70,1638,'2016-09-29 12:45:15',0,0,0,0,0),(47,47,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(48,48,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(49,49,0,0,0,0,0.6,60000,0,70,0,'2016-09-08 14:32:48',0,0,0,0,0),(50,50,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(51,51,0,0,0,0,0.6,60000,0,70,0,'2016-09-08 21:07:31',0,0,0,0,0),(52,52,0,0,0,0,0.6,60000,345.679,70,344,'2016-09-11 07:54:16',0,0,0,0,0),(54,54,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(55,55,0,1000,0,0,0.6,60000,485.723,70,484,'2016-09-18 11:35:12',0,0,0,0,0),(56,56,0,1000,0,0,0.6,60000,485.684,70,484,'2016-09-18 11:35:07',0,0,0,0,0),(57,57,0,723.1,0,3069,0.6,60000,660.407,70,3727,'2016-09-22 17:06:38',174.72,0,0,0,0),(58,58,0,0,0,1000,0.6,60000,660.383,70,1658,'2016-09-21 21:52:25',0,0,0,0,0),(59,59,0,0,0,0,0.6,60000,485.544,70,483,'2016-09-18 11:34:56',0,0,0,0,0),(60,60,0,0,0,0,0.6,60000,485.55,70,483,'2016-09-18 11:34:50',0,0,0,0,0),(61,61,0,0,0,0,0.6,60000,660.3,70,658,'2016-09-21 22:05:52',0,0,0,0,0),(62,62,0,0,0,1149,0.6,60000,660.165,70,1807,'2016-09-21 22:01:24',0,0,0,0,0),(63,63,0,895.4,0,2648,0.6,60000,659.998,70,3305,'2016-09-21 21:56:41',0,0,0,0,0),(64,64,0,0,0,0,0.6,60000,485.413,70,484,'2016-09-18 11:34:40',0,0,0,0,0),(65,65,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(66,66,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(67,67,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(68,68,0,0,0,0,0.6,60000,1.83169,70,1,'2016-09-09 22:46:25',0,0,0,0,0),(69,69,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(70,70,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(71,71,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(72,72,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(73,73,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(74,74,0,0,0,0,0.6,60000,96.3399,70,95,'2016-09-10 23:24:54',0,0,0,0,0),(75,75,0,0,0,0,0.6,60000,0,70,0,'2016-09-10 13:56:22',0,0,0,0,0),(76,76,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(77,77,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(78,78,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(79,79,200,99298.1,500,2019,0.6,60000,1854.26,370,3872,'2016-09-29 15:03:25',0,0,0,0,1),(80,80,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(81,81,1,534.5,0,897,0.6,60000,2712.86,79,1162,'2016-09-29 20:48:35',0,1000,0,0,1),(82,82,10,44.25,0,202,0.6,60000,705.1,75,220,'2016-09-20 22:55:30',0,0,0,0,0),(83,83,0,0,0,0,0.6,60000,0,70,0,'2016-09-13 12:40:52',0,0,0,0,0),(84,84,0,0,0,0,0.6,60000,0,70,0,'2016-09-13 20:07:32',0,0,0,0,0),(85,85,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(86,86,0,0,0,0,0.6,60000,0,70,0,'2016-09-15 08:04:14',0,0,0,0,0),(87,87,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(88,88,0,65.79,0,200,0.6,60000,2137.74,79,394,'2016-09-29 21:46:39',0,394,0,0,0),(89,89,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(90,90,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(91,91,0,0,0,0,0.6,60000,0.269373,70,0,'2016-09-16 06:25:12',0,0,0,0,0),(92,92,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(93,93,0,0,0,0,0.6,60000,0,70,0,'2016-09-16 06:29:23',0,0,0,0,0),(94,94,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(95,95,0,69.8,0,0,0.6,60000,2260.59,84,13,'2016-09-29 08:53:43',0,0,0,0,0),(96,96,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(97,97,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(98,98,0,159,0,0,0.6,59800,1720.29,70,215,'2016-09-29 19:11:03',0,0,0,0,0),(99,99,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(100,100,0,5,0,0,0.6,59800,1485.98,79,680,'2016-09-29 19:36:00',0,0,0,0,0),(101,101,0,0,0,0,0.6,60000,856.477,70,853,'2016-09-23 21:12:41',0,0,0,0,0),(102,102,0,109.155,0,0,0.6,60000,1225.12,70,70,'2016-09-24 18:44:58',0,0,0,0,0),(103,103,0,110.675,0,0,0.6,60000,1171.56,70,0,'2016-09-24 18:42:35',0,0,0,0,0),(104,104,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(105,105,0,112.575,0,0,0.6,60000,1188.8,70,0,'2016-09-24 08:56:05',0,0,0,0,0),(106,106,0,117.895,0,0,0.6,60000,1245.46,70,0,'2016-09-24 20:12:23',0.802705,0,0,0,0),(107,107,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(108,108,0,110.485,0,0,0.6,60000,1168.16,70,0,'2016-09-24 11:33:44',0,0,0,0,0),(109,109,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(110,110,0,112.29,0,0,0.6,60000,1185.1,70,0,'2016-09-24 12:55:08',0,0,0,0,0),(111,111,0,120.65,0,0,0.6,60000,1270.64,70,0,'2016-09-24 18:24:33',0,0,0,0,0),(113,113,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(114,114,0,112.29,0,0,0.6,60000,1237.48,70,48,'2016-09-24 15:02:32',24.0603,0,0,0,0),(115,115,0,113.05,0,0,0.6,60000,1196.51,70,0,'2016-09-24 09:59:08',0,0,0,0,0),(116,116,0,112.1,0,0,0.6,60000,1217.06,70,34,'2016-09-24 13:30:00',17.0688,0,0,0,0),(117,117,0,94.145,0,0,0.6,60000,998.163,70,0,'2016-09-24 20:41:58',0,0,0,0,0),(118,118,0,112.1,0,0,0.6,60000,1264.91,70,75,'2016-09-24 19:42:11',0,0,0,0,0),(119,119,0,115.9,0,0,0.6,60000,1222.54,70,0,'2016-09-24 11:43:29',0,0,0,0,0),(120,120,0,113.145,0,0,0.6,60000,1275.13,70,79,'2016-09-24 18:58:51',0,0,0,0,0),(121,121,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(122,122,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(123,123,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(124,124,0,114.095,0,0,0.6,60000,1378.87,70,174,'2016-09-26 17:34:04',0,0,0,0,0),(125,125,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(126,126,0,27.5,0,0,0.6,60000,2107.52,85,202,'2016-09-29 07:21:25',0,0,0,0,0),(127,127,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(128,128,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(129,129,0,110.295,0,0,0.6,60000,1164.19,70,0,'2016-09-24 09:07:46',64.5146,0,0,0,0),(130,130,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(131,131,0,0,0,0,0.6,60000,554.758,70,551,'2016-09-20 16:23:04',0,0,0,0,0),(132,132,0,103.74,0,0,0.6,60000,1096.45,70,0,'2016-09-24 20:21:50',0,0,0,0,0),(133,133,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(134,134,0,111.15,0,0,0.6,60000,1175.85,70,0,'2016-09-24 10:34:39',0,0,0,0,0),(135,135,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(136,136,0,0,0,0,0.6,60000,19.3719,70,19,'2016-09-17 15:04:22',0,0,0,0,0),(137,137,0,113.81,0,0,0.6,60000,1053.04,70,21,'2016-09-24 18:56:53',0,0,0,0,0),(138,138,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(139,139,0,108.11,0,0,0.6,60000,1139.8,70,0,'2016-09-24 01:00:30',0,0,0,0,0),(140,140,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(141,141,0,110.2,0,0,0.6,60000,1163.84,70,0,'2016-09-24 12:40:59',43.1184,0,0,0,0),(142,142,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(143,143,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(144,144,0,114.95,0,0,0.6,59900,1014.65,70,0,'2016-09-24 11:50:18',0.424418,0,0,0,0),(145,145,0,110.2,0,0,0.6,60000,1163.42,70,0,'2016-09-24 13:58:28',37.8111,0,0,0,0),(146,146,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(147,147,0,118.56,0,0,0.6,60000,1259.25,70,0,'2016-09-24 19:44:06',2.02085,0,0,0,0),(148,148,0,112.765,0,0,0.6,60000,1192.94,70,0,'2016-09-24 09:25:02',4.76611,0,0,0,0),(149,149,0,112.48,0,0,0.6,60000,1186.34,70,0,'2016-09-24 16:49:49',1.10387,0,0,0,0),(150,150,0,112.1,0,0,0.6,60000,1267.68,70,80,'2016-09-24 21:18:46',0,0,0,0,0),(151,151,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(152,152,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(153,153,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(154,154,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(155,155,0,114.665,0,0,0.6,60000,1209.41,70,0,'2016-09-24 11:21:42',0,0,0,0,0),(156,156,0,112.195,0,0,0.6,60000,1185.73,70,0,'2016-09-24 14:42:58',0,0,0,0,0),(157,157,0,110.58,0,0,0.6,60000,1169.85,70,0,'2016-09-24 10:04:00',0,0,0,0,0),(158,158,0,0,0,0,0.6,60000,1156.74,70,1151,'2016-09-24 19:33:09',0,0,0,0,0),(159,159,0,113.05,0,0,0.6,60000,1202.81,70,6,'2016-09-24 12:19:40',32.478,0,0,0,0),(160,160,0,110.58,0,0,0.6,60000,1171.03,70,0,'2016-09-24 12:44:35',0,0,0,0,0),(161,161,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(162,162,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(163,163,0,111.15,0,0,0.6,60000,1277.13,70,104,'2016-09-24 21:38:40',0,0,0,0,0),(164,164,0,119.51,0,0,0.6,60000,1061.57,70,0,'2016-09-24 14:38:44',0,0,0,0,0),(165,165,40,50,0,0,0.6,60000,2722.73,110,14,'2016-09-28 21:09:32',0,0,0,0,0),(166,166,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(167,167,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(168,168,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(169,169,0,0,0,0,0.6,59900,0,70,200,'2016-09-17 14:22:26',0,0,0,0,0),(170,170,0,100.32,0,0,0.6,60000,1064.22,70,3,'2016-09-24 22:04:11',0,0,0,0,0),(171,171,0,113.525,0,0,0.6,60000,1200.94,70,0,'2016-09-24 19:41:13',0,0,0,0,0),(172,172,0,112.86,0,0,0.6,59900,1089.3,70,0,'2016-09-24 16:12:10',0,0,0,0,0),(173,173,0,111.08,0,0,0.6,60000,1269.04,70,42,'2016-09-24 21:33:01',0,0,0,0,0),(174,174,0,89.01,0,0,0.6,60000,992.876,70,0,'2016-09-23 13:14:43',174.72,0,0,0,0),(175,175,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(176,176,0,109.44,0,0,0.6,60000,1056.02,70,0,'2016-09-24 14:30:42',0,0,0,0,0),(177,177,0,94.525,0,0,0.6,60000,998.458,70,0,'2016-09-24 22:37:47',0,0,0,0,0),(178,178,0,0,0,0,0.6,60000,1056.43,70,1053,'2016-09-24 22:22:12',0,0,0,0,0),(179,179,0,111.15,0,0,0.6,60000,1198.72,70,25,'2016-09-24 17:54:57',0,0,0,0,0),(180,180,0,108.015,0,0,0.6,59900,1023.97,70,85,'2016-09-24 12:08:42',25.3097,0,0,0,0),(181,181,0,0,0,0,0.6,60000,5.84883,70,5,'2016-09-17 16:20:48',0,0,0,0,0),(182,182,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(183,183,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(184,184,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 15:53:51',0,0,0,0,0),(185,185,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(186,186,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(187,187,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(188,188,0,115.015,0,0,0.6,60000,1240.88,70,0,'2016-09-24 18:25:41',0,0,0,0,0),(189,189,0,28.5,0,0,0.6,60000,964.152,70,660,'2016-09-29 11:30:45',0,0,0,0,0),(190,190,0,113.85,0,0,0.6,60000,1232.49,70,0,'2016-09-24 18:42:48',0,0,0,0,0),(191,191,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(192,192,0,101.83,0,0,0.6,60000,1268.57,70,157,'2016-09-24 22:13:06',0,0,0,0,0),(193,193,0,112.575,0,0,0.6,60000,1190.17,70,0,'2016-09-24 17:29:59',0,0,0,0,0),(194,194,0,110.105,0,0,0.6,60000,1169.84,70,0,'2016-09-24 12:52:20',0,0,0,0,0),(195,195,0,0,0,0,0.6,60000,1117.86,70,1112,'2016-09-24 16:50:07',0,0,0,0,0),(196,196,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(197,197,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(198,198,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(199,199,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(200,200,0,106.21,0,0,0.6,59800,962.155,70,40,'2016-09-24 17:20:21',0.498819,0,0,0,0),(201,201,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(202,202,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(203,203,0,77.22,0,0,0.6,60000,1039.69,70,175,'2016-09-24 17:24:13',0,0,0,0,0),(204,204,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(205,205,0,110.22,0,0,0.6,60000,1180.48,70,0,'2016-09-24 18:20:58',0,0,0,0,0),(206,206,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(207,207,0,0,0,0,0.6,60000,19.7431,70,19,'2016-09-17 20:29:55',0,0,0,0,0),(208,208,0,106.02,0,0,0.6,60000,1127.36,70,7,'2016-09-24 20:02:55',0,0,0,0,0),(209,209,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(210,210,0,0,0,0,0.6,60000,1.21911,70,1,'2016-09-17 17:57:49',0,0,0,0,0),(211,211,0,114,0,0,0.6,60000,1339.73,70,131,'2016-09-25 12:31:50',174.72,0,0,0,0),(212,212,0,0,0,0,0.6,60000,1021.2,70,1017,'2016-09-24 22:01:59',0,0,0,0,0),(213,213,0,0,0,0,0.6,60000,8.17314,70,8,'2016-09-17 21:21:12',0,0,0,0,0),(214,214,0,0,0,0,0.6,60000,1013.05,70,1005,'2016-09-24 22:11:30',0,0,0,0,0),(215,215,0,113.43,0,0,0.6,60000,1198.16,70,0,'2016-09-24 16:46:19',0,0,0,0,0),(216,216,0,113.24,0,0,0.6,60000,1247.08,70,51,'2016-09-24 23:23:37',0,0,0,0,0),(217,217,0,112.48,0,0,0.6,60000,1881.23,70,687,'2016-09-28 18:31:18',0,0,0,0,0),(218,218,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(219,219,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(220,220,0,113.05,0,0,0.6,60000,1192.92,70,0,'2016-09-24 16:38:41',0.474469,0,0,0,0),(221,221,0,111.91,0,0,0.6,60000,1213.53,70,27,'2016-09-24 20:57:38',0,0,0,0,0),(222,222,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(223,223,0,66.975,0,0,0.6,60000,707.913,70,0,'2016-09-24 20:14:47',0,0,0,0,0),(224,224,0,109.915,0,0,0.6,60000,1180.19,70,20,'2016-09-24 14:37:54',41.7579,0,0,0,0),(225,225,0,112.955,0,0,0.6,60000,1193.04,70,0,'2016-09-24 18:18:46',3.94516,0,0,0,0),(226,226,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(227,227,0,110.39,0,0,0.6,60000,1170.21,70,4,'2016-09-24 15:53:06',21.4159,0,0,0,0),(228,228,0,0,0,0,0.6,60000,176.114,70,175,'2016-09-18 21:12:01',0,0,0,0,0),(229,229,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(230,230,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(231,231,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(232,232,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(233,233,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(234,234,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(235,235,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(236,236,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(237,237,0,114.855,0,0,0.6,60000,1229.75,70,16,'2016-09-24 22:14:17',0,0,0,0,0),(238,238,0,0,0,0,0.6,60000,1193.14,70,1189,'2016-09-24 21:04:44',0,0,0,0,0),(239,239,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(240,240,0,117.135,0,0,0.6,60000,1039.58,70,0,'2016-09-24 20:28:17',0,0,0,0,0),(241,241,0,0,0,0,0.6,60000,960.16,70,956,'2016-09-24 08:51:17',0,0,0,0,0),(242,242,0,111.34,0,0,0.6,60000,1177.52,70,0,'2016-09-24 18:28:25',0,0,0,0,0),(243,243,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(244,244,0,114.665,0,0,0.6,60000,1211.23,70,0,'2016-09-24 20:31:13',0,0,0,0,0),(245,245,0,0,0,0,0.6,60000,172.025,70,172,'2016-09-18 21:48:31',0,0,0,0,0),(246,246,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(247,247,0,85.12,0,0,0.6,60000,853.81,70,152,'2016-09-24 19:03:48',0,0,0,0,0),(248,248,0,112.195,0,0,0.6,60000,1183.79,70,0,'2016-09-24 18:56:23',0,0,0,0,0),(249,249,0,110.01,0,0,0.6,60000,1164.29,70,0,'2016-09-24 20:40:23',0.382132,0,0,0,0),(250,250,0,111.72,0,0,0.6,60000,1179.64,70,0,'2016-09-24 19:06:28',0,0,0,0,0),(251,251,0,112.575,0,0,0.6,60000,1188.78,70,0,'2016-09-24 20:17:16',0,0,0,0,0),(252,252,10,0,0,0,0.6,60000,670.491,75,668,'2016-09-22 09:33:38',0,0,0,0,0),(253,253,0,0,0,0,0.6,60000,0.855104,70,0,'2016-09-18 13:16:07',0,0,0,0,0),(254,254,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(255,255,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(256,256,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(257,257,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(258,258,0,0,0,0,0.6,60000,0,70,0,'2016-09-18 20:17:41',0,0,0,0,0),(259,259,0,0,0,0,0.6,60000,0,70,0,'2016-09-18 20:20:47',0,0,0,0,0),(260,260,0,0,0,0,0.6,60000,255.056,70,253,'2016-09-28 11:20:41',0,0,0,0,0),(261,261,0,0,0,0,0.6,60000,1226.4,70,1221,'2016-09-29 08:12:30',0,0,0,0,0),(262,262,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(263,263,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(264,264,0,74,0,0,0.6,60000,990.973,70,187,'2016-09-27 17:28:17',0,0,0,0,0),(265,265,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(266,266,0,0,0,0,0.6,60000,0,70,0,'2016-09-19 22:49:59',0,0,0,0,0),(267,267,0,0,0,0,0.6,60000,0,70,0,'2016-09-19 22:54:19',0,0,0,0,0),(268,268,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(269,269,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(270,270,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(271,271,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(272,272,50,0,0,0,0.6,60000,1863.73,155,21859,'2016-09-29 19:08:37',0,0,0,0,1),(273,273,0,0,0,0,0.6,60000,684.549,70,682,'2016-09-29 19:09:21',0,0,0,0,0),(274,274,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(275,275,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(276,276,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(277,277,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(278,278,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(279,279,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(280,280,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(281,281,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(282,282,0,0,0,0,0.6,60000,1.74087,70,1,'2016-09-20 23:11:56',0,0,0,0,0),(283,283,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(284,284,0,0,0,0,0.6,60000,0,70,0,'2016-09-20 23:30:23',0,0,0,0,0),(285,285,0,0,0,0,0.6,60000,0,70,0,'2016-09-20 23:38:05',0,0,0,0,0),(286,286,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(287,287,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(288,288,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(289,289,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(290,290,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(291,291,0,0,0,0,0.6,60000,0,70,0,'2016-09-21 14:28:20',0,0,0,0,0),(292,292,0,4,0,0,0.6,60000,1518.02,81,314,'2016-09-29 21:13:26',0,0,0,0,0),(293,293,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(294,294,0,0,0,0,0.6,60000,0,70,0,'2016-09-22 09:32:09',0,0,0,0,0),(295,295,0,0,0,0,0.6,60000,0,70,0,'2016-09-22 09:58:14',0,0,0,0,0),(296,296,0,0,0,0,0.6,60000,0,70,0,'2016-09-22 10:13:28',0,0,0,0,0),(297,297,0,0,0,0,0.6,60000,0,70,0,'2016-09-22 17:08:08',0,0,0,0,0),(298,298,400,279.165,0,348,0.6,60000,9255.8,590,5291,'2016-09-29 08:42:49',0,0,0,0,1),(299,299,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(300,300,0,0,0,0,0.6,60000,0,70,0,'2016-09-23 02:56:28',0,0,0,0,0),(301,301,0,0,0,0,0.6,60000,349.44,70,348,'2016-09-28 09:02:35',0,348,0,0,0),(302,302,0,33.06,0,0,0.6,60000,349.44,70,0,'2016-09-28 09:03:28',0,0,0,0,0),(303,303,0,33.06,0,0,0.6,60000,349.44,70,0,'2016-09-28 09:03:52',0,0,0,0,0),(304,304,0,33.06,0,0,0.6,60000,349.44,70,0,'2016-09-28 09:04:22',0,0,0,0,0),(305,305,0,0,0,0,0.6,60000,586.177,70,584,'2016-09-28 14:43:52',0,0,0,0,0),(306,306,0,28.5,0,0,0.6,60000,349.44,70,48,'2016-09-29 08:51:10',0,0,0,0,0),(307,307,0,0,0,0,0.6,60000,0,70,0,'2016-09-24 16:06:35',0,0,0,0,0),(308,308,0,0,0,0,0.6,60000,0,70,0,'2016-09-24 16:27:48',0,0,0,0,0),(309,309,0,0,0,0,0.6,60000,0,70,0,'2016-09-24 16:33:03',0,0,0,0,0),(310,310,0,0,0,0,0.6,60000,0,70,0,'2016-09-24 16:47:17',0,0,0,0,0),(311,311,0,0,0,0,0.6,60000,0.187327,70,0,'2016-09-24 17:54:38',0,0,0,0,0),(313,313,0,11433.3,0,85667,0.6,60000,0,70,85667,'2016-09-24 21:01:56',174.72,0,0,0,0),(314,314,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(315,315,0,29.545,0,0,0.6,60000,661.49,70,348,'2016-09-29 16:58:56',0,0,0,0,0),(316,316,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(317,317,0,0,0,0,0.6,60000,0,70,0,'2016-09-25 18:17:07',0,0,0,0,0),(318,318,0,0,0,0,0.6,60000,174.72,70,174,'2016-09-28 09:04:41',0,0,0,0,0),(319,319,5,33.725,0,500,0.6,60000,356.998,72,0,'2016-09-29 09:39:13',32.641,0,0,0,0),(320,320,0,33.06,0,0,0.6,60000,349.353,70,0,'2016-09-29 10:10:50',0,0,0,0,0),(321,321,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(322,322,0,0,0,0,0.6,60000,388.588,70,387,'2016-09-29 23:25:03',0,0,0,0,0),(323,323,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(324,324,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(325,325,0,0,0,0,0.6,60000,335.76,70,333,'2016-09-29 11:38:36',0,0,0,0,0),(326,326,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(327,327,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(328,328,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(329,329,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(330,330,0,0,0,0,0.6,60000,29.022,70,29,'2016-09-28 14:19:09',0,0,0,0,0),(331,331,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(332,332,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(333,333,0,0,0,0,0.6,60000,0,70,0,'2016-09-29 12:02:52',0,0,0,0,0);
/*!40000 ALTER TABLE `playerfortuneinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-30  2:01:50
