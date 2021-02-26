create table Phone (id int, kolvo int, itogo int)

insert into Phone values(1, 2, null)
insert into Phone values(2, 3, null)
insert into Phone values(3, 4, null)
insert into Phone values(4, 1, null)

declare @sum int
set @sum = 0

update Phone
set @sum = itogo = @sum + kolvo

select * from Phone


