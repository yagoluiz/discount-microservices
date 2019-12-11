--
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1 (Debian 12.1-1.pgdg100+1)
-- Dumped by pg_dump version 12.0

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

--
-- Name: store; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE store WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.utf8' LC_CTYPE = 'en_US.utf8';


ALTER DATABASE store OWNER TO postgres;

\connect store

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

SET default_table_access_method = heap;

--
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    id uuid NOT NULL,
    price_in_cents integer NOT NULL,
    title character varying(50) NOT NULL,
    description text
);


ALTER TABLE public.product OWNER TO postgres;

--
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id uuid NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50) NOT NULL,
    date_of_birth date NOT NULL
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);

--
-- Insert data in database
--

INSERT INTO public.product(
	id, price_in_cents, title, description)
	VALUES ('a0f5e2f7-7d8e-4c7a-bc0e-7cb40d9af91a', 1000, 'iPhone 11', 'Uau! New iPhone available!');

INSERT INTO public.product(
	id, price_in_cents, title, description)
	VALUES ('2a6926e1-51b6-4c0b-b3a4-b74f408426ee', 500, 'Apple Watch', NULL);

INSERT INTO public.product(
	id, price_in_cents, title, description)
	VALUES ('db366ebc-e13e-4c4d-99a8-4a1f6b410ad1', 100, 'AirPods', NULL);

INSERT INTO public."user"(
	id, first_name, last_name, date_of_birth)
	VALUES ('9a2aaed6-38f8-4f31-9a90-751f78543ae7', 'Thuarnan', 'Nurandir', '1990-03-05');

INSERT INTO public."user"(
	id, first_name, last_name, date_of_birth)
	VALUES ('e2bda1d7-2c70-4219-a099-60077d88ea12', 'Ovten', 'Insi', '1995-10-07');

INSERT INTO public."user"(
	id, first_name, last_name, date_of_birth)
	VALUES ('3b1c5fc4-3b82-447c-89cf-120addcf7e3d', 'Ulmti', 'Veon', '1980-05-20');

--
-- PostgreSQL database dump complete
--

