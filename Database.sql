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

ALTER TABLE "users" ADD PRIMARY KEY ("username");

ALTER TABLE "cards" ADD PRIMARY KEY ("cardid");




--Inserts für curl scripts



Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,1,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,2,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GreyKnight','kienboec',0,3,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,4,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('FireDragon','kienboec',0,5,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,6,null);