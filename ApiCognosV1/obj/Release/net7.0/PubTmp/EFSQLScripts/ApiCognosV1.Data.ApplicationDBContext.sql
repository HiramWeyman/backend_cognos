IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826184703_CreacionTablas')
BEGIN
    CREATE TABLE [Perfiles] (
        [per_id] int NOT NULL IDENTITY,
        [per_desc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Perfiles] PRIMARY KEY ([per_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826184703_CreacionTablas')
BEGIN
    CREATE TABLE [Usuarios] (
        [usr_id] int NOT NULL IDENTITY,
        [usr_paterno] nvarchar(max) NOT NULL,
        [usr_materno] nvarchar(max) NOT NULL,
        [usr_nombre] nvarchar(max) NOT NULL,
        [usr_email] nvarchar(max) NOT NULL,
        [usr_password] nvarchar(max) NOT NULL,
        [usr_per_id] int NOT NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([usr_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826184703_CreacionTablas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230826184703_CreacionTablas', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826185617_foreignkey')
BEGIN
    CREATE INDEX [IX_Usuarios_usr_per_id] ON [Usuarios] ([usr_per_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826185617_foreignkey')
BEGIN
    ALTER TABLE [Usuarios] ADD CONSTRAINT [FK_Usuarios_Perfiles_usr_per_id] FOREIGN KEY ([usr_per_id]) REFERENCES [Perfiles] ([per_id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230826185617_foreignkey')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230826185617_foreignkey', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011429_fechaCreacion')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'usr_paterno');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Usuarios] ALTER COLUMN [usr_paterno] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011429_fechaCreacion')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'usr_nombre');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Usuarios] ALTER COLUMN [usr_nombre] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011429_fechaCreacion')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'usr_materno');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Usuarios] ALTER COLUMN [usr_materno] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011429_fechaCreacion')
BEGIN
    ALTER TABLE [Usuarios] ADD [FechaCreacion] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011429_fechaCreacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230827011429_fechaCreacion', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011619_fechaCreacion2')
BEGIN
    EXEC sp_rename N'[Usuarios].[FechaCreacion]', N'usr_fecha_creacion', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230827011619_fechaCreacion2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230827011619_fechaCreacion2', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902183220_tabla_pacientes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230902183220_tabla_pacientes', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902183541_tabla_pacientes2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230902183541_tabla_pacientes2', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902185829_tabla_pacientes3')
BEGIN
    CREATE TABLE [Pacientes] (
        [pac_id] int NOT NULL IDENTITY,
        [pac_paterno] nvarchar(max) NULL,
        [pac_materno] nvarchar(max) NULL,
        [pac_nombre] nvarchar(max) NULL,
        [pac_fecha_nacimiento] datetime2 NOT NULL,
        [pac_fecha_ingreso] datetime2 NOT NULL,
        [pac_edad] int NOT NULL,
        [pac_genero] int NOT NULL,
        [pac_edocivil] int NOT NULL,
        [pac_escolaridad] int NOT NULL,
        [pac_ocupacion] nvarchar(max) NULL,
        [pac_email] nvarchar(max) NOT NULL,
        [pac_telefono] nvarchar(max) NOT NULL,
        [pac_domicilio] nvarchar(max) NOT NULL,
        [pac_usr_id] int NOT NULL,
        CONSTRAINT [PK_Pacientes] PRIMARY KEY ([pac_id]),
        CONSTRAINT [FK_Pacientes_Usuarios_pac_usr_id] FOREIGN KEY ([pac_usr_id]) REFERENCES [Usuarios] ([usr_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902185829_tabla_pacientes3')
BEGIN
    CREATE INDEX [IX_Pacientes_pac_usr_id] ON [Pacientes] ([pac_usr_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230902185829_tabla_pacientes3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230902185829_tabla_pacientes3', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905174602_salud-fisica-mental')
BEGIN
    CREATE TABLE [SaludFM] (
        [salud_id] int NOT NULL IDENTITY,
        [salud_sueno] nvarchar(max) NULL,
        [salud_sueno_desc] nvarchar(max) NULL,
        [salud_alimentacion] nvarchar(max) NULL,
        [salud_alimentacion_desc] nvarchar(max) NULL,
        [salud_act_fisica] nvarchar(max) NULL,
        [salud_act_fisica_desc] nvarchar(max) NULL,
        [salud_fecha_captura] datetime2 NOT NULL,
        [salud_fecha_modificacion] datetime2 NOT NULL,
        [salud_paciente_id] int NOT NULL,
        CONSTRAINT [PK_SaludFM] PRIMARY KEY ([salud_id]),
        CONSTRAINT [FK_SaludFM_Pacientes_salud_paciente_id] FOREIGN KEY ([salud_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905174602_salud-fisica-mental')
BEGIN
    CREATE INDEX [IX_SaludFM_salud_paciente_id] ON [SaludFM] ([salud_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230905174602_salud-fisica-mental')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230905174602_salud-fisica-mental', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907042726_analisisFu')
BEGIN
    CREATE TABLE [AnalisisFU] (
        [analisis_id] int NOT NULL IDENTITY,
        [analisis_ant] nvarchar(max) NULL,
        [analisis_ant_desc] nvarchar(max) NULL,
        [analisis_con] nvarchar(max) NULL,
        [analisis_con_desc] nvarchar(max) NULL,
        [analisis_cons] nvarchar(max) NULL,
        [analisis_cons_desc] nvarchar(max) NULL,
        [analisis_fecha_captura] datetime2 NOT NULL,
        [analisis_fecha_modificacion] datetime2 NOT NULL,
        [analisis_paciente_id] int NOT NULL,
        CONSTRAINT [PK_AnalisisFU] PRIMARY KEY ([analisis_id]),
        CONSTRAINT [FK_AnalisisFU_Pacientes_analisis_paciente_id] FOREIGN KEY ([analisis_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907042726_analisisFu')
BEGIN
    CREATE INDEX [IX_AnalisisFU_analisis_paciente_id] ON [AnalisisFU] ([analisis_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907042726_analisisFu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230907042726_analisisFu', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE TABLE [DiagnosticoDS] (
        [diag_id] int NOT NULL IDENTITY,
        [diag_titulo] nvarchar(max) NULL,
        [diag_desc] nvarchar(max) NULL,
        [diag_fecha_captura] datetime2 NOT NULL,
        [diag_fecha_modificacion] datetime2 NOT NULL,
        [diag_paciente_id] int NOT NULL,
        CONSTRAINT [PK_DiagnosticoDS] PRIMARY KEY ([diag_id]),
        CONSTRAINT [FK_DiagnosticoDS_Pacientes_diag_paciente_id] FOREIGN KEY ([diag_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE TABLE [EvolucionPR] (
        [evo_id] int NOT NULL IDENTITY,
        [evo_titulo] nvarchar(max) NULL,
        [evo_desc] nvarchar(max) NULL,
        [evo_fecha_captura] datetime2 NOT NULL,
        [evo_fecha_modificacion] datetime2 NOT NULL,
        [evo_paciente_id] int NOT NULL,
        CONSTRAINT [PK_EvolucionPR] PRIMARY KEY ([evo_id]),
        CONSTRAINT [FK_EvolucionPR_Pacientes_evo_paciente_id] FOREIGN KEY ([evo_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE TABLE [OtrasAR] (
        [otras_id] int NOT NULL IDENTITY,
        [otras_titulo] nvarchar(max) NULL,
        [otras_desc] nvarchar(max) NULL,
        [otras_fecha_captura] datetime2 NOT NULL,
        [otras_fecha_modificacion] datetime2 NOT NULL,
        [otras_paciente_id] int NOT NULL,
        CONSTRAINT [PK_OtrasAR] PRIMARY KEY ([otras_id]),
        CONSTRAINT [FK_OtrasAR_Pacientes_otras_paciente_id] FOREIGN KEY ([otras_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE INDEX [IX_DiagnosticoDS_diag_paciente_id] ON [DiagnosticoDS] ([diag_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE INDEX [IX_EvolucionPR_evo_paciente_id] ON [EvolucionPR] ([evo_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    CREATE INDEX [IX_OtrasAR_otras_paciente_id] ON [OtrasAR] ([otras_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230907192957_evo-otras-diagnostico')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230907192957_evo-otras-diagnostico', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE TABLE [ConsumoSust] (
        [consumo_id] int NOT NULL IDENTITY,
        [consumo_sustancia] nvarchar(max) NULL,
        [consumo_sino] nvarchar(max) NULL,
        [consumo_edad_inicio] nvarchar(max) NULL,
        [consumo_cantidad] nvarchar(max) NULL,
        [consumo_tiempo] nvarchar(max) NULL,
        [consumo_fecha_captura] datetime2 NOT NULL,
        [consumo_fecha_modificacion] datetime2 NOT NULL,
        [consumo_paciente_id] int NOT NULL,
        CONSTRAINT [PK_ConsumoSust] PRIMARY KEY ([consumo_id]),
        CONSTRAINT [FK_ConsumoSust_Pacientes_consumo_paciente_id] FOREIGN KEY ([consumo_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE TABLE [PrevioSalud] (
        [previo_id] int NOT NULL IDENTITY,
        [previo_problema] nvarchar(max) NULL,
        [previo_medico] nvarchar(max) NULL,
        [previo_medicamento] nvarchar(max) NULL,
        [previo_tiempo_tratamiento] nvarchar(max) NULL,
        [previo_tiempo_psicologico] nvarchar(max) NULL,
        [previo_fecha_captura] datetime2 NOT NULL,
        [previo_fecha_modificacion] datetime2 NOT NULL,
        [previo_paciente_id] int NOT NULL,
        CONSTRAINT [PK_PrevioSalud] PRIMARY KEY ([previo_id]),
        CONSTRAINT [FK_PrevioSalud_Pacientes_previo_paciente_id] FOREIGN KEY ([previo_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE TABLE [ProblemasMed] (
        [problema_id] int NOT NULL IDENTITY,
        [problema_problema] nvarchar(max) NULL,
        [problema_medico] nvarchar(max) NULL,
        [problema_medicamento] nvarchar(max) NULL,
        [problema_fecha_ini_trata] datetime2 NOT NULL,
        [problema_tiempo_tratamiento] nvarchar(max) NULL,
        [problema_fecha_captura] datetime2 NOT NULL,
        [problema_fecha_modificacion] datetime2 NOT NULL,
        [problema_paciente_id] int NOT NULL,
        CONSTRAINT [PK_ProblemasMed] PRIMARY KEY ([problema_id]),
        CONSTRAINT [FK_ProblemasMed_Pacientes_problema_paciente_id] FOREIGN KEY ([problema_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE INDEX [IX_ConsumoSust_consumo_paciente_id] ON [ConsumoSust] ([consumo_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE INDEX [IX_PrevioSalud_previo_paciente_id] ON [PrevioSalud] ([previo_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    CREATE INDEX [IX_ProblemasMed_problema_paciente_id] ON [ProblemasMed] ([problema_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230912051556_antecedentes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230912051556_antecedentes', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914055332_Tratamiento')
BEGIN
    CREATE TABLE [Tratamiento] (
        [trata_id] int NOT NULL IDENTITY,
        [trata_objetivo] nvarchar(max) NOT NULL,
        [trata_tecnica] nvarchar(max) NOT NULL,
        [trata_fecha_captura] datetime2 NOT NULL,
        [trata_fecha_modificacion] datetime2 NOT NULL,
        [trata_paciente_id] int NOT NULL,
        CONSTRAINT [PK_Tratamiento] PRIMARY KEY ([trata_id]),
        CONSTRAINT [FK_Tratamiento_Pacientes_trata_paciente_id] FOREIGN KEY ([trata_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914055332_Tratamiento')
BEGIN
    CREATE INDEX [IX_Tratamiento_trata_paciente_id] ON [Tratamiento] ([trata_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230914055332_Tratamiento')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230914055332_Tratamiento', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915210251_Consultas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230915210251_Consultas', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915210536_Consultasx')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230915210536_Consultasx', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915210832_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230915210832_Initial', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915215222_ProblematicaObj')
BEGIN
    CREATE TABLE [ProbObj] (
        [pro_id] int NOT NULL IDENTITY,
        [pro_problema] nvarchar(max) NOT NULL,
        [pro_objetivo] nvarchar(max) NOT NULL,
        [pro_fecha_captura] datetime2 NOT NULL,
        [pro_fecha_modificacion] datetime2 NOT NULL,
        [pro_paciente_id] int NOT NULL,
        CONSTRAINT [PK_ProbObj] PRIMARY KEY ([pro_id]),
        CONSTRAINT [FK_ProbObj_Pacientes_pro_paciente_id] FOREIGN KEY ([pro_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915215222_ProblematicaObj')
BEGIN
    CREATE INDEX [IX_ProbObj_pro_paciente_id] ON [ProbObj] ([pro_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230915215222_ProblematicaObj')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230915215222_ProblematicaObj', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230918041137_lineaVida')
BEGIN
    CREATE TABLE [LineaVida] (
        [lin_id] int NOT NULL IDENTITY,
        [lin_titulo] nvarchar(max) NOT NULL,
        [lin_desc] nvarchar(max) NOT NULL,
        [lin_fecha_captura] datetime2 NOT NULL,
        [lin_fecha_modificacion] datetime2 NOT NULL,
        [lin_paciente_id] int NOT NULL,
        CONSTRAINT [PK_LineaVida] PRIMARY KEY ([lin_id]),
        CONSTRAINT [FK_LineaVida_Pacientes_lin_paciente_id] FOREIGN KEY ([lin_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230918041137_lineaVida')
BEGIN
    CREATE INDEX [IX_LineaVida_lin_paciente_id] ON [LineaVida] ([lin_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230918041137_lineaVida')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230918041137_lineaVida', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927064001_sesiones')
BEGIN
    CREATE TABLE [Sesion] (
        [sesion_id] int NOT NULL IDENTITY,
        [sesion_caso] nvarchar(max) NULL,
        [sesion_no] nvarchar(max) NULL,
        [sesion_terapeuta] int NOT NULL,
        [sesion_coterapeuta] int NOT NULL,
        [sesion_objetivo] nvarchar(max) NULL,
        [sesion_rev_tarea] int NOT NULL,
        [sesion_tecnica_abc] nvarchar(max) NULL,
        [sesion_otras_tecnicas] nvarchar(max) NULL,
        [sesion_tarea_asignada] nvarchar(max) NULL,
        [sesion_notas_ad] nvarchar(max) NULL,
        [sesion_recomendacion_sup] nvarchar(max) NULL,
        [sesion_fecha_captura] datetime2 NOT NULL,
        [sesion_fecha_modificacion] datetime2 NOT NULL,
        [sesion_paciente_id] int NOT NULL,
        CONSTRAINT [PK_Sesion] PRIMARY KEY ([sesion_id]),
        CONSTRAINT [FK_Sesion_Pacientes_sesion_paciente_id] FOREIGN KEY ([sesion_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927064001_sesiones')
BEGIN
    CREATE INDEX [IX_Sesion_sesion_paciente_id] ON [Sesion] ([sesion_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230927064001_sesiones')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230927064001_sesiones', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231010031902_agregando_campo')
BEGIN
    ALTER TABLE [ProbObj] ADD [pro_tecnica] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231010031902_agregando_campo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231010031902_agregando_campo', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011063310_evo_problem_division')
BEGIN
    ALTER TABLE [EvolucionPR] ADD [evo_curso_problema] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011063310_evo_problem_division')
BEGIN
    ALTER TABLE [EvolucionPR] ADD [evo_factores] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011063310_evo_problem_division')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231011063310_evo_problem_division', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    ALTER TABLE [OtrasAR] ADD [otras_apoyo_s] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    ALTER TABLE [OtrasAR] ADD [otras_aspectos_m] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    ALTER TABLE [OtrasAR] ADD [otras_autocontrol] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    ALTER TABLE [OtrasAR] ADD [otras_recursos_p] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    ALTER TABLE [OtrasAR] ADD [otras_situacion_v] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011065354_otras_areas_')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231011065354_otras_areas_', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011165433_form_caso')
BEGIN
    CREATE TABLE [FormCaso] (
        [form_id] int NOT NULL IDENTITY,
        [form_titulo] nvarchar(max) NULL,
        [form_hipotesis] nvarchar(max) NULL,
        [form_contraste] nvarchar(max) NULL,
        [form_fecha_captura] datetime2 NOT NULL,
        [form_fecha_modificacion] datetime2 NOT NULL,
        [form_paciente_id] int NOT NULL,
        CONSTRAINT [PK_FormCaso] PRIMARY KEY ([form_id]),
        CONSTRAINT [FK_FormCaso_Pacientes_form_paciente_id] FOREIGN KEY ([form_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011165433_form_caso')
BEGIN
    CREATE INDEX [IX_FormCaso_form_paciente_id] ON [FormCaso] ([form_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011165433_form_caso')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231011165433_form_caso', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_abc_tareas] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_consecuencia_emo] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_evento_act] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_obj_cond] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_obj_emo] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_obj_prac] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_pensamientos_cre] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_preguntas_debate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    ALTER TABLE [Sesion] ADD [sesion_tecnicas_estrategias] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231011183908_agregar_campos_sesion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231011183908_agregar_campos_sesion', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231012173911_comentarios')
BEGIN
    CREATE TABLE [Comentarios] (
        [com_id] int NOT NULL IDENTITY,
        [com_usuario_id] int NOT NULL,
        [com_index] int NOT NULL,
        [com_nombre_usuario] nvarchar(max) NULL,
        [com_comentario] nvarchar(max) NULL,
        [com_fecha_captura] datetime2 NOT NULL,
        [com_paciente_id] int NOT NULL,
        CONSTRAINT [PK_Comentarios] PRIMARY KEY ([com_id]),
        CONSTRAINT [FK_Comentarios_Pacientes_com_paciente_id] FOREIGN KEY ([com_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231012173911_comentarios')
BEGIN
    CREATE INDEX [IX_Comentarios_com_paciente_id] ON [Comentarios] ([com_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231012173911_comentarios')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231012173911_comentarios', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231025194657_informe')
BEGIN
    CREATE TABLE [Informe] (
        [inf_id] int NOT NULL IDENTITY,
        [inf_paterno] nvarchar(max) NULL,
        [inf_materno] nvarchar(max) NULL,
        [inf_nombre] nvarchar(max) NULL,
        [inf_fecha_nacimiento] datetime2 NOT NULL,
        [inf_fecha_ingreso] datetime2 NOT NULL,
        [inf_ultimo_mov] datetime2 NOT NULL,
        [inf_edad] int NOT NULL,
        [inf_genero] int NOT NULL,
        [inf_edocivil] int NOT NULL,
        [inf_escolaridad] int NOT NULL,
        [inf_ocupacion] nvarchar(max) NULL,
        [inf_email] nvarchar(max) NOT NULL,
        [inf_telefono] nvarchar(max) NOT NULL,
        [inf_domicilio] nvarchar(max) NOT NULL,
        [inf_tutor] int NOT NULL,
        [inf_paciente_id] int NOT NULL,
        CONSTRAINT [PK_Informe] PRIMARY KEY ([inf_id]),
        CONSTRAINT [FK_Informe_Pacientes_inf_paciente_id] FOREIGN KEY ([inf_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231025194657_informe')
BEGIN
    CREATE INDEX [IX_Informe_inf_paciente_id] ON [Informe] ([inf_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231025194657_informe')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231025194657_informe', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231030163435_agregar_terapeuta')
BEGIN
    ALTER TABLE [Pacientes] ADD [pac_coterapeuta] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231030163435_agregar_terapeuta')
BEGIN
    ALTER TABLE [Pacientes] ADD [pac_terapeuta] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231030163435_agregar_terapeuta')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231030163435_agregar_terapeuta', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101203912_genero')
BEGIN
    CREATE TABLE [cat_terapeutas] (
        [tera_id] int NOT NULL IDENTITY,
        [tera_paterno] nvarchar(max) NULL,
        [tera_materno] nvarchar(max) NULL,
        [tera_nombres] nvarchar(max) NULL,
        CONSTRAINT [PK_cat_terapeutas] PRIMARY KEY ([tera_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101203912_genero')
BEGIN
    CREATE TABLE [Genero] (
        [gen_id] int NOT NULL IDENTITY,
        [gen_desc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Genero] PRIMARY KEY ([gen_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101203912_genero')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231101203912_genero', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101210305_camposInforme')
BEGIN
    ALTER TABLE [Informe] ADD [inf_coterapeuta] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101210305_camposInforme')
BEGIN
    ALTER TABLE [Informe] ADD [inf_terapeuta] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101210305_camposInforme')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231101210305_camposInforme', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101234429_catalogosEscAndCivil')
BEGIN
    CREATE TABLE [Edocivil] (
        [civil_id] int NOT NULL IDENTITY,
        [civil_desc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Edocivil] PRIMARY KEY ([civil_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101234429_catalogosEscAndCivil')
BEGIN
    CREATE TABLE [Escolaridad] (
        [esc_id] int NOT NULL IDENTITY,
        [esc_desc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Escolaridad] PRIMARY KEY ([esc_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231101234429_catalogosEscAndCivil')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231101234429_catalogosEscAndCivil', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231108164609_estructura_fam')
BEGIN
    ALTER TABLE [Pacientes] ADD [pac_estructura_fam] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231108164609_estructura_fam')
BEGIN
    ALTER TABLE [Informe] ADD [inf_estructura_fam] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231108164609_estructura_fam')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231108164609_estructura_fam', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113190239_creencias')
BEGIN
    CREATE TABLE [Creencias] (
        [creencia_id] int NOT NULL IDENTITY,
        [creencia_irra1] nvarchar(max) NULL,
        [creencia_irra2] nvarchar(max) NULL,
        [creencia_irra3] nvarchar(max) NULL,
        [creencia_irra4] nvarchar(max) NULL,
        [creencia_irra5] nvarchar(max) NULL,
        [creencia_irra6] nvarchar(max) NULL,
        [creencia_irra7] nvarchar(max) NULL,
        [creencia_irra8] nvarchar(max) NULL,
        [creencia_irra9] nvarchar(max) NULL,
        [creencia_irra10] nvarchar(max) NULL,
        [creencia_fecha_captura] datetime2 NOT NULL,
        [creencia_fecha_modificacion] datetime2 NOT NULL,
        [creencia_paciente_id] int NOT NULL,
        CONSTRAINT [PK_Creencias] PRIMARY KEY ([creencia_id]),
        CONSTRAINT [FK_Creencias_Pacientes_creencia_paciente_id] FOREIGN KEY ([creencia_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113190239_creencias')
BEGIN
    CREATE INDEX [IX_Creencias_creencia_paciente_id] ON [Creencias] ([creencia_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113190239_creencias')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113190239_creencias', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231115070401_archivos')
BEGIN
    CREATE TABLE [Files] (
        [DocumentId] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [FileType] nvarchar(100) NULL,
        [DataFiles] varbinary(max) NULL,
        [CreatedOn] datetime2 NULL,
        CONSTRAINT [PK_Files] PRIMARY KEY ([DocumentId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231115070401_archivos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231115070401_archivos', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231117052952_camposExtraFiles')
BEGIN
    ALTER TABLE [Files] ADD [files_paciente_id] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231117052952_camposExtraFiles')
BEGIN
    ALTER TABLE [Files] ADD [files_tipo_prueba] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231117052952_camposExtraFiles')
BEGIN
    CREATE INDEX [IX_Files_files_paciente_id] ON [Files] ([files_paciente_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231117052952_camposExtraFiles')
BEGIN
    ALTER TABLE [Files] ADD CONSTRAINT [FK_Files_Pacientes_files_paciente_id] FOREIGN KEY ([files_paciente_id]) REFERENCES [Pacientes] ([pac_id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231117052952_camposExtraFiles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231117052952_camposExtraFiles', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231120214355_testscl')
BEGIN
    CREATE TABLE [TestSCL] (
        [scl_id] int NOT NULL IDENTITY,
        [scl_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestSCL] PRIMARY KEY ([scl_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231120214355_testscl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231120214355_testscl', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127205041_respSCL')
BEGIN
    CREATE TABLE [RespSCL] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespSCL] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127205041_respSCL')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231127205041_respSCL', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231129050338_testBaiInAn')
BEGIN
    CREATE TABLE [TestBAI_Inv_An] (
        [bai_id] int NOT NULL IDENTITY,
        [bai_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestBAI_Inv_An] PRIMARY KEY ([bai_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231129050338_testBaiInAn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231129050338_testBaiInAn', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231129054013_respBaiAn')
BEGIN
    CREATE TABLE [RespBAIan] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespBAIan] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231129054013_respBaiAn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231129054013_respBaiAn', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231201201800_bdidepresion')
BEGIN
    CREATE TABLE [RespBDIdp] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespBDIdp] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231201201800_bdidepresion')
BEGIN
    CREATE TABLE [TestBDI_Inv_Dp] (
        [bdi_id] int NOT NULL IDENTITY,
        [bdi_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestBDI_Inv_Dp] PRIMARY KEY ([bdi_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231201201800_bdidepresion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231201201800_bdidepresion', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231201203324_cambioCampo')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RespBDIdp]') AND [c].[name] = N'res_respuesta');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [RespBDIdp] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [RespBDIdp] ALTER COLUMN [res_respuesta] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231201203324_cambioCampo')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231201203324_cambioCampo', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231205192632_ellis')
BEGIN
    CREATE TABLE [TestEllis] (
        [ellis_id] int NOT NULL IDENTITY,
        [ellis_desc] nvarchar(max) NULL,
        [ellis_p] nvarchar(max) NULL,
        CONSTRAINT [PK_TestEllis] PRIMARY KEY ([ellis_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231205192632_ellis')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231205192632_ellis', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231206162852_respEllis')
BEGIN
    CREATE TABLE [RespEllis] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespEllis] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231206162852_respEllis')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231206162852_respEllis', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208184604_scid')
BEGIN
    CREATE TABLE [TestSCID] (
        [scid_id] int NOT NULL IDENTITY,
        [scid_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestSCID] PRIMARY KEY ([scid_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208184604_scid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231208184604_scid', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208200239_respSCID')
BEGIN
    CREATE TABLE [RespSCID] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespSCID] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208200239_respSCID')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231208200239_respSCID', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [RespIsraC] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta1] int NOT NULL,
        [res_respuesta2] int NOT NULL,
        [res_respuesta3] int NOT NULL,
        [res_respuesta4] int NOT NULL,
        [res_respuesta5] int NOT NULL,
        [res_respuesta6] int NOT NULL,
        [res_respuesta7] int NOT NULL,
        [res_observacion] nvarchar(max) NULL,
        [res_sum] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespIsraC] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [RespIsraF] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta1] int NOT NULL,
        [res_respuesta2] int NOT NULL,
        [res_respuesta3] int NOT NULL,
        [res_respuesta4] int NOT NULL,
        [res_respuesta5] int NOT NULL,
        [res_respuesta6] int NOT NULL,
        [res_respuesta7] int NOT NULL,
        [res_respuesta8] int NOT NULL,
        [res_respuesta9] int NOT NULL,
        [res_respuesta10] int NOT NULL,
        [res_observacion] nvarchar(max) NULL,
        [res_sum] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespIsraF] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [RespIsraM] (
        [res_id] int NOT NULL IDENTITY,
        [res_pregunta] int NOT NULL,
        [res_respuesta1] int NOT NULL,
        [res_respuesta2] int NOT NULL,
        [res_respuesta3] int NOT NULL,
        [res_respuesta4] int NOT NULL,
        [res_respuesta5] int NOT NULL,
        [res_respuesta6] int NOT NULL,
        [res_respuesta7] int NOT NULL,
        [res_observacion] nvarchar(max) NULL,
        [res_sum] int NOT NULL,
        [res_id_paciente] int NOT NULL,
        CONSTRAINT [PK_RespIsraM] PRIMARY KEY ([res_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [TestIsraC] (
        [isra_c_id] int NOT NULL IDENTITY,
        [isra_c_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestIsraC] PRIMARY KEY ([isra_c_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [TestIsraF] (
        [isra_f_id] int NOT NULL IDENTITY,
        [isra_f_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestIsraF] PRIMARY KEY ([isra_f_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    CREATE TABLE [TestIsraM] (
        [isra_m_id] int NOT NULL IDENTITY,
        [isra_m_desc] nvarchar(max) NULL,
        CONSTRAINT [PK_TestIsraM] PRIMARY KEY ([isra_m_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231218193755_TestIsra')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231218193755_TestIsra', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespSCL] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespSCID] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespIsraM] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespIsraF] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespIsraC] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespEllis] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespBDIdp] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    ALTER TABLE [RespBAIan] ADD [res_id_maestro] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    CREATE TABLE [Maestro_pruebas] (
        [maestro_id] int NOT NULL IDENTITY,
        [maestro_fecha] datetime2 NOT NULL,
        [maestro_tipo_prueba] int NOT NULL,
        [maestro_id_paciente] int NOT NULL,
        CONSTRAINT [PK_Maestro_pruebas] PRIMARY KEY ([maestro_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119173516_ajuste_pruebas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240119173516_ajuste_pruebas', N'7.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240120213222_pruebatabla')
BEGIN
    CREATE TABLE [TablaPrueba] (
        [prueba_id] int NOT NULL IDENTITY,
        [prueba_descripcion] nvarchar(max) NULL,
        CONSTRAINT [PK_TablaPrueba] PRIMARY KEY ([prueba_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240120213222_pruebatabla')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240120213222_pruebatabla', N'7.0.10');
END;
GO

COMMIT;
GO

