CREATE DATABASE  IF NOT EXISTS `dbgrafischekaarten` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `dbgrafischekaarten`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: dbgrafischekaarten
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblartikelen`
--

DROP TABLE IF EXISTS `tblartikelen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblartikelen` (
  `artikelnr` int(11) NOT NULL AUTO_INCREMENT,
  `naam` varchar(45) DEFAULT NULL,
  `voorraad` int(11) DEFAULT NULL,
  `prijs` double DEFAULT NULL,
  `foto` varchar(99) DEFAULT NULL,
  PRIMARY KEY (`artikelnr`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblartikelen`
--

LOCK TABLES `tblartikelen` WRITE;
/*!40000 ALTER TABLE `tblartikelen` DISABLE KEYS */;
INSERT INTO `tblartikelen` VALUES (1,'GIGABYTE GeForce RTX 2070 Windforce 8G',101,560,'GIGABYTEGeForceRTX2070Windforce8G.jpg'),(2,'GIGABYTE GeForce RTX 2080 WINDFORCE',52,779,'GIGABYTEGeForceRTX2080WINDFORCE.jpg'),(3,'ASUS Turbo GeForce RTX 2080 Ti',75,1379,'ASUSTurboGeForceRTX2080Ti.jpg'),(4,'MSI GeForce RTX 2060 VENTUS 6G OC',26,399,'MSIGeForceRTX2060VENTUS6GOC.jpg'),(5,'ASUS GeForce RTX 2060 ROG Strix Gaming',49,484,'ASUSGeForceRTX2060ROGStrixGaming.jpg'),(6,'ZOTAC Zota GAMING RTX 2080 Ti ArcticStorm',84,1829,'ZOTACZotaGAMINGRTX2080TiArcticStorm.jpg');
/*!40000 ALTER TABLE `tblartikelen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblbestellijnen`
--

DROP TABLE IF EXISTS `tblbestellijnen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblbestellijnen` (
  `ordernr` int(11) NOT NULL,
  `artikelnr` varchar(45) NOT NULL,
  `aantal` int(11) DEFAULT NULL,
  `prijs` double DEFAULT NULL,
  PRIMARY KEY (`ordernr`,`artikelnr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblbestellijnen`
--

LOCK TABLES `tblbestellijnen` WRITE;
/*!40000 ALTER TABLE `tblbestellijnen` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblbestellijnen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblbestellingen`
--

DROP TABLE IF EXISTS `tblbestellingen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblbestellingen` (
  `ordernr` int(11) NOT NULL AUTO_INCREMENT,
  `orderdatum` datetime DEFAULT NULL,
  `klantnr` int(11) DEFAULT NULL,
  PRIMARY KEY (`ordernr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblbestellingen`
--

LOCK TABLES `tblbestellingen` WRITE;
/*!40000 ALTER TABLE `tblbestellingen` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblbestellingen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblklanten`
--

DROP TABLE IF EXISTS `tblklanten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblklanten` (
  `klantnr` int(11) NOT NULL AUTO_INCREMENT,
  `naam` varchar(45) DEFAULT NULL,
  `voornaam` varchar(45) DEFAULT NULL,
  `adres` varchar(45) DEFAULT NULL,
  `postcode` varchar(45) DEFAULT NULL,
  `gemeente` varchar(45) DEFAULT NULL,
  `mail` varchar(45) DEFAULT NULL,
  `gebruikersnaam` varchar(45) DEFAULT NULL,
  `wachtwoord` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`klantnr`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblklanten`
--

LOCK TABLES `tblklanten` WRITE;
/*!40000 ALTER TABLE `tblklanten` DISABLE KEYS */;
INSERT INTO `tblklanten` VALUES (1,'Stassart','Giel','Berkenstraat 28','3850','Nieuwerkerken','giel.stassart@hotmail.com','Giel','Test123');
/*!40000 ALTER TABLE `tblklanten` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblwinkelmanden`
--

DROP TABLE IF EXISTS `tblwinkelmanden`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblwinkelmanden` (
  `klantnr` int(11) NOT NULL,
  `artikelnr` int(11) NOT NULL,
  `aantal` int(11) DEFAULT NULL,
  PRIMARY KEY (`klantnr`,`artikelnr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblwinkelmanden`
--

LOCK TABLES `tblwinkelmanden` WRITE;
/*!40000 ALTER TABLE `tblwinkelmanden` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblwinkelmanden` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-30 13:48:46
