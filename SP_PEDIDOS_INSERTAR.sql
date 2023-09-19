	--REMOVE STORED PROCEDURE {
		IF EXISTS(SELECT * FROM sys.procedures WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'SP_PEDIDOS_INSERTAR')  
		   DROP PROCEDURE [dbo].[SP_PEDIDOS_INSERTAR];
		GO
			   
	--}

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Juan Lorenzo Mejia Dasilva>
-- Create date: <18-09-2023>
-- Description:	<Procedimiento almacenado para insertar un pedido>
-- =============================================

-- =================Example=====================
-- EXEC dbo.SP_PEDIDOS_INSERTAR
-- =============================================

CREATE PROCEDURE [dbo].[SP_PEDIDOS_INSERTAR] 
(
	@NumPedido INT OUTPUT,
	@Cliente VARCHAR(50) = NULL,
	@Vendedor VARCHAR(50) = NULL
)
AS
	BEGIN
	SET @NumPedido = (SELECT MAX(CONVERT(INT,p.NUMPEDIDO)) + 1 FROM dbo.PEDIDO AS p)
		
		INSERT INTO dbo.PEDIDO
		(
		    NUMPEDIDO,
		    CLIENTE,
		    FECHA,
		    VENDEDOR
		)
		VALUES
		(   @NumPedido,	-- NUMPEDIDO - char(10)
		    @Cliente,	-- CLIENTE - char(10)
		    GETDATE(),	-- FECHA - datetime
		    @Vendedor	-- VENDEDOR - char(10)
		    )  

	END
GO