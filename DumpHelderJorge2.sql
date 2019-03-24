-- MySQL dump 10.13  Distrib 8.0.14, for Win64 (x86_64)
--
-- Host: localhost    Database: maisfuturo
-- ------------------------------------------------------
-- Server version	8.0.14

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
-- Table structure for table `aluno`
--

DROP TABLE IF EXISTS `aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aluno` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Frequencia` varchar(15) NOT NULL DEFAULT '5X',
  `Ano` varchar(2) NOT NULL,
  `Turma` varchar(5) DEFAULT NULL,
  `Escola` varchar(10) DEFAULT NULL,
  `Disciplinas` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno`
--

LOCK TABLES `aluno` WRITE;
/*!40000 ALTER TABLE `aluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nota`
--

DROP TABLE IF EXISTS `nota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `nota` (
  `Ano` varchar(2) NOT NULL,
  `Tipo` varchar(5) NOT NULL,
  `Resultado` decimal(4,2) unsigned NOT NULL,
  `ID_Aluno` int(10) unsigned NOT NULL,
  PRIMARY KEY (`Ano`,`Tipo`),
  KEY `ID_Aluno_FK_idx` (`ID_Aluno`),
  CONSTRAINT `ID_Aluno_FK` FOREIGN KEY (`ID_Aluno`) REFERENCES `aluno` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nota`
--

LOCK TABLES `nota` WRITE;
/*!40000 ALTER TABLE `nota` DISABLE KEYS */;
/*!40000 ALTER TABLE `nota` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resultadoteste`
--

DROP TABLE IF EXISTS `resultadoteste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `resultadoteste` (
  `ID_Aluno` int(10) unsigned NOT NULL,
  `ID_Teste` int(10) unsigned NOT NULL,
  `Nota` decimal(4,2) unsigned NOT NULL,
  PRIMARY KEY (`ID_Aluno`,`ID_Teste`),
  KEY `ID_Teste_idx` (`ID_Teste`),
  CONSTRAINT `ID_Aluno` FOREIGN KEY (`ID_Aluno`) REFERENCES `aluno` (`ID`) ON UPDATE CASCADE,
  CONSTRAINT `ID_Teste` FOREIGN KEY (`ID_Teste`) REFERENCES `teste` (`ID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resultadoteste`
--

LOCK TABLES `resultadoteste` WRITE;
/*!40000 ALTER TABLE `resultadoteste` DISABLE KEYS */;
/*!40000 ALTER TABLE `resultadoteste` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teste`
--

DROP TABLE IF EXISTS `teste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `teste` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Data` date NOT NULL,
  `Disciplina` varchar(10) NOT NULL,
  `Ano` varchar(2) NOT NULL,
  `Turma` varchar(5) NOT NULL,
  `Escola` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teste`
--

LOCK TABLES `teste` WRITE;
/*!40000 ALTER TABLE `teste` DISABLE KEYS */;
INSERT INTO `teste` VALUES (2,'2019-03-09','Português','10','A','Espjal'),(3,'2019-03-15','FQ','11','A','Espjal'),(4,'2019-03-15','Fisica','12','B','Espjal'),(5,'2019-03-11','Fisica','12','B','Espjal'),(6,'2019-04-08','Fisica','12','C','Espjal'),(7,'2019-02-28','BG','10','A','Espjal'),(8,'2019-03-08','Português','10','C','Espjal'),(10,'2019-03-15','Filosofia','10','A','Espjal'),(11,'2019-03-30','FQ','10','A','Espjal'),(13,'2019-03-07','BG','10','A','Espjal');
/*!40000 ALTER TABLE `teste` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-28 13:44:04
