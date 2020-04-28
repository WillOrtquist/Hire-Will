
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE DemoDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE DemoDB;
GO

-- Switch to the DemoDB Database
USE DemoDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);
CREATE TABLE standard_cakes
(
	id			int			identity(1,1),
	name		varchar(50)	not null,
	price		float		not null,
	style		varchar(50)	not null,
	size		varchar(50) not null,
	flavor		varchar(50) not null,
	frosting	varchar(50) not null,
	filling		varchar(50) default(0),
	description varchar(500) not null,
	cake_message varchar(100),
	image_path	varchar(50) not null,
	available	bit			default(1)
	

	constraint pk_cakes primary key(id)
);

CREATE TABLE styles
(
	id			int			identity(1,1),
	available bit not null,
	style varchar (50) not null,
	price float not null,
	
	constraint pk_styles primary key (id)
);
CREATE TABLE sizes
(
	id			int			identity(1,1),
	available bit not null,
	size varchar (50) not null,
	base_price float not null,

	constraint pk_sizes primary key(id)
);

CREATE TABLE flavors
(
	id			int			identity(1,1),
	available bit not null,
	flavor varchar (50) not null,

	constraint pk_flavors primary key(id)
);

CREATE TABLE frostings
(
	id			int			identity(1,1),
	available bit not null,
	frosting varchar (50) not null,

	constraint pk_frostings primary key(id)
);

CREATE TABLE fillings
(
	id			int			identity(1,1),
	available bit not null,
	filling varchar (50) not null

	constraint pk_fillings primary key(id)
);

CREATE TABLE style_size
(
	style_id int not null,
	size_id int NOT NULL,

	constraint fk_style_size_style_id foreign key (style_id) references styles (id),
	constraint fk_style_size_size_id foreign key (size_id) references sizes (id)
);

CREATE TABLE custom_cakes
(
	id			int			identity(1,1),
	name			varchar(50)	not null,
	price			float		not null,
	style_id		int	not null,
	size_id 		int not null,
	flavor_id		int not null,
	frosting_id		int not null,
	filling_id		int not null,
	cake_message	varchar(50),
	description varchar(500) not null,
	image_path	varchar(50) default('placeholder-image'),
	available	bit			default(1)
	

	constraint pk_cakes_custom primary key(id)
	constraint fk_cakes_style_id foreign key (style_id) references styles (id),
	constraint fk_cakes_size_id foreign key (size_id) references sizes (id),
	constraint fk_cakes_flavor_id foreign key (flavor_id) references flavors (id),
	constraint fk_cakes_frosting_id foreign key (frosting_id) references frostings (id),
	constraint fk_cakes_filling_id foreign key (filling_id) references fillings (id),
);

CREATE TABLE orders
(
	order_id			int			identity(1,1),
	cake_name		varchar(50) DEFAULT 'custom order'	not null,
	cake_quantity	int			not null,
	style		varchar(50)	not null,
	size		varchar(50) not null,
	flavor		varchar(50) not null,
	frosting	varchar(50) not null,
	filling		varchar(50) not null,
	cake_message varchar(50),
	order_total		float		not null,
	order_status		varchar(50)	not null,
	customer_name varchar(50) not null,
	phone_number varchar(50) not null,
	email varchar (50) not null,
	pickup_datetime datetime not null,
	
	
);


COMMIT TRANSACTION;


