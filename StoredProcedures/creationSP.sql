CREATE OR REPLACE FUNCTION register_user(
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address TEXT,
    p_municipality_id INT
) RETURNS VOID AS $$
BEGIN
    INSERT INTO public."user" (name, phone, address, municipality_id)
    VALUES (p_name, p_phone, p_address, p_municipality_id);
END;
$$ LANGUAGE plpgsql;
