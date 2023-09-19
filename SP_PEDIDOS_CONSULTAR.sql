	--REMOVE STORED PROCEDURE {
		IF EXISTS(SELECT * FROM sys.procedures WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'SP_PEDIDOS_CONSULTAR')  
		   DROP PROCEDURE [dbo].[SP_PEDIDOS_CONSULTAR];
		GO
			   
	--}

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Juan Lorenzo Mejia Dasilva>
-- Create date: <18-09-2023>
-- Description:	<Procedimiento almacenado para consultar las comisiones de ventas por Vendedor y por Mes>
-- =============================================

-- =================Example=====================
-- EXEC dbo.SP_PEDIDOS_CONSULTAR
-- =============================================

CREATE PROCEDURE [dbo].[SP_PEDIDOS_CONSULTAR] 

AS
	BEGIN
		
		SELECT DISTINCT I.NUMPEDIDO, V.NOMBRE NOMVENDEDOR, C.NOMBRE NOMCLIENTE, D.NOMBRE NOMDEP, P2.FECHA
		FROM dbo.ITEMS AS i 
			INNER JOIN dbo.PEDIDO AS p2 ON p2.NUMPEDIDO = i.NUMPEDIDO
			INNER JOIN dbo.CLIENTE AS c ON c.CODCLI = p2.CLIENTE
			INNER JOIN dbo.VENDEDOR AS v ON v.CODVEND = c.VENDEDOR
			INNER JOIN dbo.CIUDAD AS c2 ON c2.CODCIU = c.CIUDAD
			INNER JOIN dbo.DEPARTAMENTO AS d ON d.CODDEP = c2.DEPARTAMENTO

		ORDER BY P2.FECHA DESC, V.NOMBRE 

	END
GO

