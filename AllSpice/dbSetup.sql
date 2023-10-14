CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- NOTE **creator MARKED AS STRETCH GOAL ON recipes??

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(1000) NOT NULL,
        img VARCHAR(500) NOT NULL,
        category VARCHAR(100) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        archived TINYINT DEFAULT 0,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredient(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        name VARCHAR(100) NOT NULL,
        quantity VARCHAR(100) NOT NULL,
        recipeId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        recipeId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

/* NOTE SQL STATEMENTS BELOW */

-- get all recipes

SELECT * FROM recipes;

-- join get all recipes and accounts

SELECT * FROM recipes JOIN accounts;

-- join get recipe table and joint to accounts, on the accountId == recipeId

-- get allrecipes with their creator Ids

SELECT *
FROM recipes rec
    JOIN accounts act ON act.id = rec.creatorId;

-- get recipes wherein the acc Id == creator id ??

SELECT rec.*, act.*
FROM recipes rec
    JOIN accounts act ON act.id = rec.creatorId;

-- select all the recipes colums and just the account name

-- from the recipes table join accounts based on actid==alb creatorid

-- where recipes the title =='term'

SELECT rec.*, act.name
FROM recipes rec
    JOIN accounts act ON act.id = rec.creatorId
WHERE title = '';

-- select all of columns of account joined to recipes based on rec creator id = act

-- where act id == ""

SELECT *
FROM accounts act
    JOIN recipes rec ON rec.creatorId = act.id
WHERE act.id = 'xxxxx'

DELETE FROM recipes WHERE id = 3;

SELECT * FROM favorites;

SELECT favor.*, recipe.title
FROM favorites favor
    JOIN recipes recipe ON recipe.id = favor.recipeId
WHERE favor.accountId = 'xxxxx';

SELECT *
FROM favorites favor
    JOIN accounts act ON act.id = favor.accountId
WHERE recipeId = 3;

-- INSERTS

INSERT INTO
    recipes(title, category, creatorId)
VALUES (
        'test recipe a',
        'Merican',
        '64f76f68599293f30abc2ade'
    );

INSERT INTO
    recipes(category, title, img, creatorId)
VALUES (
        'Convention',
        'Ping Pong Association',
        'https://images.unsplash.com/photo-1559136560-16ad036d85d3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2069&q=80',
        '64f76f68599293f30abc2ade'
    );

INSERT INTO
    recipes(category, title, img, creatorId)
VALUES (
        'Concert',
        'Pong',
        'https://images.unsplash.com/photo-1595693143692-750b5c33e335?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1953&q=80',
        '6526c4304dedc9f41b528495'
    );

INSERT INTO
    ingredients (imgUrl, creatorId, recipeId)
VALUES (
        "https://images.unsplash.com/photo-1605548587049-8bda5bfdbbf7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTAwfHxwaW5nJTIwcG9uZ3xlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60",
        '6526c4304dedc9f41b528495',
        3
    );

INSERT INTO
    favorites(recipeId, accountId)
VALUES (
        20,
        '6526c4304dedc9f41b528495'
    );