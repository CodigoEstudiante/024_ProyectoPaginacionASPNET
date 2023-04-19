

CREATE PROC sp_ObtenerOrdenes(
@ignorar_primeros int = 0,
@cantidad_filas INT = 10,
@filtro varchar(100)
)as
begin
	select OrderId,CustomerID,ShipAddress,ShipCountry from [dbo].[Orders]
	where OrderId like '%' + @filtro +'%' OR CustomerID like '%' + @filtro +'%' or ShipAddress like '%' + @filtro +'%' or ShipCountry like '%' + @filtro +'%'
	order by OrderID
	OFFSET @ignorar_primeros ROWS
	FETCH NEXT @cantidad_filas ROWS ONLY
end

EXEC sp_ObtenerOrdenes 0,10,'HA'


create FUNCTION fn_obtenertotal 
(
 @filtro varchar(100) = ''
)
RETURNS int
AS
BEGIN
	declare @total int = 0

	set @total = (select count(orderId)[Total] from  [dbo].[Orders] where 
	OrderId like '%' + @filtro +'%' or
	CustomerID like '%' + @filtro +'%' or 
	ShipAddress like '%' + @filtro +'%' or 
	ShipCountry like '%' + @filtro +'%')

	return @total
END


select dbo.fn_obtenertotal('france')