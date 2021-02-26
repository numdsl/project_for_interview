create table Phone (ID int, IDUser int, TypePhone int, Phone nvarchar(20))

 insert into Phone values(1, 1, 1, '+74951111111')
  insert into Phone values(2, 1, 2, '+74952222222')
  insert into Phone values(3, 2, 1, '+74953333333')
  insert into Phone values(4, 3, 2, '+74954444444')

 select * from Phone

 select distinct P1.IDUser, 
  (select top(1) Phone from Phone  Where IDUser = P1.IDUser) as Phone, 
  (select top(1) ID from Phone  Where IDUser = P1.IDUser) as ID, 
  (select top(1) TypePhone from Phone  where IDUser = P1.IDUser) as TypePhone 
  from Phone as P1