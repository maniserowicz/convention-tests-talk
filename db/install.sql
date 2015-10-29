create table Users (
    [Id] [int] identity(1,1),
    [Username] nvarchar(500) not null,
    [IsActive] [bit] not null,
    constraint PK_Users primary key (Id)
)

go

create view ActiveUsers as
    select * from Users where IsActive = 1