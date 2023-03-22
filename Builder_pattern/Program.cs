using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_pattern
{
    internal class Program
    {
        public interface IBuilder
        {
            void BuildCorps();
            void BuildEngine();
            void BuildWheel();
            void BuildGearbox();

        }
        public class CreateDaewooLanos : IBuilder
        {
            private DaewooLanos daewooLanos = new DaewooLanos();

            public CreateDaewooLanos()
            {
               Reset();
            }

            public void BuildCorps()
            {
                daewooLanos.Add("Седан");
            }

            public void BuildEngine()
            {
                daewooLanos.Add("98");
            }

            public void BuildGearbox()
            {
                daewooLanos.Add("13");
            }

            public void BuildWheel()
            {
                daewooLanos.Add("5 Manual");
            }

            public void Reset()
            {
               daewooLanos = new DaewooLanos();
            }
            public DaewooLanos GetProduct()
            {
                DaewooLanos result = daewooLanos;

                Reset();

                return result;
            }
        }
        public class DaewooLanos
        {
            private List<object> _parts = new List<object>();

            public void Add(string part)
            {
                this._parts.Add(part);
            }

            public string ListParts()
            {
                string str = string.Empty;

                for (int i = 0; i < this._parts.Count; i++)
                {
                    str += this._parts[i] + ", ";
                }

                str = str.Remove(str.Length - 2); // removing last ",c"

                return "Product parts: " + str + "\n";
            }
        }
        public class CreateFordProde : IBuilder
        {
            private FordProde daewooLanos = new FordProde();

            public CreateFordProde()
            {
                Reset();
            }

            public void BuildCorps()
            {
                daewooLanos.Add("Купе");
            }

            public void BuildEngine()
            {
                daewooLanos.Add("160");
            }

            public void BuildGearbox()
            {
                daewooLanos.Add("14");
            }

            public void BuildWheel()
            {
                daewooLanos.Add("4 Auto");
            }

            public void Reset()
            {
                daewooLanos = new FordProde();
            }

            public FordProde GetProduct()
            {
                FordProde result = daewooLanos;

                Reset();

                return result;
            }
        }
        public class FordProde
        {
            private List<object> _parts = new List<object>();

            public void Add(string part)
            {
               _parts.Add(part);
            }

            public string ListParts()
            {
                string str = string.Empty;

                for (int i = 0; i < _parts.Count; i++)
                {
                    str += _parts[i] + ", ";
                }

                str = str.Remove(str.Length - 2); // removing last ",c"

                return "Product parts: " + str + "\n";
            }
        }
        public class CreateUAZPatriot : IBuilder
        {
            private UAZPatriot daewooLanos = new UAZPatriot();

            public CreateUAZPatriot() 
            {
                Reset();
            }

            public void BuildCorps()
            {
                daewooLanos.Add("Универсал");
            }

            public void BuildEngine()
            {
                daewooLanos.Add("120");
            }

            public void BuildGearbox()
            {
                daewooLanos.Add("16");
            }

            public void BuildWheel()
            {
                daewooLanos.Add("4 Manual");
            }

            public void Reset()
            {
                daewooLanos = new UAZPatriot();
            }

            public UAZPatriot GetProduct()
            {
                UAZPatriot result = daewooLanos;

                Reset();

                return result;
            }
        }
        public class UAZPatriot
        {
            private List<object> _parts = new List<object>();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public string ListParts()
            {
                string str = string.Empty;

                for (int i = 0; i < _parts.Count; i++)
                {
                    str += _parts[i] + ", ";
                }

                str = str.Remove(str.Length - 2); 

                return "Product parts: " + str + "\n";
            }
        }

        public class Shop
        {
            private IBuilder builder;

            public IBuilder Builder
            {
                set { builder = value; }
            }

            public void buildFullFeaturedProduct()
            {
                builder.BuildWheel();
                builder.BuildEngine();
                builder.BuildCorps();
                builder.BuildGearbox();
            }
        }

        static void Main(string[] args)
        {
            var director = new Shop();
            var builder = new CreateDaewooLanos();
            director.Builder = builder;
            director.buildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            var director1 = new Shop();
            var builder1 = new CreateFordProde();
            director1.Builder = builder1;
            director1.buildFullFeaturedProduct();
            Console.WriteLine(builder1.GetProduct().ListParts());

            var director2 = new Shop();
            var builder2 = new CreateUAZPatriot();
            director2.Builder = builder2;
            director2.buildFullFeaturedProduct();
            Console.WriteLine(builder2.GetProduct().ListParts());

        }
    }
}
