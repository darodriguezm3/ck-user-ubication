CREATE OR REPLACE FUNCTION update_user(
    p_user_id INT,
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address TEXT,
    p_municipality_id INT
) RETURNS VOID AS $$
BEGIN
    UPDATE public."user"
    SET name = p_name, phone = p_phone, address = p_address, municipality_id = p_municipality_id
    WHERE id = p_user_id;
END;
$$ LANGUAGE plpgsql;
