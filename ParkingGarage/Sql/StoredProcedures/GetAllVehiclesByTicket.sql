DELIMITER $$
CREATE PROCEDURE GetAllParkingVehiclesByTicket(IN ticket VARCHAR(10))
BEGIN
    SELECT V.LicensePlateId, V.Name, V.Phone, V.Ticket, V.Height, V.Width, V.Length, P.Id AS Lot 
    FROM vehicles AS V JOIN parkinglots AS P 
    ON V.licensePlateId = P.licensePlateId 
    WHERE V.Ticket = ticket AND P.licensePlateId IS NOT NULL;
END$$

CALL GetAllParkingVehiclesByTicket('Vip')