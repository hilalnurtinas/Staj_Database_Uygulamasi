
 -- CREATE DATABASE DemoDB;

use DemoDB;

 -- tablo olusturma --
 -- tablolara ekleme işlemi yapma --


CREATE TABLE demo(
	article_ID varchar(30) NOT NULL PRIMARY KEY,
	article_Name varchar(30) NOT NULL
);


insert into demo values(1, 'C#');
insert into demo values(2, 'C++');
insert into demo values(3, 'Python');
