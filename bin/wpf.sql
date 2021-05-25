--
-- PostgreSQL database dump
--

-- Dumped from database version 11.9 (Debian 11.9-0+deb10u1)
-- Dumped by pg_dump version 13.2

-- Started on 2021-05-20 19:57:33

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

--
-- TOC entry 199 (class 1259 OID 16410)
-- Name: adresse; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.adresse (
    "idAdresse" character varying(255) NOT NULL,
    pays character varying(45),
    region character varying(45),
    ville character varying(45),
    "codePostal" character varying(45),
    "adresseNom" character varying(255)
);


ALTER TABLE public.adresse OWNER TO andy_cinquin;

--
-- TOC entry 200 (class 1259 OID 16418)
-- Name: adressepersonne; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.adressepersonne (
    "adresseId" character varying(255) NOT NULL,
    "personneId" character varying(255) NOT NULL
);


ALTER TABLE public.adressepersonne OWNER TO andy_cinquin;

--
-- TOC entry 3712 (class 0 OID 0)
-- Dependencies: 200
-- Name: TABLE adressepersonne; Type: COMMENT; Schema: public; Owner: andy_cinquin
--

COMMENT ON TABLE public.adressepersonne IS 'TRIAL';


--
-- TOC entry 201 (class 1259 OID 16424)
-- Name: categorie; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.categorie (
    "idCategorie" character varying(255) NOT NULL,
    "nomCategorie" character varying(255) NOT NULL,
    "categorieId" character varying(255)
);


ALTER TABLE public.categorie OWNER TO andy_cinquin;

--
-- TOC entry 202 (class 1259 OID 16432)
-- Name: categorieproduit; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.categorieproduit (
    "categorieId" character varying(255) NOT NULL,
    "produitId" character varying(255) NOT NULL
);


ALTER TABLE public.categorieproduit OWNER TO andy_cinquin;

--
-- TOC entry 203 (class 1259 OID 16438)
-- Name: commissaire; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.commissaire (
    "idCommissaire" character varying(255) NOT NULL,
    "personneId" character varying(255) NOT NULL
);


ALTER TABLE public.commissaire OWNER TO andy_cinquin;

--
-- TOC entry 3713 (class 0 OID 0)
-- Dependencies: 203
-- Name: TABLE commissaire; Type: COMMENT; Schema: public; Owner: andy_cinquin
--

COMMENT ON TABLE public.commissaire IS 'TRIAL';


--
-- TOC entry 204 (class 1259 OID 16448)
-- Name: enchere; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.enchere (
    "idEnchere" character varying(255) NOT NULL,
    "ordreAchatId" character varying(255),
    "lotId" character varying(255) NOT NULL,
    "commissaireId" character varying(255) NOT NULL,
    "utilisateurId" character varying(255),
    "prixProposer" double precision,
    "dateHeureVente" timestamp(6) without time zone,
    "estAdjuger" boolean
);


ALTER TABLE public.enchere OWNER TO andy_cinquin;

--
-- TOC entry 3714 (class 0 OID 0)
-- Dependencies: 204
-- Name: TABLE enchere; Type: COMMENT; Schema: public; Owner: andy_cinquin
--

COMMENT ON TABLE public.enchere IS 'TRIAL';


--
-- TOC entry 205 (class 1259 OID 16456)
-- Name: estimation; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.estimation (
    "idEstimation" character varying(255) NOT NULL,
    "produitId" character varying(255) NOT NULL,
    "commissaireId" character varying(255) NOT NULL,
    "dateEstimation" timestamp(6) without time zone NOT NULL,
    "prixEstimation" double precision NOT NULL
);


ALTER TABLE public.estimation OWNER TO andy_cinquin;

--
-- TOC entry 3715 (class 0 OID 0)
-- Dependencies: 205
-- Name: TABLE estimation; Type: COMMENT; Schema: public; Owner: andy_cinquin
--

COMMENT ON TABLE public.estimation IS 'TRIAL';


--
-- TOC entry 206 (class 1259 OID 16464)
-- Name: lot; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.lot (
    "idLot" character varying(255) NOT NULL,
    "nomLot" character varying(255) NOT NULL,
    description text
);


ALTER TABLE public.lot OWNER TO andy_cinquin;

--
-- TOC entry 207 (class 1259 OID 16472)
-- Name: ordreachat; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.ordreachat (
    "idOrdreAchat" character varying(255) NOT NULL,
    "utilisateurId" character varying(255) NOT NULL,
    "lotId" character varying(255) NOT NULL,
    date timestamp(6) without time zone NOT NULL,
    "montantMax" double precision,
    informatiser boolean
);


ALTER TABLE public.ordreachat OWNER TO andy_cinquin;

--
-- TOC entry 208 (class 1259 OID 16481)
-- Name: paiement; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.paiement (
    "idPaiement" character varying(255) NOT NULL,
    "lotId" character varying(255) NOT NULL,
    "utilisateurId" character varying(255) NOT NULL,
    "typePaiement" character varying(20) NOT NULL,
    "validationPaiement" boolean
);


ALTER TABLE public.paiement OWNER TO andy_cinquin;

--
-- TOC entry 209 (class 1259 OID 16489)
-- Name: personne; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.personne (
    "idPersonne" character varying(255) NOT NULL,
    nom character varying(45),
    prenom character varying(50),
    age integer,
    email character varying(45),
    password character varying(255),
    "telephoneMobile" character varying(20),
    "telephoneFixe" character varying(20)
);


ALTER TABLE public.personne OWNER TO andy_cinquin;

--
-- TOC entry 210 (class 1259 OID 16497)
-- Name: photo; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.photo (
    "idPhoto" character varying(255) NOT NULL,
    "produitId" character varying(255) NOT NULL,
    "fichierPhoto" bytea
);


ALTER TABLE public.photo OWNER TO andy_cinquin;

--
-- TOC entry 211 (class 1259 OID 16505)
-- Name: produit; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.produit (
    "idProduit" character varying(255) NOT NULL,
    "lotId" character varying(255) NOT NULL,
    "utilisateurId" character varying(255) NOT NULL,
    "stockId" character varying(255),
    "enchereGagnanteId" character varying(255),
    "nomArtiste" character varying(45),
    "nomStyle" character varying(45),
    "nomProduits" character varying(45),
    "prixReserve" double precision,
    "referenceCatalogue" character varying(55),
    "descriptionProduit" text,
    "enStock" boolean,
    "isSend" boolean
);


ALTER TABLE public.produit OWNER TO andy_cinquin;

--
-- TOC entry 196 (class 1259 OID 16386)
-- Name: stock; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.stock (
    "idStock" character varying(255) NOT NULL,
    "adresseId" character varying(255) NOT NULL
);


ALTER TABLE public.stock OWNER TO andy_cinquin;

--
-- TOC entry 197 (class 1259 OID 16394)
-- Name: utilisateur; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.utilisateur (
    "idUtilisateur" character varying(255) NOT NULL,
    "personneId" character varying(255) NOT NULL,
    "verifIdentite" boolean,
    "listeMotClef" text,
    "verifRessortissant" boolean,
    "verifSolvable" boolean
);


ALTER TABLE public.utilisateur OWNER TO andy_cinquin;

--
-- TOC entry 198 (class 1259 OID 16402)
-- Name: vente; Type: TABLE; Schema: public; Owner: andy_cinquin
--

CREATE TABLE public.vente (
    "idVente" character varying(255) NOT NULL,
    "adresseId" character varying(255) NOT NULL,
    datedebut timestamp(6) without time zone,
    "lotId" character varying(255)
);


ALTER TABLE public.vente OWNER TO andy_cinquin;

--
-- TOC entry 3716 (class 0 OID 0)
-- Dependencies: 198
-- Name: TABLE vente; Type: COMMENT; Schema: public; Owner: andy_cinquin
--

COMMENT ON TABLE public.vente IS 'TRIAL';


--
-- TOC entry 3694 (class 0 OID 16410)
-- Dependencies: 199
-- Data for Name: adresse; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.adresse ("idAdresse", pays, region, ville, "codePostal", "adresseNom") VALUES ('51855519-74d6-45bd-9162-b3b0aed1cdbf', 'Saint George', 'LA tour Eiffel', 'Sains marie Josef', '44140', 'AAAA');
INSERT INTO public.adresse ("idAdresse", pays, region, ville, "codePostal", "adresseNom") VALUES ('94c84400-b205-48ab-ba8d-a4f901e767a7', 'France', 'Loire Atlantique', 'Nantes', '44100', '72 avenue Camus');
INSERT INTO public.adresse ("idAdresse", pays, region, ville, "codePostal", "adresseNom") VALUES ('e75438c6-dcbb-4e58-914b-81e04c96b840', 'France', 'Loire Atlantique', 'Nantes', '44100', '72 rue camus');
INSERT INTO public.adresse ("idAdresse", pays, region, ville, "codePostal", "adresseNom") VALUES ('31af522a-bf48-47ef-8552-a76ac81a480e', '', '', '', '', '');
INSERT INTO public.adresse ("idAdresse", pays, region, ville, "codePostal", "adresseNom") VALUES ('adresse3', 'Algerie', 'RegionDAlgerie', 'VilleDAlgerie', '33333', 'adresseprecise3');


--
-- TOC entry 3695 (class 0 OID 16418)
-- Dependencies: 200
-- Data for Name: adressepersonne; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.adressepersonne ("adresseId", "personneId") VALUES ('e75438c6-dcbb-4e58-914b-81e04c96b840', 'b48d79cf-0a7c-4874-9a13-83aafd3960dc');
INSERT INTO public.adressepersonne ("adresseId", "personneId") VALUES ('94c84400-b205-48ab-ba8d-a4f901e767a7', 'b48d79cf-0a7c-4874-9a13-83aafd3960dc');
INSERT INTO public.adressepersonne ("adresseId", "personneId") VALUES ('adresse3', 'personne2');
INSERT INTO public.adressepersonne ("adresseId", "personneId") VALUES ('e75438c6-dcbb-4e58-914b-81e04c96b840', 'personne2');


--
-- TOC entry 3696 (class 0 OID 16424)
-- Dependencies: 201
-- Data for Name: categorie; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.categorie ("idCategorie", "nomCategorie", "categorieId") VALUES ('categorie1', 'nom 1 ', NULL);
INSERT INTO public.categorie ("idCategorie", "nomCategorie", "categorieId") VALUES ('categorie2', 'nom 2', NULL);
INSERT INTO public.categorie ("idCategorie", "nomCategorie", "categorieId") VALUES ('categorie3', 'nom 3', 'categorie1');


--
-- TOC entry 3697 (class 0 OID 16432)
-- Dependencies: 202
-- Data for Name: categorieproduit; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.categorieproduit ("categorieId", "produitId") VALUES ('categorie3', 'produit6');


--
-- TOC entry 3698 (class 0 OID 16438)
-- Dependencies: 203
-- Data for Name: commissaire; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.commissaire ("idCommissaire", "personneId") VALUES ('commissaire1', 'Commi');


--
-- TOC entry 3699 (class 0 OID 16448)
-- Dependencies: 204
-- Data for Name: enchere; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('dd97234f-9069-41e9-b6f2-94a09df6f936', 'ordreAchat1', 'lot1', 'commissaire1', NULL, 15, '2020-12-17 00:00:00', true);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('9dad1964-1a38-4d7d-a61d-d9e629975beb', NULL, 'lot1', 'commissaire1', '33fce7a2-f2b6-463a-ac92-d68e4fd2a26c', 15, '2020-12-26 00:00:00', false);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('138181d3-a0fa-439a-9917-b7a68287077a', NULL, 'lot1', 'commissaire1', '4201f9b3-1403-49ed-b8d9-87242b6296b5', 65, '2020-12-25 00:00:00', false);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('9dbcdebb-b3f5-4d65-92f1-efbb2681761e', NULL, 'lot1', 'commissaire1', 'utilisateur3', 15, '2020-12-12 00:00:00', true);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('017085d0-f149-433d-a925-c9f82c17a4af', 'ordreAchat1', 'lot1', 'commissaire1', NULL, 23, '2020-12-16 22:52:48.187835', true);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('301762ab-ecab-4b28-b9f5-70e95c500133', NULL, 'lot1', 'commissaire1', '33fce7a2-f2b6-463a-ac92-d68e4fd2a26c', 468, '2021-01-03 00:00:00', false);
INSERT INTO public.enchere ("idEnchere", "ordreAchatId", "lotId", "commissaireId", "utilisateurId", "prixProposer", "dateHeureVente", "estAdjuger") VALUES ('1b9d83fc-cef8-40f2-8df7-9ad99ce30b44', 'ordreAchat1', 'lot1', 'commissaire1', NULL, 105, '2020-12-17 08:15:31.863431', true);


--
-- TOC entry 3700 (class 0 OID 16456)
-- Dependencies: 205
-- Data for Name: estimation; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--



--
-- TOC entry 3701 (class 0 OID 16464)
-- Dependencies: 206
-- Data for Name: lot; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.lot ("idLot", "nomLot", description) VALUES ('lot1', 'nomLot1', 'descriptionLot1');
INSERT INTO public.lot ("idLot", "nomLot", description) VALUES ('lot2', 'nomLot2', 'descriptionLot2');
INSERT INTO public.lot ("idLot", "nomLot", description) VALUES ('lot3', 'nomLot3', 'descriptionLot3');
INSERT INTO public.lot ("idLot", "nomLot", description) VALUES ('lot4', 'nomLot4', 'descriptionLot4');


--
-- TOC entry 3702 (class 0 OID 16472)
-- Dependencies: 207
-- Data for Name: ordreachat; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.ordreachat ("idOrdreAchat", "utilisateurId", "lotId", date, "montantMax", informatiser) VALUES ('ordreAchat2', 'utilisateur2', 'lot2', '2020-10-10 08:10:00', 5, true);
INSERT INTO public.ordreachat ("idOrdreAchat", "utilisateurId", "lotId", date, "montantMax", informatiser) VALUES ('ordreAchat4', 'utilisateur3', 'lot3', '2020-10-10 08:30:00', 150, false);
INSERT INTO public.ordreachat ("idOrdreAchat", "utilisateurId", "lotId", date, "montantMax", informatiser) VALUES ('ordreAchat1', 'utilisateur2', 'lot1', '2020-10-10 08:20:00', 20, true);


--
-- TOC entry 3703 (class 0 OID 16481)
-- Dependencies: 208
-- Data for Name: paiement; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--



--
-- TOC entry 3704 (class 0 OID 16489)
-- Dependencies: 209
-- Data for Name: personne; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('58ec7744-40db-4c9e-aaa9-d0ec5a7313ff', 'Nigga', 'Andyounet', 55, 'email', '123456', '45', '45');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('2b320c8b-081f-45a2-86d5-c755f592b5ae', 'Canto', 'Nalwen', 20, 'nanou@epsi.fr', '12', '04055848', '04055848');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('9ebd9a66-e25a-45a2-a525-fb1cbdbce290', 'Le Floch', 'Breval', 4, 'breval.lefloch@epsi.fr', '123456', '123456789', '123456789');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('d2ad16d0-0d1f-46da-bccf-622c8fdcef4c', 'Gaston', 'La Gaffe', 25, 'gaston@genious.fr', '12', '04055848', '04055848');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('b48d79cf-0a7c-4874-9a13-83aafd3960dc', 'UtilisateurTest', 'UtilisateurTest', 10, 'UtilisateurTest@UtilisateurTest.com', '123', '040404', '0404');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('personne2', 'Deloge', 'Sonia', 4, 'sonia1006@gmail.com', '12345', '06 22 22 22 22', '02 22 22 22 22');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('a5879c8f-c8ee-4303-8d48-285af0c685f1', 'Serix', 'George', 5, 'georgedelajungle@nasa.com', '123456', '010203', '010203');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('7ef3d661-b61f-4d52-bd88-250a409152b9', 'Sarsou', 'David', 35, 'davidou@yahoo.fr', '123', '060606060', '0604080502');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('personne3', 'Girodet', 'Vitcor', 1, 'mario2020@gmail.com', '123456', '06 33 33 33 33', '02 33 33 33 33');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('personneCommissaire', 'Comi', 'Comi', 10, 'Comi@Comi.Comi', 'Comi', '045500000', '000001121');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('Commi', 'Commi', 'Commi', 10, 'Commi@Commi.Commi', 'Commi@Commi.Commi', '140', '1111');
INSERT INTO public.personne ("idPersonne", nom, prenom, age, email, password, "telephoneMobile", "telephoneFixe") VALUES ('Commi2', 'Commi2', 'Commi2', 15, 'Commi2@Commi2.Commi2', 'Commi2', 'Commi2', 'Commi2');


--
-- TOC entry 3705 (class 0 OID 16497)
-- Dependencies: 210
-- Data for Name: photo; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.photo ("idPhoto", "produitId", "fichierPhoto") VALUES ('photo6', 'produit6', NULL);


--
-- TOC entry 3706 (class 0 OID 16505)
-- Dependencies: 211
-- Data for Name: produit; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.produit ("idProduit", "lotId", "utilisateurId", "stockId", "enchereGagnanteId", "nomArtiste", "nomStyle", "nomProduits", "prixReserve", "referenceCatalogue", "descriptionProduit", "enStock", "isSend") VALUES ('produit6', 'lot3', 'utilisateur3', 'stock3', NULL, 'artiste6', 'nomStyle6', 'nomProduits6', 10, 'referenceCatalogue6', 'description6', true, true);


--
-- TOC entry 3691 (class 0 OID 16386)
-- Dependencies: 196
-- Data for Name: stock; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.stock ("idStock", "adresseId") VALUES ('stock3', 'adresse3');


--
-- TOC entry 3692 (class 0 OID 16394)
-- Dependencies: 197
-- Data for Name: utilisateur; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--

INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('4201f9b3-1403-49ed-b8d9-87242b6296b5', '2b320c8b-081f-45a2-86d5-c755f592b5ae', false, '', false, true);
INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('c9ac8a10-6b5a-4bc9-9912-68811b2ee14c', 'a5879c8f-c8ee-4303-8d48-285af0c685f1', true, '', false, true);
INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('33fce7a2-f2b6-463a-ac92-d68e4fd2a26c', '9ebd9a66-e25a-45a2-a525-fb1cbdbce290', false, 'Cyberpunk;Anime;StarWars', false, false);
INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('94eca4b1-d39a-4106-86e9-00805a92c771', 'b48d79cf-0a7c-4874-9a13-83aafd3960dc', false, '', false, false);
INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('utilisateur2', 'personne2', false, 'mot4;mot5;mot6', false, true);
INSERT INTO public.utilisateur ("idUtilisateur", "personneId", "verifIdentite", "listeMotClef", "verifRessortissant", "verifSolvable") VALUES ('utilisateur3', 'personne3', false, 'mot7;mot8;mot9;Mot velefgegijrjg', false, true);


--
-- TOC entry 3693 (class 0 OID 16402)
-- Dependencies: 198
-- Data for Name: vente; Type: TABLE DATA; Schema: public; Owner: andy_cinquin
--



--
-- TOC entry 3502 (class 2606 OID 16417)
-- Name: adresse pk_adresse; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.adresse
    ADD CONSTRAINT pk_adresse PRIMARY KEY ("idAdresse");


--
-- TOC entry 3506 (class 2606 OID 24729)
-- Name: adressepersonne pk_adressepersonne; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.adressepersonne
    ADD CONSTRAINT pk_adressepersonne PRIMARY KEY ("personneId", "adresseId");


--
-- TOC entry 3509 (class 2606 OID 16431)
-- Name: categorie pk_categorie; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.categorie
    ADD CONSTRAINT pk_categorie PRIMARY KEY ("idCategorie");


--
-- TOC entry 3514 (class 2606 OID 16445)
-- Name: commissaire pk_commissaire; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.commissaire
    ADD CONSTRAINT pk_commissaire PRIMARY KEY ("idCommissaire");


--
-- TOC entry 3522 (class 2606 OID 16455)
-- Name: enchere pk_enchere; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.enchere
    ADD CONSTRAINT pk_enchere PRIMARY KEY ("idEnchere");


--
-- TOC entry 3526 (class 2606 OID 16463)
-- Name: estimation pk_estimation; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.estimation
    ADD CONSTRAINT pk_estimation PRIMARY KEY ("idEstimation");


--
-- TOC entry 3528 (class 2606 OID 16471)
-- Name: lot pk_lot; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.lot
    ADD CONSTRAINT pk_lot PRIMARY KEY ("idLot");


--
-- TOC entry 3531 (class 2606 OID 16480)
-- Name: ordreachat pk_ordreachat; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.ordreachat
    ADD CONSTRAINT pk_ordreachat PRIMARY KEY ("idOrdreAchat");


--
-- TOC entry 3535 (class 2606 OID 16488)
-- Name: paiement pk_paiement; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.paiement
    ADD CONSTRAINT pk_paiement PRIMARY KEY ("idPaiement");


--
-- TOC entry 3537 (class 2606 OID 16496)
-- Name: personne pk_personne; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.personne
    ADD CONSTRAINT pk_personne PRIMARY KEY ("idPersonne");


--
-- TOC entry 3540 (class 2606 OID 16504)
-- Name: photo pk_photo; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.photo
    ADD CONSTRAINT pk_photo PRIMARY KEY ("idPhoto");


--
-- TOC entry 3545 (class 2606 OID 16512)
-- Name: produit pk_produit; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.produit
    ADD CONSTRAINT pk_produit PRIMARY KEY ("idProduit");


--
-- TOC entry 3493 (class 2606 OID 16393)
-- Name: stock pk_stock; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.stock
    ADD CONSTRAINT pk_stock PRIMARY KEY ("idStock");


--
-- TOC entry 3496 (class 2606 OID 16401)
-- Name: utilisateur pk_utilisateur; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.utilisateur
    ADD CONSTRAINT pk_utilisateur PRIMARY KEY ("idUtilisateur");


--
-- TOC entry 3500 (class 2606 OID 16409)
-- Name: vente pk_vente; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.vente
    ADD CONSTRAINT pk_vente PRIMARY KEY ("idVente");


--
-- TOC entry 3516 (class 2606 OID 16447)
-- Name: commissaire unique_commissaire_personne; Type: CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.commissaire
    ADD CONSTRAINT unique_commissaire_personne UNIQUE ("personneId");


--
-- TOC entry 3503 (class 1259 OID 16533)
-- Name: fk_adressepersonne_adresse_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_adressepersonne_adresse_idx ON public.adressepersonne USING btree ("adresseId") WITH (fillfactor='90');


--
-- TOC entry 3504 (class 1259 OID 16534)
-- Name: fk_adressepersonne_personne_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_adressepersonne_personne_idx ON public.adressepersonne USING btree ("personneId") WITH (fillfactor='90');


--
-- TOC entry 3510 (class 1259 OID 16531)
-- Name: fk_categorieproduit_categorie_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_categorieproduit_categorie_idx ON public.categorieproduit USING btree ("categorieId") WITH (fillfactor='90');


--
-- TOC entry 3511 (class 1259 OID 16532)
-- Name: fk_categorieproduit_produit_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_categorieproduit_produit_idx ON public.categorieproduit USING btree ("produitId") WITH (fillfactor='90');


--
-- TOC entry 3512 (class 1259 OID 16530)
-- Name: fk_commissaire_personne_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_commissaire_personne_idx ON public.commissaire USING btree ("personneId") WITH (fillfactor='90');


--
-- TOC entry 3517 (class 1259 OID 16528)
-- Name: fk_enchere_commissaire_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_enchere_commissaire_idx ON public.enchere USING btree ("commissaireId") WITH (fillfactor='90');


--
-- TOC entry 3518 (class 1259 OID 16527)
-- Name: fk_enchere_lot_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_enchere_lot_idx ON public.enchere USING btree ("lotId") WITH (fillfactor='90');


--
-- TOC entry 3519 (class 1259 OID 16526)
-- Name: fk_enchere_ordreAchat_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX "fk_enchere_ordreAchat_idx" ON public.enchere USING btree ("ordreAchatId") WITH (fillfactor='90');


--
-- TOC entry 3520 (class 1259 OID 16529)
-- Name: fk_enchere_utilisateur_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_enchere_utilisateur_idx ON public.enchere USING btree ("utilisateurId") WITH (fillfactor='90');


--
-- TOC entry 3523 (class 1259 OID 16525)
-- Name: fk_estimation_commissaire_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_estimation_commissaire_idx ON public.estimation USING btree ("commissaireId") WITH (fillfactor='90');


--
-- TOC entry 3524 (class 1259 OID 16524)
-- Name: fk_estimation_produit_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_estimation_produit_idx ON public.estimation USING btree ("produitId") WITH (fillfactor='90');


--
-- TOC entry 3529 (class 1259 OID 16523)
-- Name: fk_ordreAchat_utilisateur_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX "fk_ordreAchat_utilisateur_idx" ON public.ordreachat USING btree ("utilisateurId") WITH (fillfactor='90');


--
-- TOC entry 3532 (class 1259 OID 16521)
-- Name: fk_paiement_lot_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_paiement_lot_idx ON public.paiement USING btree ("lotId") WITH (fillfactor='90');


--
-- TOC entry 3533 (class 1259 OID 16522)
-- Name: fk_paiement_utilisateur_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_paiement_utilisateur_idx ON public.paiement USING btree ("utilisateurId") WITH (fillfactor='90');


--
-- TOC entry 3538 (class 1259 OID 16520)
-- Name: fk_photo_produit_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_photo_produit_idx ON public.photo USING btree ("produitId") WITH (fillfactor='90');


--
-- TOC entry 3541 (class 1259 OID 16517)
-- Name: fk_produit_lot_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_produit_lot_idx ON public.produit USING btree ("lotId") WITH (fillfactor='90');


--
-- TOC entry 3542 (class 1259 OID 16519)
-- Name: fk_produit_stock_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_produit_stock_idx ON public.produit USING btree ("stockId") WITH (fillfactor='90');


--
-- TOC entry 3543 (class 1259 OID 16518)
-- Name: fk_produit_utilisateur_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_produit_utilisateur_idx ON public.produit USING btree ("utilisateurId") WITH (fillfactor='90');


--
-- TOC entry 3491 (class 1259 OID 16516)
-- Name: fk_stock_adresse_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_stock_adresse_idx ON public.stock USING btree ("adresseId") WITH (fillfactor='90');


--
-- TOC entry 3494 (class 1259 OID 16515)
-- Name: fk_utilisateur_personne_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_utilisateur_personne_idx ON public.utilisateur USING btree ("personneId") WITH (fillfactor='90');


--
-- TOC entry 3497 (class 1259 OID 16514)
-- Name: fk_vente_adresse_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_vente_adresse_idx ON public.vente USING btree ("adresseId") WITH (fillfactor='90');


--
-- TOC entry 3498 (class 1259 OID 16661)
-- Name: fk_vente_lot_idx; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fk_vente_lot_idx ON public.vente USING btree ("lotId");


--
-- TOC entry 3507 (class 1259 OID 32925)
-- Name: fki_fk_categorie_categorie; Type: INDEX; Schema: public; Owner: andy_cinquin
--

CREATE INDEX fki_fk_categorie_categorie ON public.categorie USING btree ("categorieId");


--
-- TOC entry 3552 (class 2606 OID 32926)
-- Name: categorie categorie_categorie; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.categorie
    ADD CONSTRAINT categorie_categorie FOREIGN KEY ("categorieId") REFERENCES public.categorie("idCategorie");


--
-- TOC entry 3550 (class 2606 OID 16556)
-- Name: adressepersonne fk_adressepersonne_adresse; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.adressepersonne
    ADD CONSTRAINT fk_adressepersonne_adresse FOREIGN KEY ("adresseId") REFERENCES public.adresse("idAdresse") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3551 (class 2606 OID 16561)
-- Name: adressepersonne fk_adressepersonne_personne; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.adressepersonne
    ADD CONSTRAINT fk_adressepersonne_personne FOREIGN KEY ("personneId") REFERENCES public.personne("idPersonne") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3553 (class 2606 OID 16571)
-- Name: categorieproduit fk_categorieproduit_categorie; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.categorieproduit
    ADD CONSTRAINT fk_categorieproduit_categorie FOREIGN KEY ("categorieId") REFERENCES public.categorie("idCategorie") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3554 (class 2606 OID 16576)
-- Name: categorieproduit fk_categorieproduit_produit; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.categorieproduit
    ADD CONSTRAINT fk_categorieproduit_produit FOREIGN KEY ("produitId") REFERENCES public.produit("idProduit") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3555 (class 2606 OID 16581)
-- Name: commissaire fk_commissaire_personne; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.commissaire
    ADD CONSTRAINT fk_commissaire_personne FOREIGN KEY ("personneId") REFERENCES public.personne("idPersonne") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3558 (class 2606 OID 16596)
-- Name: enchere fk_enchere_commissaire; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.enchere
    ADD CONSTRAINT fk_enchere_commissaire FOREIGN KEY ("commissaireId") REFERENCES public.commissaire("idCommissaire") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3557 (class 2606 OID 16591)
-- Name: enchere fk_enchere_lot; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.enchere
    ADD CONSTRAINT fk_enchere_lot FOREIGN KEY ("lotId") REFERENCES public.lot("idLot") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3556 (class 2606 OID 16586)
-- Name: enchere fk_enchere_ordreAchat; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.enchere
    ADD CONSTRAINT "fk_enchere_ordreAchat" FOREIGN KEY ("ordreAchatId") REFERENCES public.ordreachat("idOrdreAchat") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3559 (class 2606 OID 16601)
-- Name: enchere fk_enchere_utilisateur; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.enchere
    ADD CONSTRAINT fk_enchere_utilisateur FOREIGN KEY ("utilisateurId") REFERENCES public.utilisateur("idUtilisateur") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3561 (class 2606 OID 16611)
-- Name: estimation fk_estimation_commissaire; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.estimation
    ADD CONSTRAINT fk_estimation_commissaire FOREIGN KEY ("commissaireId") REFERENCES public.commissaire("idCommissaire") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3560 (class 2606 OID 16606)
-- Name: estimation fk_estimation_produit; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.estimation
    ADD CONSTRAINT fk_estimation_produit FOREIGN KEY ("produitId") REFERENCES public.produit("idProduit") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3562 (class 2606 OID 32931)
-- Name: ordreachat fk_ordreAchat_utilisateur_na; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.ordreachat
    ADD CONSTRAINT "fk_ordreAchat_utilisateur_na" FOREIGN KEY ("utilisateurId") REFERENCES public.utilisateur("idUtilisateur");


--
-- TOC entry 3563 (class 2606 OID 16621)
-- Name: paiement fk_paiement_lot; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.paiement
    ADD CONSTRAINT fk_paiement_lot FOREIGN KEY ("lotId") REFERENCES public.lot("idLot") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3564 (class 2606 OID 16626)
-- Name: paiement fk_paiement_utilisateur; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.paiement
    ADD CONSTRAINT fk_paiement_utilisateur FOREIGN KEY ("utilisateurId") REFERENCES public.utilisateur("idUtilisateur") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3565 (class 2606 OID 16631)
-- Name: photo fk_photo_produit; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.photo
    ADD CONSTRAINT fk_photo_produit FOREIGN KEY ("produitId") REFERENCES public.produit("idProduit") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3569 (class 2606 OID 16651)
-- Name: produit fk_produit_encheregagnante; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.produit
    ADD CONSTRAINT fk_produit_encheregagnante FOREIGN KEY ("enchereGagnanteId") REFERENCES public.enchere("idEnchere") MATCH FULL;


--
-- TOC entry 3566 (class 2606 OID 16636)
-- Name: produit fk_produit_lot; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.produit
    ADD CONSTRAINT fk_produit_lot FOREIGN KEY ("lotId") REFERENCES public.lot("idLot") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3568 (class 2606 OID 16646)
-- Name: produit fk_produit_stock; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.produit
    ADD CONSTRAINT fk_produit_stock FOREIGN KEY ("stockId") REFERENCES public.stock("idStock") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3567 (class 2606 OID 16641)
-- Name: produit fk_produit_utilisateur; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.produit
    ADD CONSTRAINT fk_produit_utilisateur FOREIGN KEY ("utilisateurId") REFERENCES public.utilisateur("idUtilisateur") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3546 (class 2606 OID 16536)
-- Name: stock fk_stock_adresse; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.stock
    ADD CONSTRAINT fk_stock_adresse FOREIGN KEY ("adresseId") REFERENCES public.adresse("idAdresse") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3547 (class 2606 OID 32936)
-- Name: utilisateur fk_utilisateur_personne; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.utilisateur
    ADD CONSTRAINT fk_utilisateur_personne FOREIGN KEY ("personneId") REFERENCES public.personne("idPersonne");


--
-- TOC entry 3548 (class 2606 OID 16551)
-- Name: vente fk_vente_adresse; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.vente
    ADD CONSTRAINT fk_vente_adresse FOREIGN KEY ("adresseId") REFERENCES public.adresse("idAdresse") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3549 (class 2606 OID 16656)
-- Name: vente fk_vente_lot; Type: FK CONSTRAINT; Schema: public; Owner: andy_cinquin
--

ALTER TABLE ONLY public.vente
    ADD CONSTRAINT fk_vente_lot FOREIGN KEY ("lotId") REFERENCES public.lot("idLot") ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2021-05-20 19:57:35

--
-- PostgreSQL database dump complete
--

