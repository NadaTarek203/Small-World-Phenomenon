
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System;
//using static Small_World.construct_Graph;
using static Small_World.functions;
using static Small_World.Movie_Actors;
using static Small_World.Queries;

namespace Small_World
{

    class Program
    {
        static void MakeGraph(FileStream MyFiles, FileStream f,StreamWriter output)
        {
           
            StreamReader streamreader, streamreader2;
           
            StreamWriter streamwiter;
            String Line;
            string[] movie; //array of each line in movies File
            string[] actor; //array of all actors
            string MovieName;
            List<KeyValuePair<string, List<string>>> MovieActors = new List<KeyValuePair<string, List<string>>>();
            HashSet<string> actors = new HashSet<string>(); //set of actors to prevent duplication
            var s = new List<KeyValuePair<string, string>>();
            // var edges = new HashSet<KeyValuePair<string, string>>();
            var edges = new List<KeyValuePair<string, string>>();//set of keyvaluepair to prevent duplication in edges
            streamreader = new StreamReader(MyFiles);
            
            Movie_Actors MA;
            
            while (streamreader.Peek() != -1) //read each line to split it and save movie name and each actor
            {
                Line = streamreader.ReadLine();
                movie = Line.Split('/');
                MovieName = movie[0];
                MA = new Movie_Actors();
                MA.movieName = MovieName;
                for (int j = 1; j < movie.Length; j++)
                {

                    actors.Add(movie[j]);
                    MA.FilmActors.Add(movie[j]);
                }
                //List<string> actorList = actors.ToList();
                MovieActors.Add(new KeyValuePair<string, List<string>>(MA.movieName, MA.FilmActors));
            }
            streamreader.Close();
            MyFiles.Close();
            Console.WriteLine("file1 read");
            MA = new Movie_Actors();
            for(int n=0;n<MovieActors.Count;n++)
            {
                for (int l = 0; l < MovieActors[n].Value.Count ; l++)
                {

                    int m = ((MovieActors[n].Value.Count - 1) - (l)) / 2;

                    if (((MovieActors[n].Value.Count - 1) - (l)) % 2 == 0)
                    {
                        int p = m + l;
                        for (int k = l + 1; k <= p; k++)
                        {
                            edges.Add(new KeyValuePair<string, string>(MovieActors[n].Value[l], MovieActors[n].Value[k]));

                            if (k + m < MovieActors[n].Value.Count && l != (k + m))
                            {
                                edges.Add(new KeyValuePair<string, string>(MovieActors[n].Value[l], MovieActors[n].Value[k + m]));
                            }

                        }
                    }
                    else if (((MovieActors[n].Value.Count - 1) - (l)) % 2 != 0)
                    {
                        int k;
                        int p = l + m;

                        for (k = l + 1; k <= p; k++)
                        {
                            edges.Add(new KeyValuePair<string, string>(MovieActors[n].Value[l], MovieActors[n].Value[k]));

                            if (k + m < MovieActors[n].Value.Count && l != (k + m))
                            {
                                edges.Add(new KeyValuePair<string, string>(MovieActors[n].Value[l], MovieActors[n].Value[k + m]));
                            }
                        }
                        if (k + m < MovieActors[n].Value.Count && l != (k + m))
                        {
                            edges.Add(new KeyValuePair<string, string>(MovieActors[n].Value[l], MovieActors[n].Value[m + k]));
                        }
                    }
                }

            }
            Console.WriteLine("edges added");
               // List<string> act = actors.ToList(); //convert hashSet of actors to list
            var e = edges.ToHashSet();
                //construct_Graph.BFSGraph(actors, e, act[0]);
            //Console.WriteLine("bfs");
            streamreader2 = new StreamReader(f);
                // cases =Int32.Parse(Line);
                //streamwiter.WriteLine("Query" + "   " + "Deg" + "   " + "Chain");
            Queries q;
            List<KeyValuePair<string, string>> QA =new List<KeyValuePair<string, string>>();

             while (streamreader2.Peek() != -1)//read line by line in Queries file to split it and test on it
             {
                 q = new Queries();
                 Line = streamreader2.ReadLine();
                 actor = Line.Split('/');
                 //string actor1 = actor[0]; //sourceActor
                 //string actor2 = actor[1];//DestinationActor
                q.Actor1 = actor[0];
                q.Actor2 = actor[1];
               QA.Add(new KeyValuePair<string, string>(q.Actor1,q.Actor2));
             }
            streamreader2.Close();
            f.Close();
            functions.ConstractGraph(actors, e);
          
            Console.WriteLine("QueriesFile read");
            Console.WriteLine("degree Of separation : ");
            foreach (var h in QA)
                {

                int x = ActorID[h.Key];
                int y = ActorID[h.Value];
               
               
                int dos=functions.degree_of_separation(actors, h.Key, h.Value);
                //List<int>MyPathes= functions.printpaths(actors, x, y);
                //int rel = functions.Relation_Of_Strength(actors, edges, h.Key, h.Value, MyPathes);
                //List<string> chain=functions.chain(MyPathes, MovieActors, actors);   
                //output.WriteLine(h.Key + "/" + h.Value);
                //output.WriteLine("DOS = " + dos + ", " + "RS = " + rel);
                //output.WriteLine("CHAIN OF ACTORS: " + string.Join(" ", MyPathes));
                //output.WriteLine("CHAIN OF MOVIES: " + string.Join(" ", chain));
            }
            output.Flush();
            output.Close();
            Console.WriteLine("dos");

        }

        static void Main(string[] args)
        {
            TextReader origConsole = Console.In;
            Console.WriteLine("0 for Sample\n 1 for small testcases Case:1 \n 2  for small testcases Case:2 \n 3 for medium testcases Case:11 \n 4 for medium testcases Case:12 \n 5 for medium testcases Case:21 \n 6 for medium testcases Case:22  \n 7 for large testcases Case:1\n 8 for large testcases Case:2 \n 9 for extreme testcases Case:1 \n x for extreme Case:2 ");
            char input = (char)Console.ReadLine()[0];
            FileStream File;
            FileStream f;
            //string out;
            StreamWriter sr;
            switch (input)
            {//sample TestCase
                case '0':
                    
                    File = new FileStream("movies1.txt", FileMode.Open, FileAccess.Read);
                    // f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Sample\queries1.txt", FileMode.Open, FileAccess.Read);
                    f =new FileStream("queries1.txt", FileMode.Open, FileAccess.Read);
                    sr= new StreamWriter("Sampleoutput.text");
                    MakeGraph(File,f,sr);
                    break;
                    //Complete/SimpleTrestCate
                    case '1':

                        //File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\small\Case1\movies193.txt", FileMode.Open, FileAccess.Read);
                        
                        //f = new FileStream( @"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\small\Case1\queries110.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("movies193.txt", FileMode.Open, FileAccess.Read);

                    f = new FileStream("queries110.txt", FileMode.Open, FileAccess.Read);
                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '2':
                    //    File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\small\Case2\movies187.txt", FileMode.Open, FileAccess.Read);
                    //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\small\Case2\queries50.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("movies187.txt", FileMode.Open, FileAccess.Read);
                    f = new FileStream("queries50.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;

                    case '3':
                       // File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case1\Movies967.txt", FileMode.Open, FileAccess.Read);
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case1\queries85.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies967.txt", FileMode.Open, FileAccess.Read);
                    f = new FileStream("queries85.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '4':
                        //File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case1\Movies967.txt", FileMode.Open, FileAccess.Read);
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case1\queries4000.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies967.txt", FileMode.Open, FileAccess.Read);
                    f = new FileStream("queries4000.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '5':
                       // File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case2\Movies4736.txt", FileMode.Open, FileAccess.Read);
                        
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case2\queries110.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies4736.txt", FileMode.Open, FileAccess.Read);

                    f = new FileStream(@"queeries110.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '6':
                    //File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case2\Movies4736.txt", FileMode.Open, FileAccess.Read);
                    // f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\medium\Case2\queries2000.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies4736.txt", FileMode.Open, FileAccess.Read);
                    f = new FileStream("queries2000.txt", FileMode.Open, FileAccess.Read);
                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '7':
                        //File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\large\Movies14129.txt", FileMode.Open, FileAccess.Read);
                
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\large\queries26.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies14129.txt", FileMode.Open, FileAccess.Read);

                    f = new FileStream("queries26.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '8':
                       // File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\large\Movies14129.txt", FileMode.Open, FileAccess.Read);
                
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\large\queries600.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies14129.txt", FileMode.Open, FileAccess.Read);

                    f = new FileStream("queries600.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case '9':
                       // File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\extreme\Movies122806.txt", FileMode.Open, FileAccess.Read);
                       //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\extreme\queries22.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies122806.txt", FileMode.Open, FileAccess.Read);
                    f = new FileStream("queries22.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    case 'x':
                        //File = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\extreme\Movies122806.txt", FileMode.Open, FileAccess.Read);
                
                        //f = new FileStream(@"D:\fcis\Third Year\2nd Term\Algorithm\[StudentsVer] Lab7 - Project Release\Testcases\Complete\extreme\queries200.txt", FileMode.Open, FileAccess.Read);
                    File = new FileStream("Movies122806.txt", FileMode.Open, FileAccess.Read);

                    f = new FileStream("queries200.txt", FileMode.Open, FileAccess.Read);

                    sr = new StreamWriter("Sampleoutput.text");
                    MakeGraph(File, f, sr);
                    break;
                    
            }

        }
    }
}

