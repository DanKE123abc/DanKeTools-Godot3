# DanKeTools_Godot

![Language](https://img.shields.io/badge/Language-Csharp-C#) ![LICENSE](https://img.shields.io/badge/LICENSE-Apache--2.0-yellow) ![Author](https://img.shields.io/badge/Author-DanKe-blue) ![Godot](https://img.shields.io/badge/Godot-v3.5.1.mono-red)

DanKeTools是基于Unity的一个基础开发框架，用于提升开发效率，这里是[DanKeTools仓库](https://github.com/DanKE123abc/DanKeTools/)。

DanKeTools_Godot是在Godot Mono版本上可以使用的开发框架，包含了一些项目中的常用组件。

#### [文档](https://github.com/DanKE123abc/DanKeTools_Godot/blob/main/DanKeTools/README.md)

### 环境

Godot开发版本： v3.5.1.stable.mono.official.6fed1ffa3

Build Tool：dotnet CLI

### 模块简介

Base —— 单例模式

Event —— 事件中心模块

IO —— 输入管理和文件管理模块

Mono —— Mono管理器模块

Net —— http模块

Scene —— 场景加载模块

Voice —— 音效管理器模块

Utils —— 常用工具类

FSM —— 有限状态机

Thread —— 子线程管理器
### 更新日志

**v1.2.0**

之后的版本号与Unity相对应

相较于Unity版，Godot版没有缓存池(/Pool)和UI(/UI)部分及一些其他工具

Godot中没有预设体，只能通过将物体设置为场景加载到树中，因此无法实现类似Unity的缓存池，且Godot中没有GC，似乎无需使用缓存池。

Godot中，本身自带的UI系统和信号管理已经很完善，无需像UGUI一样额外扩展。

其他一些工具是基于Unity设计的，无需移植到Unity

本次更新内容：

修复了一些Bug

增加了部分提示

新增了子线程管理器

**v0.9.3**

对应Unity版v1.1.3

支持rsa加解密

移植了VoiceManager

修复了一些Bug

**v0.9.2**

对应Unity版v1.1.2

**v0.9.1**

对应Unity版v1.1.0

http模块新增下载文件功能

FSM有限状态机

**v0.9.0**

对应Unity版v1.0.0

部分功能未完成
