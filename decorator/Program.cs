using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace decorator
{

    class Track
    {
        public virtual string Name { get; set; }
        public virtual void Play() { }
        

    }

    class BaseTrackDecorator : Track
    {
        protected Track _source; 

       

        public BaseTrackDecorator (Track source)
        {
            _source = source;    
            


        }

        public override string Name { get { return _source.Name; } set { _source.Name = value; } }

        public override void Play() { _source.Play();  }
    }

    class DramDecorator : BaseTrackDecorator
    {
        public DramDecorator(Track source) : base(source) { }

        public override void Play()
        {
            _source.Play();
            Console.WriteLine(" Бум туц туц тсс бам бим бом тутц");
        }

    }

    class VoiceDecorator : BaseTrackDecorator
    {
        public VoiceDecorator(Track source) : base(source) { }

        public override void Play()
        {
            _source.Play();
            Console.WriteLine(" Оууу оу ууо парам пам пам");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var track = new Track();
            track = new DramDecorator(track);


            var count = 10;
            while (count > 0)
            {
                count--;
                track.Play();
            }

            Console.WriteLine();

            track = new Track();
            track = new VoiceDecorator(track);
            count = 10;
            while (count > 0)
            {
                count--;
                track.Play();
            }

            Console.WriteLine();
            track = new Track();
            track = new VoiceDecorator(track);
            track = new DramDecorator(track);
            count = 10;
            while (count > 0)
            {
                Thread.Sleep(1000);
                count--;
                track.Play();
            }


            Console.WriteLine("Hello world");
            Console.ReadKey();

        }
    }
}
