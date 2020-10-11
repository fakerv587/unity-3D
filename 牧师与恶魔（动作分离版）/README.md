## 牧师与恶魔（动作分离版）

与之前的版本不同的是，我们这次增加了一个Action类以及一个裁判类，用整个Action类来控制所有的动作（上下船以及船的移动），当游戏结束的时候，通过裁判类来告知场景控制器游戏结束。

#### Action类：

![Action1.png](https://i.loli.net/2020/10/11/9PMDcrdnIiamUNw.png)

![Action2.png](https://i.loli.net/2020/10/11/6Xd48JIvpBlrTze.png)

![Action3.png](https://i.loli.net/2020/10/11/FHfJmZjzO5dInWM.png)

然后我们需要在firstcontroller中创建action类并修改原本的动作部分（上下船和船的移动）

创建actionmanager：

![firstcontroller1.png](https://i.loli.net/2020/10/11/cEM2R1q4ZphXSF5.png)

上下船：

![firstcontroller2.png](https://i.loli.net/2020/10/11/d6WPhxznw1a98Uv.png)

船的移动：

![firstcontroller3.png](https://i.loli.net/2020/10/11/fJYsNk3uD5cZBQP.png)

#### 裁判类：

![judge.png](https://i.loli.net/2020/10/11/eIjavJ9HK1uBqQC.png)

创建裁判类对象：

![create_judge.png](https://i.loli.net/2020/10/11/CLeBp5RoESYK2Jw.png)

判断游戏是否结束：

![check.png](https://i.loli.net/2020/10/11/vdL91zUGDH3S4r2.png)

#### 实际效果演示：

初始界面：

![welcome.png](https://i.loli.net/2020/10/11/NLWzMxlDG9oJu5p.png)

上船：

![onboat.png](https://i.loli.net/2020/10/11/Yo8VdKSjmy129c4.png)

船的移动：

![moveboat.png](https://i.loli.net/2020/10/11/2uwV6mCsPbzo9XA.png)

胜利：

![win.png](https://i.loli.net/2020/10/11/uWzvREFyoJPYbQm.png)

失败：

![lose.png](https://i.loli.net/2020/10/11/uyYkf96nECgsAxK.png)