CREATE OR REPLACE PROCEDURE register_user(
    p_name TEXT,
    p_phone TEXT,
    p_address TEXT,
    p_town_id INTEGER
)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO public."user" (name, phone, address, town_id)
    VALUES (p_name, p_phone, p_address, p_town_id);
END;
$$;
