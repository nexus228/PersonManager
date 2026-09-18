USE PersonManager_Database;
GO

/*------------------------------------------------------------------------------------*/
/*----------------------------- DATEN LÖSCHEN UND IDENTITY RESET ---------------------*/
/*------------------------------------------------------------------------------------*/

DELETE FROM [dbo].[Address];
DELETE FROM [dbo].[PhoneConnection];
DELETE FROM [dbo].[Person];

DBCC CHECKIDENT ('[dbo].[Address]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[PhoneConnection]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Person]', RESEED, 0);


/*------------------------------------------------------------------------------------*/
/*----------------------------- Personen anlegen -------------------------------------*/
/*------------------------------------------------------------------------------------*/

INSERT INTO [dbo].[Person]
    ([Name], [FirstName], [DateOfBirth])
VALUES
    ('Müller', 'Anna', '1985-03-12'),
    ('Schmidt', 'Thomas', '1978-11-05'),
    ('Rossi', 'Giulia', '1992-07-21'),
    ('Garcia', 'Miguel', '1987-01-30'),
    ('Andersson', 'Sofia', '1990-05-17'),
    ('Dubois', 'Claire', '1983-09-08'),
    ('Petrov', 'Alexander', '1975-12-03'),
    ('Nowak', 'Katarzyna', '1988-02-19'),
    ('Silva', 'João', '1995-06-25'),
    ('Kowalski', 'Mateusz', '1981-10-14'),
    ('Martin', 'Sophie', '1997-04-09'),
    ('O''Connor', 'Liam', '1972-08-31'),
    ('Hansen', 'Freja', '1993-01-22'),
    ('Papadopoulos', 'Nikos', '1986-11-17'),
    ('Fernandez', 'Lucía', '1991-03-06'),
    ('Ivanov', 'Dmitri', '1979-07-28'),
    ('Moreau', 'Émilie', '1984-12-11'),
    ('Svensson', 'Erik', '1990-09-23'),
    ('Bianchi', 'Matteo', '1987-05-04'),
    ('Müller', 'Lena', '1976-01-16'),
    ('Schneider', 'Jonas', '1996-08-12'),
    ('Nakamura', 'Yuki', '1970-04-27'),
    ('Tanaka', 'Haruto', '1982-10-06'),
    ('Chen', 'Mei', '1989-02-14'),
    ('Wang', 'Wei', '1994-06-19'),
    ('Zhang', 'Lin', '1980-12-28'),
    ('Kim', 'Min-Jae', '1985-07-03'),
    ('Park', 'Ji-Won', '1992-11-09'),
    ('Singh', 'Arjun', '1998-03-25'),
    ('Patel', 'Priya', '1983-05-30'),
    ('Khan', 'Aisha', '1977-09-18'),
    ('Hassan', 'Omar', '1991-01-07'),
    ('Abdullah', 'Layla', '1986-04-22'),
    ('Williams', 'James', '1974-11-13'),
    ('Johnson', 'Emily', '1989-08-26'),
    ('Brown', 'Michael', '1995-02-02'),
    ('Smith', 'Olivia', '1981-06-15'),
    ('Taylor', 'Ethan', '1978-10-29'),
    ('Wilson', 'Charlotte', '1993-12-07'),
    ('Anderson', 'Noah', '1987-03-19'),
    ('Okafor', 'Chinedu', '1984-07-11'),
    ('Mensah', 'Ama', '1973-05-24'),
    ('Diallo', 'Ibrahim', '1990-01-31'),
    ('Ndlovu', 'Thandiwe', '1988-09-16'),
    ('Costa', 'Beatriz', '1996-11-21'),
    ('Santos', 'Rafael', '1982-02-08'),
    ('Silva', 'Mariana', '1979-06-27'),
    ('Petrović', 'Nikola', '1994-10-03'),
    ('Kovač', 'Ivana', '1985-12-18'),
    ('Alvarez', 'Diego', '1997-05-09');

/*------------------------------------------------------------------------------------*/
/*----------------------- Adressen anlegen -------------------------------------------*/
/*------------------------------------------------------------------------------------*/
INSERT INTO [dbo].[Address]
    ([PersonId], [ZipCode], [City], [Street], [HouseNumber])
VALUES
    -- Müller, Anna
    (1, '01067', 'Dresden', 'Musterstraße', '12'),

    -- Schmidt, Thomas
    (2, '01309', 'Dresden', 'Waldstraße', '8'),

    -- Rossi, Giulia
    (3, '10115', 'Berlin', 'Friedrichstraße', '45'),
    (3, '20144', 'Hamburg', 'Alsterstraße', '17'),

    -- Garcia, Miguel
    (4, '50667', 'Köln', 'Domstraße', '21'),

    -- Andersson, Sofia
    (5, '20095', 'Hamburg', 'Mönckebergstraße', '34'),
    (5, '24103', 'Kiel', 'Holstenstraße', '12'),

    -- Dubois, Claire
    (6, '60311', 'Frankfurt am Main', 'Zeil', '58'),

    -- Petrov, Alexander
    (7, '80331', 'München', 'Marienplatz', '4'),
    (7, '86150', 'Augsburg', 'Maximilianstraße', '28'),

    -- Nowak, Katarzyna
    (8, '04109', 'Leipzig', 'Goethestraße', '23'),

    -- Silva, João
    (9, '01069', 'Dresden', 'Wilsdruffer Straße', '31'),

    -- Kowalski, Mateusz
    (10, '01067', 'Dresden', 'Wallstraße', '15'),
    (10, '01159', 'Dresden', 'Löbtauer Straße', '73'),

    -- Martin, Sophie
    (11, '70173', 'Stuttgart', 'Königstraße', '52'),

    -- O'Connor, Liam
    (12, '50670', 'Köln', 'Venloer Straße', '18'),
    (12, '40213', 'Düsseldorf', 'Ratinger Straße', '11'),

    -- Hansen, Freja
    (13, '24103', 'Kiel', 'Holstenstraße', '7'),

    -- Papadopoulos, Nikos
    (14, '01099', 'Dresden', 'Bautzner Straße', '64'),

    -- Fernandez, Lucía
    (15, '40213', 'Düsseldorf', 'Königsallee', '24'),
    (15, '45127', 'Essen', 'Limbecker Straße', '36'),

    -- Ivanov, Dmitri
    (16, '01067', 'Dresden', 'Schloßstraße', '29'),

    -- Moreau, Émilie
    (17, '79098', 'Freiburg im Breisgau', 'Kaiser-Joseph-Straße', '36'),
    (17, '68159', 'Mannheim', 'Planken', '14'),

    -- Svensson, Erik
    (18, '01097', 'Dresden', 'Königsbrücker Straße', '42'),

    -- Bianchi, Matteo
    (19, '90402', 'Nürnberg', 'Königstraße', '14'),

    -- Müller, Lena
    (20, '01099', 'Dresden', 'Alaunstraße', '25'),
    (20, '09111', 'Chemnitz', 'Brückenstraße', '10'),

    -- Schneider, Jonas
    (21, '01069', 'Dresden', 'Budapester Straße', '5'),

    -- Nakamura, Yuki
    (22, '04103', 'Leipzig', 'Karl-Liebknecht-Straße', '19'),
    (22, '06108', 'Halle (Saale)', 'Leipziger Straße', '42'),

    -- Tanaka, Haruto
    (23, '80333', 'München', 'Leopoldstraße', '28'),

    -- Chen, Mei
    (24, '01067', 'Dresden', 'Prager Straße', '33'),

    -- Wang, Wei
    (25, '20097', 'Hamburg', 'Hammerbrookstraße', '6'),
    (25, '28195', 'Bremen', 'Sögestraße', '15'),

    -- Zhang, Lin
    (26, '50674', 'Köln', 'Aachener Straße', '77'),

    -- Kim, Min-Jae
    (27, '40210', 'Düsseldorf', 'Schadowstraße', '12'),

    -- Park, Ji-Won
    (28, '70174', 'Stuttgart', 'Theodor-Heuss-Straße', '9'),
    (28, '76133', 'Karlsruhe', 'Kaiserstraße', '41'),

    -- Singh, Arjun
    (29, '01069', 'Dresden', 'Bergstraße', '16'),

    -- Patel, Priya
    (30, '04107', 'Leipzig', 'Karl-Heine-Straße', '24'),

    -- Khan, Aisha
    (31, '60313', 'Frankfurt am Main', 'Zeil', '88'),
    (31, '65183', 'Wiesbaden', 'Kirchgasse', '19'),

    -- Hassan, Omar
    (32, '01099', 'Dresden', 'Hechtstraße', '41'),

    -- Abdullah, Layla
    (33, '24105', 'Kiel', 'Düsternbrooker Weg', '13'),

    -- Williams, James
    (34, '10117', 'Berlin', 'Leipziger Straße', '54'),
    (34, '14467', 'Potsdam', 'Brandenburger Straße', '22'),

    -- Johnson, Emily
    (35, '20099', 'Hamburg', 'Steindamm', '32'),

    -- Brown, Michael
    (36, '50668', 'Köln', 'Eigelstein', '27'),

    -- Smith, Olivia
    (37, '80336', 'München', 'Lindwurmstraße', '18'),
    (37, '93047', 'Regensburg', 'Maximilianstraße', '31'),

    -- Taylor, Ethan
    (38, '01067', 'Dresden', 'Kreuzstraße', '10'),

    -- Wilson, Charlotte
    (39, '70182', 'Stuttgart', 'Hauptstätter Straße', '22'),

    -- Anderson, Noah
    (40, '90403', 'Nürnberg', 'Burgstraße', '7'),
    (40, '97070', 'Würzburg', 'Domstraße', '15'),

    -- Okafor, Chinedu
    (41, '01099', 'Dresden', 'Kamenzer Straße', '35'),

    -- Mensah, Ama
    (42, '50667', 'Köln', 'Hohenzollernring', '44'),

    -- Diallo, Ibrahim
    (43, '04109', 'Leipzig', 'Grimmaische Straße', '16'),
    (43, '01067', 'Dresden', 'Seestraße', '8'),

    -- Ndlovu, Thandiwe
    (44, '20095', 'Hamburg', 'Mönckebergstraße', '39'),

    -- Costa, Beatriz
    (45, '01067', 'Dresden', 'Schießgasse', '3'),

    -- Santos, Rafael
    (46, '80331', 'München', 'Sendlinger Straße', '21'),
    (46, '90402', 'Nürnberg', 'Kaiserstraße', '17'),

    -- Silva, Mariana
    (47, '01097', 'Dresden', 'Radeberger Straße', '58'),

    -- Petrović, Nikola
    (48, '79098', 'Freiburg im Breisgau', 'Bertoldstraße', '12'),

    -- Kovač, Ivana
    (49, '04105', 'Leipzig', 'Eutritzscher Straße', '29'),
    (49, '01069', 'Dresden', 'Wiener Straße', '46'),

    -- Alvarez, Diego
    (50, '50667', 'Köln', 'Breite Straße', '63');


/*------------------------------------------------------------------------------------*/
/*----------------------- Telefonnummern anlegen -------------------------------------*/
/*------------------------------------------------------------------------------------*/

INSERT INTO [dbo].[PhoneConnection]
    ([PersonId], [PhoneNumber])
VALUES
    -- Müller, Anna
    (1, '0351 1234567'),
    (1, '0171 2345678'),

    -- Schmidt, Thomas
    (2, '+49 351 2345678'),

    -- Rossi, Giulia
    (3, '030 34567890'),
    (3, '+49 151 34567890'),

    -- Garcia, Miguel
    (4, '0221 4567890'),

    -- Andersson, Sofia
    (5, '+49 40 5678901'),
    (5, '0176 56789012'),

    -- Dubois, Claire
    (6, '069 6789012'),

    -- Petrov, Alexander
    (7, '+49 89 7890123'),
    (7, '+49 160 7890123'),

    -- Nowak, Katarzyna
    (8, '0341 8901234'),

    -- Silva, João
    (9, '+49 351 9012345'),
    (9, '0151 90123456'),

    -- Kowalski, Mateusz
    (10, '0351 1122334'),

    -- Martin, Sophie
    (11, '+49 711 2233445'),
    (11, '0176 22334455'),

    -- O'Connor, Liam
    (12, '0221 3344556'),

    -- Hansen, Freja
    (13, '+49 431 4455667'),
    (13, '0170 44556677'),

    -- Papadopoulos, Nikos
    -- keine Telefonnummer

    -- Fernandez, Lucía
    (15, '0211 5566778'),

    -- Ivanov, Dmitri
    -- keine Telefonnummer

    -- Moreau, Émilie
    (17, '+49 761 6677889'),
    (17, '+49 152 66778899'),

    -- Svensson, Erik
    -- keine Telefonnummer

    -- Bianchi, Matteo
    (19, '0911 7788990'),

    -- Müller, Lena
    (20, '+49 351 8899001'),
    (20, '0172 88990011'),
    (20, '0351 8899002'),

    -- Schneider, Jonas
    (21, '0351 9900112'),

    -- Nakamura, Yuki
    (22, '+49 341 1011121'),
    (22, '0157 10111213'),

    -- Tanaka, Haruto
    (23, '089 1213141'),

    -- Chen, Mei
    (24, '+49 351 1314151'),

    -- Wang, Wei
    (25, '040 1516171'),
    (25, '+49 171 15161718'),

    -- Zhang, Lin
    -- keine Telefonnummer

    -- Kim, Min-Jae
    (27, '+49 211 1718192'),
    (27, '0160 17181920'),

    -- Park, Ji-Won
    (28, '0711 1920212'),

    -- Singh, Arjun
    (29, '+49 351 2021223'),

    -- Patel, Priya
    (30, '0341 2122234'),
    (30, '+49 176 21222345'),

    -- Khan, Aisha
    (31, '069 2223245'),

    -- Hassan, Omar
    (32, '+49 351 2324256'),
    (32, '0151 23242567'),

    -- Abdullah, Layla
    -- keine Telefonnummer

    -- Williams, James
    (34, '+49 30 2526273'),
    (34, '0176 25262738'),

    -- Johnson, Emily
    (35, '040 2627283'),

    -- Brown, Michael
    (36, '+49 221 2728293'),
    (36, '+49 151 27282930'),

    -- Smith, Olivia
    (37, '089 2829304'),

    -- Taylor, Ethan
    -- keine Telefonnummer

    -- Wilson, Charlotte
    (39, '+49 711 3031324'),
    (39, '0170 30313245'),

    -- Anderson, Noah
    (40, '0911 3132334'),

    -- Okafor, Chinedu
    (41, '+49 351 3233345'),
    (41, '0162 32333456'),
    (41, '0351 3233346'),

    -- Mensah, Ama
    (42, '0221 3334354'),

    -- Diallo, Ibrahim
    (43, '+49 341 3435365'),
    (43, '0177 34353656'),

    -- Ndlovu, Thandiwe
    -- keine Telefonnummer

    -- Costa, Beatriz
    (45, '+49 351 3637384'),

    -- Santos, Rafael
    (46, '089 3738394'),
    (46, '+49 152 37383945'),

    -- Silva, Mariana
    (47, '0351 3839405'),

    -- Petrović, Nikola
    -- keine Telefonnummer

    -- Kovač, Ivana
    (49, '+49 341 3940415'),
    (49, '0171 39404156'),

    -- Alvarez, Diego
    (50, '0221 4041425'),
    (50, '0151 40414256');