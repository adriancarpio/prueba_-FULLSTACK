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

INSERT INTO forms (name) VALUES ('Formulario de Contacto');
INSERT INTO forms (name) VALUES ('Registro de Usuario');

INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Nombre', 'text', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Correo Electrónico', 'email', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (1, 'Mensaje', 'textarea', FALSE);

INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Usuario', 'text', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Contraseña', 'password', TRUE);
INSERT INTO inputs (form_id, name, type, required) VALUES (2, 'Confirmar Contraseña', 'password', TRUE);
