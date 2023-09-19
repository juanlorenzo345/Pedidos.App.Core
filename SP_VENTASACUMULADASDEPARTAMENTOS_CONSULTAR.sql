	--REMOVE STORED PROCEDURE {
		IF EXISTS(SELECT * FROM sys.procedures WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'SP_VENTASACUMULADASDEPARTAMENTOS_CONSULTAR')  
		   DROP PROCEDURE [dbo].[SP_VENTASACUMULADASDEPARTAMENTOS_CONSULTAR];
		GO
			   
	--}

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Juan Lorenzo Mejia Dasilva>
-- Create date: <18-09-2023>
-- Description:	<Procedimiento almacenado para consultar las ventas acumuladas por departamentos>
-- =============================================

-- =================Example=====================
-- EXEC dbo.SP_VENTASACUMULADASDEPARTAMENTOS_CONSULTAR
-- =============================================

CREATE PROCEDURE [dbo].[SP_VENTASACUMULADASDEPARTAMENTOS_CONSULTAR] 
(
	@FechaInicial DATETIME = NULL
	, @FechaFinal DATETIME = NULL
)
AS
	BEGIN
		
		SELECT d.CODDEP, d.NOMBRE AS NOMDEP, SUM(I.PRECIO) AS VENTASACUMULADAS
		FROM dbo.ITEMS AS i 
			INNER JOIN dbo.PRODUCTO AS p ON p.CODPROD = i.PRODUCTO
			INNER JOIN dbo.PEDIDO AS p2 ON p2.NUMPEDIDO = i.NUMPEDIDO
			INNER JOIN dbo.CLIENTE AS c ON c.CODCLI = p2.CLIENTE
			INNER JOIN dbo.VENDEDOR AS v ON v.CODVEND = c.VENDEDOR
			INNER JOIN dbo.CIUDAD AS c2 ON c2.CODCIU = c.CIUDAD
			INNER JOIN dbo.DEPARTAMENTO AS d ON d.CODDEP = c2.DEPARTAMENTO
		WHERE p2.FECHA >= @FechaInicial AND	p2.FECHA <= @FechaFinal
		GROUP BY d.CODDEP, d.NOMBRE
		ORDER BY D.NOMBRE

	END
GO
