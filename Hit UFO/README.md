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

![CGActionManager.png](https://i.loli.net/2020/10/24/IjZfnixcXdStKCp.png)

**CGFlyAction**

![CGFlyAction.png](https://i.loli.net/2020/10/24/aXkfmF1b28YSeRI.png)

**Disk**

![Disk.png](https://i.loli.net/2020/10/24/9ZMFs2Kau8eNRyd.png)

**DiskFactory**

![DiskFactory.png](https://i.loli.net/2020/10/24/slyQ5k7GFJzqUBg.png)

**FirstController**

![FirstController.png](https://i.loli.net/2020/10/24/HvyfwPKEc3TMimY.png)

**IScreenController**

![IScreenController.png](https://i.loli.net/2020/10/24/eZ32BXONxLREo1h.png)

**ISSActionCallback**

![ISSActionCallback.png](https://i.loli.net/2020/10/24/YVKSxOp4LJ7efR6.png)

**IUserAction**

![IUserAction.png](https://i.loli.net/2020/10/24/KfOHDZYGWopUVCc.png)

**Singleton**

![Singleton.png](https://i.loli.net/2020/10/24/KGmUY7a9lwJSizs.png)

**SSAction**

![SSAction.png](https://i.loli.net/2020/10/24/X64Z58ShLJqfjMd.png)

**SSActionManager**

![SSActionManager.png](https://i.loli.net/2020/10/24/xwr7qpQVBWIPba1.png)

**SSDirector**

![SSDirector.png](https://i.loli.net/2020/10/24/8pbSJXHksc1VoRY.png)

**UserGUI**

![UserGUI.png](https://i.loli.net/2020/10/24/rWbxXNBPf2yUK1T.png)