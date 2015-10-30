create view ActiveUsers as
    select * from Users where IsActive = 1