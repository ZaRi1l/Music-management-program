-- USERS 테이블
INSERT INTO USERS (ID, name, tel_num, password) VALUES ('C001', '김철수', '010-1234-5678', 'password123')
/
INSERT INTO USERS (ID, name, tel_num, password) VALUES ('C002', '이현아', '010-4267-4211', 'password555')
/
INSERT INTO USERS (ID, name, tel_num, password) VALUES ('C003', '박민수', '010-4567-8901', 'password789')
/

-- TRACK 테이블 
INSERT INTO TRACK (track_no, track_name, track_cover, genre, play_count, like_count, price, ID) VALUES ('T001', 'Dynamite', NULL, 'POP', 40000, 500, 1500, 'C001')
/
INSERT INTO TRACK (track_no, track_name, track_cover, genre, play_count, like_count, price, ID) VALUES ('T002', 'Highway to Hell', NULL, 'ROCK', 800000, 400000, 2000, 'C002')
/
INSERT INTO TRACK (track_no, track_name, track_cover, genre, play_count, like_count, price, ID) VALUES ('T003', 'Moonlight Sonata', NULL, 'CLASSIC', 500000, 300000, 1100, 'C003')
/

-- PLAYLIST 테이블
INSERT INTO PLAYLIST (ID, track_no, track_name, genre) VALUES ('C001', 'T001', 'Dynamite', 'POP')
/
INSERT INTO PLAYLIST (ID, track_no, track_name, genre) VALUES ('C002', 'T002', 'Highway to Hell', 'ROCK')
/
INSERT INTO PLAYLIST (ID, track_no, track_name, genre) VALUES ('C003', 'T003', 'Moonlight Sonata', 'CLASSIC')
/


-- USER_PROFILE 테이블 
INSERT INTO USER_PROFILE (ID, NAME, photo, user_comment) VALUES ('C001', '김철수', NULL, 'BTS 최고!')
/
INSERT INTO USER_PROFILE (ID, NAME, photo, user_comment) VALUES ('C002', '이현아', NULL, '락 좋아!')
/
INSERT INTO USER_PROFILE (ID, NAME, photo, user_comment) VALUES ('C003', '박민수', NULL, '클래식은 진리.')
/

-- TRAN 테이블
INSERT INTO TRAN (tran_no, ID, sell_qty, last_month_sell, track_no) VALUES ('T001001', 'C001', 5, 10, 'T001')
/
INSERT INTO TRAN (tran_no, ID, sell_qty, last_month_sell, track_no) VALUES ('T002002', 'C002', 3, 8, 'T002')
/
INSERT INTO TRAN (tran_no, ID, sell_qty, last_month_sell, track_no) VALUES ('T003003', 'C003', 6, 5, 'T003')
/