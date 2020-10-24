### 任务要求：

编写一个简单的鼠标打飞碟（Hit UFO）游戏

- 游戏内容要求：
    1. 游戏有 n 个 round，每个 round 都包括10 次 trial；
    2. 每个 trial 的飞碟的色彩、大小、发射位置、速度、角度、同时出现的个数都可能不同。它们由该 round 的 ruler 控制；
    3. 每个 trial 的飞碟有随机性，总体难度随 round 上升；
    4. 鼠标点中得分，得分规则按色彩、大小、速度不同计算，规则可自由设定。
- 游戏的要求：
    - 使用带缓存的工厂模式管理不同飞碟的生产与回收，该工厂必须是场景单实例的！具体实现见参考资源 Singleton 模板类
    - 近可能使用前面 MVC 结构实现人机交互与游戏模型分离

如果你的使用工厂有疑问，参考：[弹药和敌人：减少，重用和再利用](http://www.manew.com/thread-48481-1-1.html)；参考：[Unity对象池（Object Pooling）理解与简单应用](https://gameinstitute.qq.com/community/detail/121124) 代码质量较低，比较凌乱

### 游戏设计

**CGActionManager**

飞行动作管理类

![CGActionManager.png](https://i.loli.net/2020/10/24/IjZfnixcXdStKCp.png)

**CGFlyAction**

飞行动作，当飞碟飞到屏幕最下端时，进行回调

![CGFlyAction.png](https://i.loli.net/2020/10/24/aXkfmF1b28YSeRI.png)

**Disk**

每个飞碟拥有三个属性，分数，速度和方向

![Disk.png](https://i.loli.net/2020/10/24/9ZMFs2Kau8eNRyd.png)

**DiskFactory**

飞碟工厂；每一次从空闲队列中查找可用飞碟，否则建立新飞碟；根据轮次产生不同分数的飞碟

![DiskFactory.png](https://i.loli.net/2020/10/24/slyQ5k7GFJzqUBg.png)

**FirstController**

场景控制器

首先发送飞碟，然后hit则移除飞碟，将分数加上飞碟对应的分数；假如点击重新开始按钮则重新开始游戏；每次更新加载新的飞碟

![FirstController.png](https://i.loli.net/2020/10/24/HvyfwPKEc3TMimY.png)

**IScreenController**

场景控制类

![IScreenController.png](https://i.loli.net/2020/10/24/eZ32BXONxLREo1h.png)

**ISSActionCallback**

回调函数

![ISSActionCallback.png](https://i.loli.net/2020/10/24/YVKSxOp4LJ7efR6.png)

**IUserAction**

用户动作接口

![IUserAction.png](https://i.loli.net/2020/10/24/KfOHDZYGWopUVCc.png)

**Singleton**

场景单实例。

![Singleton.png](https://i.loli.net/2020/10/24/KGmUY7a9lwJSizs.png)

**SSAction**

动作基类

![SSAction.png](https://i.loli.net/2020/10/24/X64Z58ShLJqfjMd.png)

**SSActionManager**

动作管理类

![SSActionManager.png](https://i.loli.net/2020/10/24/xwr7qpQVBWIPba1.png)

**SSDirector**

导演类

![SSDirector.png](https://i.loli.net/2020/10/24/8pbSJXHksc1VoRY.png)

**UserGUI**

用户界面

![UserGUI.png](https://i.loli.net/2020/10/24/rWbxXNBPf2yUK1T.png)

#### 添加背景：

这次我使用了AllSkyFree以及StarNestSkybox中的天空背景对于整个游戏进行设置



#### 游戏展示：

开始游戏：

![hit.png](https://i.loli.net/2020/10/24/jrSCvAlePQGZtVg.png)

击中飞碟分数增加：

![get point.png](https://i.loli.net/2020/10/24/8ekbIRwluAOovFT.png)

游戏结束：

![game over.png](https://i.loli.net/2020/10/24/nkOyIsTeHoEhDZU.png)

