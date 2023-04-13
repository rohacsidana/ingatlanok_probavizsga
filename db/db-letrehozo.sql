--create database ingatlan
use ingatlan

--create table kategoriak
--(
--	id int identity(10,1),
--	nev varchar(50) unique not null,
--	primary key(id)
--)

--create table ingatlanok
--(
--	id int identity(1000,1),
--	kategoria int not null,
--	leiras varchar(100),
--	hirdetesDatuma date,
--	tehermentes bit not null,
--	ar int not null,
--	kepUrl varchar(150),
--	primary key(id)
--)

--alter table ingatlanok
--ADD FOREIGN KEY (kategoria) REFERENCES kategoriak(id);

--alter table ingatlanok
--	add constraint defaultDatum
--	default getDate() FOR hirdetesDatuma;
--go