--/*============================================================================================================*/
-- Script di generazione Schema "Missioni"
--
-- RDBMS : 	POSTGRES
--
-- Versione  : 25 Febbraio 2022
--
--------------------------------------------------------
-- Sintassi NOMENCLATURA :
--
-- Constraint Primary 			"[Tabella]_[colonna]_PK"
-- Constraint Unique  			"[Tabella]_[colonna]_UK"
-- Foreign Key							"[TabellaP]_[TabellaF]_FK
-- Unique Index							_UI [num]
-- Check Constraint Index		_CK [num]
--
--============================================================================================================*/
DO $$
DECLARE
table_name text;
var int;

BEGIN
 RAISE log 'Creazione "Missioni"';

--------------------------------------------------------------------------------
RAISE NOTICE 'CausaliMissione';
--------------------------------------------------------------------------------
DROP TABLE IF EXISTS  "Missioni"."TipoCausaliMissione" CASCADE;

DROP TABLE IF EXISTS  "Missioni"."CausaliMissione" CASCADE;
CREATE TABLE IF NOT EXISTS "Missioni"."CausaliMissione" (
	"idCausaliMissione" int8					NOT NULL
	,"descCausaleMissione"	varchar(200) 	NOT NULL
	,"tipoMissione"					char(1) 			NULL
	,"dtIns" 								timestamp			NULL
	,"user" 								varchar(40) 	NULL
	,CONSTRAINT "CausaliMissione_PK" PRIMARY KEY ("idCausaliMissione")
	 USING INDEX TABLESPACE ts_sipecdb_idx
	 )
 TABLESPACE ts_sipecdb_tb;

--------------------------------------------------------------------------------
RAISE NOTICE 'TipologiaMissione';
--------------------------------------------------------------------------------

DROP TABLE IF EXISTS  "Missioni"."TipologieMissione" CASCADE;
CREATE TABLE IF NOT EXISTS "Missioni"."TipologieMissione" (

	"idTipologiaMissione" 	character varying(1)		NOT NULL
   ,"descrTipMissione"			character varying(200)	NOT NULL
  ,"vistiConTransiti"			character varying(1)		NULL	DEFAULT 'N'
	,"dtIns" 								timestamp		NULL
	,"user" 								varchar(40) 	NULL
	,CONSTRAINT "TipologieMissione_PK" PRIMARY KEY ("idTipologiaMissione")
	 USING INDEX TABLESPACE ts_sipecdb_idx
	 )
 TABLESPACE ts_sipecdb_tb;


--------------------------------------------------------------------------------
RAISE NOTICE 'AnagraficaTipiMissione';  -- TIPI_MISSIONE  
--------------------------------------------------------------------------------

DROP TABLE IF EXISTS  "Missioni"."AnagraficaTipiMissione" CASCADE;
CREATE TABLE IF NOT EXISTS "Missioni"."AnagraficaTipiMissione" (
  "idAnagraficaTipiMissione"	uuid       NOT NULL -- pk
  ,"codSedeMissione" 				uuid															NULL
  ,"descrizioneMissione"		character varying(300)      NOT NULL
  ,"capoTurno"							BOOLEAN        NOT NULL
  ,"idTipologiaMissione"         	int8            NULL
  ,"codEvento"							integer                      					NULL
  ,"dtInizioValidita"				timestamp without time zone 			NOT NULL
  ,"dtFineValidita"					timestamp without time zone
	,"dtIns" 									timestamp																NULL
	,"user" 									varchar(40) 														NULL
	,CONSTRAINT "AnagraficaTipiMissione_PK" PRIMARY KEY ("idAnagraficaTipiMissione")
	 USING INDEX TABLESPACE ts_sipecdb_idx
	 )
 TABLESPACE ts_sipecdb_tb;

--------------------------------------------------------------------------------
RAISE NOTICE 'Missioni';
--------------------------------------------------------------------------------

DROP TABLE IF EXISTS  "Missioni"."Missioni" CASCADE;
CREATE TABLE IF NOT EXISTS "Missioni"."Missioni" (
	"idMissione" 									uuid															NOT NULL -- PK
	,"codSedeMissione" 						uuid															NULL
	,"idAnagraficaTipiMissione" 	uuid							NOT NULL
	,"dataOraInizioMissione"		timestamp without time zone   NOT NULL
	,"dataOraFineMissione"			timestamp without time zone 	NOT NULL
-- località descrittive -----------------------------------------------------
	,"localitaPartenza"					character varying(200)						NULL
	,"localitaDestinazione"			character varying(200)						NULL
---------------------------------------------------------------??????-------
  -- Partenza
	,"codSedeAmmPartenza" 			uuid															NULL
  -- Destinazione
	,"codSedeAmmDestinazione" 	uuid															NULL
-----------------------------------------------------------------------
	,"motivoMissione"						character varying(150)						NULL
	,"mezziTrasporto"						character varying(50)							NULL
	,"estremiAutorizzazione"		character varying(130)      			NULL
  ,"idTipologiaMissione"							character varying(1)							NULL			DEFAULT 'M'
  ,"codEvento"								int8															NULL
  ,"flProv"										boolean														NOT	NULL	DEFAULT false
  ,"flSedeVvf"								boolean														NOT	NULL	DEFAULT true
  ,"idCausaliMissione" 				int8															NULL
  ,"dataInizioMissione"				timestamp													NULL
  ,"dtInizioValidita"					timestamp without time zone 			NOT NULL
  ,"dtFineValidita"						timestamp without time zone
	,"dtIns" 										timestamp			NULL
	,"user" 										varchar(40) 	NULL
	,CONSTRAINT "Missioni_PK" PRIMARY KEY ("idMissione")
	 USING INDEX TABLESPACE ts_sipecdb_idx
	 )
 TABLESPACE ts_sipecdb_tb;

--------------------------------------------------------------------------------
RAISE NOTICE 'Anagrafica Missioni del dipendente';
--------------------------------------------------------------------------------

DROP TABLE IF EXISTS  "Missioni"."MissioniDipendenti" CASCADE;
CREATE TABLE IF NOT EXISTS "Missioni"."MissioniDipendenti" (
	 "idMissione" 						uuid			NOT NULL -- Pkey 1 padre Missioni
	,"idDipendente" 					uuid 															NOT NULL	-- Pkey 3
	,"codFiscale" 						character varying(16)														NULL
	,"idMansione"							character varying(1)							NOT NULL	DEFAULT 'N'
	,"dataOraPartitoSede"			timestamp without time zone   		NOT NULL
	,"dataOraArrivatoSede"		timestamp without time zone 			NOT NULL
	,"fLavorato"							boolean														NULL 			DEFAULT 'false'
	,"dtInizioValidita"				timestamp without time zone 			NOT NULL
	,"dtFineValidita"					timestamp without time zone
	,"dtIns" 									timestamp															NULL
	,"user" 									character varying(40) 													NULL
	,CONSTRAINT "MissioniDipendenti_PK" PRIMARY KEY ("idMissione","idDipendente")
	 USING INDEX TABLESPACE ts_sipecdb_idx
	 )
 TABLESPACE ts_sipecdb_tb;

--------------------------------------------------------------------------------
RAISE NOTICE 'Transiti Missioni del dipendente';
--------------------------------------------------------------------------------
DROP TABLE IF EXISTS  "Missioni"."MissioniTransiti";
CREATE TABLE IF not EXISTS "Missioni"."MissioniTransiti" (
	 "idMissione" 						uuid															NOT NULL	-- Pkey 1 padre Missioni
	,"idDipendente" 					uuid 															NOT NULL	-- Pkey 2
	,"idTransito" 						uuid 															NOT NULL	-- Pkey 3
	,"dtInizioValidita"				timestamp without time zone 			NOT NULL
	,"dtFineValidita"					timestamp without time zone
	,"dtIns" 									timestamp													NULL
	,"user" 									character varying(40) 						NULL
,CONSTRAINT "MissioniTransiti_PK" PRIMARY KEY ("idMissione","idDipendente","idTransito")
 USING INDEX TABLESPACE ts_sipecdb_idx
 ) ;


-------------------------------------------------------------------------------------
-- Foreign key
-------------------------------------------------------------------------------------
ALTER TABLE "Missioni"."MissioniDipendenti" 
ADD CONSTRAINT "MissioniDipendenti_FK" 
FOREIGN KEY ("idMissione") 
REFERENCES "Missioni"."Missioni"("idMissione");

CREATE INDEX "MissioniDipendenti_UK" ON "Missioni"."Missioni" USING btree ("idCausaliMissione");

ALTER TABLE "Missioni"."Missioni" 
ADD CONSTRAINT "Missioni_FK1" FOREIGN KEY ("idCausaliMissione") 
REFERENCES "Missioni"."CausaliMissione"("idCausaliMissione");

ALTER TABLE "Missioni"."Missioni" 
ADD CONSTRAINT "Missioni_FK2" FOREIGN KEY ("idAnagraficaTipiMissione") 
REFERENCES "Missioni"."AnagraficaTipiMissione"("idAnagraficaTipiMissione");

ALTER TABLE "Missioni"."MissioniTransiti" 
ADD CONSTRAINT "MissioniTransiti_FK" 
FOREIGN KEY ("idMissione","idDipendente") 
REFERENCES "Missioni"."MissioniDipendenti"("idMissione","idDipendente");

ALTER TABLE "Missioni"."Missioni" 
ADD CONSTRAINT "Missioni_FK3" 
FOREIGN KEY ("idTipologiaMissione") 
REFERENCES "Missioni"."TipologieMissione"("idTipologiaMissione");
----------------------------------------------------------------------------------------
-- Sistemazione dei Tablespace ed Owner
----------------------------------------------------------------------------------------

GRANT ALL ON TABLE	"Missioni"."Missioni" 				TO sipec_test_owner,sipec_test_web,public;
GRANT ALL ON TABLE	"Missioni"."MissioniDipendenti" 	TO sipec_test_owner,sipec_test_web,public;
GRANT ALL ON TABLE	"Missioni"."MissioniTransiti" 		TO sipec_test_owner,sipec_test_web,public;
GRANT ALL ON TABLE	"Missioni"."CausaliMissione"	TO sipec_test_owner,sipec_test_web,public;
GRANT ALL ON TABLE	"Missioni"."AnagraficaTipiMissione"		TO sipec_test_owner,sipec_test_web,public;
GRANT ALL ON TABLE	"Missioni"."TipologieMissione"		TO sipec_test_owner,sipec_test_web,public;
--------------------------------------------------------------------------------
RAISE NOTICE 'Fine Elaborazione';
--------------------------------------------------------------------------------
END ;
$$



