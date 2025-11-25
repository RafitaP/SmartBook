-- Refuerzos opcionales exigidos por el PDF:
ALTER TABLE personas ADD UNIQUE KEY ux_persona_celular (celular);
ALTER TABLE lotes ADD UNIQUE KEY ux_lote_codigo (codigo), ADD UNIQUE KEY ux_lote_anio_consec (anio, consecutivo);
