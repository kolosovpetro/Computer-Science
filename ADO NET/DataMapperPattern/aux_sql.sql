SELECT * FROM clients;

INSERT INTO clients (client_id, first_name, last_name, birthday) VALUES (8, 'Andrey', 'Velikiy', '1994-03-19');

SELECT *
FROM copies
WHERE movie_id = 3
ORDER BY movie_id;

SELECT * FROM rentals WHERE client_id = 9;

UPDATE clients SET first_name = 'firstname', last_name = 'lastname', birthday = 'birthday' WHERE client_id = id;

UPDATE copies
SET
available = true
WHERE movie_id = 7;