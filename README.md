# homeTraining
유니티,키넥트,아두이노를 이용한 캡스톤디자인1 게임형 스마트 홈 트레이닝 프로젝트입니다.
## 프로그램 소개
### 구조도

<img width="699" alt="스크린샷 2022-06-10 오전 11 14 08" src="https://user-images.githubusercontent.com/91768822/172976835-f90efbd6-9e23-4dd6-962e-894f51633bfc.png">

### 게임 컨셉
 게임 컨셉은 죄수(사용자)가 감옥에서 탈출하여 추격자로 부터 도망치는 배경이다. 운동은 밴드를 이용한 하체 운동 을 위주로 한다. 사용자는 하체에 운동 밴드를 착용하고, 키 넥트로 자신의 동작을 인식시켜 플레이어 캐릭터를 조작한 다. 사용자는 도망치면서 나오는 장애물들에 대해 적절한 하체 운동 동작으로 피하는 동작을 해야 한다. 클리어 기준을 달성한 후엔 구속장치를 끊어버리며 게임을 클리어 하게 된다.
 
 컨텐츠는 몰입도를 위해 사용자와 캐릭터와 상황을 동일시 함을 목표로한다. 게임 컨텐츠는 죄수가 구속장치를 달고 도망치는 설정이다. 사용자는 운동밴드를 다리에 착용하여 캐릭터와 같이 구속장치를 단 것처럼 느끼게 하고, 키넥트로 캐릭터 모델의 움직임이 사용자를 트래킹 하여 같은 움직임을 취하게 함으로써 몰입도를 높인다.
 
<img width="311" alt="스크린샷 2022-06-08 오후 11 25 01" src="https://user-images.githubusercontent.com/91768822/172642675-041be6b6-7971-44a1-9e55-9410fc882d01.png">

 게임 오버 기준이 되는 캐릭터를 추격하는 간수를 배치한다. 간수의 속도로 사용자의 운동 템포를 조절하여 사용자가 게임의 요소로서 자연스럽게 받아들이도록 한다. 추적은 Unity의 Nav Mesh Agent를 이용한다. 특정 강도의 운동을 충분히 진행하여 게임 캐릭터의 근육의 모양이 변화하면 밴드 교체시간을 주고, 더 높은 강도의 밴드를 이용하여 더 강한 운동 효과를 낼 수 있도록 한다. 사용자가 일정 시간 운동을 진행한 후엔 ‘장애물 점검 시간’이란 문구와 함께 30초를 휴식할 수 있도록 한다.

### 목표
아두이노와 근전도 센서 모듈을 활용해 게임 중 플 레이어의 부위별 근육 사용량을 측정하여 그만큼 캐릭터의 능력치와 외형에 반영한다. 사용자가 자신의 운동량을 가시 적으로 파악하고 계속해서 캐릭터를 발전시키기 위해 운동 하도록 유도한다. 아두이노와 Windows의 serial communication엔 통신 안정성을 위해 Wi-Fi, 게임 엔진으로는 키넥트와 아두이노 API가 제공된 Unity를 사용한다. 이러한 게임형 스마트 홈트레이닝 시스템을 통해 사용자가 더 적극적으로 운동에 참여 할 수 있도록 하는 것이 본 프로젝트의 목표이다.
## 게임 시나리오
캐릭터를 일정 시간 움직일 수 없는 딜레이 상태로 만드는 것이 장애물의 공통적 패널티다.
### 밴디드퀵핏(좌우)

<img width="285" alt="스크린샷 2022-06-08 오후 11 51 18" src="https://user-images.githubusercontent.com/91768822/172647702-d5c3e282-4058-4fed-a3c2-6a620e93107b.png">

<img width="1198" alt="스크린샷 2022-06-08 오후 9 03 24" src="https://user-images.githubusercontent.com/91768822/172647478-dc6d11f1-da34-4201-8ce8-535aa8aec39b.png">

<img width="1192" alt="스크린샷 2022-06-08 오후 9 03 42" src="https://user-images.githubusercontent.com/91768822/172648665-4a779f12-d949-4095-aece-a432f41017d3.png">

격자에 폭탄이 놓여 있는 발판 장애물을 제시한다. 이를 통해 전진하며 자연스럽게 밴디드 퀵 핏을 하며 나아갈 수 있도록 한다. 시간안에 장애물을 지나가지 못하거나 다른 동작을 하여 폭탄에 닿으면 폭탄이 폭발한다.

### 밴디드 퀵 핏 (전후)

<img width="1141" alt="스크린샷 2022-06-08 오후 8 45 29" src="https://user-images.githubusercontent.com/91768822/172648046-fed1efe1-3e51-4165-b015-0c31d48a703a.png">

캐릭터의 전진에 사용한다.
### 사이드 스쿼트

<img width="1193" alt="스크린샷 2022-06-08 오후 9 04 06" src="https://user-images.githubusercontent.com/91768822/172648498-9b931453-f684-43e4-b362-0877e86e66c3.png">

좁은 길과 절벽이 제시되고, 캐릭터는 한쪽 벽에 붙어서 전진한다. 이때, 벽이 있는 쪽으로 사이드 스쿼트를 하면서 전진해야 한다. 진행 방향이 다르거나 도중 다른 동작을 취한다면 절벽으로 떨어진다.
### 점프 스쿼트

<img width="1197" alt="스크린샷 2022-06-08 오후 9 02 56" src="https://user-images.githubusercontent.com/91768822/172648913-c57a4eae-d193-4be3-83dc-02f34752a0b0.png">

사용자의 앞에 계단이 제시된다. 사용자는 계단을 점프 스쿼트 동작을 통해 계단을 오른다.

### 마무리 스쿼트

<img width="1204" alt="스크린샷 2022-06-08 오후 9 04 22" src="https://user-images.githubusercontent.com/91768822/172649364-924a683b-2059-4926-beb9-46d18056e745.png">

사용자가 운동량 게이지(도망칠 거리)를 모두 채워 캐릭 터가 마지막 단계까지 변화한 경우 구속 장치를 끊는 마지막 동작으로 일정 횟수만큼 제자리 스쿼트 동작을 하도록 한다. 정해진 횟수를 채운 후엔 캐릭터가 구속 장치를 끊고 게임이 클리어된다.
