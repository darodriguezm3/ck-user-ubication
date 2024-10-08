-- Crear esquema (opcional)
CREATE SCHEMA IF NOT EXISTS public;

-- 1. Tabla de País
CREATE TABLE IF NOT EXISTS public.country (
    id SERIAL PRIMARY KEY,          -- Identificador del país
    name VARCHAR(100) NOT NULL UNIQUE  -- Nombre del país
);

-- 2. Tabla de Departamento
CREATE TABLE IF NOT EXISTS public.department (
    id SERIAL PRIMARY KEY,                 -- Identificador del departamento
    name VARCHAR(100) NOT NULL,            -- Nombre del departamento
    country_id INT NOT NULL,               -- Clave foránea hacia la tabla país
    CONSTRAINT fk_country FOREIGN KEY (country_id) REFERENCES public.country(id) ON DELETE CASCADE
);

-- 3. Tabla de Municipio
CREATE TABLE IF NOT EXISTS public.municipality (
    id SERIAL PRIMARY KEY,               -- Identificador del municipio
    name VARCHAR(100) NOT NULL,          -- Nombre del municipio
    department_id INT NOT NULL,          -- Clave foránea hacia la tabla departamento
    CONSTRAINT fk_department FOREIGN KEY (department_id) REFERENCES public.department(id) ON DELETE CASCADE
);

-- 4. Tabla de Usuario
CREATE TABLE IF NOT EXISTS public."user" (
    id SERIAL PRIMARY KEY,                -- Identificador del usuario
    name VARCHAR(100) NOT NULL,           -- Nombre del usuario
    phone VARCHAR(20),                    -- Teléfono del usuario
    address TEXT,                         -- Dirección del usuario
    municipality_id INT NOT NULL,         -- Clave foránea hacia municipio
    CONSTRAINT fk_municipality_user FOREIGN KEY (municipality_id) REFERENCES public.municipality(id) ON DELETE CASCADE
);

-- Índices en las claves foráneas
CREATE INDEX idx_department_country ON public.department (country_id);
CREATE INDEX idx_municipality_department ON public.municipality (department_id);
CREATE INDEX idx_user_municipality ON public."user" (municipality_id);


-- Población inicial de países
INSERT INTO public.country (name) VALUES ('Colombia'), ('México');

-- Población inicial de departamentos (en este caso de Colombia)
INSERT INTO public.department (name, country_id) VALUES ('Antioquia', 1), ('Cundinamarca', 1);

-- Población inicial de municipios (en este caso de Antioquia)
INSERT INTO public.municipality (name, department_id) VALUES ('Medellín', 1), ('Envigado', 1);

-- Insertar un usuario
INSERT INTO public."user" (name, phone, address, country_id, department_id, municipality_id)
VALUES ('Juan Pérez', '123456789', 'Calle Falsa 123', 1, 1, 1);