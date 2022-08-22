using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public delegate void eventHandler();

    public class clsDelegateEvent
    {
        public static void Mains(string[] args)
        {
            Cat cat = new Cat();//不可使用父类声明，因为由父类声明子类创建的对象只能调用继承自父类的属性和方法，
                                //而不能调用子类新增的属性和方法，即Cry()方法。
            Observer mouse1 = new Mouse("小白鼠", cat);
            Observer mouse2 = new Mouse("小黑鼠", cat);
            Observer mouse3 = new Mouse("小黄鼠", cat);
            Observer host = new Host("小明", cat);
            cat.Cry();

            Console.ReadKey();
        }

    }

    public abstract class Observer
    {
        public String name;
        public Observer(Subject subject)
        {
            subject.obsEvent += new eventHandler(Response);
        }

        public abstract void Response();
    }

    public class Mouse : Observer
    {
        public Mouse(String name, Subject subject) : base(subject)
        {
            this.name = name;
        }

        public override void Response()
        {
            Console.WriteLine("{0}开始逃跑了...", name);
        }
    }

    public class Host : Observer
    {
        public Host(String name, Subject subject) : base(subject)
        {
            this.name = name;
        }

        public override void Response()
        {
            Console.WriteLine("主人被惊醒了...");
        }
    }

    public abstract class Subject
    {
        public event eventHandler obsEvent;

        protected void Act()
        {
            if (obsEvent != null)
            {
                obsEvent();
            }
        }
    }

    public class Cat : Subject
    {
        public void Cry()
        {
            Console.WriteLine("猫叫了...");
            Act();
        }
    }

}
