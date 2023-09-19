	--REMOVE STORED PROCEDURE {
		IF EXISTS(SELECT * FROM sys.procedures WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'SP_ITEMS_INSERTAR')  
		   DROP PROCEDURE [dbo].[SP_ITEMS_INSERTAR];
		GO
			   
	--}

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Juan Lorenzo Mejia Dasilva>
-- Create date: <18-09-2023>
-- Description:	<Procedimiento almacenado para insertar el detalle de un pedido>
-- =============================================

-- =================Example=====================
-- EXEC dbo.SP_ITEMS_INSERTAR
-- =============================================

CREATE PROCEDURE [dbo].[SP_ITEMS_INSERTAR] 
(
	@NumPedido VARCHAR(50),
	@Producto VARCHAR(50) = NULL,
	@Precio VARCHAR(50) = NULL,
	@Cantidad VARCHAR(50) = NULL
)
AS
	BEGIN
	
		INSERT INTO dbo.ITEMS
		(
			NUMPEDIDO,
			PRODUCTO,
			PRECIO,
			CANTIDAD
		)
		VALUES
		(   @NumPedido,   -- NUMPEDIDO - char(10)
			@Producto,   -- PRODUCTO - char(10)
			CAST(REPLACE(@Precio, ',', '.') AS NUMERIC(18,2)), -- PRECIO - numeric(18, 0)
			CAST(REPLACE(@Cantidad, ',', '.') AS NUMERIC(18,2))  -- CANTIDAD - numeric(18, 0)
			)

	END
GO
