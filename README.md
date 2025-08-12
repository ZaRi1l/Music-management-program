# 🎵 음원 관리 시스템 (Music Management System)

C#과 Oracle DB를 기반으로 구축한 데스크톱 음원 관리 프로그램입니다. 아티스트가 자유롭게 음원을 등록하고, 사용자는 차트와 검색을 통해 원하는 음악을 구매할 수 있는 플랫폼을 구현했습니다. 이 프로젝트는 '데이터베이스 프로그래밍' 교과목의 팀 프로젝트로 진행되었습니다.

<br>

<div align="center">
  <!-- 이곳에 프로그램 메인 스크린샷을 넣어주세요 -->
  <img src="docs/구현 사진/메인화면.jpg" alt="프로그램 메인 화면" width="900"/>
</div>

<br>

---

## 🚀 주요 기능 (Key Features)

### For All Users
- **회원 관리**: 고객과 아티스트 유형을 선택하여 회원가입 및 로그인
- **프로필 관리**: 이름, 소개말, 프로필 사진 등 개인 프로필 수정
- **음원 차트**: 인기 차트, 최신 차트 등 실시간 음원 순위 제공
- **음원 검색**: 제목, 가수, 장르 등 다양한 조건으로 원하는 음원을 검색

### For Listeners (고객)
- **음원 구매**: 차트나 검색 결과를 통해 원하는 음원 구매
- **구매 내역 관리**: 구매한 음원 목록을 확인하고, 일정 시간 내 반품 기능 제공
- **플레이리스트**: 나만의 플레이리스트 생성 및 관리

### For Artists (아티스트)
- **음원 관리**: 자신의 음원(음원 파일, 커버 이미지, 곡 정보)을 직접 업로드 및 삭제
- **판매 현황**: 업로드한 음원의 판매량 실시간 확인
- **정산 관리**: 일/월/연 단위의 판매 통계 및 정산 내역 확인

<br>

---

## 💻 기술 스택 (Tech Stack)

| Category      | Technologies Used                                                                                                                                                                  |
|---------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Language**  | <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">                                                                                   |
| **Framework** | <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white">                                                                                    |
| **UI**        | <img src="https://img.shields.io/badge/Windows%20Forms-026E81?style=for-the-badge&logo=windows&logoColor=white">                                                                       |
| **Database**  | <img src="https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white"> <img src="https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white"> |
| **IDE & VCS** | <img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white"> <img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white"> |

<br>

---

## 📊 데이터베이스 설계 (Database Design)

본 프로젝트는 체계적인 데이터베이스 설계를 기반으로 구현되었습니다. 요구사항 분석을 통해 엔티티를 도출하고, **정규화(Normalization)** 과정을 거쳐 데이터의 중복을 최소화하고 무결성을 확보했습니다. 최종적으로 설계된 ERD는 다음과 같습니다.

<br>

<div align="center">
  <!-- 이곳에 프로젝트 ERD(물리적 데이터 모델) 이미지를 넣어주세요 -->
  <img src="docs/프로젝트 구현 자료(SQL, ERD)/물리 ERD.jpg" alt="ERD" width="900"/>
</div>

<br>

---

## 🖼️ 주요 기능 구현 화면

| 로그인 및 회원가입 | 메인 화면 및 음원 차트 |
| :---: | :---: |
| <!-- 이미지 경로 수정 --> <img src="docs/구현 사진/로그인 화면.jpg" alt="로그인" width="400"> | <!-- 이미지 경로 수정 --> <img src="docs/구현 사진/메인화면.jpg" alt="메인차트" width="400"> |
| **음원 검색 및 구매** | **아티스트의 음원 업로드** |
| <!-- 이미지 경로 수정 --> <img src="docs/구현 사진/검색하기2.jpg" alt="검색구매" width="400"> | <!-- 이미지 경로 수정 --> <img src="docs/구현 사진/음원 업로드2.jpg" alt="업로드" width="400"> |

<br>

---

## ✨ 나의 역할 및 기여 (My Role & Contribution)

이 프로젝트에서 저는 다음과 같은 역할을 수행하며 기여했습니다.

- **데이터베이스 설계 주도**:
  - 프로젝트 요구사항을 분석하여 `업무 기술서` 작성
  - 데이터 무결성을 위한 `정규화` 과정 수행 및 최종 테이블 설계
- **핵심 기능 로직 구현 (C#)**:
  - `인기차트`와 `최신차트`를 집계하고 표시하는 로직 구현
  - `제목`, `가수`, `장르` 등 다중 조건 `검색 기능` 구현
  - 사용자의 `음원 구매 기능` 및 관련 데이터 처리 로직 구현
- **데이터베이스 구축**:
  - 설계된 스키마를 바탕으로 테이블을 생성하는 `CREATE SQL` 스크립트 작성
  - 초기 데이터 및 테스트 데이터를 위한 `INSERT SQL` 스크립트 작성

<br>

---

## 👥 Team
- 4인 1조로 진행된 팀 프로젝트입니다.


---

[프로젝트 상세 설계 문서 보기 (개인정보 제외 버전)](docs/DBP_오후반_2조_박규태_최종보고서_clean_ver.hwp)
