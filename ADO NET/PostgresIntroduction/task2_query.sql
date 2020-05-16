SELECT first_name ,last_name
FROM actors a
JOIN starring s ON s.actor_id=a.actor_id
JOIN movies m ON m.movie_id=s.movie_id
WHERE m.movie_id = 1;

