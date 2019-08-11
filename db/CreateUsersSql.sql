create table movies.app_users
(
    id             int auto_increment
        primary key,
    username       varchar(500) charset utf8 not null,
    password       varchar(500) charset utf8 not null,
    configurations json                      null
);