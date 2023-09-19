	--REMOVE STORED PROCEDURE {
		IF EXISTS(SELECT * FROM sys.procedures WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'SP_COMISIONVENDEDORDEPARTAMENTOS_CONSULTAR')  
		   DROP PROCEDURE [dbo].[SP_COMISIONVENDEDORDEPARTAMENTOS_CONSULTAR];
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
-- EXEC dbo.SP_COMISIONVENDEDORDEPARTAMENTOS_CONSULTAR
-- =============================================

CREATE PROCEDURE [dbo].[SP_COMISIONVENDEDORDEPARTAMENTOS_CONSULTAR] 
(
	@FechaInicial VARCHAR(50) = NULL
)
AS
	BEGIN
		
		SELECT MONTH(p2.FECHA) AS MES, V.NOMBRE AS NOMVENDEDOR, SUM(I.PRECIO) AS VENTASACUMULADAS, SUM(I.PRECIO * 0.1) AS COMISIONACUMULADA
		FROM dbo.ITEMS AS i 
			INNER JOIN dbo.PRODUCTO AS p ON p.CODPROD = i.PRODUCTO
			INNER JOIN dbo.PEDIDO AS p2 ON p2.NUMPEDIDO = i.NUMPEDIDO
			INNER JOIN dbo.CLIENTE AS c ON c.CODCLI = p2.CLIENTE
			INNER JOIN dbo.VENDEDOR AS v ON v.CODVEND = c.VENDEDOR
			INNER JOIN dbo.CIUDAD AS c2 ON c2.CODCIU = c.CIUDAD
			INNER JOIN dbo.DEPARTAMENTO AS d ON d.CODDEP = c2.DEPARTAMENTO
		WHERE MONTH(p2.FECHA) = MONTH(@FechaInicial) AND	
		YEAR(p2.FECHA) = YEAR(@FechaInicial)
		GROUP BY MONTH(p2.FECHA), V.NOMBRE
		ORDER BY V.NOMBRE

	END
GO
