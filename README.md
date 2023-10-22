# 유니티 부트캠프 1기 참여 (주관 : 에티버스러닝) 
- 기간 : 2023.06.19 ~ 현재 

# Unity1Jo
- Unity 2D 쿠키런 모작 팀 프로젝트 (toy project)
- 점프와 슬라이드로 조작을 하며 장애물들을 피해 달리면서 젤리를 먹어 점수를 올리는 게임

![image](https://github.com/urshin/Unity1Jo/assets/46379443/f09c6285-74fd-4f08-a6ef-665127d83399)

# 팀 프로젝트 개요 
- 제작기간 : 3주
- 개발도구 : Unity
- 버전 : 2022.3.4f1
- 개발언어 : C#
- 플랫폼 : 모바일
- 장르 : 사이드 스크롤 러닝 액션 게임
- 팀원 : 4명
 ![image](https://github.com/urshin/Unity1Jo/assets/46379443/51b41bde-a19f-4b3d-a3fb-dc943f21bf3d)
 
# 영상  
- 플레이 영상 링크: https://youtu.be/wNj_AiQ3rXE

# 참여 부분 
- UI 자동화 환경 생성 및 플레이어 조작 버튼 기능 구현
![image](https://github.com/urshin/Unity1Jo/assets/46379443/829aadf7-0fb2-4887-9eb4-14f6c50e8aea)
![image](https://github.com/urshin/Unity1Jo/assets/46379443/322b4239-4fe8-492a-8405-41043124b6ca)

- 데이터 관리 및 UI 버튼 기능 구현 (캐릭터 장금, 해금, 선택)
![image](https://github.com/urshin/Unity1Jo/assets/46379443/e6cc058b-e2c5-4023-a5cd-6ebc7f13ce9b)

- 쿠키 특성 구현 
![image](https://github.com/urshin/Unity1Jo/assets/46379443/b5ad7f62-7ccd-4783-9a85-603b7f034c9d)

- 보너스 타임 애니메이션 연출 및 player state 구현
![image](https://github.com/urshin/Unity1Jo/assets/46379443/1c076e55-2d02-4023-ba48-45d85a0e9e21)
![image](https://github.com/urshin/Unity1Jo/assets/46379443/418cbe5a-d983-4acd-ac5c-5952ea34a61d)

  
# 게임 내 사용한 디자인 패턴 
1. Singleton Pattern
![image](https://github.com/urshin/Unity1Jo/assets/46379443/4bed1125-1e38-407f-b883-dcf9b6626a25)

2. State Pattern 
![image](https://github.com/urshin/Unity1Jo/assets/46379443/36090e31-f34e-43a9-a9d4-dd5a89f687ad)

# 회고록 
- 프로젝트를 하면서 초기 설정이 오래걸리고 기본 틀을 탄탄하게 다지려고 노력하였다. 꽤 긴 요구 분석이 필요했고 버그도 많았다. 
- 플레이어가 기본적으로 가져야 할 state들을 미리 설정해 두어서 새로운 쿠키 제작에 용이했고 Spawn Manager를 통한 아이템, 
장애물 생성을 통해 레벨 디자인에 용이했다. 하지만 하나의 프리팹 안에 animator나 sprite가 변경되는 식은 개발 할 시 효율적이지 못했다.
그리고 맵을 수정 할 때마다 Json파일을 수정해야하는 번거로움이 발생해서 GSTU 플러그인을 활용하여 Unity와 스프레드 시트를 동기화하여 자동 수정 환경을 
구축하게되었다. 마지막으로 쿠키의 체력을 UI화면에 표시하는 기능 개발 시 클래스 간의 결합도가 높아 옵저버 패턴 사용 하여 객체간의 의존성 제거 필요했다.
