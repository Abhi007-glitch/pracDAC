Delimiter &&
create Procedure EvenIterate()
Begin
        Declare done Int default 0;
        Declare Worker_id int;
        Declare First_name varchar(20);
        Declare Last_name varchar(20);
        Declare Salary int ;
        Declare Joining_date DateTime;
        Declare Department varchar(20);
        Declare curCount int default 0;

        Declare even_cursor cursor for
        Select * from Worker;
        Declare continue handler for not found set done=1;
        open even_cursor;
        loop_label:loop
          fetch even_cursor into worker_id,First_name,Last_name,Salary,Joining_date,Department;
        if (done=1)then
                leave loop_label;
        end if;
        if (curCount%2=1) then
        insert into temp values (worker_id,First_name,Last_name,Salary,Joining_date,Department);
        end if;
        set curCount = curCount+1;
        iterate loop_label;
end loop;
close even_cursor;
end &&

delimiter ;
