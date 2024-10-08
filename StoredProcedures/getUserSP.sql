CREATE OR REPLACE FUNCTION get_user_by_id(p_user_id INT)
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
    FROM public."user" u
    WHERE u.id = p_user_id;
END;
$$ LANGUAGE plpgsql;
