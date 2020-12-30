DROP TABLE users;
DROP TABLE cards;

--Creating Tables


CREATE Table IF NOT EXISTS users(
username TEXT,
userpassword TEXT,
coins int
);

CREATE TABLE IF NOT EXISTS cards(
cardname TEXT,
cardowner TEXT,
cardstatus int
);



CREATE Table IF NOT EXISTS Stack(
StackID int, --PK
Cardname string,
);


