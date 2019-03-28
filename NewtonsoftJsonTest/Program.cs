using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsoftJsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLoop();
            Console.ReadLine();
        }

        public static void TestNest()
        {
            var classA = new ClassA();
            classA.Id = 1;
            classA.Name = "TestA";
            classA.Description = "TestA Description";
            classA.BList = new List<ClassB>();
            classA.BList.Add(new ClassB()
            {
                Id = 1,
                Name = "TestB1",
                Description = "TestB1 Description"
            });
            classA.BList.Add(new ClassB()
            {
                Id = 1,
                Name = "TestB2",
                Description = "TestB2 Description"
            });

            var json = JsonConvert.SerializeObject(classA, Formatting.Indented);
            Console.WriteLine("---------TestNest--------" + Environment.NewLine + json);
        }

        public static void TestLoop()
        {
            var classC = new ClassC();
            classC.Id = 1;
            classC.Name = "TestC";
            classC.Description = "TestC Description";

            var classD = new ClassD();
            classD.Id = 1;
            classD.Name = "TestD";
            classD.Description = "TestC DescriptionD";

            classC.D = classD;
            classD.C = classC;

            var json = JsonConvert.SerializeObject(classC, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            Console.WriteLine("---------TestLoop--------" + Environment.NewLine + json);
        }
    }

    public class ClassA
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<ClassB> BList { get; set; }
    }

    public class ClassB
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ClassC
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ClassD D { get; set; }
    }

    public class ClassD
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ClassC C { get; set; }
    }
}
