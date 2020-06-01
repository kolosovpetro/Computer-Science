BEGIN;
--Dropping previously created tables
DROP TABLE IF EXISTS starring CASCADE;
DROP TABLE IF EXISTS rentals CASCADE;
DROP TABLE IF EXISTS copies CASCADE; 
DROP TABLE IF EXISTS actors CASCADE;
DROP TABLE IF EXISTS clients CASCADE;
DROP TABLE IF EXISTS employees CASCADE;
DROP TABLE IF EXISTS movies CASCADE;

--Creating new database schema
CREATE TABLE public.actors
(
  actor_id integer NOT NULL,
  first_name character varying,
  last_name character varying,
  birthday timestamp with time zone,
  CONSTRAINT actors_pkey PRIMARY KEY (actor_id)
);

CREATE TABLE public.movies
(
  title character varying NOT NULL,
  year integer NOT NULL,
  age_restriction integer,
  movie_id integer NOT NULL,
  price real,
  CONSTRAINT movies_pkey PRIMARY KEY (movie_id)
);

CREATE TABLE public.starring
(
  actor_id integer NOT NULL,
  movie_id integer NOT NULL,
  CONSTRAINT starring_pkey PRIMARY KEY (actor_id, movie_id),
  CONSTRAINT starring_actor_id_fkey FOREIGN KEY (actor_id)
      REFERENCES public.actors (actor_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT starring_movie_id_fkey FOREIGN KEY (movie_id)
      REFERENCES public.movies (movie_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE public.clients
(
  client_id integer NOT NULL,
  first_name character varying,
  last_name character varying,
  birthday timestamp with time zone,
  CONSTRAINT clients_pkey PRIMARY KEY (client_id)
);

CREATE TABLE public.copies
(
  copy_id integer NOT NULL,
  available boolean,
  movie_id integer,
  CONSTRAINT copies_pkey PRIMARY KEY (copy_id),
  CONSTRAINT copies_movie_id_fkey FOREIGN KEY (movie_id)
      REFERENCES public.movies (movie_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE public.rentals
(
  copy_id integer NOT NULL,
  client_id integer NOT NULL,
  date_of_rental timestamp with time zone,
  date_of_return timestamp with time zone,
  CONSTRAINT rentals_pkey PRIMARY KEY (copy_id, client_id),
  CONSTRAINT rentals_client_id_fkey FOREIGN KEY (client_id)
      REFERENCES public.clients (client_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT rentals_copy_id_fkey FOREIGN KEY (copy_id)
      REFERENCES public.copies (copy_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE public.employees
(
  employee_id integer NOT NULL,
  first_name character varying,
  last_name character varying,
  city character varying,
  salary real,
  CONSTRAINT employees_pkey PRIMARY KEY (employee_id)
);


--Filling tables with data
INSERT INTO employees (employee_id, first_name, last_name, city, salary)
VALUES
(1, 'John', 'Smith', 'New York', 150),
(2, 'Ben', 'Johnson', 'New York', 250),
(3, 'Louis', 'Armstrong', 'New Orleans', 75),
(4, 'John', 'Lennon', 'London', 300),
(5, 'Peter', 'Gabriel', 'London', 100);

INSERT INTO movies (movie_id, title, year,age_restriction, price)
VALUES
(1,'Star Wars Episode IV: A New Hope', 1979, 12, 10),
(2,'Ghostbusters',1984, 12, 5.5),
(3,'Terminator',1984, 15, 8.5),
(4,'Taxi Driver', 1976, 17, 5),
(5,'Platoon',1986, 18, 5),
(6,'Frantic',1988, 15, 8.5),
(7,'Ronin',1998, 13, 9.5),
(8,'Analyze This',1999, 16, 10.5),
(9,'Leon: the Professional',1994, 16, 8.5),
(10,'Mission Impossible',1996, 13, 8.5);

INSERT INTO actors (actor_id, first_name, last_name, birthday)
VALUES 
(1,'Arnold','Schwarzenegger', '1947-07-30'),
(2,'Anthony', 'Daniels', '1946-02-21'),
(3,'Harrison', 'Ford', '1942-07-13'),
(4,'Carrie', 'Fisher', '1956-10-21'),
(5,'Alec', 'Guiness', '1914-04-02'),
(6,'Peter', 'Cushing', '1913-05-26'),
(7,'David', 'Prowse', '1944-05-19'),
(8,'Peter', 'Mayhew', '1935-07-01'),
(9,'Michael', 'Biehn', '1956-07-31'),
(10,'Linda', 'Hamilton', '1956-09-26'),
(11,'Bill', 'Murray', '1950-09-21'),
(12,'Dan', 'Aykroyd', '1952-07-01'),
(13,'Sigourney', 'Weaver', '1949-10-08'),
(14,'Robert', 'De Niro', '1943-08-17'),
(15,'Jodie', 'Foster', '1962-11-19'),
(16,'Harvey', 'Keitel', '1939-05-13'),
(17,'Cybill', 'Shepherd', '1950-02-18'),
(18,'Tom', 'Berenger', '1949-05-31'),
(19,'Willem', 'Dafoe', '1955-07-22'),
(20,'Charlie', 'Sheen', '1965-09-03'),
(21,'Harrison', 'Ford', '1942-07-13'),
(22,'Emmanuelle', 'Seigner', '1966-06-22'),
(23,'Jean', 'Reno', '1948-07-30'),
(24,'Billy', 'Crystal', '1948-03-14'),
(25,'Lisa', 'Kudrow', '1963-07-30'),
(26,'Gary', 'Oldman', '1958-03-21'),
(27,'Natalie', 'Portman', '1981-06-09'),
(28,'Tom', 'Cruise', '1962-07-03');

INSERT INTO starring (actor_id, movie_id)
VALUES
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 1),
(7, 1),
(8, 1),
(1, 3),
(9, 3),
(10,3),
(11,2),
(12,2),
(13,2),
(14,4),
(15,4),
(16,4),
(17,4),
(18,5),
(19,5),
(20,5),
(21,6),
(22,6),
(14,7),
(23,7),
(14,8),
(24,8),
(25,8),
(23,9),
(27,9),
(23,10),
(28,10);

INSERT INTO copies (copy_id, movie_id, available)
VALUES
(1,1,true),
(2,1,false),
(3,2,true),
(4,3,true),
(5,3,false),
(6,3,true),
(7,4,true),
(8,5,false),
(9,6,true),
(10,6,false),
(11,6,true),
(12,7,true),
(13,7,true),
(14,8,false),
(15,9,true),
(16,10,true),
(17,10,false),
(18,10,true),
(19,10,true),
(20,10,true);

INSERT INTO clients (client_id, first_name, last_name, birthday)
VALUES
(1,'Hank','Hill', '1954-04-19'),
(2,'Brian','Griffin', '2011-09-11'),
(3,'Gary', 'Goodspeed', '1989-03-12'),
(4,'Bob', 'Belcher', '1977-01-23'),
(5,'Lisa', 'Simpson', '2012-05-09'),
(6,'Rick', 'Sanchez', '1965-03-17');


INSERT INTO rentals (client_id, copy_id, date_of_rental, date_of_return)
VALUES
(1,1, '2005-07-04','2005-07-05'),
(1,6, '2005-07-19','2005-07-22'),
(2,3, '2005-07-24','2005-07-25'),
(2,5, '2005-07-26','2005-07-27'),
(2,7, '2005-07-29','2005-07-30'),
(3,12,'2005-07-10','2005-07-13'),
(3,20,'2005-07-16','2005-07-17'),
(3,3, '2005-07-22','2005-07-23'),
(3,7, '2005-07-24','2005-07-25'),
(4,13,'2005-07-01','2005-07-05'),
(5,11,'2005-07-10','2005-07-13'),
(6,1, '2005-07-06','2005-07-07'),
(6,7, '2005-07-29','2005-07-30'),
(6,19,'2005-07-29','2005-07-30');

COMMIT;