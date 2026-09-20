CREATE VIEW [dbo].[PersonDataView]
	AS SELECT
    person.Id AS PersonId,
    person.FirstName,
    person.Name,
    person.DateOfBirth,
    address.ZipCode,
    address.City,
    address.Street,
    address.HouseNumber,
    phoneConnection.PhoneNumber
FROM Person person
LEFT JOIN Address address
    ON person.Id = address.PersonId
LEFT JOIN PhoneConnection phoneConnection
    ON person.Id = phoneConnection.PersonId;
