# 1. What query would you run to get the total revenue for March of 2012?
SELECT MONTHNAME(charged_datetime) AS 'Month',SUM(amount) AS 'Revenue'
FROM billing
WHERE MONTHNAME(charged_datetime) IN ('March');

# 2. What query would you run to get total revenue collected from the client with an id of 2?
SELECT SUM(billing.amount) As 'Total Revenue'
FROM billing
JOIN clients ON clients.client_id = billing.client_id
WHERE billing.client_id = 2;

# 3. What query would you run to get all the sites that client=10 owns?
SELECT sites.domain_name
FROM sites
JOIN clients ON clients.client_id = sites.client_id
WHERE sites.client_id = 10;

# 4. What query would you run to get total # of sites created per month per year for the client with an id of 1? What about for client=20?
SELECT YEAR(created_datetime) AS 'Year',MONTHNAME(created_datetime) AS 'Month', COUNT(*) AS 'Websites'
FROM sites
WHERE sites.client_id = 1
GROUP BY YEAR(created_datetime),MONTHNAME(created_datetime);

# 5. What query would you run to get the total # of leads generated for each of the sites between January 1, 2011 to February 15, 2011?
SELECT sites.domain_name, DATE(registered_datetime),COUNT(*) AS '# of Leads'
FROM leads
JOIN sites ON sites.site_id = leads.site_id
WHERE leads.registered_datetime >= '2011-01-01%' AND leads.registered_datetime <= '2011-02-15%'
GROUP BY sites.domain_name
ORDER BY COUNT(*);
# 6. What query would you run to get a list of client names and the total # of leads we've generated for each of our clients between January 1, 2011 to December 31, 2011?
SELECT concat(clients.first_name,' ',clients.last_name) AS 'Names',COUNT(*) AS 'Leads',DATE(leads.registered_datetime) AS 'Date'
FROM clients
JOIN sites ON sites.client_id = clients.client_id
JOIN leads ON leads.site_id = sites.site_id
WHERE leads.registered_datetime >= '2011-01-01%' AND leads.registered_datetime <= '2011-12-31%'
GROUP BY concat(clients.first_name,' ',clients.last_name);

# 7. What query would you run to get a list of client names and the total # of leads we've generated for each client each month between months 1 - 6 of Year 2011?
SELECT concat(clients.first_name,' ',clients.last_name) AS 'Names',COUNT(*) AS 'Leads',DATE(leads.registered_datetime) AS 'Date'
FROM clients
JOIN sites ON sites.client_id = clients.client_id
JOIN leads ON leads.site_id = sites.site_id
WHERE leads.registered_datetime >= '2011-01-01%' AND leads.registered_datetime <= '2011-06-30%'
GROUP BY concat(clients.first_name,' ',clients.last_name);

# 8. What query would you run to get a list of client names and the total # of leads we've generated for each of our clients' sites between January 1, 2011 to December 31, 2011? Order this query by client id.  Come up with a second query that shows all the clients, the site name(s), and the total number of leads generated from each site for all time.
SELECT concat(clients.first_name,' ',clients.last_name) AS 'Names',sites.domain_name,COUNT(*) AS 'Leads',DATE(leads.registered_datetime) AS 'Date'
FROM clients
JOIN sites ON sites.client_id = clients.client_id
JOIN leads ON leads.site_id = sites.site_id
WHERE leads.registered_datetime >= '2011-01-01%' AND leads.registered_datetime <= '2011-12-31%'
GROUP BY sites.domain_name
ORDER BY clients.client_id;

SELECT concat(clients.first_name,' ',clients.last_name) AS 'Names',sites.domain_name,COUNT(*) AS 'Leads',DATE(leads.registered_datetime) AS 'Date'
FROM clients
JOIN sites ON sites.client_id = clients.client_id
JOIN leads ON leads.site_id = sites.site_id
GROUP BY sites.domain_name
ORDER BY clients.client_id;

# 9. Write a single query that retrieves total revenue collected from each client for each month of the year. Order it by client id.
SELECT concat(clients.first_name,' ',clients.last_name) AS 'Names',MONTHNAME(billing.charged_datetime) AS 'Month',YEAR(billing.charged_datetime) AS 'Year',SUM(billing.amount) AS 'Revenue'
FROM billing
JOIN clients ON clients.client_id = billing.client_id
GROUP BY billing.charged_datetime
ORDER BY clients.client_id;

# 10. Write a single query that retrieves all the sites that each client owns. Group the results so that each row shows a new client. It will become clearer when you add a new field called 'sites' that has all the sites that the client owns. (HINT: use GROUP_CONCAT)

SELECT concat(clients.first_name,' ',clients.last_name) AS 'Client Name',group_concat(sites.domain_name) AS 'Domain Names'
FROM sites
JOIN clients ON clients.client_id = sites.client_id
GROUP BY sites.client_id
ORDER BY sites.client_id ASC;