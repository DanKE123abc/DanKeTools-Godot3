# Godot中使用单例的方法

在Godot中，如果想要继承Node并使用单例，需要到 ***项目/项目设置/自动加载*** 中添加脚本。

调用单例（例如使用SceneManager）

```c#
var sceneManager = GetNode<SceneManager>("/root/SceneManager");//初始化
sceneManager.LoadSceneAsyn("res://Scenes/Change.tscn",Test);//调用方法
```



在DanKeTools中有些脚本无法继承Singleton，需要您自行将它们添加到自动加载以保证它们是单例运行。
