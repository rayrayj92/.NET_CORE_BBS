# .NET_CORE_BBS

## 개요
.NET CORE 3.1을 사용하여 게시판 및 로그인 기능 구현
MAIN LANDING PAGE의 FRONT-END 디자인

## 기술
* .NET Core 3.1
    * Entity Framework 3.1.1
    * Identity 3.1.1
* MSSQL 13.0.4001
* Bootstrap 4.3.1
* JQuery 3.3.1
* CK Editor 4.14.0

## 기능
* 게시판
    * Input 값 유효성 체크[Back-End, Front-End(HTML5 Attribute)]
    * Pagination
    * 작성(Create)
        * 첨부파일 저장
        * 위지위그(CK Editor)
    * 조회(Read)
        * 첨부파일 다운로드
        * 조회수 + 1 Update
    * 수정(Update)
        * 첨부파일 수정 및 저장
        * 위지위그(CK Editor)
    * 삭제(Delete)
        * 삭제
* 로그인
    * 관리자 페이지 세션 체크 및 ROLE 체크
    * 세션 타이머 값 지정
    * Input 값 유효성 체크[Back-End, Front-End(HTML5 Attribute)]
    * 로그아웃 [세션 파괴]
    
## 데모
링크 -> https://www.youtube.com/watch?v=VM-_YKWzino
