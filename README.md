# MultiFPSTeach

## 项目简介

MultiFPSTeach 是一个基于 Unreal Engine 开发的第一人称射击 (FPS) 教学示例项目，包含基本的角色控制、武器系统、射击机制以及多人联机同步功能。该项目适用于想要学习 Unreal Engine FPS 开发的开发者。

## 主要功能特性

- **FPS 角色控制**: 实现角色的行走、奔跑、跳跃、瞄准等动作。
- **武器系统**: 支持多种武器（如 AK47、M4A1、MP7、DesertEagle、狙击枪等）。
- **射击系统**: 实现子弹射击、后坐力、命中检测、伤害计算等功能。
- **多人联机同步**: 通过 Unreal Engine 的网络复制实现多人游戏功能。
- **界面交互**: 包括血量、弹药 UI 以及准星 UI 交互。

## 运行环境

- **引擎版本**: Unreal Engine 4.27 / 5.x
- **开发语言**: C++
- **支持平台**: Windows

## 服务器测试界面

![服务器测试界面](Images/start_screen.png)

## 游戏内截图

![游戏内截图](Images/gameplay.png)

## 代码结构

```
MultiFPSTeach/
├── Source/
│   ├── MultiFPSTeach/           # 游戏模块
│   │   ├── MultiFPSTeach.cpp     # 游戏模块主入口
│   │   ├── MultiFPSTeach.h       # 游戏模块头文件
│   ├── Characters/               # 角色相关代码
│   │   ├── FPSTeachBaseCharacter.cpp  # FPS 角色类实现
│   │   ├── FPSTeachBaseCharacter.h    # FPS 角色类头文件
│   ├── Weapons/                  # 武器系统
│   │   ├── WeaponBaseClient.cpp   # 客户端武器逻辑
│   │   ├── WeaponBaseClient.h     # 客户端武器头文件
│   │   ├── WeaponBaseServer.cpp   # 服务器武器逻辑
│   │   ├── WeaponBaseServer.h     # 服务器武器头文件
│   ├── Controllers/               # 玩家控制器
│   │   ├── MultiFPSPlayerController.cpp # FPS 玩家控制器
│   │   ├── MultiFPSPlayerController.h   # FPS 玩家控制器头文件
│   ├── GameModes/                 # 游戏模式
│   │   ├── MultiFPSTeachGameModeBase.cpp  # 游戏模式逻辑
│   │   ├── MultiFPSTeachGameModeBase.h    # 游戏模式头文件
│   ├── Libraries/                 # 工具库
│   │   ├── KismetMultiFPSLibrary.cpp # 自定义 Kismet 函数库
│   │   ├── KismetMultiFPSLibrary.h   # 自定义 Kismet 头文件
```

## 主要类及功能概述

### 1. `AFPSTeachBaseCharacter` (FPS 角色)

- `BeginPlay()`: 初始化角色状态，如生命值、控制器绑定。
- `MoveForward(float AxisValue)`: 角色前进和后退。
- `MoveRight(float AxisValue)`: 角色左右移动。
- `InputFirePressed()`: 处理武器射击输入。
- `InputReload()`: 处理换弹操作。
- `ServerFireRifleWeapon_Implementation()`: 服务器端步枪射击逻辑。
- `ServerReloadPrimary_Implementation()`: 服务器端换弹逻辑。

### 2. `AWeaponBaseClient` (客户端武器类)

- `DisplayWeaponEffect()`: 播放武器射击特效。
- `PlayShootAnimation()`: 触发枪械射击动画。
- `PlayReloadAnimation()`: 触发枪械换弹动画。

### 3. `AWeaponBaseServer` (服务器武器类)

- `OnOtherBeginOverlap()`: 处理武器拾取事件。
- `EquipWeapon()`: 设置武器拾取后的物理状态。
- `MultiShootingEffect_Implementation()`: 服务器端触发射击特效。

### 4. `AMultiFPSPlayerController` (玩家控制器)

- `PlayerCameraShake()`: 触发玩家摄像机震动。
- `CreatePlayerUI()`: 创建 HUD 界面。
- `UpdateAmmoUI()`: 更新弹药 UI。
- `UpdateHealthUI()`: 更新生命值 UI。

### 5. `UKismetMultiFPSLibrary` (蓝图工具库)

- `SortValues(TArray<FDeathMatchPlayerData>& Values)`: 排序玩家分数。
- `QuickSort(TArray<FDeathMatchPlayerData>& Values, int start, int end)`: 快速排序算法实现。
