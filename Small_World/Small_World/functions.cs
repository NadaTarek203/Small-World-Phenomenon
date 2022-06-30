using System.Collections.Generic;using System;

using System.Linq;
using System.Text;
//using static Small_World.construct_Graph;
using static Small_World.Program;
namespace Small_World
{
    public class functions
    {
        static List<List<int>> AllposPaths;

        static List<int>[] adjacents;
        //static List<int>[] path;
        //static List<KeyValuePair<string, List<string>>> adjacents = new List<KeyValuePair<string, List<string>>>();
        static Queue<string> Q;
        static string secondActor;
        //int time = 0;
        static int min;
        static string[] color;
        static string[] parent;
        static int[] discovery_Time;
        public static Dictionary<string, int> ActorID ;
        static List<List<int>> All;
        static List<int> MinPath = new List<int>();
        public static void printALLPossiblePaths(HashSet<string> actors, int actor1, int actor2)
        {

            // AllposPaths = new List<List<int>>();
            string[] ActorsColors = new string[actors.Count];
            List<int> PosPaths = new List<int>();
            PosPaths.Add(actor1);
           
            AllPossiblePathsBetweenNodes(actor1, actor2, PosPaths, ActorsColors);
        }

        public static void AllPossiblePathsBetweenNodes(int actor1, int actor2, List<int> paths, string[] ActorsColors)
        {
            if (actor1 == actor2)
            {
                Console.WriteLine(string.Join(" ", paths));
                //All.Add(new List<int>(paths));
                // Console.WriteLine(All);
                return;
            }

            ActorsColors[actor1] = "gray";

            foreach (int i in adjacents[actor1])
            {
                if (ActorsColors[i] != "gray")
                {
                    //Colors[i] = "white";
                    paths.Add(i);
                 
                    AllPossiblePathsBetweenNodes(i, actor2, paths, ActorsColors);
                    paths.Remove(i);
                }
            }
            //Colors[actor1] = "white";
            //return All;
        }

        public static List<int> printpaths(HashSet<string> actors, int actor1, int actor2)
        {
            int[] predcessior = new int[actors.Count];
            int[] distance = new int[actors.Count];
            Min_Path(actor1, actor2, actors, predcessior, distance);
           
            List<int> path = new List<int>();
            int temp = actor2;
            path.Add(temp);
            while(predcessior[temp]!=-1)
            {
                path.Add(predcessior[temp]);
                temp = predcessior[temp];
            }
           // Console.WriteLine("path is");
            for(int i=path.Count-1;i>=0 ;i--)
            {
                Console.Write(path[i] + " ");
            }
            return path;
        }
       
       public  static bool Min_Path( int actor1, int actor2, HashSet<string> actors,int[] predcessior, int[] distance)
        {
            Queue<int> min = new Queue<int>();
            
            string[] visitedNode = new string[actors.Count];
            for(int i=0;i<actors.Count;i++)
            {
                visitedNode[i] = "white";
                predcessior[i] = -1;
                //distance[i] = int.MaxValue;
            }
            visitedNode[actor1] = "gray";
           // predcessior[actor1] = -1;
            distance[actor1] =0;
            min.Enqueue(actor1);
            while (min.Count!=0)
            {
                int temp = min.Dequeue();
                foreach (int i in adjacents[temp])
                {
                    if (visitedNode[i] !="gray")
                    {
                        visitedNode[i] = "gray";
                      distance[i] = distance[temp] + 1;
                       predcessior[i] = temp;
                       min.Enqueue(i);
                if (i==actor2)
                        {
                            return true;
                        }
                    }
                }
            }
                return false;
        }
        //public static List<int> MinPaths(List<List<int>> Myallpathes)
        //{
        //    // Console.WriteLine("lslslsl");
        //    for (int i = 0; i < Myallpathes.Count; i++)
        //    {
        //        if (Myallpathes[i].Count < min)
        //        {
        //            min = Myallpathes[i].Count;
        //            MinPath = Myallpathes[i].ToList();

        //        }
        //    }
        //    //Console.WriteLine("lslslsl");
        //    Console.WriteLine(string.Join(" ", MinPath));
        //    return MinPath;
        //}
        public static void ConstractGraph(HashSet<string> actors, HashSet<KeyValuePair<string, string>> Movie_File)
        {
            List<string> newActor = actors.ToList();
            adjacents = new List<int>[newActor.Count];
            parent = new string[actors.Count];
            discovery_Time = new int[actors.Count];
            ActorID = new Dictionary<string, int>();
            for (int i = 0; i < newActor.Count; i++)
            {
                adjacents[i] = new List<int>();//adjacent
                ActorID.Add(newActor[i], i);
            }
                foreach (var adj in Movie_File)
                {

                int ind1 = ActorID[adj.Key];
                int ind2 = ActorID[adj.Value];

                adjacents[ind1].Add(ind2);
                adjacents[ind2].Add(ind1);

            }
           
        }
        
        // static HashSet<int>[] adjacents;
        public static void gragh(HashSet<string> actors)
        {
               color = new string[actors.Count];
             parent = new string[actors.Count];
            discovery_Time = new int[actors.Count];
            //Count = new int[actors.Count];
            // int finish_time;
            //int index=ActorID[Source];
            List<string> newActor = actors.ToList();
            for (int i = 0; i < newActor.Count; i++)
            {
               // ActorID.Add(newActor[i], i);
                color[i] = "white";
                parent[i] = null;
                //discovery_Time[i] = -1;
            }

            color[0] = "gray";
            discovery_Time[0] = 0;
            parent[0] = null;
        }
        public static int degree_of_separation(HashSet<string> actors,string SourceActor,string DestinationActor)
        {
            List<string> newActor = actors.ToList();
            // List<string> li;
            int destIndex = 0;
            //path = new List<int>[actors.Count];
            Q = new Queue<string>();
            // List<string>[] chain =new List<string>[newActor.Count];
           
            gragh(actors);
            Q.Enqueue(SourceActor);
        
            while (Q.Count != 0)
            {
                secondActor = Q.Dequeue();
                int ind = ActorID[secondActor];
                int i = ActorID[SourceActor];
               // chain[ind] = new List<string>();
                if (secondActor==DestinationActor) //termination
                {

                    destIndex = ActorID [DestinationActor];
                    Console.WriteLine(discovery_Time[destIndex]);
                    break;
                       
                }
                //adjacents = new List<int>[newActor.Count];
                foreach (var v in adjacents[ind])
                {
                   
                    //int x = newActor.IndexOf(v);
                    if (color[v] == "white")
                    {
                        color[v] = "gray";
                        discovery_Time[v] = discovery_Time[ind] + 1;
                        parent[v] = secondActor;
                        Q.Enqueue(newActor[v]);
                    }
                    
                     //path[ind].Add(v);
                    
                }
                
                color[ind] = "black";
            }
           

            return discovery_Time[destIndex];
        }

        public static int Relation_Of_Strength(HashSet<string> actors, List<KeyValuePair<string, string>> Movie_File, string SourceActor, string DestinationActor,List<int>MyChain)
        {
           

            List<KeyValuePair<int, int>> path = new List<KeyValuePair<int, int>>();
            //int e = newActor.IndexOf(SourceActor);
            for (int c = 0; c < MyChain.Count - 1; c++)
            {
                path.Add(new KeyValuePair<int, int>(MyChain[c], MyChain[c + 1]));
            }
            int count = 0;
            foreach (var l in path)
            {
                foreach (var s in Movie_File)
                {
                    
                    if (ActorID[s.Key] == l.Key && ActorID[s.Value] == l.Value)
                    {
                        count++;
                    }
                    else if (ActorID[s.Key] == l.Value && ActorID[s.Value] == l.Key)
                    {
                        count++;
                    }
                }

            }
            Console.WriteLine(count);
            return count;
        }
        

        public static List<string> chain(List<int>path, List<KeyValuePair<string, List<string>>> MovieActors, HashSet<string> actors)
        {
            int x, y;
            List<string> list = new List<string>();
            for (int i = 0; i < (path.Count) - 1; i++)
            {
                x = path[i];
                y = path[i + 1];
                for (int j = 0; j < MovieActors.Count; j++)
                {
                
                    List<string> acts = MovieActors.ElementAt(j).Value;
                 
                if (acts.Contains(actors.ElementAt(x))&& acts.Contains(actors.ElementAt(y)))
                {

                    Console.Write(MovieActors.ElementAt(j).Key);

                        list.Add(MovieActors.ElementAt(j).Key);
                        break;
                }

                    
                }
                if (i < path.Count - 2)
                {
                Console.Write(" => ");
                    list.Add(" => ");
                }
            }
            return list;
            //Console.WriteLine(index);
        }
    }
}
