create table P (M int, N int)

  insert into P values(1, 1)
  insert into P values(2, 2)
  insert into P values(3, 3)
  insert into P values(4, 4)
  insert into P values(1, 1) 
 
-- вариант 1
select M, N from P group by M, N

-- вариант 2
select DISTINCT M, N from P



