### 游戏对象运动的本质

实际上游戏对象的运动是游戏对象随着游戏时间空间位置、旋转角度以及大小的变化，通过矩阵变换来实现游戏对象空间属性的改变。

### 抛物线运动

首先我想到的是可以直接根据公式调整物体的位置：

![way1.png](https://i.loli.net/2020/10/03/RWYp6DOFCATbJme.png)

其次我查询资料发现物体拥有重力属性，于是又有一种方法：

![way2.png](https://i.loli.net/2020/10/03/VhJSYM6CRjFx9Ez.png)

最后，我采用不同的方法去运用原本的公式，这样最后一种方法也有了

![way3.png](https://i.loli.net/2020/10/03/v4tHWKJhxUIzQYn.png)

### 太阳系模拟

我们首先创建太阳系以及八大行星

![first.png](https://i.loli.net/2020/10/03/1CpsEUKHhAGNo6v.png)

然后稍微改变一下球的大小和位置

![second.png](https://i.loli.net/2020/10/03/2TNpPKrMQmyo764.png)

然后将太阳系贴图贴上

![third.png](https://i.loli.net/2020/10/03/RHlI7TWbXGE1njw.png)

然后根据之前写过的代码，进行类似的操作，代码如下

![code.png](https://i.loli.net/2020/10/03/mM7VcRNQ4DCqyux.png)

最后效果

![finish.png](https://i.loli.net/2020/10/03/kBvM9o25OzcuRqf.png)

### 牧师与恶魔

#### 游戏中的事物

牧师、恶魔、船、河流、河岸

#### 规则表

| 状态                                     | 操作             | 结果             |
| ---------------------------------------- | ---------------- | ---------------- |
| 牧师或者恶魔在河岸上，且船在该河岸有空位 | 点击牧师或者恶魔 | 牧师或者恶魔上船 |
| 牧师或者恶魔在船上                       | 点击牧师或者恶魔 | 牧师或者恶魔上岸 |
| 某一河岸上恶魔数量大于牧师               | （None）         | 玩家失败         |
| 牧师和恶魔都渡过河                       | （None）         | 玩家成功         |

#### 对象

| 对象       | 代表意思 |
| ---------- | -------- |
| 蓝色球体   | 牧师     |
| 红色长方体 | 恶魔     |
| 蓝色长方体 | 河       |
| 灰色长方体 | 河岸     |
| 棕色长方体 | 船       |



#### 代码

Director：导演类采用了单实例的方法，拥有全局属性，这样就可以在

![director.png](https://i.loli.net/2020/10/03/etcM95gm8kZXalh.png)

SceneController：场记控制器

![SceneController.png](https://i.loli.net/2020/10/03/TAlZo4ORD75v1ct.png)



FirstController：场景控制器，为SceneController的实例，对于场景进行加载，为此我们需要将游戏对象做成预设，这样就可以直接创建。

![firstcontroller1.png](https://i.loli.net/2020/10/03/L3PYvFdzZKCgcaV.png)

![firstcontroller2.png](https://i.loli.net/2020/10/03/SXYI3jPx9qy7sab.png)

![firstcontroller3.png](https://i.loli.net/2020/10/03/n2XQLCt7HN8g9lO.png)

![firstcontroller4.png](https://i.loli.net/2020/10/03/AQrZmsINzHDUEJb.png)

![firstcontroller5.png](https://i.loli.net/2020/10/03/E4mBFGow1ML6d7X.png)

![firstcontroller6.png](https://i.loli.net/2020/10/03/qtpRnoKQdOeLW51.png)

![firstcontroller7.png](https://i.loli.net/2020/10/03/DeOFjn3mxyGtMqL.png)

![firstcontroller8.png](https://i.loli.net/2020/10/03/AibFUEfT8q4mP1k.png)

Boat：

![boat.png](https://i.loli.net/2020/10/03/Cmj9LcPnzval4AR.png)

IUserAction：

![03KRte.png](https://s1.ax1x.com/2020/10/03/03KRte.png)

Move：

![03K2kD.png](https://s1.ax1x.com/2020/10/03/03K2kD.png)

Role：

![03KcTO.png](https://s1.ax1x.com/2020/10/03/03KcTO.png)![03Kym6.png](https://s1.ax1x.com/2020/10/03/03Kym6.png)

UserGUI：

![03K60K.png](https://s1.ax1x.com/2020/10/03/03K60K.png)



#### 游戏过程截图：

初始界面:

![03Kjpj.png](https://s1.ax1x.com/2020/10/03/03Kjpj.png)
上船:

![03KLtg.png](https://s1.ax1x.com/2020/10/03/03KLtg.png)
船的移动:

![03Kv1s.png](https://s1.ax1x.com/2020/10/03/03Kv1s.png)
win:

![03KOhQ.png](https://s1.ax1x.com/2020/10/03/03KOhQ.png)

Lose:

![03Kxcn.png](https://s1.ax1x.com/2020/10/03/03Kxcn.png)