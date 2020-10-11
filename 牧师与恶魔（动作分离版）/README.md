# homework4

## 自己的场景构建

首先我们通过asset store去下载相应的asset

![assert_store.png](https://i.loli.net/2020/10/11/2v8CLzl5AdIwDZX.png)

我下载了3个素材

Fantasy Skybox FREE:

![1.png](https://i.loli.net/2020/10/11/j8rVlpuLMhcR45W.png)

Terrain Tools Sample Asset Pack:

![2.png](https://i.loli.net/2020/10/11/eas2C7V8Y1Qu4xN.png)

Grass Flowers Pack Free:

![3.png](https://i.loli.net/2020/10/11/ogZS6UNOlRY4mL9.png)

首先在相机中的天空使用天空贴图，

然后在场景中创建地形，并且用笔刷和图层构建自己的地形

最后创建tree，并且创建树枝以及树叶

最终场景：

![sence.png](https://i.loli.net/2020/10/11/Q1Pd3iSt96qwV4k.png)

### 总结：

我们可以在官方文档中发现定义：

```
GameObjects are the fundamental objects in Unity that represent characters, props and scenery. They do not accomplish much in themselves but they act as containers for Components, which implement the real functionality.
```

将其翻译成中文：

```
游戏对象是统一的基本对象，代表人物、道具和风景。它们本身并不能完成很多工作，但它们充当组件的容器，这些组件实现了真正的功能。
```

所以我们可以了解到，游戏对象仅为一个容器，需要我们为它们添加各种不同的组件来构建它们，然后将各个游戏对象进行组合，从而达到我们想要的完成的目的。

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