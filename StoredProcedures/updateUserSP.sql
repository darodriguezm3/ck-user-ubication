CREATE OR REPLACE PROCEDURE update_user(
    p_user_id INT,
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address TEXT,
    p_town_id INT
) RETURNS VOID AS $$
BEGIN
    UPDATE public."user"
    SET name = p_name, phone = p_phone, address = p_address, town_id = p_town_id
    WHERE id = p_user_id;
END;
$$ LANGUAGE plpgsql;
