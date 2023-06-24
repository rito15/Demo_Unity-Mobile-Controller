# 유니티 모바일 컨트롤러 간단 데모
<br/>

## 사용 애셋
- <https://assetstore.unity.com/packages/tools/input-management/lean-touch-30111>
- <https://assetstore.unity.com/packages/tools/gui/lean-gui-72138>
<br/>

## 문서
- <https://carloswilkes.com/Documentation/LeanTouch>
<br/>

## 유니티 에디터 버전
- 2021.3.15f
<br/>

## 미리보기
![2023_0624_MobileController](https://github.com/rito15/Demo_Unity-Mobile-Controller/assets/42164422/ade8e36d-8f03-462e-a62a-765a5f6c648b)

<br/>

## 기능
- 모바일 조작
  - 캐릭터 이동
  - 캐릭터 카메라 회전
  - 캐릭터 카메라 줌 인/아웃

- 입력
  - 모바일 조이스틱 UI
  - 화면 터치 드래그
  - 화면 멀티 터치 드래그 줌 인/아웃
<br/>

## 참고사항
- WebGL 모바일 브라우저 환경에서 터치 이슈 발생 시, New Input System 사용 필요
- New Input System 적용 방법
  - Package Manager - Unity Registry - Input System 설치
  - Project Settings - Player - Other Settings - Configuration - Active Input Handling - `Input System Package (new)`로 변경
