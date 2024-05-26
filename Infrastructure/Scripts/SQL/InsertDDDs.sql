-- Norte
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('68', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Acre')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('96', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Amap�')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('92', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Amazonas')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('91', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Par�')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('69', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Rond�nia')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('95', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Roraima')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('63', (SELECT Id FROM Regiao WHERE Nome = 'Norte' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Tocantins')));

-- Nordeste
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('82', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Alagoas')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('71', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Bahia')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('85', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Cear�')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('98', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Maranh�o')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('83', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Para�ba')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('81', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Pernambuco')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('86', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Piau�')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('84', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Rio Grande do Norte')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('79', (SELECT Id FROM Regiao WHERE Nome = 'Nordeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Sergipe')));

-- Centro-Oeste
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('62', (SELECT Id FROM Regiao WHERE Nome = 'Centro-Oeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Goi�s')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('65', (SELECT Id FROM Regiao WHERE Nome = 'Centro-Oeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Mato Grosso')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('67', (SELECT Id FROM Regiao WHERE Nome = 'Centro-Oeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Mato Grosso do Sul')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('61', (SELECT Id FROM Regiao WHERE Nome = 'Centro-Oeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Distrito Federal')));

-- Sudeste
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('27', (SELECT Id FROM Regiao WHERE Nome = 'Sudeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Esp�rito Santo')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('31', (SELECT Id FROM Regiao WHERE Nome = 'Sudeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Minas Gerais')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('21', (SELECT Id FROM Regiao WHERE Nome = 'Sudeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Rio de Janeiro')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('11', (SELECT Id FROM Regiao WHERE Nome = 'Sudeste' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'S�o Paulo')));

-- Sul
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('41', (SELECT Id FROM Regiao WHERE Nome = 'Sul' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Paran�')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('51', (SELECT Id FROM Regiao WHERE Nome = 'Sul' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Rio Grande do Sul')));
INSERT INTO DDD (Codigo, RegiaoId) VALUES ('48', (SELECT Id FROM Regiao WHERE Nome = 'Sul' AND EstadoId = (SELECT Id FROM Estado WHERE Nome = 'Santa Catarina')));
