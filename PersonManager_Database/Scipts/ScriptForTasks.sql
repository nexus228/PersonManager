USE PersonManager_Database;
GO

/**
* Counts the number of records in the Person table.
**/
SELECT COUNT(*) FROM Person;

/**
* Counts the number of records in the Address table who live in Dresden.
**/
SELECT COUNT(DISTINCT PersonId) FROM Address WHERE City = 'Dresden';

/**
* Counts the number of records in the PhoneConnection table who have more than one phone number.
**/
SELECT COUNT(*) FROM (
    SELECT PersonId
    FROM PhoneConnection
    GROUP BY PersonId
    HAVING COUNT(*) > 1
) AS PersonsWithMultiplePhoneNumbers;

/**
* Counts the number of records in the Address table for each city.
**/
SELECT City, COUNT(DISTINCT PersonId) AS PersonCountForCity FROM Address GROUP BY City;

/**
* Show all Persons with data - multiple entries are shown for persons... 
*/
SELECT * FROM PersonDataView;

/**
* Show all Entries which phonenumber doesnt starts with 0 or + 
**/
SELECT *
FROM PhoneConnection
WHERE PhoneNumber NOT LIKE '0%'
  AND PhoneNumber NOT LIKE '+%';
/**
* Delete all Entries which phonenumber doesnt starts with 0 or + 
**/
DELETE FROM PhoneConnection
WHERE PhoneNumber NOT LIKE '0%'
  AND PhoneNumber NOT LIKE '+%';


/**
* Add Column with UpperCase Name
**/ 
/** ALTER TABLE Person DROP COLUMN UpperCasePersonName **/
ALTER TABLE Person ADD UpperCasePersonName AS Upper(Name + ', ' + FirstName)
