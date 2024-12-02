-- MySQL dump 10.10
--
-- Host: localhost    Database: smart_pos_database
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt

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
-- Table structure for table `tbl_pos_bill_printersettings`
--

DROP TABLE IF EXISTS `tbl_pos_bill_printersettings`;
CREATE TABLE `tbl_pos_bill_printersettings` (
  `ID` int(11) NOT NULL auto_increment,
  `ObjectName` varchar(50) NOT NULL,
  `ValueName` varchar(50) NOT NULL,
  `NeedToPrint` tinyint(4) NOT NULL,
  `LeftMargin` int(11) NOT NULL,
  `TopMargin` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `LabelName` varchar(500) character set utf8 collate utf8_unicode_ci NOT NULL,
  `LblLeftMargain` int(11) NOT NULL,
  `LblTopMargin` int(11) NOT NULL,
  `LblWidth` int(11) NOT NULL,
  `FontSize` int(11) NOT NULL,
  `Hight` int(11) NOT NULL,
  `FontStyle` enum('Regular','Bold','Italic') NOT NULL,
  `FontAlignment` enum('Left','Center','Right','Justified') default NULL,
  `LblFontAlign` enum('Left','Center','Right','Justified') default NULL,
  PRIMARY KEY  (`ObjectName`,`ValueName`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AVG_ROW_LENGTH=162;

--
-- Dumping data for table `tbl_pos_bill_printersettings`
--

LOCK TABLES `tbl_pos_bill_printersettings` WRITE;
/*!40000 ALTER TABLE `tbl_pos_bill_printersettings` DISABLE KEYS */;
INSERT INTO `tbl_pos_bill_printersettings` VALUES (38,'Restaurant_Card_Bill','Balance Amount',0,0,0,0,'',0,0,0,7,0,'Regular','Left','Left'),(39,'Restaurant_Card_Bill','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(32,'Restaurant_Card_Bill','Card Pay Fee',1,2400,600,1560,'Card Pay Fee :',120,600,2700,10,240,'Regular','Right','Left'),(27,'Restaurant_Card_Bill','Casher',1,1320,1120,2400,'Casher :',120,1120,1200,10,240,'Regular','Left','Left'),(23,'Restaurant_Card_Bill','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(24,'Restaurant_Card_Bill','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(22,'Restaurant_Card_Bill','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(28,'Restaurant_Card_Bill','Date',1,720,1330,960,'Date :',120,1320,600,10,240,'Regular','Left','Left'),(35,'Restaurant_Card_Bill','Discoun',1,2400,1200,1560,'Discoun :',120,1200,2700,10,240,'Regular','Right','Left'),(25,'Restaurant_Card_Bill','Invoice No',1,1320,750,2400,'Invoice No :',120,750,1200,10,240,'Regular','Left','Left'),(40,'Restaurant_Card_Bill','Message',1,0,2250,4080,'',0,0,0,10,240,'Regular','Center','Left'),(34,'Restaurant_Card_Bill','Net Total',1,2400,1000,1560,'Net Total :',120,1000,2700,10,240,'Regular','Right','Left'),(37,'Restaurant_Card_Bill','Pay Amount',1,2400,1600,1560,'Pay Amount :',120,1600,2700,10,240,'Regular','Right','Left'),(31,'Restaurant_Card_Bill','Service Charge',1,2400,400,1560,'Service Charge :',120,400,2700,10,240,'Regular','Right','Left'),(42,'Restaurant_Card_Bill','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(41,'Restaurant_Card_Bill','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(30,'Restaurant_Card_Bill','Sub Total',1,2400,200,1560,'Sub Total :',120,200,2700,10,240,'Regular','Right','Left'),(26,'Restaurant_Card_Bill','Table Name',1,1320,950,2400,'Table Name :',120,950,1200,10,240,'Regular','Left','Left'),(33,'Restaurant_Card_Bill','Tax',1,2400,800,1560,'Tax :',120,800,2700,10,240,'Regular','Right','Left'),(29,'Restaurant_Card_Bill','Time',1,2640,1330,960,'Time :',1920,1320,960,10,240,'Regular','Left','Left'),(36,'Restaurant_Card_Bill','Total',1,2400,1400,1560,'Total :',120,1400,2700,10,240,'Bold','Right','Left'),(17,'Restaurant_Cash_Bill','Balance Amount',1,2400,1800,1560,'Balance Amount :',120,1800,2700,10,240,'Regular','Right','Left'),(18,'Restaurant_Cash_Bill','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(11,'Restaurant_Cash_Bill','Card Pay Fee',1,2400,600,1560,'Card Pay Fee :',120,600,2700,10,240,'Regular','Right','Left'),(6,'Restaurant_Cash_Bill','Casher',1,1320,1120,2400,'Casher :',120,1120,1200,10,240,'Regular','Left','Left'),(2,'Restaurant_Cash_Bill','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(3,'Restaurant_Cash_Bill','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(1,'Restaurant_Cash_Bill','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(7,'Restaurant_Cash_Bill','Date',1,720,1330,960,'Date :',120,1320,600,10,240,'Regular','Left','Left'),(14,'Restaurant_Cash_Bill','Discoun',1,2400,1200,1560,'Discoun :',120,1200,2700,10,240,'Regular','Right','Left'),(4,'Restaurant_Cash_Bill','Invoice No',1,1320,750,2400,'Invoice No :',120,750,1200,10,240,'Regular','Left','Left'),(19,'Restaurant_Cash_Bill','Message',1,0,2250,4080,'',0,0,0,10,240,'Regular','Center','Left'),(13,'Restaurant_Cash_Bill','Net Total',1,2400,1000,1560,'Net Total :',120,1000,2700,10,240,'Regular','Right','Left'),(16,'Restaurant_Cash_Bill','Pay Amount',1,2400,1600,1560,'Pay Amount :',120,1600,2700,10,240,'Regular','Right','Left'),(10,'Restaurant_Cash_Bill','Service Charge',1,2400,400,1560,'Service Charge :',120,400,2700,10,240,'Regular','Right','Left'),(21,'Restaurant_Cash_Bill','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(20,'Restaurant_Cash_Bill','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(9,'Restaurant_Cash_Bill','Sub Total',1,2400,200,1560,'Sub Total :',120,200,2700,10,240,'Regular','Right','Left'),(5,'Restaurant_Cash_Bill','Table Name',1,1320,950,2400,'Table Name :',120,950,1200,10,240,'Regular','Left','Left'),(12,'Restaurant_Cash_Bill','Tax',1,2400,800,1560,'Tax :',120,800,2700,10,240,'Regular','Right','Left'),(8,'Restaurant_Cash_Bill','Time',1,2640,1330,960,'Time :',1920,1320,960,10,240,'Regular','Left','Left'),(15,'Restaurant_Cash_Bill','Total',1,2400,1400,1560,'Total :',120,1400,2700,10,240,'Bold','Right','Left'),(50,'Restaurant_Table_Bill','Casher',1,2100,720,1900,'Casher :',120,720,1900,8,240,'Regular','Left','Right'),(45,'Restaurant_Table_Bill','Date',1,720,720,1320,'Date :',120,720,600,10,240,'Regular','Left','Left'),(49,'Restaurant_Table_Bill','Full Total',1,2040,480,1900,'Total :',120,480,1800,10,240,'Regular','Right','Left'),(43,'Restaurant_Table_Bill','Invoice No ',1,1440,240,2000,'Invoice No :',120,240,1320,10,240,'Regular','Left','Left'),(48,'Restaurant_Table_Bill','Service Charge',1,2040,240,1900,'Service Chage :',120,240,1800,10,240,'Regular','Right','Left'),(47,'Restaurant_Table_Bill','Sub Total',1,2040,0,1900,'Sub Total :',120,0,1800,10,240,'Regular','Right','Left'),(44,'Restaurant_Table_Bill','Table Name',1,1440,480,2000,'Table Name :',120,480,1320,10,240,'Regular','Left','Left'),(46,'Restaurant_Table_Bill','Time',1,2640,720,1320,'Time :',2040,720,600,10,240,'Regular','Left','Left'),(75,'Supper_Market_Card_Bill_English','Balance Amount',1,2400,1800,1560,'Balance Amount :',120,1800,2700,10,240,'Regular','Right','Left'),(76,'Supper_Market_Card_Bill_English','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(69,'Supper_Market_Card_Bill_English','Card Pay Fee',1,2400,600,1560,'Card Pay Fee :',120,600,2700,10,240,'Regular','Right','Left'),(64,'Supper_Market_Card_Bill_English','Casher',1,1320,1120,2400,'Casher :',120,1120,1200,10,240,'Regular','Left','Left'),(60,'Supper_Market_Card_Bill_English','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(61,'Supper_Market_Card_Bill_English','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(59,'Supper_Market_Card_Bill_English','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(65,'Supper_Market_Card_Bill_English','Date',1,720,1330,960,'Date :',120,1320,600,10,240,'Regular','Left','Left'),(72,'Supper_Market_Card_Bill_English','Discoun',1,2400,1200,1560,'Discoun :',120,1200,2700,10,240,'Regular','Right','Left'),(62,'Supper_Market_Card_Bill_English','Invoice No',1,1320,750,2400,'Invoice No :',120,750,1200,10,240,'Regular','Left','Left'),(77,'Supper_Market_Card_Bill_English','Message',1,0,2250,4080,'',0,0,0,10,240,'Regular','Center','Left'),(71,'Supper_Market_Card_Bill_English','Net Total',1,2400,1000,1560,'Net Total :',120,1000,2700,10,240,'Regular','Right','Left'),(74,'Supper_Market_Card_Bill_English','Pay Amount',1,2400,1600,1560,'Pay Amount :',120,1600,2700,10,240,'Regular','Right','Left'),(68,'Supper_Market_Card_Bill_English','Service Charge',1,2400,400,1560,'Service Charge :',120,400,2700,10,240,'Regular','Right','Left'),(79,'Supper_Market_Card_Bill_English','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(78,'Supper_Market_Card_Bill_English','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(67,'Supper_Market_Card_Bill_English','Sub Total',1,2400,200,1560,'Sub Total :',120,200,2700,10,240,'Regular','Right','Left'),(63,'Supper_Market_Card_Bill_English','Table Name',1,1320,950,2400,'Table Name :',120,950,1200,10,240,'Regular','Left','Left'),(70,'Supper_Market_Card_Bill_English','Tax',1,2400,800,1560,'Tax :',120,800,2700,10,240,'Regular','Right','Left'),(66,'Supper_Market_Card_Bill_English','Time',1,2640,1330,960,'Time :',1920,1320,960,10,240,'Regular','Left','Left'),(73,'Supper_Market_Card_Bill_English','Total',1,2400,1400,1560,'Total :',120,1400,2700,10,240,'Bold','Right','Left'),(96,'Supper_Market_Card_Bill_Sinhala','Balance Amount',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(97,'Supper_Market_Card_Bill_Sinhala','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(90,'Supper_Market_Card_Bill_Sinhala','Card Pay Fee',1,2400,400,1560,'කාඩ්පත් සදහා අයකිරීම් :',120,400,3100,10,240,'Regular','Right','Left'),(85,'Supper_Market_Card_Bill_Sinhala','Casher',1,2000,1000,2400,'අයකැමි :',120,1000,2000,10,240,'Regular','Left','Left'),(81,'Supper_Market_Card_Bill_Sinhala','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(82,'Supper_Market_Card_Bill_Sinhala','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(80,'Supper_Market_Card_Bill_Sinhala','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(86,'Supper_Market_Card_Bill_Sinhala','Date',1,720,1250,960,'දිනය :',120,1250,960,10,240,'Regular','Left','Left'),(93,'Supper_Market_Card_Bill_Sinhala','Discoun',1,2400,1000,1560,'ඔබ ලැබූ ලාභය :',120,1000,2700,10,240,'Regular','Right','Left'),(83,'Supper_Market_Card_Bill_Sinhala','Invoice No',1,2000,750,2400,'බිල්පත් අංකය :',120,750,2000,10,240,'Regular','Left','Left'),(98,'Supper_Market_Card_Bill_Sinhala','Message',1,0,2250,4080,'',0,0,0,8,240,'Bold','Center','Center'),(92,'Supper_Market_Card_Bill_Sinhala','Net Total',1,2400,800,1560,'මුළු එකතුව :',120,800,2700,10,240,'Regular','Right','Left'),(95,'Supper_Market_Card_Bill_Sinhala','Pay Amount',1,2400,1400,1560,'කාඩ්පත් අගය :',120,1400,2700,10,240,'Regular','Right','Left'),(89,'Supper_Market_Card_Bill_Sinhala','Service Charge',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(100,'Supper_Market_Card_Bill_Sinhala','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(99,'Supper_Market_Card_Bill_Sinhala','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(88,'Supper_Market_Card_Bill_Sinhala','Sub Total',1,2400,200,1560,'එකතුව :',120,200,2700,10,240,'Regular','Right','Left'),(84,'Supper_Market_Card_Bill_Sinhala','Table Name',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(91,'Supper_Market_Card_Bill_Sinhala','Tax',1,2400,600,1560,'Tax :',120,600,2700,10,240,'Regular','Right','Left'),(87,'Supper_Market_Card_Bill_Sinhala','Time',1,2640,1250,960,'වේලාව :',1920,1250,960,10,240,'Regular','Left','Left'),(94,'Supper_Market_Card_Bill_Sinhala','Total',1,2400,1200,1560,'ගෙවිය යුතු මුළු මුදල :',120,1200,2900,10,240,'Bold','Right','Left'),(117,'Supper_Market_Cash_Bill_English','Balance Amount',1,2400,1800,1560,'Balance Amount :',120,1800,2700,10,240,'Regular','Right','Left'),(118,'Supper_Market_Cash_Bill_English','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(111,'Supper_Market_Cash_Bill_English','Card Pay Fee',1,2400,600,1560,'Card Pay Fee :',120,600,2700,10,240,'Regular','Right','Left'),(106,'Supper_Market_Cash_Bill_English','Casher',1,1320,1120,2400,'Casher :',120,1120,1200,10,240,'Regular','Left','Left'),(102,'Supper_Market_Cash_Bill_English','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(103,'Supper_Market_Cash_Bill_English','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(101,'Supper_Market_Cash_Bill_English','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(107,'Supper_Market_Cash_Bill_English','Date',1,720,1330,960,'Date :',120,1320,600,10,240,'Regular','Left','Left'),(114,'Supper_Market_Cash_Bill_English','Discoun',1,2400,1200,1560,'Discoun :',120,1200,2700,10,240,'Regular','Right','Left'),(104,'Supper_Market_Cash_Bill_English','Invoice No',1,1320,750,2400,'Invoice No :',120,750,1200,10,240,'Regular','Left','Left'),(119,'Supper_Market_Cash_Bill_English','Message',1,0,2250,4080,'',0,0,0,10,240,'Regular','Center','Left'),(113,'Supper_Market_Cash_Bill_English','Net Total',1,2400,1000,1560,'Net Total :',120,1000,2700,10,240,'Regular','Right','Left'),(116,'Supper_Market_Cash_Bill_English','Pay Amount',1,2400,1600,1560,'Pay Amount :',120,1600,2700,10,240,'Regular','Right','Left'),(110,'Supper_Market_Cash_Bill_English','Service Charge',1,2400,400,1560,'Service Charge :',120,400,2700,10,240,'Regular','Right','Left'),(121,'Supper_Market_Cash_Bill_English','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(120,'Supper_Market_Cash_Bill_English','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(109,'Supper_Market_Cash_Bill_English','Sub Total',1,2400,200,1560,'Sub Total :',120,200,2700,10,240,'Regular','Right','Left'),(105,'Supper_Market_Cash_Bill_English','Table Name',1,1320,950,2400,'Table Name :',120,950,1200,10,240,'Regular','Left','Left'),(112,'Supper_Market_Cash_Bill_English','Tax',1,2400,800,1560,'Tax :',120,800,2700,10,240,'Regular','Right','Left'),(108,'Supper_Market_Cash_Bill_English','Time',1,2640,1330,960,'Time :',1920,1320,960,10,240,'Regular','Left','Left'),(115,'Supper_Market_Cash_Bill_English','Total',1,2400,1400,1560,'Total :',120,1400,2700,10,240,'Bold','Right','Left'),(138,'Supper_Market_Cash_Bill_Sinhala','Balance Amount',1,2400,1400,1560,'ඉතිරිය :',120,1400,2700,10,240,'Regular','Right','Left'),(139,'Supper_Market_Cash_Bill_Sinhala','BarCode',1,0,2000,4080,'',0,0,0,16,240,'Regular','Center','Left'),(132,'Supper_Market_Cash_Bill_Sinhala','Card Pay Fee',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(127,'Supper_Market_Cash_Bill_Sinhala','Casher',1,2000,1000,2400,'අයකැමි :',120,1000,2000,10,240,'Regular','Left','Left'),(123,'Supper_Market_Cash_Bill_Sinhala','Company Address',1,120,240,4000,'',0,0,0,10,240,'Regular','Center','Left'),(124,'Supper_Market_Cash_Bill_Sinhala','Company MobileNo',1,120,480,4000,'',0,0,0,10,240,'Regular','Center','Left'),(122,'Supper_Market_Cash_Bill_Sinhala','Company Name',1,120,0,4000,'',0,0,0,10,240,'Regular','Center','Center'),(128,'Supper_Market_Cash_Bill_Sinhala','Date',1,960,1250,960,'දිනය :',120,1250,960,10,240,'Regular','Left','Left'),(135,'Supper_Market_Cash_Bill_Sinhala','Discoun',1,2400,800,1560,'ඔබ ලැබූ ලාභය :',120,800,2700,10,240,'Regular','Right','Left'),(125,'Supper_Market_Cash_Bill_Sinhala','Invoice No',1,2000,750,2400,'බිල්පත් අංකය :',120,750,2000,10,240,'Regular','Left','Left'),(140,'Supper_Market_Cash_Bill_Sinhala','Message',1,0,2250,4080,'',0,0,0,10,240,'Regular','Center','Left'),(134,'Supper_Market_Cash_Bill_Sinhala','Net Total',1,2400,600,1560,'මුළු එකතුව :',120,600,2700,10,240,'Regular','Right','Left'),(137,'Supper_Market_Cash_Bill_Sinhala','Pay Amount',1,2400,1200,1560,'ගෙවු මුදල :',120,1200,2700,10,240,'Regular','Right','Left'),(131,'Supper_Market_Cash_Bill_Sinhala','Service Charge',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(142,'Supper_Market_Cash_Bill_Sinhala','Software Company Mobile',1,0,2650,4080,'',0,0,0,8,240,'Regular','Center','Left'),(141,'Supper_Market_Cash_Bill_Sinhala','Software Company Name',1,1700,2450,1920,'Software by',0,2450,1680,8,240,'Regular','Left','Right'),(130,'Supper_Market_Cash_Bill_Sinhala','Sub Total',1,2400,200,1560,'එකතුව :',120,200,2700,10,240,'Regular','Right','Left'),(126,'Supper_Market_Cash_Bill_Sinhala','Table Name',0,0,0,0,'',0,0,0,8,0,'Bold','Center','Center'),(133,'Supper_Market_Cash_Bill_Sinhala','Tax',1,2400,400,1560,'Tax :',120,400,2700,10,240,'Regular','Right','Left'),(129,'Supper_Market_Cash_Bill_Sinhala','Time',1,2640,1250,960,'වේලාව :',1920,1250,960,10,240,'Regular','Left','Left'),(136,'Supper_Market_Cash_Bill_Sinhala','Total',1,2400,1000,1560,'ගෙවිය යුතු මුළු මුදල :',120,1000,3100,10,240,'Bold','Right','Left');
/*!40000 ALTER TABLE `tbl_pos_bill_printersettings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_cash_book`
--

DROP TABLE IF EXISTS `tbl_pos_cash_book`;
CREATE TABLE `tbl_pos_cash_book` (
  `ID` int(11) NOT NULL auto_increment,
  `Description` varchar(255) default NULL,
  `Credit` decimal(18,2) default NULL,
  `Debit` decimal(18,2) default NULL,
  `cUser` int(11) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_cash_book`
--

LOCK TABLES `tbl_pos_cash_book` WRITE;
/*!40000 ALTER TABLE `tbl_pos_cash_book` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_cash_book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_cheques`
--

DROP TABLE IF EXISTS `tbl_pos_cheques`;
CREATE TABLE `tbl_pos_cheques` (
  `ID` int(11) NOT NULL auto_increment,
  `Description` varchar(255) default NULL,
  `ChequesNo` varchar(255) default NULL,
  `ChequesDate` datetime default NULL,
  `Income` decimal(18,2) default NULL,
  `Expense` decimal(18,2) default NULL,
  `cUser` int(11) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_cheques`
--

LOCK TABLES `tbl_pos_cheques` WRITE;
/*!40000 ALTER TABLE `tbl_pos_cheques` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_cheques` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_colors`
--

DROP TABLE IF EXISTS `tbl_pos_colors`;
CREATE TABLE `tbl_pos_colors` (
  `ID` int(11) NOT NULL auto_increment,
  `PanelName` varchar(255) default NULL,
  `PanelColor` varchar(255) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_colors`
--

LOCK TABLES `tbl_pos_colors` WRITE;
/*!40000 ALTER TABLE `tbl_pos_colors` DISABLE KEYS */;
INSERT INTO `tbl_pos_colors` VALUES (1,'col','Navy'),(2,'col2','LightBlue'),(3,'col3','Honeydew'),(4,'hText','Navy'),(5,'Text','Blue');
/*!40000 ALTER TABLE `tbl_pos_colors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_company_profile`
--

DROP TABLE IF EXISTS `tbl_pos_company_profile`;
CREATE TABLE `tbl_pos_company_profile` (
  `ID` int(11) NOT NULL auto_increment,
  `CompanyName` varchar(255) collate utf8_unicode_ci default NULL,
  `Address` varchar(255) collate utf8_unicode_ci default NULL,
  `MobileNo` varchar(255) collate utf8_unicode_ci default NULL,
  `Email` varchar(50) collate utf8_unicode_ci default NULL,
  `CatgoryName` varchar(255) collate utf8_unicode_ci default NULL COMMENT 'Restaurant 2 SupperMarket 1',
  `CatgoryID` int(11) default NULL,
  `SoftCompany` varchar(255) collate utf8_unicode_ci default NULL,
  `SoftMoboleNo` varchar(255) collate utf8_unicode_ci default NULL,
  `IsEnglish` int(11) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_company_profile`
--

LOCK TABLES `tbl_pos_company_profile` WRITE;
/*!40000 ALTER TABLE `tbl_pos_company_profile` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_company_profile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_customers`
--

DROP TABLE IF EXISTS `tbl_pos_customers`;
CREATE TABLE `tbl_pos_customers` (
  `ID` int(11) NOT NULL auto_increment,
  `CustomerName` varchar(255) collate utf8_unicode_ci default NULL,
  `CustomerAddress` varchar(255) collate utf8_unicode_ci default NULL,
  `CustomerMobileNo` varchar(255) collate utf8_unicode_ci default NULL,
  `CustomerEmail` varchar(255) collate utf8_unicode_ci default NULL,
  `BalanceAmount` decimal(18,2) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_customers`
--

LOCK TABLES `tbl_pos_customers` WRITE;
/*!40000 ALTER TABLE `tbl_pos_customers` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_customers_info`
--

DROP TABLE IF EXISTS `tbl_pos_customers_info`;
CREATE TABLE `tbl_pos_customers_info` (
  `ID` int(11) NOT NULL auto_increment,
  `CusID` int(11) default NULL,
  `Description` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `Debit` decimal(18,2) default NULL,
  `Credit` decimal(18,2) default NULL,
  `cUser` int(11) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_customers_info`
--

LOCK TABLES `tbl_pos_customers_info` WRITE;
/*!40000 ALTER TABLE `tbl_pos_customers_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_customers_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_database`
--

DROP TABLE IF EXISTS `tbl_pos_database`;
CREATE TABLE `tbl_pos_database` (
  `Host` varchar(255) collate utf8_unicode_ci default NULL,
  `UserName` varchar(255) collate utf8_unicode_ci default NULL,
  `Password` varchar(255) collate utf8_unicode_ci default NULL,
  `DatabaseName` varchar(255) collate utf8_unicode_ci default NULL,
  `Type` varchar(255) collate utf8_unicode_ci default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_database`
--

LOCK TABLES `tbl_pos_database` WRITE;
/*!40000 ALTER TABLE `tbl_pos_database` DISABLE KEYS */;
INSERT INTO `tbl_pos_database` VALUES ('localhost','root','Msdh@7#8','smart_pos_database','0');
/*!40000 ALTER TABLE `tbl_pos_database` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_grn`
--

DROP TABLE IF EXISTS `tbl_pos_grn`;
CREATE TABLE `tbl_pos_grn` (
  `ID` int(11) NOT NULL auto_increment,
  `GRNNumber` varchar(255) NOT NULL,
  `Description` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `SupplierID` int(11) default NULL,
  `TotalAmount` decimal(18,2) default NULL,
  `PayAmount` decimal(18,2) default NULL,
  `Method` varchar(255) default NULL,
  `cDate` datetime default NULL,
  `cUser` int(11) default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `GRNNumber` (`GRNNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_grn`
--

LOCK TABLES `tbl_pos_grn` WRITE;
/*!40000 ALTER TABLE `tbl_pos_grn` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_grn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_grn_details`
--

DROP TABLE IF EXISTS `tbl_pos_grn_details`;
CREATE TABLE `tbl_pos_grn_details` (
  `ID` int(11) NOT NULL auto_increment,
  `GRN_ID` int(11) default NULL,
  `ItemCode` varchar(255) default NULL,
  `ItemName` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `BuyingCost` decimal(18,2) default NULL,
  `Quantity` decimal(10,3) default NULL,
  `Total` decimal(18,2) default NULL,
  `ExpDate` datetime default NULL,
  `cDate` datetime default NULL,
  `cUser` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_grn_details`
--

LOCK TABLES `tbl_pos_grn_details` WRITE;
/*!40000 ALTER TABLE `tbl_pos_grn_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_grn_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_index`
--

DROP TABLE IF EXISTS `tbl_pos_index`;
CREATE TABLE `tbl_pos_index` (
  `ID` int(11) NOT NULL auto_increment,
  `InvoiceDate` date default NULL,
  `InvoiceCode` varchar(255) collate utf8_unicode_ci default NULL,
  `InvoiceNumber` varchar(255) collate utf8_unicode_ci default NULL,
  `GRNdate` date default NULL,
  `GRNcode` varchar(255) collate utf8_unicode_ci default NULL,
  `GRNnumber` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_index`
--

LOCK TABLES `tbl_pos_index` WRITE;
/*!40000 ALTER TABLE `tbl_pos_index` DISABLE KEYS */;
INSERT INTO `tbl_pos_index` VALUES (1,'2024-11-23','INV','1','2024-11-22','GRN','2');
/*!40000 ALTER TABLE `tbl_pos_index` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_invoice_details`
--

DROP TABLE IF EXISTS `tbl_pos_invoice_details`;
CREATE TABLE `tbl_pos_invoice_details` (
  `ID` int(11) NOT NULL auto_increment,
  `InvNumber` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `SubTotal` decimal(15,2) default NULL,
  `ServiceChg` decimal(15,2) default NULL,
  `CardFee` decimal(15,2) default NULL,
  `TAX` decimal(15,2) default NULL,
  `NetTotal` decimal(15,2) default NULL,
  `Discount` decimal(15,2) default NULL,
  `InvoiceAmount` decimal(15,2) default NULL,
  `InvoicePayAmount` decimal(15,2) default NULL,
  `InvoiceBalAmount` decimal(15,2) default NULL,
  `PayMethod` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `IsServiceChg` int(11) default '0',
  `IsCardFee` int(11) default '0',
  `IsTAX` int(11) default '0',
  `cDate` datetime default NULL,
  `cUser` int(11) default NULL,
  `Status` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `uDate` datetime default NULL,
  `uUser` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tbl_pos_invoice_details`
--

LOCK TABLES `tbl_pos_invoice_details` WRITE;
/*!40000 ALTER TABLE `tbl_pos_invoice_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_invoice_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_item_category`
--

DROP TABLE IF EXISTS `tbl_pos_item_category`;
CREATE TABLE `tbl_pos_item_category` (
  `ID` int(11) NOT NULL auto_increment,
  `CategoryName` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_item_category`
--

LOCK TABLES `tbl_pos_item_category` WRITE;
/*!40000 ALTER TABLE `tbl_pos_item_category` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_item_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_items`
--

DROP TABLE IF EXISTS `tbl_pos_items`;
CREATE TABLE `tbl_pos_items` (
  `ID` double unsigned NOT NULL default '0',
  `item_name` varchar(150) NOT NULL,
  `item_name_sinhala` varchar(500) character set utf8 collate utf8_unicode_ci default NULL,
  `item_name_uni` varchar(300) default NULL,
  `item_name_en` varchar(150) default NULL,
  `barcode` varchar(255) default NULL,
  `barcode2` varchar(255) default NULL,
  `barcode3` varchar(255) default NULL,
  `unit` varchar(255) default NULL,
  `labled_price` decimal(15,2) default NULL,
  `special_price` decimal(15,2) default NULL,
  `wholesale_price` decimal(15,2) default NULL,
  `buying_cost` decimal(15,2) default NULL,
  `Category` int(11) default NULL,
  `supplier` int(11) default NULL,
  `kot_item` int(11) NOT NULL default '0',
  `units_per_one` double default NULL,
  `parent_code` double default NULL,
  `InStock` decimal(10,3) default '0.000',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AVG_ROW_LENGTH=278;

--
-- Dumping data for table `tbl_pos_items`
--

LOCK TABLES `tbl_pos_items` WRITE;
/*!40000 ALTER TABLE `tbl_pos_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_kot_print`
--

DROP TABLE IF EXISTS `tbl_pos_kot_print`;
CREATE TABLE `tbl_pos_kot_print` (
  `InvNumber` varchar(255) collate utf8_unicode_ci default NULL,
  `TableName` varchar(255) collate utf8_unicode_ci default NULL,
  `ItemCode` varchar(255) collate utf8_unicode_ci default NULL,
  `ItemName` varchar(255) collate utf8_unicode_ci default NULL,
  `Qnt` varchar(255) collate utf8_unicode_ci default NULL,
  `cUser` varchar(255) collate utf8_unicode_ci default NULL,
  `cDate` datetime default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_kot_print`
--

LOCK TABLES `tbl_pos_kot_print` WRITE;
/*!40000 ALTER TABLE `tbl_pos_kot_print` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_kot_print` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_privilage`
--

DROP TABLE IF EXISTS `tbl_pos_privilage`;
CREATE TABLE `tbl_pos_privilage` (
  `ID` int(11) NOT NULL auto_increment,
  `RoleID` int(11) NOT NULL,
  `Action` int(11) NOT NULL,
  `IsTrue` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AVG_ROW_LENGTH=1820;

--
-- Dumping data for table `tbl_pos_privilage`
--

LOCK TABLES `tbl_pos_privilage` WRITE;
/*!40000 ALTER TABLE `tbl_pos_privilage` DISABLE KEYS */;
INSERT INTO `tbl_pos_privilage` VALUES (1,1,1,1),(2,1,2,1),(3,1,3,1),(4,1,4,1),(5,1,5,1),(6,1,6,1),(7,1,7,1),(8,1,8,1),(9,1,9,1),(10,1,10,1),(11,1,11,1),(12,1,12,1),(13,1,13,1),(14,1,14,1),(15,1,15,1),(16,1,16,1),(17,1,17,1),(18,1,18,1),(19,1,19,1),(20,1,20,1),(21,1,21,1),(22,1,22,1),(23,1,23,1),(24,1,24,1),(25,1,25,1),(26,1,26,1),(27,2,1,1),(28,2,2,1),(29,2,3,1),(30,2,4,1),(31,2,5,1),(32,2,6,1),(33,2,7,1),(34,2,8,1),(35,2,9,1),(36,2,10,1),(37,2,11,1),(38,2,12,1),(39,2,13,1),(40,2,14,1),(41,2,15,1),(42,2,16,1),(43,2,17,1),(44,2,18,1),(45,2,19,1),(46,2,20,1),(47,2,21,1),(48,2,22,1),(49,2,23,1),(50,2,24,1),(51,2,25,1),(52,2,26,1),(53,3,1,0),(54,3,2,0),(55,3,3,0),(56,3,4,0),(57,3,5,0),(58,3,6,0),(59,3,7,0),(60,3,8,0),(61,3,9,0),(62,3,10,0),(63,3,11,0),(64,3,12,0),(65,3,13,0),(66,3,14,0),(67,3,15,0),(68,3,16,0),(69,3,17,0),(70,3,18,0),(71,3,19,0),(72,3,20,0),(73,3,21,0),(74,3,22,0),(75,3,23,0),(76,3,24,0),(77,3,25,0),(78,3,26,0),(79,4,1,0),(80,4,2,0),(81,4,3,0),(82,4,4,0),(83,4,5,0),(84,4,6,0),(85,4,7,0),(86,4,8,0),(87,4,9,0),(88,4,10,0),(89,4,11,0),(90,4,12,0),(91,4,13,0),(92,4,14,0),(93,4,15,0),(94,4,16,0),(95,4,17,0),(96,4,18,0),(97,4,19,0),(98,4,20,0),(99,4,21,0),(100,4,22,0),(101,4,23,0),(102,4,24,0),(103,4,25,0),(104,4,26,0);
/*!40000 ALTER TABLE `tbl_pos_privilage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_ref_printer_settings`
--

DROP TABLE IF EXISTS `tbl_pos_ref_printer_settings`;
CREATE TABLE `tbl_pos_ref_printer_settings` (
  `ID` int(11) NOT NULL auto_increment,
  `ObjectName` varchar(255) default NULL,
  `PrinterName` varchar(255) default NULL,
  `PaperSize` varchar(255) default NULL,
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_ref_printer_settings`
--

LOCK TABLES `tbl_pos_ref_printer_settings` WRITE;
/*!40000 ALTER TABLE `tbl_pos_ref_printer_settings` DISABLE KEYS */;
INSERT INTO `tbl_pos_ref_printer_settings` VALUES (1,'POS','Microsoft Print to PDF','[PaperSize A4 Kind=A4 Height=1169 Width=827]'),(2,'KOT','Microsoft Print to PDF','[PaperSize Letter Kind=Letter Height=1100 Width=850]');
/*!40000 ALTER TABLE `tbl_pos_ref_printer_settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_restaurant_sales`
--

DROP TABLE IF EXISTS `tbl_pos_restaurant_sales`;
CREATE TABLE `tbl_pos_restaurant_sales` (
  `ID` int(11) NOT NULL auto_increment,
  `InvoiceID` int(11) default NULL,
  `TableName` varchar(255) collate utf8_unicode_ci default NULL,
  `ItemsCode` varchar(255) collate utf8_unicode_ci default NULL,
  `ItemsName` varchar(255) collate utf8_unicode_ci default NULL,
  `Price` decimal(19,2) default NULL,
  `Quantity` decimal(10,3) default NULL,
  `TotalPrice` decimal(19,2) default NULL,
  `KOT` int(11) default NULL,
  `Status` varchar(255) collate utf8_unicode_ci default NULL,
  `cDate` datetime default NULL,
  `cUser` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_restaurant_sales`
--

LOCK TABLES `tbl_pos_restaurant_sales` WRITE;
/*!40000 ALTER TABLE `tbl_pos_restaurant_sales` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_restaurant_sales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_role`
--

DROP TABLE IF EXISTS `tbl_pos_role`;
CREATE TABLE `tbl_pos_role` (
  `ID` int(11) NOT NULL auto_increment,
  `RoleName` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_role`
--

LOCK TABLES `tbl_pos_role` WRITE;
/*!40000 ALTER TABLE `tbl_pos_role` DISABLE KEYS */;
INSERT INTO `tbl_pos_role` VALUES (1,'SupperAdmin'),(2,'Owner'),(3,'Supervisor'),(4,'Cashier');
/*!40000 ALTER TABLE `tbl_pos_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_serial_key`
--

DROP TABLE IF EXISTS `tbl_pos_serial_key`;
CREATE TABLE `tbl_pos_serial_key` (
  `SerialKey` varchar(255) collate utf8_unicode_ci default NULL,
  `ExDate` varchar(255) collate utf8_unicode_ci default NULL,
  `Status` varchar(255) collate utf8_unicode_ci default NULL,
  `SoftCompany` varchar(255) collate utf8_unicode_ci default NULL,
  `SoftMobileNo` varchar(255) collate utf8_unicode_ci default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_serial_key`
--

LOCK TABLES `tbl_pos_serial_key` WRITE;
/*!40000 ALTER TABLE `tbl_pos_serial_key` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_serial_key` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_stock`
--

DROP TABLE IF EXISTS `tbl_pos_stock`;
CREATE TABLE `tbl_pos_stock` (
  `ID` int(11) NOT NULL auto_increment,
  `ItemID` int(11) default NULL,
  `Description` varchar(255) default NULL,
  `Date` datetime default NULL,
  `InStock` decimal(10,3) default NULL,
  `OutStock` decimal(10,3) default NULL,
  `BuyingCost` decimal(10,2) default NULL,
  `ExpDate` datetime default NULL,
  `cUser` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_stock`
--

LOCK TABLES `tbl_pos_stock` WRITE;
/*!40000 ALTER TABLE `tbl_pos_stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_supper_market_sales`
--

DROP TABLE IF EXISTS `tbl_pos_supper_market_sales`;
CREATE TABLE `tbl_pos_supper_market_sales` (
  `ID` int(11) NOT NULL auto_increment,
  `InvoiceID` int(11) default NULL,
  `ItemCode` varchar(255) default NULL,
  `ItemName` varchar(500) character set utf8 collate utf8_unicode_ci default NULL,
  `LabledPrice` decimal(15,2) default NULL,
  `SpecialPrice` decimal(15,2) default NULL,
  `Quantity` decimal(15,2) default NULL,
  `TotalPrice` decimal(15,2) default NULL,
  `cDate` datetime default NULL,
  `cUser` int(11) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_supper_market_sales`
--

LOCK TABLES `tbl_pos_supper_market_sales` WRITE;
/*!40000 ALTER TABLE `tbl_pos_supper_market_sales` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_supper_market_sales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_suppliers`
--

DROP TABLE IF EXISTS `tbl_pos_suppliers`;
CREATE TABLE `tbl_pos_suppliers` (
  `ID` int(11) NOT NULL,
  `SuppliersName` varchar(255) collate utf8_unicode_ci default NULL,
  `SuppliersMobileNo` varchar(255) collate utf8_unicode_ci default NULL,
  `SuppliersEmail` varchar(255) collate utf8_unicode_ci default NULL,
  `BalanceAmount` decimal(18,2) default '0.00',
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_suppliers`
--

LOCK TABLES `tbl_pos_suppliers` WRITE;
/*!40000 ALTER TABLE `tbl_pos_suppliers` DISABLE KEYS */;
INSERT INTO `tbl_pos_suppliers` VALUES (0,'','','','0.00','2024-11-23 12:13:47');
/*!40000 ALTER TABLE `tbl_pos_suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_suppliers_info`
--

DROP TABLE IF EXISTS `tbl_pos_suppliers_info`;
CREATE TABLE `tbl_pos_suppliers_info` (
  `ID` int(11) NOT NULL auto_increment,
  `SupID` int(11) default NULL,
  `Description` varchar(255) character set utf8 collate utf8_unicode_ci default NULL,
  `Debit` decimal(18,2) default NULL,
  `Credit` decimal(18,2) default NULL,
  `cUser` int(11) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_pos_suppliers_info`
--

LOCK TABLES `tbl_pos_suppliers_info` WRITE;
/*!40000 ALTER TABLE `tbl_pos_suppliers_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_suppliers_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_system_action`
--

DROP TABLE IF EXISTS `tbl_pos_system_action`;
CREATE TABLE `tbl_pos_system_action` (
  `ID` int(11) NOT NULL auto_increment,
  `ActionName` varchar(255) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AVG_ROW_LENGTH=819;

--
-- Dumping data for table `tbl_pos_system_action`
--

LOCK TABLES `tbl_pos_system_action` WRITE;
/*!40000 ALTER TABLE `tbl_pos_system_action` DISABLE KEYS */;
INSERT INTO `tbl_pos_system_action` VALUES (1,'Add New User'),(2,'Edit User'),(3,'Role Management'),(4,'View Account'),(5,'View Report'),(6,'Edit Charges'),(7,'View Invoice'),(8,'View Invoice Details'),(9,'Invoice Deleting'),(10,'Add New Customer'),(11,'View Customer Details'),(12,'Edit Customer Details'),(13,'Customer Deleting'),(14,'Add New Supplier'),(15,'View Supplier Details'),(16,'Edit Suppliet Details'),(17,'Supplirt Deleting'),(18,'Add New Category'),(19,'Edit Category'),(20,'Category Deleting'),(21,'Add New Product'),(22,'Edit Product'),(23,'Product Deleting'),(24,'Add New Restaurant Table'),(25,'Edit Restaurant Table'),(26,'Restaurant Table Deleting');
/*!40000 ALTER TABLE `tbl_pos_system_action` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_system_setting`
--

DROP TABLE IF EXISTS `tbl_pos_system_setting`;
CREATE TABLE `tbl_pos_system_setting` (
  `ID` int(11) NOT NULL auto_increment,
  `ObjName` varchar(50) collate utf8_unicode_ci default NULL,
  `ObjValue` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_system_setting`
--

LOCK TABLES `tbl_pos_system_setting` WRITE;
/*!40000 ALTER TABLE `tbl_pos_system_setting` DISABLE KEYS */;
INSERT INTO `tbl_pos_system_setting` VALUES (1,'Service Charge','0'),(2,'Card Payment Fee','0'),(3,'TAX','0');
/*!40000 ALTER TABLE `tbl_pos_system_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_tables`
--

DROP TABLE IF EXISTS `tbl_pos_tables`;
CREATE TABLE `tbl_pos_tables` (
  `ID` int(11) NOT NULL auto_increment,
  `TableName` varchar(255) collate utf8_unicode_ci default NULL,
  `TableCode` varchar(255) collate utf8_unicode_ci default NULL,
  `TableIsUse` int(11) default '0',
  `InvID` int(11) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_tables`
--

LOCK TABLES `tbl_pos_tables` WRITE;
/*!40000 ALTER TABLE `tbl_pos_tables` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_pos_tables` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_units`
--

DROP TABLE IF EXISTS `tbl_pos_units`;
CREATE TABLE `tbl_pos_units` (
  `ID` int(11) NOT NULL auto_increment,
  `UnitName` varchar(255) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_pos_units`
--

LOCK TABLES `tbl_pos_units` WRITE;
/*!40000 ALTER TABLE `tbl_pos_units` DISABLE KEYS */;
INSERT INTO `tbl_pos_units` VALUES (1,'Psc'),(2,'Kg'),(3,'ml');
/*!40000 ALTER TABLE `tbl_pos_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pos_user`
--

DROP TABLE IF EXISTS `tbl_pos_user`;
CREATE TABLE `tbl_pos_user` (
  `ID` int(11) NOT NULL auto_increment,
  `FullName` varchar(255) collate utf8_unicode_ci default NULL,
  `UserName` varchar(255) collate utf8_unicode_ci default NULL,
  `Password` varchar(255) collate utf8_unicode_ci NOT NULL,
  `MobileNo` varchar(10) collate utf8_unicode_ci NOT NULL,
  `Email` varchar(255) collate utf8_unicode_ci default NULL,
  `Active` int(11) NOT NULL default '1' COMMENT '1 = Active, 0 = DeActive',
  `RoleID` int(11) NOT NULL,
  `cUser` int(11) default NULL,
  `cDate` datetime default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `UserName` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AVG_ROW_LENGTH=16384;

--
-- Dumping data for table `tbl_pos_user`
--

LOCK TABLES `tbl_pos_user` WRITE;
/*!40000 ALTER TABLE `tbl_pos_user` DISABLE KEYS */;
INSERT INTO `tbl_pos_user` VALUES (1,'Isuru Piyumantha','isuru','MdIsV2xRCopx0hV6WDnnKUzGyiwBNw9KLXwpnYZjjz8=','0','0',1,1,1,'2024-11-23 12:13:57');
/*!40000 ALTER TABLE `tbl_pos_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-29  6:08:08
