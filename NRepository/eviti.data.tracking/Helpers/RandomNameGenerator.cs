using System;
using System.Collections.Generic;
namespace eviti.Data.Tracking.Helpers
{

    public class PersonResult
    {

        public string FirstName = string.Empty;
        public string Middle = string.Empty;
        public string LastName = string.Empty;
    }
    // this looks like it would be good to get
    //http://www.fakenamegenerator.com/
    public class RandomNameGenerator
    {


        private static Random random = new Random();

        private List<Tuple<int, int, int>> permutations;


        private List<string> FirstNames = new List<string> {
        "Jerome",
        "Daniel",
        "Ted",
        "David",
        "Frank",
        "Misty",
        "Bob",
        "Danny",
        "Alice",
        "Richard",
        "William",
        "Laura"
    };


        private List<string> LastNamesA = new List<string> {
        "A.",
        "B.",
        "C.",
        "D.",
        "E.",
        "F.",
        "G.",
        "H.",
        "I.",
        "J.",
        "K.",
        "L."

    };
        private List<string> LastNamesB = new List<string> {
        "Johnson",
        "Williams",
        "Jones",
        "Brown",
        "David",
        "Miller",
        "Wilson",
        "Anderson",
        "Thomas",
        "Jackson",
        "White",
        "Robinson"

    };



        private object _mylock = new object();
        public string GetName()
        {
            if ((permutations == null))
            {
                lock ((_mylock))
                {
                    if ((permutations == null))
                    {
                        GenerateStaticList();
                    }
                }
            }

            int Index = random.Next(0, permutations.Count);
            Tuple<int, int, int> tuple = permutations[Index];
            return (string.Format("{0} {1} {2}", FirstNames[tuple.Item1], LastNamesA[tuple.Item2], LastNamesB[tuple.Item3]));
        }



        //private Dictionary<Guid, CancerType> _CancerTypes;
        //public Dictionary<Guid, CancerType> CancerTypes
        //{
        //    get
        //    {
        //        if (_CancerTypes == null)
        //        {
        //            _CancerTypes = (new CancerReferenceProvider()).GetAllCancerTypes().ToDictionary(x => x.Guid);
        //        }
        //        return _CancerTypes;
        //    }
        //}



        public List<PersonResult> GenerateStaticList()
        {
            permutations = new List<Tuple<int, int, int>>();
            List<string> generatedNames = new List<string>();


            int a = 0;
            int b = 0;
            int c = 0;

            List<string> first = new List<string> {
            "First 1",
            "First 2",
            "First 3",
            "First 4",
            "First 5",
            "First 6",
            "First 7",
            "First 8",
            "First 9",
            "First 10",
            "First 11",
            "First 12",
            "First 13"
        };


            List<string> Middle = new List<string> {
            "Middle 1",
            "Middle 2",
            "Middle 3",
            "Middle 4",
            "Middle 5",
            "Middle 6",
            "Middle 7",
            "Middle 8",
            "Middle 9",
            "Middle 10",
            "Middle 11",
            "Middle 12",
            "Middle 13"
        };


            List<string> Last = new List<string> {
            "Last 1",
            "Last 2",
            "Last 3",
            "Last 4",
            "Last 5",
            "Last 6",
            "Last 7",
            "Last 8",
            "Last 9",
            "Last 10",
            "Last 11",
            "Last 12",
            "Last 13"
        };

            //FirstNames = (From x In CancerTypes.Values Select x.TypeName).ToList()
            //LastNamesA = LastNamesA2
            //LastNamesB = (From x In CancerTypes.Values Select x.TypeName).ToList()


            //FirstNames = first;
            //LastNamesA = Middle;
            //LastNamesB = Last;




            //We want to generate 500 names. 

            while (permutations.Count < 500)
            {

                a = random.Next(0, FirstNames.Count);
                b = random.Next(0, LastNamesA.Count);
                c = random.Next(0, LastNamesB.Count);


                Tuple<int, int, int> tuple = new Tuple<int, int, int>(a, b, c);

                if (!permutations.Contains(tuple))
                {
                    permutations.Add(tuple);
                }
            }
            var list = new List<PersonResult>();
            foreach (var tuple in permutations)
            {
                PersonResult r = new PersonResult();
                r.FirstName = FirstNames[tuple.Item1];
                r.Middle = LastNamesA[tuple.Item2];
                r.LastName = LastNamesB[tuple.Item3];
                list.Add(r);
                generatedNames.Add(string.Format("{0} {1} {2}", FirstNames[tuple.Item1], LastNamesA[tuple.Item2], LastNamesB[tuple.Item3]));
            }

            //For Each n In generatedNames
            //    Console.WriteLine(n)
            //Next

            //Console.ReadKey()

            return list;
        }

        public List<PersonResult> GenerateWithRandomNamesBob(int TotalItems = 500)
        {
            permutations = new List<Tuple<int, int, int>>();
            List<string> generatedNames = new List<string>();


            int a = 0;
            int b = 0;
            int c = 0;

            List<string> First = new List<string>();


            List<string> Middle = new List<string>();


            List<string> Last = new List<string>();
           

            int TotalNamesToGen = TotalItems/6;
            if (TotalNamesToGen<20)
            {
                TotalNamesToGen = 20;
            }
            for (int i =1;i <= TotalNamesToGen; i++)
            {
                First.Add("First " + i.ToString());
            }
            for (int i = 0; i <= TotalNamesToGen; i++)
            {
                Middle.Add("Middle " + i.ToString());
            }
            for (int i = 0; i <= TotalNamesToGen; i++)
            {
                Last.Add("Last " + i.ToString());
            }

            //FirstNames = (From x In CancerTypes.Values Select x.TypeName).ToList()
            //LastNamesA = LastNamesA2
            //LastNamesB = (From x In CancerTypes.Values Select x.TypeName).ToList()


            //FirstNames = first;
            //LastNamesA = Middle;
            //LastNamesB = Last;

            //https://mockaroo.com/
            //https://joshclose.github.io/CsvHelper/getting-started

            throw new ApplicationException("Fix the CSV Import");

            //We want to generate 500 names. 

            while (permutations.Count < TotalItems)
            {

                //a = random.Next(0, FirstNames.Count);
                //b = random.Next(0, LastNamesA.Count);
                //c = random.Next(0, LastNamesB.Count);

                a = random.Next(0, First.Count);
                b = random.Next(0, Middle.Count);
                c = random.Next(0, Last.Count);


                Tuple<int, int, int> tuple = new Tuple<int, int, int>(a, b, c);

                if (!permutations.Contains(tuple))
                {
                    permutations.Add(tuple);
                }
            }
            var list = new List<PersonResult>();
            foreach (var tuple in permutations)
            {
                PersonResult r = new PersonResult();
                //r.FirstName = FirstNames[tuple.Item1];
                //r.Middle = LastNamesA[tuple.Item2];
                //r.LastName = LastNamesB[tuple.Item3];

                r.FirstName = First[tuple.Item1];
                r.Middle = Middle[tuple.Item2];
                r.LastName = Last[tuple.Item3];

                list.Add(r);
                generatedNames.Add(string.Format("{0} {1} {2}", First[tuple.Item1], Middle[tuple.Item2], Last[tuple.Item3]));
              //  generatedNames.Add(string.Format("{0} {1} {2}", FirstNames[tuple.Item1], LastNamesA[tuple.Item2], LastNamesB[tuple.Item3]));
            }

            //For Each n In generatedNames
            //    Console.WriteLine(n)
            //Next

            //Console.ReadKey()

            return list;
        }

    }
}
