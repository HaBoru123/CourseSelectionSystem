/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80033
 Source Host           : localhost:3306
 Source Schema         : db_1

 Target Server Type    : MySQL
 Target Server Version : 80033
 File Encoding         : 65001

 Date: 01/06/2023 23:01:04
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `cno` int(0) NOT NULL AUTO_INCREMENT,
  `cname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ccredit` int(0) NOT NULL,
  `cweeks` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `clessons` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `period` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`cno`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES (1, '数据库', 2, '周一', '1-2', '1-12周');
INSERT INTO `course` VALUES (2, '数据库', 4, '周一', '1-2', '1-12周');
INSERT INTO `course` VALUES (3, '数学', 4, '周一', '3-4', '1-17周');
INSERT INTO `course` VALUES (4, '信息系统', 1, '周一', '5-6', '1-17周');
INSERT INTO `course` VALUES (5, '信息系统', 5, '周五', '5-6', '1-17周');
INSERT INTO `course` VALUES (6, '数据结构', 4, '周四', '3-4', '1-17周');
INSERT INTO `course` VALUES (7, '数据处理', 4, '周三', '1-2', '1-12周');
INSERT INTO `course` VALUES (8, 'Pascal语言', 4, '周四', '5-6', '1-12周');
INSERT INTO `course` VALUES (9, '信息安全数学基础', 4, '星期二', '3-4节', '1-17周');
INSERT INTO `course` VALUES (10, '信息安全数学基础', 4, '星期二', '3-4节', '1-17周');
INSERT INTO `course` VALUES (12, '信息安全数学基础', 4, '星期二', '3-4节', '1-17周');

-- ----------------------------
-- Table structure for sc
-- ----------------------------
DROP TABLE IF EXISTS `sc`;
CREATE TABLE `sc`  (
  `sno` int(0) NOT NULL,
  `cno` int(0) NOT NULL,
  PRIMARY KEY (`sno`, `cno`) USING BTREE,
  INDEX `cno`(`cno`) USING BTREE,
  CONSTRAINT `ssno` FOREIGN KEY (`sno`) REFERENCES `student` (`sno`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sc
-- ----------------------------
INSERT INTO `sc` VALUES (1, 1);
INSERT INTO `sc` VALUES (1, 3);
INSERT INTO `sc` VALUES (1, 4);

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student`  (
  `sno` int(0) NOT NULL,
  `sname` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `grade` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dept` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `scredit` int(0) NOT NULL,
  PRIMARY KEY (`sno`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of student
-- ----------------------------
INSERT INTO `student` VALUES (1, '张一', '21级', '计算机学院', 8);
INSERT INTO `student` VALUES (2, '王二', '21级', '计算机学院', 2);
INSERT INTO `student` VALUES (3, '李三', '21级', '网络空间安全学院', 2);
INSERT INTO `student` VALUES (4, '赵四', '21级', '网络空间安全学院', 2);
INSERT INTO `student` VALUES (5, '孙五', '21级', '药学院', 2);
INSERT INTO `student` VALUES (6, '钱六', '21级', '药学院', 2);

-- ----------------------------
-- Table structure for sysmanager
-- ----------------------------
DROP TABLE IF EXISTS `sysmanager`;
CREATE TABLE `sysmanager`  (
  `manid` int(0) NOT NULL,
  `mpassword` int(0) NOT NULL,
  PRIMARY KEY (`manid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysmanager
-- ----------------------------
INSERT INTO `sysmanager` VALUES (55, 55);
INSERT INTO `sysmanager` VALUES (66, 66);
INSERT INTO `sysmanager` VALUES (77, 7);
INSERT INTO `sysmanager` VALUES (111, 111);
INSERT INTO `sysmanager` VALUES (222, 222);
INSERT INTO `sysmanager` VALUES (333, 333);
INSERT INTO `sysmanager` VALUES (444, 444);

-- ----------------------------
-- Table structure for sysstudent
-- ----------------------------
DROP TABLE IF EXISTS `sysstudent`;
CREATE TABLE `sysstudent`  (
  `stuid` int(0) NOT NULL AUTO_INCREMENT,
  `upassword` int(0) NOT NULL,
  PRIMARY KEY (`stuid`) USING BTREE,
  CONSTRAINT `sysstudent_ibfk_1` FOREIGN KEY (`stuid`) REFERENCES `student` (`sno`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysstudent
-- ----------------------------
INSERT INTO `sysstudent` VALUES (1, 1);

-- ----------------------------
-- View structure for v1
-- ----------------------------
DROP VIEW IF EXISTS `v1`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `v1` AS select `student`.`sno` AS `sno`,`student`.`sname` AS `sname`,`course`.`cname` AS `cname`,`course`.`ccredit` AS `ccredit`,`course`.`clessons` AS `clessons`,`course`.`cweeks` AS `cweeks`,`course`.`period` AS `period`,`sc`.`cno` AS `cno` from ((`student` join `sc` on((`student`.`sno` = `sc`.`sno`))) join `course` on((`sc`.`cno` = `course`.`cno`)));

-- ----------------------------
-- Procedure structure for gengxin
-- ----------------------------
DROP PROCEDURE IF EXISTS `gengxin`;
delimiter ;;
CREATE PROCEDURE `gengxin`(IN cn int,IN cc int)
BEGIN
 if( cc<10)
 then 
 UPDATE student set scredit=scredit-(select ccredit from course where cno=cn)+cc where sno in (select sno from sc where cno=cn);
 UPDATE course set ccredit=cc where cno=cn;
 end if;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for outputstore
-- ----------------------------
DROP PROCEDURE IF EXISTS `outputstore`;
delimiter ;;
CREATE PROCEDURE `outputstore`(IN num int,IN shop_pos VARCHAR(18),IN storeID VARCHAR(32),IN shopID VARCHAR(18))
BEGIN
	#Routine body goes here...
	UPDATE warehouse_info SET 
	shop_num = num
WHERE store_id = storeID AND shop_id = shopID AND pos_info = shop_pos;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for putstore
-- ----------------------------
DROP PROCEDURE IF EXISTS `putstore`;
delimiter ;;
CREATE PROCEDURE `putstore`(IN num int,IN shop_pos VARCHAR(18),IN storeID VARCHAR(32),IN shopID VARCHAR(18))
BEGIN
	#Routine body goes here...
	UPDATE warehouse_info SET 
	shop_num = num,pos_info = shop_pos
WHERE store_id = storeID AND shop_id = shopID;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table sc
-- ----------------------------
DROP TRIGGER IF EXISTS `tg4`;
delimiter ;;
CREATE TRIGGER `tg4` AFTER INSERT ON `sc` FOR EACH ROW begin
UPDATE student set scredit=scredit+(select ccredit from course where cno=new.cno) where sno=new.sno;
end
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table sc
-- ----------------------------
DROP TRIGGER IF EXISTS `tianke`;
delimiter ;;
CREATE TRIGGER `tianke` BEFORE INSERT ON `sc` FOR EACH ROW BEGIN
IF EXISTS(SELECT * from sc NATURAL JOIN course where sno=new.sno and clessons=(SELECT clessons from course where cno=new.cno) and cweeks=(SELECT cweeks FROM course WHERE cno=new.cno))then SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='课程冲突';
end if;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table student
-- ----------------------------
DROP TRIGGER IF EXISTS `tg3`;
delimiter ;;
CREATE TRIGGER `tg3` AFTER DELETE ON `student` FOR EACH ROW BEGIN
delete from sc where sno=old.sno;
end
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table sysstudent
-- ----------------------------
DROP TRIGGER IF EXISTS `tg2`;
delimiter ;;
CREATE TRIGGER `tg2` BEFORE INSERT ON `sysstudent` FOR EACH ROW BEGIN
if NEW.stuid in (SELECT sno from student ) and NEW.stuid not in (select stuid from sysstudent)
then set new.upassword=1;
end if;
end
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
