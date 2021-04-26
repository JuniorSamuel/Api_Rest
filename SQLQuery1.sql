
create table Producto(
	idProducto int identity(1,1) primary key,
	nombre varchar(45),
	precio float,
	descripcion varchar(200),
)


create table Cliente(
	idCliente int identity(1,1) primary key,
	nombre varchar(45),
	apellido varchar(45)
)

create table Vendedor(
	idVendedor int identity(1,1) primary key,
	nombre varchar(45),
	apellido varchar(45),
	fechar_Contratado date,
)

create table Historial_ventas(
	idHistorial int identity(1,1) primary key,
	idCliente int foreign key references Cliente(idCliente),
	idVendedor int foreign key references Vendedor(idVendedor),
	idProducto int foreign key references Producto(idProducto),
	fecha date default getdate(),
)

go


go
insert into Cliente(nombre, apellido) values 
('Junior Samuel',  'De Los santos'),
('Jose Miguel',  'Upia'),
('Alfredo',  'Lopez'),
('Carlos Luis',  'Martinez lopez')

insert into Producto(nombre,precio, descripcion) values
('Producto1', 99.9, 'Descripcion general'),
('Producto2', 59.9, 'Descripcion general'),
('Producto3', 299.9, 'Descripcion general'),
('Producto4', 399.9, 'Descripcion general')

insert into Vendedor(nombre, apellido, fechar_Contratado) values 
('Maria', 'Rodriguez', GETDATE()-302),
('Manuel', 'Rozo', GETDATE()-100)

insert into Historial_ventas(idCliente, idVendedor,idProducto, fecha) values 
(1,1,1, GETDATE()-99),(1,1,2, GETDATE()-99),
(1,1,3, GETDATE()-99),(2,1,1, GETDATE()-70),
(2,1,4, GETDATE()-70),(3,2,1, GETDATE()-30),
(4,2,2, GETDATE()-20),(4,2,1, GETDATE()-20),
(4,2,3, GETDATE()-20),(2,2,3, GETDATE()-4),
(2,2,2, GETDATE()-4),(1,2,1, GETDATE()-4)
