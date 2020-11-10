## 作业内容

1、改进飞碟（Hit UFO）游戏：

- 游戏内容要求：
    1. 按 *adapter模式* 设计图修改飞碟游戏
    2. 使它同时支持物理运动与运动学（变换）运动

2、打靶游戏（**可选作业**）：

- 游戏内容要求：
    1. 靶对象为 5 环，按环计分；
    2. 箭对象，射中后要插在靶上
        - **增强要求**：射中后，箭对象产生颤抖效果，到下一次射击 或 1秒以后
    3. 游戏仅一轮，无限 trials；
        - **增强要求**：添加一个风向和强度标志，提高难度



## 具体实例

1.改进飞碟

我们需要按照adapter模式设计图修改飞碟游戏

那我们需要先了解什么是adapter设计模式

Adapter适配器模式是将两个不兼容的类组合在一起使用。适配器起到一种转换和包装的作用。

Adapter设计模式主要目的组合两个不相干类，常用有两种方法：第一种解决方案是修改各自类的接口。但是如果没有源码，或者不愿意为了一个应用而修改各自的接口，则需要使用Adapter适配器，在两种接口之间创建一个混合接口。

Adapter适配器设计模式中有3个重要角色：被适配者Adaptee，适配器Adapter和目标对象Target。其中两个现存的想要组合到一起的类分别是被适配者Adaptee和目标对象Target角色，我们需要创建一个适配器Adapter将其组合在一起。

实现Adapter适配器设计模式有两种方式：**组合(compositon, has-a关系)和继承(inheritance,is-a关系)。**

懂了之后，我们将原本的代码进行一定程度上的修改。

为了能够进行物理学上的飞行，我们在原有的基础上增加PhysisFlyAction.cs以及PhysisActionManager.cs两个文件，用来描述飞碟在物理学下的运动。

PhysisFlyAction:

![PhysisFlyAction.png](https://i.loli.net/2020/11/10/SPj5YfQUhCV7NnW.png)

PhysisActionManager:

![PhysisActionManager.png](https://i.loli.net/2020/11/10/CXHubzvoFPiES7r.png)

然后为了满足物理学的运动，我们需要对我们飞碟的预制加上刚体组件。

![rigidbody.png](https://i.loli.net/2020/11/10/82QjnfgVYh3uUaw.png)

之后为了满足Adapter设计模式的需求，我们创建IActionManager.cs文件，用于进行不同模式下飞碟的飞行。

IActionManager:

![IActionManager.png](https://i.loli.net/2020/11/10/dg5DEQwckYCvx9a.png)

之后由于之前将所有文件都写在FirstController中过于冗余，所以我们将其拆分成FirstController，RoundController以及Score三个文件，这样就可以使得每个文件有管理着自己不同的区域，方便后序程序的编写。

FirstController:

![FirstController.png](https://i.loli.net/2020/11/10/8RthGq2IJEPjTim.png)

Score:

![Score.png](https://i.loli.net/2020/11/10/R32Gb8K1rHekzSp.png)

RoundController:

![RoundController.png](https://i.loli.net/2020/11/10/Bd9aoDA6MgSKWnf.png)