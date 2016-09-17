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
) ENGINE=InnoDB AUTO_INCREMENT=198 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `playerfortuneinfo`
--

LOCK TABLES `playerfortuneinfo` WRITE;
/*!40000 ALTER TABLE `playerfortuneinfo` DISABLE KEYS */;
INSERT INTO `playerfortuneinfo` VALUES (1,1,61,35,0,8087,0.6,60000,6279.48,300,4317,'2016-09-17 09:13:59',0,0,0,0,1),(2,2,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(3,3,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(4,4,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(5,5,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(6,6,0,0,0,0,0.6,60000,0,70,0,'2016-09-01 15:49:43',0,0,0,0,0),(7,7,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(8,8,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(9,9,0,0,0,0,0.6,60000,1946.79,70,1939,'2016-09-17 10:10:34',0,0,0,0,0),(10,10,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(11,11,0,0,0,0,0.6,60000,650.356,70,648,'2016-09-05 18:47:06',0,0,0,0,0),(12,12,42,18.5,0,14000,0.6,60000,2674.84,125,3350,'2016-09-17 14:43:02',0,1500,0,0,1),(13,13,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(14,14,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(15,15,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(16,16,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(17,17,0,25.65,0,0,0.6,60000,454.989,70,183,'2016-09-14 18:33:41',0,0,0,0,0),(18,18,0,0,0,0,0.6,60000,1024.06,70,1020,'2016-09-16 19:08:51',0,0,0,0,0),(19,19,0,0,0,0,0.6,60000,1849.15,70,1841,'2016-09-16 19:06:40',0,0,0,0,0),(20,20,5,0,0,2500,0.6,60000,1034.99,70,1030,NULL,0,0,0,0,0),(21,21,5,5,0,0,0.6,60000,2213.53,86,1203,'2016-09-17 14:44:40',0,1000,0,0,1),(22,22,1231,285,0,5900,3.6,360000,12579.2,790,14570,'2016-09-16 07:56:23',0,0,0,0,1),(23,23,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(24,24,0,0,0,0,0.6,60000,1339.39,70,1331,'2016-09-12 09:07:52',0,0,0,0,0),(25,25,0,0,0,0,0.6,60000,0,70,0,'2016-09-03 18:24:41',0,0,0,0,0),(26,26,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(27,27,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(28,28,0,0,0,0,0.6,60000,0,70,0,'2016-09-03 19:02:53',0,0,0,0,0),(29,29,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(30,30,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(31,31,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(32,32,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(33,33,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(34,34,0,0,0,0,0.6,60000,327.163,70,324,'2016-09-07 08:11:54',0,0,0,0,0),(35,35,1,119.415,0,500,0.6,60000,1617.32,71,354,'2016-09-17 12:43:19',0,0,0,0,0),(36,36,0,0,0,0,0.6,60000,763.021,70,760,'2016-09-13 19:35:26',0,0,0,0,0),(37,37,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(38,38,0,0,0,0,0.6,60000,176.177,70,175,'2016-09-08 14:45:38',0,0,0,0,0),(39,39,0,0,0,0,0.6,60000,174.72,70,174,'2016-09-08 14:45:34',0,0,0,0,0),(40,40,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 16:14:33',0,0,0,0,0),(41,41,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 16:18:41',0,0,0,0,0),(42,42,0,0,0,0,0.6,60000,0,70,0,'2016-09-06 17:03:28',0,0,0,0,0),(43,43,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(44,44,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(45,45,0,0,0,0,0.6,60000,4844.07,220,4840,'2016-09-17 14:01:12',0,4000,0,0,1),(46,46,0,95,0,0,0.6,60000,1648.09,70,643,'2016-09-17 14:03:38',0,0,0,0,0),(47,47,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(48,48,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(49,49,0,0,0,0,0.6,60000,0,70,0,'2016-09-08 14:32:48',0,0,0,0,0),(50,50,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(51,51,0,0,0,0,0.6,60000,0,70,0,'2016-09-08 21:07:31',0,0,0,0,0),(52,52,0,0,0,0,0.6,60000,345.679,70,344,'2016-09-11 07:54:16',0,0,0,0,0),(53,53,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(54,54,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(55,55,0,0,0,0,0.6,60000,311.003,70,310,'2016-09-11 08:31:53',0,0,0,0,0),(56,56,0,0,0,0,0.6,60000,310.964,70,310,'2016-09-11 08:31:48',0,0,0,0,0),(57,57,0,0,0,0,0.6,60000,310.967,70,310,'2016-09-11 08:31:45',0,0,0,0,0),(58,58,0,0,0,0,0.6,60000,310.943,70,310,'2016-09-11 08:31:38',0,0,0,0,0),(59,59,0,0,0,0,0.6,60000,310.824,70,309,'2016-09-11 08:31:28',0,0,0,0,0),(60,60,0,0,0,0,0.6,60000,310.83,70,309,'2016-09-11 08:31:31',0,0,0,0,0),(61,61,0,0,0,0,0.6,60000,310.86,70,310,'2016-09-11 08:31:42',0,0,0,0,0),(62,62,0,0,0,0,0.6,60000,310.725,70,310,'2016-09-11 08:31:35',0,0,0,0,0),(63,63,0,0,0,0,0.6,60000,310.558,70,309,'2016-09-11 08:31:14',0,0,0,0,0),(64,64,0,0,0,0,0.6,60000,310.693,70,310,'2016-09-11 08:31:21',0,0,0,0,0),(65,65,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(66,66,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(67,67,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(68,68,0,0,0,0,0.6,60000,1.83169,70,1,'2016-09-09 22:46:25',0,0,0,0,0),(69,69,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(70,70,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(71,71,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(72,72,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(73,73,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(74,74,0,0,0,0,0.6,60000,96.3399,70,95,'2016-09-10 23:24:54',0,0,0,0,0),(75,75,0,0,0,0,0.6,60000,0,70,0,'2016-09-10 13:56:22',0,0,0,0,0),(76,76,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(77,77,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(78,78,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(79,79,200,0,0,0,0.6,60000,0,370,0,'2016-09-11 07:09:51',0,0,0,0,1),(80,80,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(81,81,1,0,0,3692,0.6,60000,682.75,71,3938,'2016-09-17 13:58:21',0,0,0,0,1),(82,82,10,44.25,0,202,0.6,60000,517.9,75,33,'2016-09-16 07:02:07',48.7735,0,0,0,0),(83,83,0,0,0,0,0.6,60000,0,70,0,'2016-09-13 12:40:52',0,0,0,0,0),(84,84,0,0,0,0,0.6,60000,0,70,0,'2016-09-13 20:07:32',0,0,0,0,0),(85,85,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(86,86,0,0,0,0,0.6,60000,0,70,0,'2016-09-15 08:04:14',0,0,0,0,0),(87,87,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(88,88,0,0,0,0,0.6,60000,185.134,70,183,'2016-09-16 22:46:04',0,0,0,0,0),(89,89,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(90,90,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(91,91,0,0,0,0,0.6,60000,0.269373,70,0,'2016-09-16 06:25:12',0,0,0,0,0),(92,92,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(93,93,0,0,0,0,0.6,60000,0,70,0,'2016-09-16 06:29:23',0,0,0,0,0),(94,94,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(95,95,0,0,0,0,0.6,60000,113.866,70,113,'2016-09-17 11:07:49',0,0,0,0,0),(96,96,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(97,97,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(98,98,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(99,99,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(100,100,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(101,101,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(102,102,0,0,0,0,0.6,60000,1.093,70,1,'2016-09-17 14:22:20',0,0,0,0,0),(103,103,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(104,104,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(105,105,0,0,0,0,0.6,60000,0.125713,70,0,'2016-09-17 11:30:49',0,0,0,0,0),(106,106,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(107,107,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(108,108,0,0,0,0,0.6,60000,4.50035,70,4,'2016-09-17 12:36:36',0,0,0,0,0),(109,109,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(110,110,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(111,111,0,0,0,0,0.6,60000,19.1085,70,19,'2016-09-17 14:17:17',0,0,0,0,0),(113,113,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(114,114,0,0,0,0,0.6,60000,18.4855,70,18,'2016-09-17 14:11:45',0,0,0,0,0),(115,115,0,0,0,0,0.6,60000,13.9822,70,13,'2016-09-17 13:43:52',0,0,0,0,0),(116,116,0,0,0,0,0.6,60000,3.17621,70,3,'2016-09-17 14:27:49',0,0,0,0,0),(117,117,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(118,118,0,0,0,0,0.6,60000,9.36,70,9,'2016-09-17 15:02:08',0,0,0,0,0),(119,119,0,0,0,0,0.6,60000,0.262119,70,0,'2016-09-17 11:47:55',0,0,0,0,0),(120,120,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 11:46:06',0,0,0,0,0),(121,121,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(122,122,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(123,123,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(124,124,0,0,0,0,0.6,60000,16.1028,70,16,'2016-09-17 14:03:13',0,0,0,0,0),(125,125,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(126,126,0,0,0,0,0.6,60000,1.28528,70,1,'2016-09-17 12:06:14',0,0,0,0,0),(127,127,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(128,128,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(129,129,0,0,0,0,0.6,60000,1.07396,70,1,'2016-09-17 14:43:09',0,0,0,0,0),(130,130,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(131,131,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 12:08:28',0,0,0,0,0),(132,132,0,0,0,0,0.6,60000,0.0975328,70,0,'2016-09-17 12:01:16',0,0,0,0,0),(133,133,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(134,134,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(135,135,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(136,136,0,0,0,0,0.6,60000,19.3719,70,19,'2016-09-17 15:04:22',0,0,0,0,0),(137,137,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(138,138,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(139,139,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 12:24:09',0,0,0,0,0),(140,140,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(141,141,0,0,0,0,0.6,60000,1.09914,70,1,'2016-09-17 14:48:25',0,0,0,0,0),(142,142,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(143,143,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(144,144,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(145,145,0,0,0,0,0.6,60000,5.09745,70,5,'2016-09-17 14:47:00',0,0,0,0,0),(146,146,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(147,147,0,0,0,0,0.6,60000,0.945786,70,0,'2016-09-17 14:28:39',0,0,0,0,0),(148,148,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(149,149,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(150,150,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(151,151,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(152,152,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(153,153,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(154,154,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(155,155,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 13:11:54',0,0,0,0,0),(156,156,0,0,0,0,0.6,60000,4.48872,70,4,'2016-09-17 14:11:27',0,0,0,0,0),(157,157,0,0,0,0,0.6,60000,12.3992,70,12,'2016-09-17 15:11:30',0,0,0,0,0),(158,158,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(159,159,0,0,0,0,0.6,60000,16.6685,70,16,'2016-09-17 15:50:25',0,0,0,0,0),(160,160,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(161,161,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(162,162,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(163,163,0,0,0,0,0.6,60000,11.0004,70,11,'2016-09-17 15:16:10',0,0,0,0,0),(164,164,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(165,165,0,0,0,0,0.6,60000,9.2786,70,9,'2016-09-17 15:09:49',0,0,0,0,0),(166,166,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(167,167,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(168,168,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(169,169,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(170,170,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(171,171,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(172,172,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(173,173,0,0,0,0,0.6,60000,8.26887,70,5,'2016-09-17 15:36:25',0,0,0,0,0),(174,174,0,0,0,0,0.6,60000,9.06507,70,9,'2016-09-17 15:57:40',0,0,0,0,0),(175,175,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(176,176,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 14:50:39',0,0,0,0,0),(177,177,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 14:50:45',0,0,0,0,0),(178,178,0,0,0,0,0.6,60000,5.05736,70,5,'2016-09-17 15:48:32',0,0,0,0,0),(179,179,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(180,180,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(181,181,0,0,0,0,0.6,60000,0.256484,70,0,'2016-09-17 15:29:13',0,0,0,0,0),(182,182,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(183,183,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(184,184,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 15:53:51',0,0,0,0,0),(185,185,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(186,186,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(187,187,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(188,188,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(189,189,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(190,190,0,0,0,0,0.6,60000,0,70,0,'2016-09-17 15:42:04',0,0,0,0,0),(191,191,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(192,192,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(193,193,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(194,194,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(195,195,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(196,196,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0),(197,197,0,0,0,0,0.6,60000,0,70,0,NULL,0,0,0,0,0);
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

-- Dump completed on 2016-09-17 16:01:34
