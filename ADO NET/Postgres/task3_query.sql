SELECT *
FROM copies c
JOIN rentals r ON r.copy_id = c.copy_id
JOIN clients cl ON cl.client_id = r.client_id
WHERE movie_id = 4 AND available = true
