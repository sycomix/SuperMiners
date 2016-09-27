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
-- Table structure for table `goldcoinrechargerecord`
--

DROP TABLE IF EXISTS `goldcoinrechargerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `goldcoinrechargerecord` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OrderNumber` varchar(35) NOT NULL,
  `UserID` int(11) unsigned NOT NULL,
  `SpendRMB` float unsigned NOT NULL,
  `GainGoldCoin` float unsigned NOT NULL,
  `CreateTime` datetime NOT NULL,
  `PayTime` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `OrderNumber_UNIQUE` (`OrderNumber`),
  KEY `userinfo_id_goldcoinrechargerecord_userid_idx` (`UserID`),
  CONSTRAINT `userinfo_id_goldcoinrechargerecord_userid` FOREIGN KEY (`UserID`) REFERENCES `playersimpleinfo` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=89 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goldcoinrechargerecord`
--

LOCK TABLES `goldcoinrechargerecord` WRITE;
/*!40000 ALTER TABLE `goldcoinrechargerecord` DISABLE KEYS */;
INSERT INTO `goldcoinrechargerecord` VALUES (1,'201609081233500040224454765443981',12,10,1000,'2016-09-08 12:33:50','0001-01-01 00:00:00'),(5,'201609081906450918221256081061646',1,1000,150000,'2016-09-08 19:06:46','0001-01-01 00:00:00'),(9,'201609092231280217224454765441782',12,10,1500,'2016-09-09 22:31:28','0001-01-01 00:00:00'),(10,'201609092232250703224454765447354',12,10,1500,'2016-09-09 22:32:26','0001-01-01 00:00:00'),(11,'201609092233090143224454765443650',12,10,1500,'2016-09-09 22:33:09','0001-01-01 00:00:00'),(12,'201609092233520308224454765444961',12,20,3000,'2016-09-09 22:33:52','0001-01-01 00:00:00'),(13,'201609092235070502221256081065992',1,500,75000,'2016-09-09 22:35:08','0001-01-01 00:00:00'),(14,'201609092238560068224454765442164',12,10,1500,'2016-09-09 22:38:56','0001-01-01 00:00:00'),(15,'201609092244500142221256081064957',1,10,1500,'2016-09-09 22:44:50','0001-01-01 00:00:00'),(16,'201609092341260382224454765446189',12,20,3000,'2016-09-09 23:41:26','0001-01-01 00:00:00'),(17,'201609092342290827224454765441271',12,10,1500,'2016-09-09 23:42:30','0001-01-01 00:00:00'),(18,'201609092343330795224454765445793',12,30,4500,'2016-09-09 23:43:34','0001-01-01 00:00:00'),(19,'201609092351460408224454765445199',12,10,1500,'2016-09-09 23:51:46','0001-01-01 00:00:00'),(20,'201609100013110413224454765449957',12,10,1500,'2016-09-10 00:13:11','0001-01-01 00:00:00'),(21,'2016091107070801042212565283385673',79,1000,150000,'2016-09-11 07:07:08','0001-01-01 00:00:00'),(22,'2016091107084304822212565283382732',79,1000,150000,'2016-09-11 07:08:43','0001-01-01 00:00:00'),(27,'201609111557480864224454765447307',12,10,1500,'2016-09-11 15:57:49','0001-01-01 00:00:00'),(29,'201609111558510756224454765441260',12,20,3000,'2016-09-11 15:58:52','0001-01-01 00:00:00'),(30,'201609111559560146224454765445655',12,15,2250,'2016-09-11 15:59:56','0001-01-01 00:00:00'),(32,'201609111625200292224454765442750',12,30,4500,'2016-09-11 16:25:20','0001-01-01 00:00:00'),(33,'201609111625580324224454765447436',12,10,1500,'2016-09-11 16:25:58','0001-01-01 00:00:00'),(34,'201609111626340870224454765448137',12,15,2250,'2016-09-11 16:26:35','0001-01-01 00:00:00'),(35,'201609111629290007224454765449435',12,10,1500,'2016-09-11 16:29:29','0001-01-01 00:00:00'),(37,'201609111630380885224454765444655',12,15,2250,'2016-09-11 16:30:39','0001-01-01 00:00:00'),(39,'201609111631320381224454765442444',12,10,1500,'2016-09-11 16:31:32','0001-01-01 00:00:00'),(46,'201609111917320263224454765444109',12,10,1500,'2016-09-11 19:17:32','0001-01-01 00:00:00'),(47,'201609111918330227224454765447620',12,10,1500,'2016-09-11 19:18:33','0001-01-01 00:00:00'),(48,'201609111919110866224454765447949',12,20,3000,'2016-09-11 19:19:12','0001-01-01 00:00:00'),(50,'201609112027130814224454765444156',12,10,1500,'2016-09-11 20:27:14','0001-01-01 00:00:00'),(51,'201609112029460646224454765446099',12,20,3000,'2016-09-11 20:29:47','0001-01-01 00:00:00'),(52,'201609112051450337224454765446034',12,20,3000,'2016-09-11 20:51:45','0001-01-01 00:00:00'),(53,'201609112052500276224454765443628',12,10,1500,'2016-09-11 20:52:50','0001-01-01 00:00:00'),(54,'201609112058010644224454765445267',12,10,1500,'2016-09-11 20:58:02','0001-01-01 00:00:00'),(55,'201609120942000533224454765445562',12,10,1500,'2016-09-12 09:42:01','0001-01-01 00:00:00'),(56,'2016091213215306942210128627732578',21,500,75000,'2016-09-12 13:21:54','0001-01-01 00:00:00'),(57,'201609121420360407225386301807801',81,10,1500,'2016-09-12 14:20:36','0001-01-01 00:00:00'),(58,'2016091617221503122210128627735818',21,80,12000,'2016-09-16 17:22:15','2016-09-16 17:22:15'),(59,'2016091619172601762210128627737679',21,10,1500,'2016-09-16 19:17:26','2016-09-16 19:17:26'),(60,'201609171320500013224454765443936',12,10,1500,'2016-09-17 13:20:50','2016-09-17 13:21:19'),(61,'201609171325490401224454765443170',12,10,1500,'2016-09-17 13:25:49','2016-09-17 13:25:49'),(62,'201609171326030202224454765442288',12,10,1500,'2016-09-17 13:26:03','2016-09-17 13:26:36'),(63,'201609171328210280224454765446271',12,10,1500,'2016-09-17 13:28:21','2016-09-17 13:28:42'),(64,'201609171331380163224454765444854',12,10,1500,'2016-09-17 13:31:38','2016-09-17 13:31:59'),(65,'201609182223310323224454765442118',12,10,1000,'2016-09-18 22:23:31','2016-09-18 22:23:31'),(66,'201609182223510100224454765442974',12,10,1000,'2016-09-18 22:23:51','2016-09-18 22:23:51'),(67,'201609182223580598224454765444683',12,10,1000,'2016-09-18 22:23:59','2016-09-18 22:24:31'),(68,'201609182236390406224454765441189',12,15,1500,'2016-09-18 22:36:39','2016-09-18 22:37:02'),(69,'2016092007320500942212089844038324',126,20,2000,'2016-09-20 07:32:05','2016-09-20 07:32:05'),(70,'2016092008365302872217671406325390',95,20,2000,'2016-09-20 08:36:53','2016-09-20 08:36:53'),(71,'201609201853090532222041954195604',272,500,50000,'2016-09-20 18:53:10','2016-09-20 18:54:04'),(72,'2016092023204903122213494335108288',165,25,2500,'2016-09-20 23:20:49','2016-09-20 23:20:49'),(73,'201609211916360543222087488301671',45,400,40000,'2016-09-21 19:16:37','2016-09-21 19:16:37'),(74,'201609211918020310222087488304636',45,70,7000,'2016-09-21 19:18:02','2016-09-21 19:18:02'),(75,'201609211919180714222087488308493',45,180,18000,'2016-09-21 19:19:19','2016-09-21 19:19:19'),(76,'2016092122284403102213494335108640',165,25,2500,'2016-09-21 22:28:44','2016-09-21 22:28:44'),(77,'2016092208210905362217671406329004',95,30,3000,'2016-09-22 08:21:10','2016-09-22 08:21:10'),(78,'2016092218094706392218867686343195',88,92,9200,'2016-09-22 18:09:48','2016-09-22 18:09:48'),(79,'2016092218314506172221463269135042',298,4000,400000,'2016-09-22 18:31:46','2016-09-22 18:32:27'),(80,'2016092308284406032212089844032210',126,30,3000,'2016-09-23 08:28:45','2016-09-23 08:28:45'),(81,'2016092408102004622217671406329859',95,30,3000,'2016-09-24 08:10:20','2016-09-24 08:10:20'),(82,'2016092410111902652213494335102117',165,50,5000,'2016-09-24 10:11:19','2016-09-24 10:11:19'),(83,'201609242100530785225647914457260',292,30,3000,'2016-09-24 21:00:54','2016-09-24 21:00:54'),(84,'2016092508435907552217671406326770',95,30,3000,'2016-09-25 08:44:00','2016-09-25 08:44:00'),(85,'2016092511191607652213494335109411',165,25,2500,'2016-09-25 11:19:17','2016-09-25 11:19:17'),(86,'201609261947550091225647914456301',292,40,4000,'2016-09-26 19:47:55','2016-09-26 19:47:55'),(87,'2016092701470301562213494335101075',165,25,2500,'2016-09-27 01:47:03','2016-09-27 01:47:03'),(88,'2016092708493309772217671406323620',95,30,3000,'2016-09-27 08:49:34','2016-09-27 08:49:34');
/*!40000 ALTER TABLE `goldcoinrechargerecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-27 13:37:49
