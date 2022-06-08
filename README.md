# homeTraining
유니티,키넥트,아두이노를 이용한 캡스톤디자인1 게임형 스마트 홈 트레이닝 프로젝트입니다.
## 프로그램 소개
### 게임 컨셉
게임 컨셉은 죄수(사용자)가 감옥에서 탈출하여 추격자로 부터 도망치는 배경이다. 운동은 밴드를 이용한 하체 운동 을 위주로 한다. 사용자는 하체에 운동 밴드를 착용하고, 키 넥트로 자신의 동작을 인식시켜 플레이어 캐릭터를 조작한 다. 사용자는 도망치면서 나오는 장애물들에 대해 적절한 하체 운동 동작으로 피하는 동작을 해야 한다. 클리어 기준을 달성한 후엔 구속장치를 끊어버리며 게임을 클리어 하게 된다.
컨텐츠는 몰입도를 위해 사용자와 캐릭터와 상황을 동일시 함을 목표로한다. 게임 컨텐츠는 죄수가 구속장치를 달고 도망치는 설정이다. 사용자는 운동밴드를 다리에 착용하여 캐릭터와 같이 구속장치를 단 것처럼 느끼게 하고, 키넥트로 캐릭터 모델의 움직임이 사용자를 트래킹 하여 같은 움직임을 취하게 함으로써 몰입도를 높인다.

게임 오버 기준이 되는 캐릭터를 추격하는 간수를 배치한 다. 간수의 속도로 사용자의 운동 템포를 조절하여 사용자 가 게임의 요소로서 자연스럽게 받아들이도록 한다. 추적은 Unity의 Nav Mesh Agent를 이용한다. 특정 강도의 운동을 충분히 진행하여 게임 캐릭터의 근육의 모양이 변화하면 밴 드 교체 시간을 주고, 더 높은 강도의 밴드를 이용하여 더 강한 운동 효과를 낼 수 있도록 한다. 사용자가 일정 시간 운동을 진행한 후엔 ‘장애물 점검 시간’이란 문구와 함께
30초를 휴식할 수 있도록 한다.
### 목표
아두이노와 Myoware Muscle Sensor를 활용해 게임 중 플 레이어의 부위별 근육 사용량을 측정하여 그만큼 캐릭터의 능력치와 외형에 반영한다. 사용자가 자신의 운동량을 가시 적으로 파악하고 계속해서 캐릭터를 발전시키기 위해 운동 하도록 유도한다. 아두이노와 Windows의 serial communication엔 통신 안정성을 위해 Wi-Fi, 게임 엔진으로는 키넥트와 아두이노 API가 제공된 Unity를 사용한다. 이러한 게임형 스마트 홈트레이닝 시스템을 통해 사용자가 더 적극적으로 운동에 참여 할 수 있도록 하는 것이 본 프로젝트의 목표이다.
## 프로그램 사용방법
