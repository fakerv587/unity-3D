## 作业要求：

智能巡逻兵

- 提交要求：
- 游戏设计要求：
    - 创建一个地图和若干巡逻兵(使用动画)；
    - 每个巡逻兵走一个3~5个边的凸多边型，位置数据是相对地址。即每次确定下一个目标位置，用自己当前位置为原点计算；
    - 巡逻兵碰撞到障碍物，则会自动选下一个点为目标；
    - 巡逻兵在设定范围内感知到玩家，会自动追击玩家；
    - 失去玩家目标后，继续巡逻；
    - 计分：玩家每次甩掉一个巡逻兵计一分，与巡逻兵碰撞游戏结束；
- 程序设计要求：
    - 必须使用订阅与发布模式传消息
        - subject：OnLostGoal
        - Publisher: ?
        - Subscriber: ?
    - 工厂模式生产巡逻兵
- 友善提示1：生成 3~5个边的凸多边型
    - 随机生成矩形
    - 在矩形每个边上随机找点，可得到 3 - 4 的凸多边型
    - 5 ?
- 友善提示2：参考以前博客，给出自己新玩法

## 作业内容

### 游戏玩法：

在一副地图中拥有若干个区域，每个区域内有两个史莱姆以及两个水晶，玩家需要操控主角（宇航员）避开史莱姆获取水晶。

### 预制介绍：

本游戏包含三个预制，史莱姆，宇航员以及地图

史莱姆是采用RPG Monster Duo PBR Polyart中的史莱姆为原型，然后添加刚体以及碰撞体，并修改其动作模式完成的。

![](./pic/prop.png)

![](./pic/prop1.png)

![](./pic/prop2.png)

宇航员则是采用Stylized Astronaut的宇航员为原型，添加类似于史莱姆的操作。

![](./pic/player.png)

![](./pic/player1.png)

![](./pic/player2.png)

地图则是利用LowpolyStreetPack以及Stylized Crystal中的预制进行制作。

![](./pic/plane.png)

![](./pic/plane1.png)

### 游戏代码

CCMoveToAction.cs

从一个位置运动到另一个位置的动作

![](./pic/ccmovetoaction.png)

CCTracertAction.cs

创建跟随对象的动作

![](./pic/cctracertaction.png)

SSAction.cs

动作基类

![](./pic/ssaction.png)

SSActionManager.cs

动作管理基类。

![](./pic/ssactionmanager.png)

SSDirector.cs

导演类

![](./pic/ssdirector.png)

Singleton.cs

创建单例

![](./pic/singleton.png)

Interface.cs

公共接口

![](./pic/interface.png)

GameEventManager.cs

游戏事件管理：在订阅和发布模式中的中继，让发布者和订阅者没有直接联系。

![](./pic/gameeventmanager.png)

FirstSceneController.cs

场景控制器（订阅者）

![](./pic/firstscenecontroller.png)

InterfaceGUI.cs

初始化文字以及获得键盘输入

![](./pic/interfacegui.png)

PropFactory.cs

工厂模式

![](./pic/propfactory.png)

Prop.cs

史莱姆

![](./pic/propcs.png)

### 游戏过程截图

开始游戏

![](./pic/start.png)

得分

![](./pic/scored.png)

死亡

![](./pic/die.png)