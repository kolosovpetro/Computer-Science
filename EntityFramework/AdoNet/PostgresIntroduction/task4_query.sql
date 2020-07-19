SELECT c.copy_id, c.available, cl.first_name, cl.last_name
FROM copies c
JOIN rentals r ON r.copy_id = c.copy_id
JOIN clients cl ON cl.client_id = r.client_id
WHERE movie_id = 3