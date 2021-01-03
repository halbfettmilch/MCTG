DROP TABLE users;
DROP TABLE cards;

--Creating Tables


CREATE Table IF NOT EXISTS users(
username TEXT,
userpassword TEXT,
userstatus INT,
coins int
);

CREATE TABLE IF NOT EXISTS cards(
cardname TEXT,
cardowner TEXT,
cardstatus int,
cardID int,
cardprice int
);

