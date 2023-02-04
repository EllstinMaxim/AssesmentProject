/*
SQLyog Community v13.1.2 (64 bit)
MySQL - 5.6.41-log : Database - assesmenttest
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `contactmaster` */

DROP TABLE IF EXISTS `contactmaster`;

CREATE TABLE `contactmaster` (
  `ContactID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `PhoneNumber` varchar(255) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `City` varchar(10) DEFAULT NULL,
  `State` varchar(10) DEFAULT NULL,
  `Country` varchar(10) DEFAULT NULL,
  `PostalCode` varchar(10) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `GeoLat` varchar(100) DEFAULT NULL,
  `GeoLong` varchar(100) DEFAULT NULL,
  `PlaceName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ContactID`),
  UNIQUE KEY `Uniq_Email` (`Email`),
  UNIQUE KEY `Uniq_PhNo` (`PhoneNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*Data for the table `contactmaster` */

insert  into `contactmaster`(`ContactID`,`FirstName`,`LastName`,`Email`,`PhoneNumber`,`Address`,`City`,`State`,`Country`,`PostalCode`,`CreatedBy`,`CreatedDate`,`UpdatedBy`,`UpdatedDate`,`GeoLat`,`GeoLong`,`PlaceName`) values 
(6,'Ellstin','Maxim','ellstinmaxim26@gmail.com','+60174059812','Civil Aerodrome Post','Coimbatore','TAMIL NADU','India','638002',1,'2023-02-02 02:28:20',1,'2023-02-04 15:42:36','11.040626','77.039264',NULL),
(8,'Ravi','Chandran','RaviChandran@gmail.com','+91 985622521','Bharathiyar University','Coimbatore','TAMIL NADU','India','638002',1,'2023-02-04 15:35:52',1,'2023-02-04 16:08:19','11.036843','76.878952',NULL),
(9,'Radha','Krishnan','RadhaKrishnan@gmail.com','+91 985475213','Kurudampalayam','Coimbatore','TAMIL NADU','India','638002',1,'2023-02-04 15:37:17',1,'2023-02-04 15:37:17','11.098904','76.934337',NULL),
(10,'Jeyalakshmi','Narayanan','JeyaNarayana@gmail.com','+91 98574526','Chettipalayam','Coimbatore','TAMIL NADU','India','638002',1,'2023-02-04 15:38:27',1,'2023-02-04 16:10:07','10.955132','77.022308',NULL),
(11,'RamKumar','Gandhi','RamGandhi@gmail.com','+91 9856321458','Chettipalayam','Coimbatore','TAMIL NADU','India','638002',1,'2023-02-04 15:39:41',1,'2023-02-04 15:55:58','10.903583','77.024309',NULL);

/* Procedure structure for procedure `usp_Contactmaster` */

/*!50003 DROP PROCEDURE IF EXISTS  `usp_Contactmaster` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Contactmaster`(IN in_Mode VARCHAR(20),
	IN in_ContactID INT,IN in_FirstName VARCHAR(255),IN in_LastName VARCHAR(255),IN in_Email VARCHAR(255),IN in_PhoneNumber VARCHAR(255),
	IN in_Address VARCHAR(255),IN in_City VARCHAR(10),IN in_State VARCHAR(10),IN in_Country VARCHAR(10),IN in_PostalCode VARCHAR(10),
	in in_GeoLat VARCHAR(100), in in_GeoLong VARCHAR(100), 
	IN in_CreatedBy INT,IN in_UpdatedBy INT )
BEGIN
	IF in_Mode='Select'  THEN
		SELECT * FROM contactmaster;
	elseIF in_Mode='SELECT_MAP'  THEN
		SELECT ContactID,FirstName,GeoLat,GeoLong,address as PlaceName FROM contactmaster;
	elseIF in_Mode='EDIT'  THEN
		SELECT * FROM contactmaster WHERE ContactID=in_ContactID;
	ELSEIF in_Mode='MAXID'  THEN
		SELECT max(ContactID) FROM contactmaster;
	ELSEIF in_Mode='INSERT'  THEN
		INSERT INTO contactmaster(
			FirstName,LastName,Email,PhoneNumber,Address,City,State,Country,PostalCode,GeoLat,GeoLong,
			CreatedBy,CreatedDate,UpdatedBy,UpdatedDate)
		VALUES(in_FirstName,in_LastName,in_Email,in_PhoneNumber,in_Address,in_City,in_State,in_Country,in_PostalCode,
		       in_GeoLat, in_GeoLong,
		       in_CreatedBy,NOW(),in_UpdatedBy,NOW());   
	ELSEIF in_Mode='UPDATE'  THEN
		UPDATE contactmaster SET 	            
		FirstName=in_FirstName,
		LastName=in_LastName,
		Email=in_Email,
		PhoneNumber=in_PhoneNumber,
		Address=in_Address,
		City=in_City,
		State=in_State,
		Country=in_Country,
		PostalCode=in_PostalCode,
		GeoLat=in_GeoLat,
		GeoLong=in_GeoLong,
		
		UpdatedBy=in_UpdatedBy,
		UpdatedDate=NOW()
		WHERE ContactID=in_ContactID;
	
	ELSEIF in_Mode='DELETE'  THEN
		DELETE FROM contactmaster WHERE ContactID=in_ContactID;
	
	END IF;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
