DELIMITER $$
CREATE PROCEDURE GetAllParkingVehiclesByTicket(IN ticket VARCHAR(255))
BEGIN
	SELECT * FROM vehicles AS V JOIN parkinglots AS P
	ON V.licensePlateId = P.licensePlateId
    WHERE V.Ticket = ticket AND P.licensePlateId IS NOT NULL;
END$$

CALL GetAllParkingVehiclesByTicket('Vip')