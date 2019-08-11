create table movies.movies
(
    id          int auto_increment
        primary key,
    title       varchar(200) not null,
    upc         bigint       not null,
    ean         bigint       null,
    description text         null,
    constraint movies_upc_uindex
        unique (upc)
);