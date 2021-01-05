DROP TABLE users;
DROP TABLE cards;

--Creating Tables


CREATE Table IF NOT EXISTS users(
username TEXT,
userpassword TEXT,
userstatus INT,
coins int,
userbio TEXT,
userimage TEXT,
gamesplayed INT,
wins INT,
losses INT
);



CREATE TABLE IF NOT EXISTS cards(
cardname TEXT,
cardowner TEXT,
cardstatus int,
cardID int,
cardprice int
);


