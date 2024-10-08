CREATE OR REPLACE FUNCTION get_all_users()
RETURNS TABLE (
    id INT,
    name VARCHAR,
    phone VARCHAR,
    address TEXT,
    town_id INT
) AS $$
BEGIN
    RETURN QUERY
    SELECT u.id, u.name, u.phone, u.address, u.town_id
    FROM public."user" u;
END;
$$ LANGUAGE plpgsql;
