
-- 1. USERS 테이블
CREATE TABLE USERS (
    ID   VARCHAR2(20) NOT NULL, 
    name    VARCHAR2(20),
    tel_num    VARCHAR2(20),
    password    VARCHAR2(20),
    CONSTRAINT USERS_PK PRIMARY KEY (ID)
)
/


-- 2. TRACK 테이블
CREATE TABLE TRACK (
    track_no    VARCHAR2(20) NOT NULL,
    track_name    VARCHAR2(20) NOT NULL,
    track_cover  	BLOB,
    genre    VARCHAR2(20),
    play_count    INTEGER,
    like_count    INTEGER,
    price    INTEGER,
    rel_date DATE DEFAULT SYSDATE,
    ID    VARCHAR2(20),
    CONSTRAINT TRACK_PK PRIMARY KEY (track_no),
    CONSTRAINT FK_TRACK_EMP FOREIGN KEY (ID) REFERENCES USERS (ID)
)
/

-- 3. PLAYLIST 테이블
CREATE TABLE PLAYLIST (
    ID    VARCHAR2(20),
    track_no    VARCHAR2(20) NOT NULL,
    track_name    VARCHAR2(20) NOT NULL,
    genre    VARCHAR2(20),
    CONSTRAINT PLAYLIST_PK PRIMARY KEY (ID, track_no),
    CONSTRAINT FK_PLAYLIST_CUSTOM FOREIGN KEY (ID) REFERENCES USERS (ID)
)
/


-- 4. USER_PROFILE 테이블
CREATE TABLE USER_PROFILE (
    ID    VARCHAR2(20) NOT NULL,
    NAME VARCHAR2(20),
    photo       VARCHAR2(20) ,
    user_comment VARCHAR2(200),
    CONSTRAINT PROFILE_PK PRIMARY KEY (ID),
    CONSTRAINT FK_PROFILE_CUSTOM FOREIGN KEY (ID) REFERENCES USERS (ID)
)
/


-- 5. TRAN 테이블
CREATE TABLE TRAN (
    tran_no    VARCHAR2(20) NOT NULL,
    ID    VARCHAR2(20) NOT NULL,
    buy_date    DATE DEFAULT SYSDATE,
    sell_qty    INTEGER,
    last_month_sell    INTEGER,
    track_no    VARCHAR2(20) NOT NULL,
    CONSTRAINT TRAN_PK PRIMARY KEY (tran_no, track_no, ID),
    CONSTRAINT FK_TRAN_CUSTOM FOREIGN KEY (ID) REFERENCES USERS (ID),
    CONSTRAINT FK_TRAN_TRACK FOREIGN KEY (track_no) REFERENCES TRACK (track_no)
)
/

