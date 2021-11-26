DELIMITER $$
CREATE PROCEDURE InsertParkingLots(size INT)
BEGIN
	DECLARE counter INT DEFAULT 1;
    
    WHILE counter <= size DO
	 INSERT INTO parkinglots VALUES(DEFAULT, NULL); 

     SET counter = counter + 1;
     END WHILE;
END$$

CALL InsertParkingLots(60)