
--1
--Repuesto más utilizado agrupado por Marca/Modelo en las reparaciones realizadas 
--(Mostrar Descripción del Repuesto y cantidad de veces usado)
SELECT 
r.nombre
,max(t2.cantidad)
FROM [TallerMecanico].[dbo].[Vehiculos] v
INNER JOIN [TallerMecanico].[dbo].[Presupuestos] p on v.id = p.IdVehiculo
INNER JOIN [TallerMecanico].[dbo].[Desperfectos] d on p.Id = d.IdPresupuesto
INNER JOIN [TallerMecanico].[dbo].DesperfectosRepuestos dr on d.Id = dr.IdDesperfecto
INNER JOIN [TallerMecanico].[dbo].Repuestos r on dr.IdRepuesto = r.Id
left join
(

SELECT 
Repuestos.nombre,
count(Repuestos.nombre) as Cantidad
FROM [TallerMecanico].[dbo].[Vehiculos] 
INNER JOIN [TallerMecanico].[dbo].[Presupuestos] on [Vehiculos].id = [Presupuestos].IdVehiculo
INNER JOIN [TallerMecanico].[dbo].[Desperfectos] on [Presupuestos].Id = [Desperfectos].IdPresupuesto
INNER JOIN [TallerMecanico].[dbo].DesperfectosRepuestos on [Desperfectos].Id = DesperfectosRepuestos.IdDesperfecto
INNER JOIN [TallerMecanico].[dbo].Repuestos on DesperfectosRepuestos.IdRepuesto = Repuestos.Id
group by [Vehiculos].[Marca],[Vehiculos].[Modelo],Repuestos.nombre
) t2 on r.nombre = t2.nombre

group by v.[Marca],v.[Modelo],r.nombre

--2
--Promedio del Monto Total de Presupuestos agrupado por Marca/Modelo
SELECT 
[Vehiculos].[Marca],[Vehiculos].[Modelo],
AVG(Presupuestos.total) AS Promedio
FROM [TallerMecanico].[dbo].[Vehiculos] 
INNER JOIN [TallerMecanico].[dbo].[Presupuestos] on [Vehiculos].id = [Presupuestos].IdVehiculo
INNER JOIN [TallerMecanico].[dbo].[Desperfectos] on [Presupuestos].Id = [Desperfectos].IdPresupuesto
group by [Vehiculos].[Marca],[Vehiculos].[Modelo]

--3
--Sumatoria del Monto Total de Presupuestos para Autos y para Motos
SELECT 
SUM(Presupuestos.total) AS Promedio
FROM [TallerMecanico].[dbo].[Vehiculos] 
INNER JOIN [TallerMecanico].[dbo].[Presupuestos] on [Vehiculos].id = [Presupuestos].IdVehiculo
INNER JOIN [TallerMecanico].[dbo].[Desperfectos] on [Presupuestos].Id = [Desperfectos].IdPresupuesto
where vehiculos.id in(select idvehiculo from [TallerMecanico].[dbo].automoviles union all select idvehiculo from [TallerMecanico].[dbo].motos)


