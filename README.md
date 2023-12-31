# 3D Maze Game 심태용

1. 게임 기획
2. 개발 방향성

---
# 1. 게임 기획

3D 게임개발 강의를 들으면서 강의 내용을 토대로 개발이 가능한 게임을 고민하던 중 미로게임을 만들면 재밌을 것 같아서 기획하게 되었습니다.

실제로 미로찾기 게임을 해본 경험이 있었는데, 야외기도 하고, 공간의 제약으로 인해서 다양한 미로찾기 게임을 할 수 없는 점이 아쉽게 느껴졌습니다. 

그래서 3D로 제작하여 추후에 VR이나 PC 게임으로 실제와 같은 미로찾기를 할 수 있으면 시공간의 제약도 없고, 원하는 미로나, 캐릭터, 아이템 등 다양한 요소들을 추가할 수 있을 것 같다고 생각하게 되었습니다.

스크립트 작성이나, 유니티 엔진 사용이 익숙하지 않은 것 같아 복습 겸 개발진행을 구상하며 개인과제를 진행했습니다.

시작씬의 경우 유명한 영화인 메이즈러너 포스터를 가져와 만들어보았고, 시작버튼을 누르면 게임씬으로 전환되도록 만들었습니다.

인풋시스템을 활용하여 플레이어의 움직임을 구현했고, 카메라가 플레이어의 시야에 맞춰 이동할 수 있도록 해주었습니다.

Tools -> ProBuilder 를 활용하여 맵을 만들어주었습니다.

시작지점을 만들어주고, 미로에서 찾아야 되는 오브젝트를 만들어서 종료지점으로 만들었습니다.

종료지점에서는 뮤직존을 만들어 노래가 나오도록 해주었습니다.

---
# 2. 개발 방향성

아직 구현하지 못한 기능들이 많이 있어 추후에 기회가 된다면 개발하고자 합니다. 

1. 제한시간과 플레이어의 스태미나, 체력을 만들고자 합니다.  
2. 미로 맵 중간중간 미로탈출에 도움이 될 수 있는 아이템을 제작하려 합니다. (왔던 길을 표시할 수 있는 스프레이, 제한시간 추가 아이템, 나침반, 체력 및 스태미나 회복 아이템, 적과 전투할 수 있는 무기)
3. 미로 맵에 랜덤으로 생성되는 적NPC를 만들어서 전투를 해야되는 부분도 구현하고자 합니다.
4. 다양한 미로맵을 제작하여 단계별 미로를 만들고 싶습니다.
5. 효과음이나, 파티클 이펙트 등 게임의 퀄리티를 높일 수 있는 유니티 엔진 활용합니다.
6. 애니메이션을 추가하여 플레이어의 동작을 만듭니다.(Idle, Jump, Run, Attack)
