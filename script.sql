CREATE TABLE forms (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE inputs (
    id SERIAL PRIMARY KEY,
    form_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    type VARCHAR(50) NOT NULL,
    required BOOLEAN NOT NULL,
    CONSTRAINT fk_form FOREIGN KEY (form_id) REFERENCES forms(id) ON DELETE CASCADE
);

-- Insertar datos de prueba en forms
INSERT INTO forms (name) VALUES ('Personas');
INSERT INTO forms (name) VALUES ('Mascotas');

-- Insertar datos de prueba para el formulario Personas
INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Nombres', 'text', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Fecha de Nacimiento', 'date', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Estatura', 'number', FALSE);

-- Insertar datos de prueba para el formulario Mascotas
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Especie', 'text', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Raza', 'text', FALSE);
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Color', 'text', FALSE);
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Nombre', 'text', TRUE);
