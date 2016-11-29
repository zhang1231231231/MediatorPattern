using System;

namespace MediatorPattern
{
    // 抽象牌友类
    public abstract class AbstractCardPattern
    {
        public int MoneyCount { get; set; }
        public AbstractCardPattern()
        {
            MoneyCount = 0;
        }

        public abstract void ChangenCount(int count, AbstractMediator mediator);
    }

    //抽象中介者类
    public abstract class AbstractMediator
    {
        protected AbstractCardPattern A;
        protected AbstractCardPattern B;

        public AbstractMediator(AbstractCardPattern a, AbstractCardPattern b)
        {
            A = a;
            B = b;
        }

        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }

    //具体中介者类
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(AbstractCardPattern a, AbstractCardPattern b) : base(a, b)
        {
        }

        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;

        }

        public override void BWin(int count)
        {
            A.MoneyCount -= count;
            B.MoneyCount += count;
        }
    }

    //牌友类A
    public class PatterA : AbstractCardPattern
    {

        //依赖抽象中介者对象
        public override void ChangenCount(int count, AbstractMediator mediator)
        {
            mediator.AWin(count);
        }
    }

    //牌友类B
    public class PatterB : AbstractCardPattern
    {

        //依赖抽象中介者对象
        public override void ChangenCount(int count, AbstractMediator mediator)
        {
            mediator.BWin(count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPattern A = new PatterA();
            AbstractCardPattern B = new PatterB();

            //初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;
            AbstractMediator mediator = new MediatorPater(A, B);

            //A赢了
            A.ChangenCount(5, mediator);
            Console.WriteLine("A 当前的钱:{0}", A.MoneyCount);
            Console.WriteLine("B 当前的钱:{0}", B.MoneyCount);

            //B赢了
            B.ChangenCount(10, mediator);
            Console.WriteLine("A 当前的钱:{0}", A.MoneyCount);
            Console.WriteLine("B 当前的钱:{0}", B.MoneyCount);
			Console.ReadLine();
        }
    }
}
