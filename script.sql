CREATE TABLE Commande(
   id INT,
   PRIMARY KEY(id)
);

CREATE TABLE Conso(
   id INT,
   nom VARCHAR(50),
   PRIMARY KEY(id)
);

CREATE TABLE contenir(
   id INT,
   id_1 INT,
   etat VARCHAR(50),
   PRIMARY KEY(id, id_1),
   FOREIGN KEY(id) REFERENCES Commande(id),
   FOREIGN KEY(id_1) REFERENCES Conso(id)
);
