DROP TABLE users CASCADE;
DROP TABLE cards CASCADE;

--Creating Tables


CREATE Table IF NOT EXISTS users(
username TEXT PRIMARY KEY,
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
cardID int PRIMARY KEY,
cardprice int
);



--insert for curl scripts (so cardowner is not NULL)
insert into users(username,userpassword,userstatus,coins,userbio,userimage,gamesplayed,wins,losses)values('kienboec','daniel',0,20,'','',0,0,0);
insert into users(username,userpassword,userstatus,coins,userbio,userimage,gamesplayed,wins,losses)values('vollmilch','cool',0,20,'','',0,0,0);

ALTER TABLE cards ADD FOREIGN KEY ("cardowner")
REFERENCES users ("username") ON DELETE CASCADE;




--Inserts für curl scripts



Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,1,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,2,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GreyKnight','kienboec',0,3,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,4,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('FireDragon','kienboec',0,5,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GoblinKing','kienboec',0,6,null);

Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('WizzardNovice','vollmilch',0,11,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('ElderKraken','vollmilch',0,12,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('GreyKnight','vollmilch',0,13,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('FireElveShaman','vollmilch',0,14,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('FireDragon','vollmilch',0,15,null);
Insert into cards(cardname,cardowner,cardstatus,cardid,cardprice) values ('OrkBoyz','vollmilch',0,16,null);