CREATE OR REPLACE FUNCTION register_user(
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address TEXT,
    p_town_id INT
) RETURNS VOID AS $$
BEGIN
    INSERT INTO public."user" (name, phone, address, town_id)
    VALUES (p_name, p_phone, p_address, p_town_id);
END;
$$ LANGUAGE plpgsql;
