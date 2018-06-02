# 1. What query would you run to get all the customers inside city_id = 312? Your query should return customer first name, last name, email, and address.
SELECT concat(customer.first_name," ",customer.last_name) AS 'Customer Name',customer.email,address.address
FROM customer
JOIN address ON address.address_id = customer.address_id
WHERE address.city_id = 312;

# 2. What query would you run to get all comedy films? Your query should return film title, description, release year, rating, special features, and genre (category).
SELECT film_text.title,film_text.description,film.release_year,film.rating,film.special_features,category.name
FROM film
JOIN film_text ON film_text.film_id = film.film_id
JOIN film_category ON film_category.film_id = film.film_id
JOIN category ON film_category.category_id = category.category_id
WHERE category.name IN ('Comedy');

# 3. What query would you run to get all the films joined by actor_id=5? Your query should return the actor id, actor name, film title, description, and release year.
SELECT DISTINCT actor.actor_id, concat(actor.first_name," ",actor.last_name) AS 'Actor Name',film_text.title,film_text.description,film.release_year
FROM actor
JOIN film_actor ON film_actor.actor_id = actor.actor_id
JOIN film ON film.film_id = film_actor.film_id
JOIN film_text on film.film_id = film_text.film_id
WHERE actor.actor_id = 5;

# 4. What query would you run to get all the customers in store_id = 1 and inside these cities (1, 42, 312 and 459)? Your query should return customer first name, last name, email, and address.
SELECT store.store_id,concat(customer.first_name," ",customer.last_name) AS 'Customer',customer.email,address.address
FROM store
JOIN customer ON store.store_id = customer.store_id
JOIN address ON address.address_id = customer.address_id
WHERE customer.store_id = 1 AND address.city_id IN (1,42,312,459);

# 5. What query would you run to get all the films with a "rating = G" and "special feature = behind the scenes", joined by actor_id = 15? Your query should return the film title, description, release year, rating, and special feature. Hint: You may use LIKE function in getting the 'behind the scenes' part.
SELECT film_text.title,film_text.description,film.rating,film.special_features
FROM actor
JOIN film_actor ON film_actor.actor_id = actor.actor_id
JOIN film ON film.film_id = film_actor.film_id
JOIN film_text on film.film_id = film_text.film_id
WHERE film.rating IN ('G') AND actor.actor_id = 15 AND film.special_features LIKE '%behind%';


# 6. What query would you run to get all the actors that joined in the film_id = 369? Your query should return the film_id, title, actor_id, and actor_name.
SELECT actor.actor_id,concat(actor.first_name,' ',actor.last_name) AS 'Name',film.film_id,film_text.title
FROM actor
JOIN film_actor ON film_actor.actor_id = actor.actor_id
JOIN film ON film.film_id = film_actor.film_id
JOIN film_text on film.film_id = film_text.film_id
WHERE film.film_id = 369;

# 7. What query would you run to get all drama films with a rental rate of 2.99? Your query should return film title, description, release year, rating, special features, and genre (category).
SELECT film_text.title,film_text.description,film.release_year,film.rating,film.special_features
FROM film
JOIN film_text ON film_text.film_id = film.film_id
JOIN film_category ON film_category.film_id = film.film_id
JOIN category ON category.category_id = film_category.category_id
WHERE film.rental_rate IN ('2.99') AND category.name IN ('Drama');

# 8. What query would you run to get all the action films which are joined by SANDRA KILMER? Your query should return film title, description, release year, rating, special features, genre (category), and actor's first name and last name.
SELECT film_text.title,film_text.description,film.release_year,film.rating,film.special_features,category.name,concat(actor.first_name,' ',actor.last_name) AS 'Actor Name'
FROM film
JOIN film_text ON film_text.film_id = film.film_id
JOIN film_category ON film_category.film_id = film.film_id
JOIN category ON category.category_id = film_category.category_id
JOIN film_actor ON film_actor.film_id = film.film_id
JOIN actor ON actor.actor_id = film_actor.actor_id
WHERE actor.first_name IN ('SANDRA') AND actor.last_name IN ('KILMER') AND category.name IN ('Action');
