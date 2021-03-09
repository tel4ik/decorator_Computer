using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Computer
{
    class Computer
    {
        public virtual string Name { get; set; }
        public virtual void complecte() { }
    }

    class BaseTrackDecorator : Computer
    {
        protected Computer _source;



        public BaseTrackDecorator(Computer source)
        {
            _source = source;
        }

        public override string Name { get { return _source.Name; } set { _source.Name = value; } }
        public override void complecte() { _source.complecte(); }
    }

    class CPUDecorator : BaseTrackDecorator
    {
        public CPUDecorator(Computer source) : base(source) { }

        public override void complecte()
        {
            _source.complecte();
            Console.WriteLine(" Частота процессора 2.3 Ггц");
        }

    }

    class GPUDecorator : BaseTrackDecorator
    {
        public GPUDecorator(Computer source) : base(source) { }

        public override void complecte()
        {
            _source.complecte();
            Console.WriteLine(" Частота видеокарты 2.3 Ггц");
        }

    }

    class RAMDecorator : BaseTrackDecorator
    {
        public RAMDecorator(Computer source) : base(source) { }

        public override void complecte()
        {
            _source.complecte();
            Console.WriteLine(" Частота ОП 1.666 Ггц");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Computer();
            comp = new CPUDecorator(comp);

            comp.complecte();
            Console.WriteLine();

            Thread.Sleep(1000);
            comp = new Computer();
            comp = new GPUDecorator(comp);
            comp.complecte();
            Console.WriteLine();

            Thread.Sleep(1000);
            comp = new Computer();
            comp = new RAMDecorator(comp);
            comp.complecte();

            Thread.Sleep(1000);
            Console.WriteLine();
            comp = new Computer();
            comp = new RAMDecorator(comp);
            comp = new GPUDecorator(comp);
            comp = new CPUDecorator(comp);
            comp.complecte();

            Console.ReadKey();

        }
    }
}
