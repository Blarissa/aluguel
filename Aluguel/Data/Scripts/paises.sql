CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

INSERT INTO paises (id,codigo, nome) VALUES
(uuid_generate_v1(), 'af', 'Afeganistão'),
(uuid_generate_v1(), 'za', 'África do Sul'),
(uuid_generate_v1(), 'al', 'Albânia'),
(uuid_generate_v1(), 'de', 'Alemanha'),
(uuid_generate_v1(), 'ad', 'Andorra'),
(uuid_generate_v1(), 'ao', 'Angola'),
(uuid_generate_v1(), 'ag', 'Antígua e Barbuda'),
(uuid_generate_v1(), 'sa', 'Arábia Saudita'),
(uuid_generate_v1(), 'dz', 'Argélia'),
(uuid_generate_v1(), 'ar', 'Argentina'),
(uuid_generate_v1(), 'am', 'Armênia'),
(uuid_generate_v1(), 'au', 'Austrália'),
(uuid_generate_v1(), 'at', 'Áustria'),
(uuid_generate_v1(), 'az', 'Azerbaijão'),
(uuid_generate_v1(), 'bs', 'Bahamas'),
(uuid_generate_v1(), 'bd', 'Bangladexe'),
(uuid_generate_v1(), 'bb', 'Barbados'),
(uuid_generate_v1(), 'bh', 'Barém'),
(uuid_generate_v1(), 'be', 'Bélgica'),
(uuid_generate_v1(), 'bz', 'Belize'),
(uuid_generate_v1(), 'bj', 'Benim'),
(uuid_generate_v1(), 'by', 'Bielorrússia'),
(uuid_generate_v1(), 'bo', 'Bolívia'),
(uuid_generate_v1(), 'ba', 'Bósnia e Herzegovina'),
(uuid_generate_v1(), 'bw', 'Botsuana'),
(uuid_generate_v1(), 'br', 'Brasil'),
(uuid_generate_v1(), 'bn', 'Brunei'),
(uuid_generate_v1(), 'bg', 'Bulgária'),
(uuid_generate_v1(), 'bf', 'Burquina Fasso'),
(uuid_generate_v1(), 'bi', 'Burundi'),
(uuid_generate_v1(), 'bt', 'Butão'),
(uuid_generate_v1(), 'cv', 'Cabo Verde'),
(uuid_generate_v1(), 'kh', 'Camboja'),
(uuid_generate_v1(), 'cm', 'Camarões'),
(uuid_generate_v1(), 'ca', 'Canadá'),
(uuid_generate_v1(), 'qa', 'Catar'),
(uuid_generate_v1(), 'kz', 'Cazaquistão'),
(uuid_generate_v1(), 'cf', 'República Centro-Africana'),
(uuid_generate_v1(), 'td', 'Chade'),
(uuid_generate_v1(), 'cz', 'Chéquia'),
(uuid_generate_v1(), 'cl', 'Chile'),
(uuid_generate_v1(), 'cn', 'China'),
(uuid_generate_v1(), 'cy', 'Chipre'),
(uuid_generate_v1(), 'co', 'Colômbia'),
(uuid_generate_v1(), 'km', 'Comores'),
(uuid_generate_v1(), 'cg', 'República do Congo'),
(uuid_generate_v1(), 'cd', 'República Democrática do Congo'),
(uuid_generate_v1(), 'kr', 'Coreia do Sul'),
(uuid_generate_v1(), 'kp', 'Coreia do Norte'),
(uuid_generate_v1(), 'ci', 'Costa do Marfim'),
(uuid_generate_v1(), 'cr', 'Costa Rica'),
(uuid_generate_v1(), 'hr', 'Croácia'),
(uuid_generate_v1(), 'cu', 'Cuba'),
(uuid_generate_v1(), 'dk', 'Dinamarca'),
(uuid_generate_v1(), 'dj', 'Djibuti'),
(uuid_generate_v1(), 'dm', 'Dominica'),
(uuid_generate_v1(), 'do', 'República Dominicana'),
(uuid_generate_v1(), 'eg', 'Egito'),
(uuid_generate_v1(), 'sv', 'El Salvador'),
(uuid_generate_v1(), 'ae', 'Emirados Árabes Unidos'),
(uuid_generate_v1(), 'ec', 'Equador'),
(uuid_generate_v1(), 'er', 'Eritreia'),
(uuid_generate_v1(), 'sk', 'Eslováquia'),
(uuid_generate_v1(), 'si', 'Eslovênia'),
(uuid_generate_v1(), 'es', 'Espanha'),
(uuid_generate_v1(), 'us', 'Estados Unidos'),
(uuid_generate_v1(), 'ee', 'Estónia'),
(uuid_generate_v1(), 'sz', 'Essuatíni'),
(uuid_generate_v1(), 'et', 'Etiópia'),
(uuid_generate_v1(), 'fj', 'Fiji'),
(uuid_generate_v1(), 'ph', 'Filipinas'),
(uuid_generate_v1(), 'fi', 'Finlândia'),
(uuid_generate_v1(), 'fr', 'França'),
(uuid_generate_v1(), 'ga', 'Gabão'),
(uuid_generate_v1(), 'gm', 'Gâmbia'),
(uuid_generate_v1(), 'gh', 'Gana'),
(uuid_generate_v1(), 'ge', 'Geórgia'),
(uuid_generate_v1(), 'gd', 'Granada'),
(uuid_generate_v1(), 'gr', 'Grécia'),
(uuid_generate_v1(), 'gt', 'Guatemala'),
(uuid_generate_v1(), 'gy', 'Guiana'),
(uuid_generate_v1(), 'gw', 'Guiné-Bissau'),
(uuid_generate_v1(), 'gn', 'Guiné'),
(uuid_generate_v1(), 'gq', 'Guiné Equatorial'),
(uuid_generate_v1(), 'ht', 'Haiti'),
(uuid_generate_v1(), 'hn', 'Honduras'),
(uuid_generate_v1(), 'hu', 'Hungria'),
(uuid_generate_v1(), 'ye', 'Iêmen'),
(uuid_generate_v1(), 'in', 'Índia'),
(uuid_generate_v1(), 'id', 'Indonésia'),
(uuid_generate_v1(), 'iq', 'Iraque'),
(uuid_generate_v1(), 'ir', 'Irã'),
(uuid_generate_v1(), 'ie', 'Irlanda'),
(uuid_generate_v1(), 'is', 'Islândia'),
(uuid_generate_v1(), 'il', 'Israel'),
(uuid_generate_v1(), 'it', 'Itália'),
(uuid_generate_v1(), 'jm', 'Jamaica'),
(uuid_generate_v1(), 'jp', 'Japão'),
(uuid_generate_v1(), 'jo', 'Jordânia'),
(uuid_generate_v1(), 'kw', 'Kuwait'),
(uuid_generate_v1(), 'la', 'Laos'),
(uuid_generate_v1(), 'ls', 'Lesoto'),
(uuid_generate_v1(), 'lv', 'Letônia'),
(uuid_generate_v1(), 'lb', 'Líbano'),
(uuid_generate_v1(), 'lr', 'Libéria'),
(uuid_generate_v1(), 'ly', 'Líbia'),
(uuid_generate_v1(), 'li', 'Listenstaine'),
(uuid_generate_v1(), 'lt', 'Lituânia'),
(uuid_generate_v1(), 'lu', 'Luxemburgo'),
(uuid_generate_v1(), 'mk', 'Macedônia do Norte'),
(uuid_generate_v1(), 'mg', 'Madagáscar'),
(uuid_generate_v1(), 'my', 'Malásia'),
(uuid_generate_v1(), 'mw', 'Maláui'),
(uuid_generate_v1(), 'mv', 'Maldivas'),
(uuid_generate_v1(), 'ml', 'Mali'),
(uuid_generate_v1(), 'mt', 'Malta'),
(uuid_generate_v1(), 'ma', 'Marrocos'),
(uuid_generate_v1(), 'mh', 'Ilhas Marshall'),
(uuid_generate_v1(), 'mu', 'Ilhas Maurícias'),
(uuid_generate_v1(), 'mr', 'Mauritânia'),
(uuid_generate_v1(), 'mx', 'México'),
(uuid_generate_v1(), 'mm', 'Mianmar'),
(uuid_generate_v1(), 'fm', 'Estados Federados da Micronésia'),
(uuid_generate_v1(), 'mz', 'Moçambique'),
(uuid_generate_v1(), 'md', 'Moldávia'),
(uuid_generate_v1(), 'mc', 'Mónaco'),
(uuid_generate_v1(), 'mn', 'Mongólia'),
(uuid_generate_v1(), 'me', 'Montenegro'),
(uuid_generate_v1(), 'na', 'Namíbia'),
(uuid_generate_v1(), 'nr', 'Nauru'),
(uuid_generate_v1(), 'np', 'Nepal'),
(uuid_generate_v1(), 'ni', 'Nicarágua'),
(uuid_generate_v1(), 'ne', 'Níger'),
(uuid_generate_v1(), 'ng', 'Nigéria'),
(uuid_generate_v1(), 'no', 'Noruega'),
(uuid_generate_v1(), 'nz', 'Nova Zelândia'),
(uuid_generate_v1(), 'om', 'Omã'),
(uuid_generate_v1(), 'nl', 'Países Baixos'),
(uuid_generate_v1(), 'pw', 'Palau'),
(uuid_generate_v1(), 'pa', 'Panamá'),
(uuid_generate_v1(), 'pg', 'Papua-Nova Guiné'),
(uuid_generate_v1(), 'pk', 'Paquistão'),
(uuid_generate_v1(), 'py', 'Paraguai'),
(uuid_generate_v1(), 'pe', 'Peru'),
(uuid_generate_v1(), 'pl', 'Polónia'),
(uuid_generate_v1(), 'pt', 'Portugal'),
(uuid_generate_v1(), 'ke', 'Quênia'),
(uuid_generate_v1(), 'kg', 'Quirguistão'),
(uuid_generate_v1(), 'ki', 'Quiribáti'),
(uuid_generate_v1(), 'gb', 'Reino Unido'),
(uuid_generate_v1(), 'ro', 'Roménia'),
(uuid_generate_v1(), 'rw', 'Ruanda'),
(uuid_generate_v1(), 'ru', 'Rússia'),
(uuid_generate_v1(), 'ws', 'Samoa'),
(uuid_generate_v1(), 'sb', 'Ilhas Salomão'),
(uuid_generate_v1(), 'sm', 'San Marino'),
(uuid_generate_v1(), 'lc', 'Santa Lúcia'),
(uuid_generate_v1(), 'kn', 'São Cristóvão e Neves'),
(uuid_generate_v1(), 'st', 'São Tomé e Príncipe'),
(uuid_generate_v1(), 'vc', 'São Vicente e Granadinas'),
(uuid_generate_v1(), 'sc', 'Seicheles'),
(uuid_generate_v1(), 'sn', 'Senegal'),
(uuid_generate_v1(), 'lk', 'Seri Lanca'),
(uuid_generate_v1(), 'sl', 'Serra Leoa'),
(uuid_generate_v1(), 'rs', 'Sérvia'),
(uuid_generate_v1(), 'sg', 'Singapura'),
(uuid_generate_v1(), 'sy', 'Síria'),
(uuid_generate_v1(), 'so', 'Somália'),
(uuid_generate_v1(), 'sd', 'Sudão'),
(uuid_generate_v1(), 'ss', 'Sudão do Sul'),
(uuid_generate_v1(), 'se', 'Suécia'),
(uuid_generate_v1(), 'ch', 'Suíça'),
(uuid_generate_v1(), 'sr', 'Suriname'),
(uuid_generate_v1(), 'th', 'Tailândia'),
(uuid_generate_v1(), 'tj', 'Tajiquistão'),
(uuid_generate_v1(), 'tz', 'Tanzânia'),
(uuid_generate_v1(), 'tl', 'Timor-Leste'),
(uuid_generate_v1(), 'tg', 'Togo'),
(uuid_generate_v1(), 'to', 'Tonga'),
(uuid_generate_v1(), 'tt', 'Trinidad e Tobago'),
(uuid_generate_v1(), 'tn', 'Tunísia'),
(uuid_generate_v1(), 'tm', 'Turcomenistão'),
(uuid_generate_v1(), 'tr', 'Turquia'),
(uuid_generate_v1(), 'tv', 'Tuvalu'),
(uuid_generate_v1(), 'ua', 'Ucrânia'),
(uuid_generate_v1(), 'ug', 'Uganda'),
(uuid_generate_v1(), 'uy', 'Uruguai'),
(uuid_generate_v1(), 'uz', 'Uzbequistão'),
(uuid_generate_v1(), 'vu', 'Vanuatu'),
(uuid_generate_v1(), 've', 'Venezuela'),
(uuid_generate_v1(), 'vn', 'Vietname'),
(uuid_generate_v1(), 'zm', 'Zâmbia'),
(uuid_generate_v1(), 'zw', 'Zimbábue');