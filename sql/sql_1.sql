create table table1 (number int)

declare @count int
set @count = 0
while (@count < 1000)
begin
insert into table1 values(10 + rand()*(1001))
set @count = @count + 1
end

select * from table1



