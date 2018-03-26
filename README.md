# 3d-1 离散仿真引擎基础 作业与练习
1.简答题
-
### 解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。

 对象一般是一些资源的集合体，是资源整合的具体表现，在游戏中一般为玩家，敌人，环境等，而资源可组成游戏中所有的对象，一般包括声音，脚本，材质等，资源可以被多个对象使用，资源作为模板，可实例化成游戏中具体的对象。
 
 ### 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
 
 资源和对象组织都采用了树状结构，对象和上级对象是继承关系，上级对象是下级对象的parent，下级对象是上级对象的child，资源可以建立各个子文件夹来分别存放。
 如下所示
 
 ![资源](http://m.qpic.cn/psb?/V130IzoX3J4uRT/mP.ieMH1nlYwVqxiS9eUkkwbqKGCvh1gRT48.zxPWz4!/b/dEIBAAAAAAAA&bo=gACIAIAAiAADCSw!&rf=viewer_4 "资源" )
 ![对象](http://m.qpic.cn/psb?/V130IzoX3J4uRT/t2E0QwwcIWrSyi5o8OQkpQ0nc*kM3ANQV*xBVECmBYo!/b/dEIBAAAAAAAA&bo=5wCZAOcAmQADGTw!&rf=viewer_4 "对象")
 
 ### 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private void Awake()
    {
        Debug.Log("Init Awake");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Init Start");
	  }
	
	  // Update is called once per frame
	  void Update () {
         Debug.Log("Init Update");
  	}

    private void FixedUpdate()
    {
        Debug.Log("Init FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log("Init LateUpdate");
    }

    private void OnGUI()
    {
        Debug.Log("Init OnGUI");
    }

    private void OnDisable()
    {
        Debug.Log("Init OnDisable");
    }

    private void OnEnable()
    {
        Debug.Log("Init OnEnable");
    }
}
```

### 查找脚本手册，了解 GameObject，Transform，Component 对象
1.GameObject 游戏物体 是Unity场景里面所有实体的基类.

Component 组件 一切附加到游戏物体的基类。

Transform 变换 物体的位置、旋转和缩放。场景中的每一个物体都有一个Transform。用于储存并操控物体的位置、旋转和缩放。每一个Transform可以有一个父级，允许你分层次应用位置、旋转和缩放。可以在Hierarchy面板查看层次关系。他们也支持计数器（enumerator），因此你可以使用循环遍历子物体。

2.table对象的属性：activeInHierarchy（表示GameObject是否在场景中处于active状态）、activeSelf（GameObject的本地活动状态）、isStatic（仅编辑器API，指定游戏对象是否为静态）、layer（游戏对象所在的图层。图层的范围为[0 … 31]）、scene（游戏对象所属的场景）、tag（游戏对象的标签）、transform（附加到这个GameObject的转换）

table的Transform的属性有：Position、Rotation、Scale，从文档中可以了解更多关于Transform的属性

table的部件有：Mesh Filter、Box Collider、Mesh Renderer

3.![umlet](http://m.qpic.cn/psb?/V130IzoX3J4uRT/QlzxDSNGDkUe98UvH9w9264b*lREI3Hz.gG6MVOo8MM!/b/dFYBAAAAAAAA&bo=fAHQAHwB0AADCSw!&rf=viewer_4 "umlet")

### 整理相关学习资料，编写简单代码验证以下技术的实现：

1.查找对象：

```C#
//通过对象名称
public static GameObject Find(string name)
//通过标签获取单个游戏对象
public static GameObject FindWithTag(string tag)
//通过标签获取多个游戏对象
public static GameObject[] FindGameObjectsWithTag(string tag)
```

2.添加子对象：

```C#
public static GameObject CreatePrimitive(PrimitiveType type)
```

3.遍历对象树：

```C#
foreach (Transform child in transform) {  
    Debug.Log(child.gameObject.name);  
}  
```

4.清除所有子对象

```C#
foreach (Transform child in transform) {  
    Destroy(child.gameObject);  
} 
```

### 资源预设（Prefabs）与 对象克隆 (clone)

#### 预设的好处：

通过添加组件并将它们的属性设置为适当的值，在场景中构建一个GameObject是很方便的。然而，当你有像NPC，道具或场景多次重复使用的景物时，这会显得十分繁琐。而预设（Prefab）的好处体现在，通过预设可以实例化出具有相同属性的对象， 并且当你需要编辑一个对象的时候无需对其他副本进行相同的编辑，其他的实例会自动产生相应的改变。

#### 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？

对象克隆的实例之间不会相互影响，即克隆对象A不会因克隆对象B的改变而改变。而对预设进行修改会作用到该预设所有的实例上。

#### 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

    public GameObject table;
    void Awake()
    {
        //Debug.Log("Init Awake");
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Init Start");

        //将table预设实例化为游戏对象
        GameObject anotherTable = (GameObject)Instantiate(table.gameObject);
        anotherTable.name = "newTable";
        anotherTable.transform.position = new Vector3(0, Random.Range(5, 7), 0);
        anotherTable.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Init Update");
    }

}
```

### 尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法

组合模式允许用户将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合。组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。

```C#
//父类对象（table）方法：
void Start()
{
    Debug.Log("Table Start");
    this.BroadcastMessage("testBroad", "hello sons!");
}
//子类对象（chair）方法：
public void testBroad(string str)
{
    print("chair received: " + str);
}
```

![out](http://m.qpic.cn/psb?/V130IzoX3J4uRT/Q0sXp6pdN3hTM0pqhGRykIsYRPmJlIRYoo2e*IElWb4!/b/dJEAAAAAAAAA&bo=JAGTACQBkwADCSw!&rf=viewer_4 "out")

2.井字棋
-

