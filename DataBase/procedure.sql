delimiter $

Create Procedure listingNames(In val int)
begin
   Declare name varchar(50);
   select customer_name from Sales where amount>val;
   
end$

delimiter ;



delimiter $

Create Procedure evenOddSumDiff(IN input int,Out result int)
begin
   Declare sum int ;
   Declare cur int ;

   set sum=0;
   set cur=1;

   loop_label : loop
   if cur>input then
      leave loop_label;
   else 
      set sum=sum+cur;
      set cur = cur +1;
   end if;
   iterate loop_label;
   end loop;

   set result=sum;
end$

delimiter ;


delimiter $
create Trigger beforeInsertBonus before Insert on Bonus for each row
begin 
    if NEW.BONUS_AMOUNT<1000 then
       set NEW.BONUS_AMOUNT=1001;
    end if; 
end$
delimiter;


delimiter $
create Trigger afterUpdateBonus after Update on Bonus for each row
begin 
    Declare old_record;
    select old
    if NEW.BONUS_AMOUNT<900 then
       set NEW.BONUS_AMOUNT=OLD.BONUS_AMOUNT;
    end if; 
end$
delimiter;



delimiter $ 
create Trigger AfterInsertEmployees After Insert on employees for each row 
begin
     if (NEW.age%2=0) then
        insert into EMP values (NEW.emp_id,NEW.emp_name,NEW.age,NEW.salary);
     end if;
end$
delimiter ;


delimiter &
create Procedure findEvenEmployee()
BEGIN
     DECLARE cnt INT DEFAULT 0;
    
     DECLARE done INT DEFAULT 0;
    
     DECLARE id int;
    DECLARE name varchar(50);
     Declare Age int;
     Declare sal int;
    
     DECLARE even_cursor Cursor for 
     select * from employees;
     DECLARE CONTINUE HANDLER FOR NOT FOUND set done=1;
     
     open even_cursor;
     loop_label:loop
     fetch even_cursor into id,name,Age,sal;
     if done=1 then 
        leave loop_label;
     end if;
     if MOD(cnt,2)=0 then
       insert into temp values (id,name,Age,sal);
     end if;
     set cnt=cnt+1;
     iterate loop_label;
    end loop;
    close even_cursor;
END&
    delimiter ;


delimiter $
create Function ageCal(date Date) returns int deterministic
begin
     return Year(curDate())-Year(date);
end$
delimiter ;



delimiter $
Create Trigger afterInsert after Insert on customers1 for each row
BEGIN
    if old.birthdate is null then
       set old.birthdate = curDate();
    end if;
END$
delimiter ;