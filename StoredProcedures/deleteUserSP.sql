CREATE OR REPLACE PROCEDURE delete_user(p_user_id INT)
RETURNS VOID AS $$
BEGIN
    DELETE FROM public."user" WHERE id = p_user_id;
END;
$$ LANGUAGE plpgsql;
